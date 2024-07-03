using static System.Net.WebRequestMethods;

namespace Fina.Core;
public static class Configuration
{
    /// <summary>
    /// Numero padrao das paginas
    /// </summary>
    public const int DefaultPageNumber = 1;
    /// <summary>
    /// Tamanho padrao das paginas
    /// </summary>
    public const int DefaultPageSize = 25;
    /// <summary>
    /// Status Code Padrao de Sucesso
    /// </summary>
    public const int DefaultStatusCode = 200;

    public static string BackendUrl { get; set; } = "http://localhost:5073";
    public static string FrontendUrl { get; set; } = "http://localhost:5123";
}
