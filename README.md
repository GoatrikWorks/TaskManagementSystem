# Task Management System
Created by Erik Elb (GoatrikWorks)

## Description
A modern task management system built with .NET 8, implementing Clean Architecture and CQRS patterns.

## Tech Stack
- .NET 8
- Entity Framework Core
- MediatR
- FluentValidation
- SQLite
- xUnit for testing

## Getting Started
1. Clone the repository
2. Run `dotnet restore`
3. Run `dotnet ef database update -s src/TaskManagementSystem.API`
4. Run `dotnet run --project src/TaskManagementSystem.API`

## Project Structure
- `src/TaskManagementSystem.Domain`: Core domain models and logic
- `src/TaskManagementSystem.Application`: Application services and CQRS implementations
- `src/TaskManagementSystem.Infrastructure`: Data access and external services
- `src/TaskManagementSystem.API`: REST API endpoints
- `tests/TaskManagementSystem.UnitTests`: Unit tests
- `tests/TaskManagementSystem.IntegrationTests`: Integration tests

## Features
- Task creation and management
- Task status tracking
- Task comments
- Task history logging
- Priority management

## API Documentation
API documentation is available via Swagger UI at `/swagger` when running the application.
