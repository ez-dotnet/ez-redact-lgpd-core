using System.Security.Cryptography;
using LGPD.Redact.Core;
using LGPD.Redact.Core.Attributes;

var builder = WebApplication.CreateBuilder(args);

// Gera chave HMAC se não estiver configurada (ex: via env var LGPD__HmacKey)
if (string.IsNullOrEmpty(builder.Configuration["LGPD:HmacKey"]))
    builder.Configuration["LGPD:HmacKey"] = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

// Lê MaskChar, Guid, HmacFor, HmacKey, HmacKeyId do appsettings.json + env vars
// A seção "LGPD" é vinculada ao LGPDRedactOptions em runtime
builder.Services.AddLGPDRedaction(builder.Configuration);

builder.Logging.EnableRedaction(o => o.ApplyDiscriminator = false);

var app = builder.Build();

app.MapGet("/", (ILogger<Program> log, ILGPDRedactService redact) =>
{
    log.LogInformacoes(
        "Maria Silva",
        "maria.silva@email.com",
        "123.456.789-01",
        "12.345.678/0001-90",
        "e8d26618-2e11-4b22-8d26-66182e114b22",
        "(11) 98888-4444",
        "4532 1178 9012 3456",
        "01310-900");

    var redacted = new
    {
        CPF = redact.Redact(DadoPessoal.CPF, "123.456.789-01"),
        CNPJ = redact.Redact(DadoPessoal.CNPJ, "12.345.678/0001-90"),
        Email = redact.Redact(DadoPessoal.Email, "maria.silva@email.com"),
        Nome = redact.Redact(DadoPessoal.Nome, "Maria Silva"),
        Telefone = redact.Redact(DadoPessoal.Telefone, "(11) 98888-4444"),
        CartaoCredito = redact.Redact(DadoPessoal.CartaoCredito, "4532 1178 9012 3456"),
        CEP = redact.Redact(DadoPessoal.CEP, "01310-900"),
        Guid = redact.Redact(DadoPessoal.Guid, "e8d26618-2e11-4b22-8d26-66182e114b22"),
        Pix = redact.Redact(DadoPessoal.Pix, "e8d26618-2e11-4b22-8d26-66182e114b22"),
    };

    return Results.Ok(redacted);
});

app.Run();

public static partial class Logs
{
    [LoggerMessage(LogLevel.Information, "Dados: Nome={Nome} | Email={Email} | CPF={Cpf} | CNPJ={Cnpj} | GUID={Guid} | Tel={Tel} | Cartao={Cartao} | CEP={Cep}")]
    public static partial void LogInformacoes(
        this ILogger logger,
        [NomeData] string nome,
        [EmailData] string email,
        [CPFData] string cpf,
        [CNPJData] string cnpj,
        [GuidData] string guid,
        [TelefoneData] string tel,
        [CartaoCreditoData] string cartao,
        [CEPData] string cep);
}
