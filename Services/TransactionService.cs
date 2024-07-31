using TransactionApi.Models;
using TransactionApi.Repositories;

namespace TransactionApi.Services
{
  public class TransactionService : ITransactionService
  {
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
      _repository = repository;

    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
      return await _repository.GetAllTransactionsAsync();
    }

    public async Task<Transaction?> UpdateTransactionStatusAsync(int id, string newStatus)
    {
      return await _repository.UpdateTransactionStatusAsync(id, newStatus);

    }


  }



}