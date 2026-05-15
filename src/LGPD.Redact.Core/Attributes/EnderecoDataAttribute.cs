using System;
using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class EnderecoDataAttribute : DataClassificationAttribute 
{ 
    public EnderecoDataAttribute() : base(LGPDTaxonomy.Endereco) { } 
}
