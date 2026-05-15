using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class GeolocalizacaoDataAttribute : DataClassificationAttribute
{
    public GeolocalizacaoDataAttribute() : base(LGPDTaxonomy.Geolocalizacao) { }
}
