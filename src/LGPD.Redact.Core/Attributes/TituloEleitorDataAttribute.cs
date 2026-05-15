using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class TituloEleitorDataAttribute : DataClassificationAttribute
{
    public TituloEleitorDataAttribute() : base(LGPDTaxonomy.TituloEleitor) { }
}
