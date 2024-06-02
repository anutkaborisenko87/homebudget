using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HomeBudget.Models.Entities.DAL;

[Table("Transactions")]
public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    [Required]
    public TransactionType TransactionType { get; set; }
    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
}