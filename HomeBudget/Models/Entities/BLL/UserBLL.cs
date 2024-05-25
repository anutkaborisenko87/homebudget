using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Entities.BLL;

public class UserBLL
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<Transaction> Transactions { get; }
}