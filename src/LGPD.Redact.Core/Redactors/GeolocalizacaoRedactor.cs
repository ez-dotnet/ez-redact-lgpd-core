using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class GeolocalizacaoRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);

        var sourceStr = source.ToString();
        var matches = Patterns.Geolocalizacao().Matches(sourceStr);

        foreach (Match match in matches)
        {
            for (int i = match.Index; i < match.Index + match.Length; i++)
            {
                if (destination[i] == '.')
                {
                    for (int j = i + 1; j < match.Index + match.Length && char.IsDigit(destination[j]); j++)
                        destination[j] = '*';
                }
            }
        }

        return source.Length;
    }
}
