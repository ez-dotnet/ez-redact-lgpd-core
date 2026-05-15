using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class EnderecoIPDataAttribute : DataClassificationAttribute
{
    public EnderecoIPDataAttribute() : base(LGPDTaxonomy.EnderecoIP) { }
}
