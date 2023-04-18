namespace Auth.Api.Models;

public class OpenIdConfiguration
{
    public const string SectionName = nameof(OpenIdConfiguration);
    
    /// <summary>
    /// Наименование cookie.
    /// </summary>
    public string CookieName { get; set; } = string.Empty;

    /// <summary>
    /// Адрес эндпоинта получения мета информации.
    /// </summary>
    public string Authority { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор клиента.
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Секретный ключ клиента.
    /// </summary>
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// Требовать TLS.
    /// </summary>
    public bool RequireHttpsMetadata { get; set; }

    /// <summary>
    /// Путь обратного вызова для возврата кода авторизации.
    /// </summary>
    public string CallbackPath { get; set; } = string.Empty;

    /// <summary>
    /// URL редиректа после разлогина.
    /// </summary>
    public Uri SignedOutRedirectUri { get; set; } = default!;

    /// <summary>
    /// Список скоупов.
    /// </summary>
    public List<string> Scopes { get; } = new();

    /// <summary>
    /// URL эндпоинта авторизации.
    /// </summary>
    public Uri AuthorizationUrl { get; set; } = default!;

    /// <summary>
    /// URL эндпоинта управления токенами.
    /// </summary>
    public string TokenEndpoint { get; set; } = string.Empty;
}