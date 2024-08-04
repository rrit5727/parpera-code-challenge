using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionApi.Controllers;
using TransactionApi.Models;
using TransactionApi.Services;
using Xunit;

namespace TransactionApi.Tests
{
    public class TransactionsControllerTests
    {
        private readonly Mock<ITransactionService> _mockService;
        private readonly TransactionsController _controller;

        public TransactionsControllerTests()
        {
            _mockService = new Mock<ITransactionService>();
            _controller = new TransactionsController(_mockService.Object);
        }

        [Fact]
        public async Task GetTransactions_ReturnsOkResult_WithListOfTransactions()
        {
            // Arrange
            var transactions = new List<Transaction>
            {
                new Transaction { Id = 1, DateTime = DateTime.Now, Description = "Test", Amount = 100, Status = "Pending" }
            };
            _mockService.Setup(service => service.GetAllTransactionsAsync()).ReturnsAsync(transactions);

            // Act
            var result = await _controller.GetTransactions();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Transaction>>(actionResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task UpdateTransactionStatus_ReturnsOkResult_WithUpdatedTransaction()
        {
            // Arrange
            var transaction = new Transaction { Id = 1, DateTime = DateTime.Now, Description = "Test", Amount = 100, Status = "Pending" };
            _mockService.Setup(service => service.UpdateTransactionStatusAsync(1, "Completed")).ReturnsAsync(transaction);

            // Act
            var result = await _controller.UpdateTransactionStatus(1, "Completed");

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Transaction>(actionResult.Value);
            Assert.Equal("Completed", returnValue.Status);
        }

        [Fact]
        public async Task UpdateTransactionStatus_ReturnsNotFound_WhenTransactionNotFound()
        {
            // Arrange
            _mockService.Setup(service => service.UpdateTransactionStatusAsync(1, "Completed")).ReturnsAsync((Transaction)null);

            // Act
            var result = await _controller.UpdateTransactionStatus(1, "Completed");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}