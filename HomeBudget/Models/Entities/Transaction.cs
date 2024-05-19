using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeBudget.Models.Entities;

[Table("Transactions")]
public class Transaction
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
    
    public string Description { get; set; }
    [Required]
    public TransactionType TransactionType { get; set; }
    [Required]
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    [Required]
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }
}