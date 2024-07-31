using Microsoft.EntityFrameworkCore;
using TransactionApi.Models;

namespace TransactionApi.Data
{
  public class TransactionContext : DbContext 
  {
    public TransactionContext(DbContextOptions<TransactionContext> options)
      : base(options)
      
    {      
    }

    public DbSet<Transaction> Transactions { get; set; } = null!;
  }
}