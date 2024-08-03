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

