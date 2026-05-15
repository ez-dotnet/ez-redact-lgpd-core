using System;
using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class CPFRedactorTest
{
    [Theory]
    [InlineData("123.456.789-00", "123.***.***-00")]
    [InlineData("12345678900", "123******00")]
    public void CpfRedactor_DeveMascararMiolo(string input, string expected)
    {
        var redactor = new CPFRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void CpfRedactor_DeveLidarComInputVazio()
    {
        var redactor = new CPFRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void CpfRedactor_DeveLidarComInputNulo()
    {
        var redactor = new CPFRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
