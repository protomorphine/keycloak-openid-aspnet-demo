using Auth.Api.Models;
using Microsoft.OpenApi.Models;

namespace Auth.Api.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services, OpenIdConfiguration cfg)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,

                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = cfg.AuthorizationUrl,
                        TokenUrl = new Uri(cfg.TokenEndpoint),
                        Scopes = cfg.Scopes.ToDictionary(it => it, _ => string.Empty)
                    }
                },
                Description = "Auth by KeyCloak"
            });
        });
    } 
}