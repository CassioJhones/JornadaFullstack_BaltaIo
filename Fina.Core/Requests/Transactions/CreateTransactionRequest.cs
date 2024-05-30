using Fina.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Fina.Core.Requests.Transactions;
public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Titulo invalido")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo invalido")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

    [Required(ErrorMessage = "Valor invalido")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Categoria invalido")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Data invalida")]
    public DateTime? PaidOrReceivedAt { get; set; }

}
