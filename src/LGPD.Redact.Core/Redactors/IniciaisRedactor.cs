using System;
using Microsoft.Extensions.Compliance.Redaction;

namespace LGPD.Redact.Core.Redactors;

public abstract class IniciaisRedactor : Redactor
{
    public override int GetRedactedLength(ReadOnlySpan<char> input) => input.Length;
    
    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        source.CopyTo(destination);
        
        bool proximoEhInicial = true;
        
        for (int i = 0; i < destination.Length; i++)
        {
            if (char.IsWhiteSpace(destination[i]) || destination[i] == ',' || destination[i] == '-')
            {
                proximoEhInicial = true;
                continue;
            }
            
            if (char.IsLetter(destination[i]) && proximoEhInicial)
                proximoEhInicial = false;
            else
                destination[i] = '*';
        }
        
        return source.Length;
    }
}