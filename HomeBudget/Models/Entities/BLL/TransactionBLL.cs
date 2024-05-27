using System.ComponentModel.DataAnnotations;
using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Entities.BLL;

public class TransactionBLL
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    public TransactionType TransactionType { get; set; }
    public virtual User User { get; set; }
    public virtual Category Category { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}