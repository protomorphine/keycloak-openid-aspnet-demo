using Auth.Api.Extensions;
using Auth.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

var openIdConfiguration = builder.Configuration.GetSection(OpenIdConfiguration.SectionName).Get<OpenIdConfiguration>()!;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger(openIdConfiguration);
builder.Services.AddKeyCloak(openIdConfiguration);

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthUsePkce();
        options.OAuthClientId(openIdConfiguration.ClientId);
        options.OAuthClientSecret(openIdConfiguration.ClientSecret);
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyHeader();
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowAnyOrigin();
});

app.Run();