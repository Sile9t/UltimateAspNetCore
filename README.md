# Ultimate ASP.NET Core Web API

This project is a learning implementation based on the book **Code Maze — “Ultimate ASP.NET Core Web API”**.  
It demonstrates building a **clean, layered architecture** using ASP.NET Core, splitting responsibilities across **Entities**, **Repository**, **Service**, and **Presentation** layers.  

> ⚠️ Note: CQRS and MediatR are not yet included, but the project is prepared for easy extension.

---

## 🚀 Features
- 📂 **Layered architecture** (Entities, Repository, Service, Presentation).
- 🔄 **Repository & Service patterns** for clean data access and business logic separation.
- 🛠 **Action Filters** showcasing ASP.NET Core filter pipeline.
- 📑 **Contracts & DTOs** to decouple domain models from API.
- 📝 **Custom LoggerService** for centralized logging.
- 🌐 **Swagger UI** support for API testing.

---

## 🛠️ Tech Stack
- **.NET 8 / ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **Dependency Injection**
- **Swagger / Swashbuckle**
- **Custom Logging Service**

---

## 📦 Installation & Run
1. Clone the repository:
   ```bash
   git clone https://github.com/Sile9t/UltimateAspNetCore.git
   cd UltimateAspNetCore

2. Restore dependencies:

   ```bash
   dotnet restore

3. Build and run the project:

   ```bash
   dotnet build
   dotnet run --project CompanyEmployees.Presentation

4. Open in browser:

   Swagger UI: https://localhost:5001/swagger

   API root: https://localhost:5001/api

---

## 📂 Project Structure
   /ActionFilters                — Custom ASP.NET Core action filters
   /CompanyEmployees.Presentation — Main Web API project (controllers, Startup)
   /Contracts                    — Interfaces and DTOs
   /Entities                     — Domain entities (database models)
   /LoggerService                — Centralized logging service
   /Repository                   — Data access layer (CRUD implementation)
   /Service.Contracts            — Business logic contracts
   /Service                      — Business logic implementation
   /Shared                       — Shared utilities
   WebApplication1.sln           — Visual Studio solution

---

## 📸 Example API Request
   
   GET /api/companies
   
      Response:
      [
        {
          "id": "e2b6c1a3-51c4-4a19-88e9-08db2e17e12b",
          "name": "Code Maze Ltd.",
          "address": "123 Code Street",
          "country": "USA"
        }
      ]

---

## 🔮 Roadmap

   - Add CQRS pattern with MediatR.

   - Integrate FluentValidation for DTO validation.

   - Extend unit test coverage (xUnit / NUnit).
