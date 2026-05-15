using System;
using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class CNPJDataAttribute : DataClassificationAttribute 
{ 
    public CNPJDataAttribute() : base(LGPDTaxonomy.CNPJ) { } 
}
