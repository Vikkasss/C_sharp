namespace FinancialAccounts.Models;

public class Operation
{
    public int id { get; set; }            // id operation
    public string type { get; set; }       // operation type
    public int bankAccountId { get; set; } //reference to account
    public decimal amount { get; set; }    // operation sum
    public DateTime date { get; set; }     // date operation
    public string description { get; set; }//description operation
    public int category_id { get; set; }   // reference to category
}