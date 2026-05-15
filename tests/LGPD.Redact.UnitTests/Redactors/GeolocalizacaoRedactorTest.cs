using LGPD.Redact.Core.Redactors;
using LGPD.Redact.UnitTests.Helpers;

namespace LGPD.Redact.UnitTests.Redactors;

public class GeolocalizacaoRedactorTest
{
    [Theory]
    [InlineData("-23.5505, -46.6333", "-23.****, -46.****")]
    [InlineData("23.5505, 46.6333", "23.****, 46.****")]
    [InlineData("-12.3456,-78.9012", "-12.****,-78.****")]
    [InlineData("0.0000, 0.0000", "0.****, 0.****")]
    [InlineData("90.0000, 180.0000", "90.****, 180.****")]
    public void GeolocalizacaoRedactor_DeveMascararCoordenadas(string input, string expected)
    {
        var redactor = new GeolocalizacaoRedactor();
        AssertionHelper.Equal(redactor, input, expected);
    }

    [Fact]
    public void GeolocalizacaoRedactor_DeveLidarComInputVazio()
    {
        var redactor = new GeolocalizacaoRedactor();
        AssertionHelper.Equal(redactor, "", "");
    }

    [Fact]
    public void GeolocalizacaoRedactor_DeveLidarComInputNulo()
    {
        var redactor = new GeolocalizacaoRedactor();
        AssertionHelper.Equal(redactor, null!, "");
    }
}
