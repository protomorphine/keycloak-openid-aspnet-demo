using Auth.Api.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Logging;

namespace Auth.Api.Extensions;

public static class AuthExtensions
{
    public static void AddKeyCloak(this IServiceCollection services, OpenIdConfiguration cfg)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = cfg.CookieName;
            })
            .AddOpenIdConnect(options =>
            {
                IdentityModelEventSource.ShowPII = true;

                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;

                options.Authority = cfg.Authority;
                options.ClientId = cfg.ClientId;
                options.ClientSecret = cfg.ClientSecret;

                options.RequireHttpsMetadata = cfg.RequireHttpsMetadata;
                options.UsePkce = true;
                options.SaveTokens = true;

                options.CallbackPath = cfg.CallbackPath;
                options.SignedOutRedirectUri = cfg.SignedOutRedirectUri.ToString();

                options.ResponseType = "code";
                options.ResponseMode = "query";
                options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;

                foreach (var scope in cfg.Scopes)
                    options.Scope.Add(scope);

                options.CorrelationCookie.SameSite = SameSiteMode.Strict;
                options.NonceCookie.SameSite = SameSiteMode.Strict;
            });

        services.AddAuthorization();
    }
}