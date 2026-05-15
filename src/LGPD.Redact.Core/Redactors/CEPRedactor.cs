using System;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class CEPRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;

    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);
        
        var match = Patterns.CEP().Match(source.ToString());
        
        if (match.Success)
        {
            int d = 0;

            for (int i = destination.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(destination[i]))
                {
                    destination[i] = '*';
                    d++;
                }
                
                if (d == 3) 
                    break;
            }
        }
        
        return source.Length;
    }
}
