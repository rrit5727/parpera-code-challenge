using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionApi.Models;
using TransactionApi.Repositories;
using TransactionApi.Services;
using Xunit;

namespace TransactionApi.Tests
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _mockRepository;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            _mockRepository = new Mock<ITransactionRepository>();
            _service = new TransactionService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTransactionsAsync_ReturnsTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = 1, DateTime = DateTime.Now, Description = "Test", Amount = 100, Status = "Pending" }
            };
            _mockRepository.Setup(repo => repo.GetAllTransactionsAsync()).ReturnsAsync(transactions);

            // Act
            var result = await _service.GetAllTransactionsAsync();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task UpdateTransactionStatusAsync_UpdatesStatus()
        {
            // Arrange
            var transaction = new Transaction { Id = 1, DateTime = DateTime.Now, Description = "Test", Amount = 100, Status = "Pending" };
            _mockRepository.Setup(repo => repo.UpdateTransactionStatusAsync(1, "Completed")).ReturnsAsync(transaction);

            // Act
            var result = await _service.UpdateTransactionStatusAsync(1, "Completed");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Completed", result.Status);
        }
    }
}