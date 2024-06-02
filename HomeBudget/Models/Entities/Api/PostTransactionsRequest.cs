using System.ComponentModel.DataAnnotations;

namespace HomeBudget.Models.Entities.Api;

public class PostTransactionsRequest
{
    public decimal Amount { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    public TransactionType TransactionType { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}