using System.Text.Json.Serialization;

namespace Fina.Core.Responses;
/// <summary>
/// Classe Base para as Responses
/// </summary>
public class Response<TData>
{
    [JsonConstructor]//define o construtor padrao pro aspNet
    public Response() => _statusCode = Configuration.DefaultStatusCode;

    public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        Data = data;
        _statusCode = code;
        Message = message;
    }

    private int _statusCode = Configuration.DefaultStatusCode;
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _statusCode is >= 200 and <= 299;
}