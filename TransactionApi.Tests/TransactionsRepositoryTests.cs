using Microsoft.EntityFrameworkCore;
using TransactionApi.Data;
using TransactionApi.Models;
using TransactionApi.Repositories;
using Xunit;

namespace TransactionApi.Tests
{
    public class TransactionRepositoryTests
    {
        private TransactionContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TransactionContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new TransactionContext(options);
        }

        [Fact]
        public async Task GetAllTransactionsAsync_ReturnsAllTransactions()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Transactions.AddRange(
                new Transaction { Id = 1, DateTime = DateTime.Parse("2020-01-01T00:00:00Z") },
                new Transaction { Id = 2, DateTime = DateTime.Parse("2020-01-02T00:00:00Z") }
            );
            context.SaveChanges();
            var repository = new TransactionRepository(context);

            // Act
            var result = await repository.GetAllTransactionsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task UpdateTransactionStatusAsync_UpdatesStatus()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Transactions.Add(new Transaction { Id = 1, Status = "Pending" });
            context.SaveChanges();
            var repository = new TransactionRepository(context);

            // Act
            var result = await repository.UpdateTransactionStatusAsync(1, "Completed");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Completed", result.Status);
        }
    }
}