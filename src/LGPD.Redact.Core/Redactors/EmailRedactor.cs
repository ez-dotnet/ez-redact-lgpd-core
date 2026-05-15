using System;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class EmailRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);

        if (Patterns.Email().IsMatch(source))
        {
            int atIndex = source.IndexOf('@');
            
            if (atIndex > 1)
            {
                for (int i = 1; i < atIndex; i++)
                    destination[i] = '*';
            }
            else if (atIndex == 1)
            {
                // Caso o e-mail tenha apenas uma letra antes do @ (ex: a@b.com)
                // Mantemos como está ou mascaramos tudo antes do @ se preferir
            }
        }
        else
        {
            destination.Fill('*');
        }

        return source.Length;
    }
}
