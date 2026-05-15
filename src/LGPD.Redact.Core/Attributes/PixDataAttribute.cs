using System;
using LGPD.Redact.Core.Taxonomies;
using Microsoft.Extensions.Compliance.Classification;

namespace LGPD.Redact.Core.Attributes;

public class PixDataAttribute : DataClassificationAttribute 
{ 
    public PixDataAttribute() : base(LGPDTaxonomy.Pix) { } 
}
