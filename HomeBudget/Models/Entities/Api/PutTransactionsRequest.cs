namespace HomeBudget.Models.Entities.Api;

public class PutTransactionsRequest: PostTransactionsRequest
{
    public int Id { get; set; }
}