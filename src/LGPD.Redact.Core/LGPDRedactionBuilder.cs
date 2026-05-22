using Microsoft.Extensions.DependencyInjection;

namespace LGPD.Redact.Core;

internal sealed class LGPDRedactionBuilder : ILGPDRedactionBuilder
{
    public IServiceCollection Services { get; }

    public LGPDRedactionBuilder(IServiceCollection services)
    {
        Services = services;
    }
}
