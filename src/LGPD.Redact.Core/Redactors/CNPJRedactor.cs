using System;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class CNPJRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;
    
    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);
        
        if (Patterns.CNPJ().IsMatch(source))
        {
            int d = 0;
            
            for (int i = 0; i < destination.Length; i++)
            {
                if (char.IsLetterOrDigit(destination[i]))
                {
                    d++;
                    if (d > 2 && d <= 8) 
                        destination[i] = '*';
                }
            }
        }
        
        return source.Length;
    }
}
