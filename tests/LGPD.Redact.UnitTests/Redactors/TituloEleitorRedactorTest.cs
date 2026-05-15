using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class TituloEleitorRedactorTest
{
    [Theory]
    [InlineData("123456789012", "1234****9012")]
    [InlineData("1234.5678.9012", "1234.****.9012")]
    [InlineData("1234 5678 9012", "1234 **** 9012")]
    [InlineData("000000000000", "0000****0000")]
    public void TituloEleitorRedactor_DeveMascararMiolo(string input, string expected)
    {
        var redactor = new TituloEleitorRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void TituloEleitorRedactor_DeveLidarComInputVazio()
    {
        var redactor = new TituloEleitorRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void TituloEleitorRedactor_DeveLidarComInputNulo()
    {
        var redactor = new TituloEleitorRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
