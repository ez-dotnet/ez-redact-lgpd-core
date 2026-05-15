using System;
using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class EnderecoRedactorTest
{
    [Theory]
    [InlineData("Avenida Paulista, 1000", "A****** P*******, ****")]
    [InlineData("Rua Chile", "R** C****")]
    public void EnderecoRedactor_DeveManterIniciais(string input, string expected)
    {
        var redactor = new EnderecoRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void EnderecoRedactor_DeveLidarComInputVazio()
    {
        var redactor = new EnderecoRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void EnderecoRedactor_DeveLidarComInputNulo()
    {
        var redactor = new EnderecoRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
