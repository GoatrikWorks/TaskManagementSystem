# Task Management System API
Created by GoatrikWorks - Erik Elb

## Overview
REST API för hantering av tasks med full CRUD-funktionalitet och användarspårning.

## Teknisk Stack
- .NET 8
- Entity Framework Core
- MediatR för CQRS
- FluentValidation
- AutoMapper
- xUnit för testing

## Getting Started
1. Klona repositoryt
2. Sätt connection string i appsettings.json
3. Kör migrations: `dotnet ef database update`
4. Starta API:et: `dotnet run`

## API Endpoints
- GET /api/tasks/{id} - Hämta specifik task
- POST /api/tasks - Skapa ny task
- PUT /api/tasks/{id}/status - Uppdatera task status
