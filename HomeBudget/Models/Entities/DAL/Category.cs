using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBudget.Models.Entities.DAL;

[Table("Categories")]
public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    
    public IEnumerable<Transaction> Transactions { get; }
}