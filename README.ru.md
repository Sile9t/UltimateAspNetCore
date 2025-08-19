# Ultimate ASP.NET Core Web API

Учебный проект, реализованный по книге **Code Maze — “Ultimate ASP.NET Core Web API”**.  
Проект демонстрирует построение многослойной архитектуры с использованием ASP.NET Core, разделяя ответственность между слоями **Entities**, **Repository**, **Service** и **Presentation**.  

> ⚠️ В текущей версии отсутствует реализация CQRS и MediatR, но проект легко расширить для их поддержки.

---

## 🚀 Возможности
- 📂 **Многослойная архитектура** (Entities, Repository, Service, Presentation).
- 🔄 **Repository & Service pattern** для работы с данными.
- 🛠 **Action Filters** — пример внедрения фильтров ASP.NET Core.
- 📑 **Contracts & DTOs** для строгого разделения доменной модели и API.
- 📝 **LoggerService** для централизованного логирования.
- 🌐 Поддержка **Swagger UI** для тестирования API.

---

## 🛠️ Технологии
- **.NET 8 / ASP.NET Core Web API**
- **C#**
- **Entity Framework Core** (для доступа к данным)
- **Dependency Injection**
- **Swagger / Swashbuckle**
- **Custom Logging Service**

---

## 📦 Установка и запуск
1. Клонировать репозиторий:
   ```bash
   git clone https://github.com/Sile9t/UltimateAspNetCore.git
   cd UltimateAspNetCore

2. Восстановить зависимости:

   ```bash
   dotnet restore


3. Собрать и запустить проект:

   ```bash
   dotnet build
   dotnet run --project CompanyEmployees.Presentation


4. Перейти по адресу:

   Swagger UI: https://localhost:5001/swagger

   API: https://localhost:5001/api

---

## 📂 Структура проекта
   ```java
   /ActionFilters             — кастомные фильтры для контроллеров
   /CompanyEmployees.Presentation — основной проект Web API (контроллеры, Startup)
   /Contracts                 — интерфейсы и DTO
   /Entities                  — доменные сущности (модели БД)
   /LoggerService             — собственный сервис логирования
   /Repository                — реализация слоя доступа к данным (CRUD)
   /Service.Contracts         — интерфейсы бизнес-логики
   /Service                   — реализация бизнес-логики
   /Shared                    — общие утилиты
   WebApplication1.sln        — решение Visual Studio
   ```

---

## 📸 Пример API-запроса
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

## 🔮 Планы по развитию

   - Добавить CQRS с использованием MediatR.

   - Подключить FluentValidation для валидации DTO.

   - Расширить покрытие тестами (xUnit / NUnit).
