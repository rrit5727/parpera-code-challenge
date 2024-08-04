using System;
using TransactionApi.Data;
using TransactionApi.Models;

namespace TransactionApi
{
    public static class SeedData
    {
        public static void Initialize(TransactionContext context)
        {
            // Clear existing data
            context.Transactions.RemoveRange(context.Transactions);
            context.SaveChanges();

            // Seed new data
            context.Transactions.AddRange(
                new Transaction
                {
                    Id = 11,
                    DateTime = DateTime.Parse("2020-09-08T16:34:23Z"),
                    Description = "Bank Deposit",
                    Amount = 500.00m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 10,
                    DateTime = DateTime.Parse("2020-09-08T09:02:23Z"),
                    Description = "Transfer to James",
                    Amount = -20.00m,
                    Status = "Pending"
                },
                new Transaction
                {
                    Id = 9,
                    DateTime = DateTime.Parse("2020-09-07T21:52:23Z"),
                    Description = "ATM withdrawal",
                    Amount = -20.00m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 8,
                    DateTime = DateTime.Parse("2020-09-06T10:32:23Z"),
                    Description = "Google Subscription",
                    Amount = -15.00m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 7,
                    DateTime = DateTime.Parse("2020-09-06T07:33:23Z"),
                    Description = "Apple Store",
                    Amount = -2000.00m,
                    Status = "Cancelled"
                },
                new Transaction
                {
                    Id = 6,
                    DateTime = DateTime.Parse("2020-08-23T17:39:23Z"),
                    Description = "Mini Mart",
                    Amount = -23.76m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 5,
                    DateTime = DateTime.Parse("2020-08-16T21:06:23Z"),
                    Description = "Mini Mart",
                    Amount = -56.43m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 4,
                    DateTime = DateTime.Parse("2020-06-15T18:17:23Z"),
                    Description = "Country Railways",
                    Amount = -167.78m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 3,
                    DateTime = DateTime.Parse("2020-04-09T16:26:23Z"),
                    Description = "Refund",
                    Amount = 30.00m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 2,
                    DateTime = DateTime.Parse("2020-04-01T12:47:23Z"),
                    Description = "Amazon Online",
                    Amount = -30.00m,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 1,
                    DateTime = DateTime.Parse("2020-03-30T23:53:23Z"),
                    Description = "Bank Deposit",
                    Amount = 500.00m,
                    Status = "Completed"
                }
            );

            context.SaveChanges();
        }
    }
}