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
