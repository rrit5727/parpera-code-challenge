using System.ComponentModel.DataAnnotations; 

namespace TransactionApi.Models
{
  public class Transaction
  {
    public int Id { get; set; }

    [Required]
    public DateTime DateTime {get; set; }

    [Required]
    public string Description {get; set; } = string.Empty;

    [Required]
    public decimal Amount {get; set; }

    [Required]
    public string Status {get; set; } = string.Empty;
  }
}