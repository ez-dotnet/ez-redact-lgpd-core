using System;
using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class CNPJRedactorTest
{
    [Theory]
    [InlineData("12.345.678/0001-90", "12.***.***/0001-90")]
    [InlineData("ABCDE123000190", "AB******000190")]
    public void CnpjRedactor_DevePreservarRaizERadical(string input, string expected)
    {
        var redactor = new CNPJRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void CnpjRedactor_DeveLidarComInputVazio()
    {
        var redactor = new CNPJRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void CnpjRedactor_DeveLidarComInputNulo()
    {
        var redactor = new CNPJRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
