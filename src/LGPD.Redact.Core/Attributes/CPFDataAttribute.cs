using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class CPFDataAttribute : DataClassificationAttribute 
{ 
    public CPFDataAttribute() : base(LGPDTaxonomy.CPF) { } 
}
