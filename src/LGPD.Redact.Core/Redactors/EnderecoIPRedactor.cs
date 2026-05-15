using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class EnderecoIPRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);

        var sourceStr = source.ToString();

        var ipv4Matches = Patterns.Ipv4().Matches(sourceStr);
        foreach (Match match in ipv4Matches)
        {
            int dotsFound = 0;
            for (int i = match.Index; i < match.Index + match.Length; i++)
            {
                if (destination[i] == '.')
                {
                    dotsFound++;
                    continue;
                }
                if (dotsFound >= 2)
                    destination[i] = '*';
            }
        }

        var ipv6Matches = Patterns.Ipv6().Matches(sourceStr);
        foreach (Match match in ipv6Matches)
        {
            int colonsFound = 0;
            for (int i = match.Index; i < match.Index + match.Length; i++)
            {
                if (destination[i] == ':')
                {
                    colonsFound++;
                    continue;
                }
                if (colonsFound >= 5 && destination[i] != '.')
                    destination[i] = '*';
            }
        }

        return source.Length;
    }
}
