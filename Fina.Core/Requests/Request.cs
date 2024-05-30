namespace Fina.Core.Requests;

public abstract class Request
{
    public string UserId { get; set; } = string.Empty;
}
//classe abstrata nao pode ser instanciada, pode ser herdada
