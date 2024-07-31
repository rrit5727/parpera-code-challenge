using TransactionApi.Models;

namespace TransactionApi.Repositories
{
  public interface ITransactionRepository
  {
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    Task<Transaction?> UpdateTransactionStatusAsync(int id, string newStatus)
  }


}