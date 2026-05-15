using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class CNHDataAttribute : DataClassificationAttribute
{
    public CNHDataAttribute() : base(LGPDTaxonomy.CNH) { }
}
