using System;
using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class CEPRedactorTest
{
    [Theory]
    [InlineData("01310-900", "01310-***")]
    [InlineData("01310900", "01310***")]
    public void CepRedactor_DeveEsconderFinal(string input, string expected)
    {
        var redactor = new CEPRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void CepRedactor_DeveLidarComInputVazio()
    {
        var redactor = new CEPRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void CepRedactor_DeveLidarComInputNulo()
    {
        var redactor = new CEPRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
