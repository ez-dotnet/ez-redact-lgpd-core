using System;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public class PixRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;
    
    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);
        
        var match = Patterns.PixChaveAleatoria().Match(source.ToString());
        
        if (match.Success)
            for (int i = 4; i < destination.Length - 8; i++)
                if (destination[i] != '-') 
                    destination[i] = '*';

        return source.Length;
    }
}
