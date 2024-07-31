using Microsoft.EntityFrameworkCore;
using TransactionApi.Data;
using TransactionApi.Models;

namespace TransactionApi.Repositories
{
  public class TransactionRepository : ITransactionRepository
  {
    private readonly TransactionContext _context;

    public TransactionRepository(TransactionContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
      return await _context.Transactions
        .OrderByDescending(t => t.DateTime)
        .ToListAsync();
    }

    public async Task<Transaction?> UpdateTransactionStatusAsync(int id, string newStatus)
    {
      var transaction = await _context.Transactions.FindAsync(id);
      if (transaction == null)
      {
        return null;
      }

      transaction.Status = newStatus;
      await _context.SaveChangesAsync();
      return transaction;

    }


  }



}