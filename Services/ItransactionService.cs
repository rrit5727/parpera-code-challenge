using TransactionApi.Models;

namespace TransactionApi.Services
{
  public interface ITransactionService
  {
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    Task<Transaction?> UpdateTransactionStatusAsync(int id, string newStatus);
  }

}