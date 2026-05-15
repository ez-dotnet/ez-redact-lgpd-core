using LGPD.Redact.Core.Redactors;
using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Redaction;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona mascaramento de dados.
    /// </summary>
    /// <param name="services"><inheritdoc cref="IServiceCollection"/></param>
    /// <param name="usarRedact">Se false então os dados serão exibidos.</param>
    /// <returns></returns>
    public static IServiceCollection AddLGPDRedaction(this IServiceCollection services, bool usarRedact = true)
    {
        services.AddRedaction(builder =>
        {
            if (usarRedact)
            {
                builder.SetRedactor<CartaoCreditoRedactor>(LGPDTaxonomy.CartaoCredito);
                builder.SetRedactor<CEPRedactor>(LGPDTaxonomy.CEP);
                builder.SetRedactor<CNPJRedactor>(LGPDTaxonomy.CNPJ);
                builder.SetRedactor<CPFRedactor>(LGPDTaxonomy.CPF);
                builder.SetRedactor<EmailRedactor>(LGPDTaxonomy.Email);
                builder.SetRedactor<EnderecoRedactor>(LGPDTaxonomy.Endereco);
                builder.SetRedactor<NomeRedactor>(LGPDTaxonomy.Nome);
                builder.SetRedactor<PixRedactor>(LGPDTaxonomy.Pix);
                builder.SetRedactor<TelefoneRedactor>(LGPDTaxonomy.Telefone);
                builder.SetRedactor<EnderecoIPRedactor>(LGPDTaxonomy.EnderecoIP);
                builder.SetRedactor<MacAddressRedactor>(LGPDTaxonomy.MacAddress);
                builder.SetRedactor<GeolocalizacaoRedactor>(LGPDTaxonomy.Geolocalizacao);
                builder.SetRedactor<CNHRedactor>(LGPDTaxonomy.CNH);
                builder.SetRedactor<TituloEleitorRedactor>(LGPDTaxonomy.TituloEleitor);
                builder.SetFallbackRedactor<ErasingRedactor>();
            }
            else
            {
                builder.SetFallbackRedactor<NullRedactor>();
            }
        });

        return services;
    }
}
