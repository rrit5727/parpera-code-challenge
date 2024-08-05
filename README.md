# Transaction API 

This project is a .NET Core-based RESTful API for managing transactions.

## Features

- Retrieve a list of transactions ordered by datetime in descending order
- Update a transaction's status
- Simple token-based authentication for the update API
- Data persitence using SQLite

## Prerequisites 

- .Net 6.0 SDK or later
- VS code

## Getting started

1. Clone the repository;
2. Navigate to the project directory;
3. Restore dependencies;
4. Run the application;


The API will be available at 'https://localhost:5183' 

## API Endpoints

- GET '/api/transactions' - Retrieve all transactions
- PUT '/api/transactions/{id}/status' - Update a transaction's status (requires authentication)

## Authentication 

To update a transaction's status, include the following header in your request: "Authorization: Bearer secret-token"

## Dependencies

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.InMemory (for testing)

## Caveats
There is a problem with duplicate attributes due to those automatically generated on build. To address this, run 'rm -rf bin obj' and remove any other 'bin/obj' folders (i.e. in the test folder) before either running 'dotnet run', 'dotnet build' or 'dotnet test'. Apologies - I haven't been able to resolve this as at the time of submission