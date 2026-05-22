using Microsoft.Extensions.DependencyInjection;

namespace LGPD.Redact.Core;

/// <summary>
/// Builder para configuração de redação LGPD.
/// Serve como ponto de partida para extensões de outros pacotes
/// (ex: <c>LGPD.Redact.Serialization</c>, <c>LGPD.Redact.EntityFramework</c>).
/// </summary>
public interface ILGPDRedactionBuilder
{
    /// <summary>
    /// O <see cref="IServiceCollection"/> onde os serviços são registrados.
    /// </summary>
    IServiceCollection Services { get; }
}
