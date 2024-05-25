using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Entities.BLL;

public class TransactionBLL
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    public TransactionType TransactionType { get; set; }
    public virtual UserBLL User { get; set; }
    public virtual CategoryBLL Category { get; set; }
}