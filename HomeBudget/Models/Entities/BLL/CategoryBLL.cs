using HomeBudget.Models.Entities.DAL;

namespace HomeBudget.Models.Entities.BLL;

public class CategoryBLL
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    public virtual IEnumerable<Transaction> Transactions { get; set; }
}