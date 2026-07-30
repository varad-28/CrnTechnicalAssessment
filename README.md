# CRN Technical Assessment - .NET 8 Web API

A robust, enterprise-grade RESTful Web API built using **.NET 8** and **Clean Architecture**. This project manages products and related items, featuring advanced architectural patterns, database integration, validation, pagination, JWT authentication, containerization, and unit testing.

---

## ??? Architecture & Tech Stack

This project strictly follows **Clean Architecture** principles, separating concerns into four core layers:
1. **Domain:** Contains enterprise entities (`Product`, `Item`) and core business rules.
2. **Application:** Contains business logic, Data Transfer Objects (DTOs), interfaces, and FluentValidation rules.
3. **Infrastructure:** Implements Entity Framework Core, database contexts, repository patterns, and migrations.
4. **API:** The presentation layer containing controllers, middleware, and application configuration (`Program.cs`).

### Key Technologies & Libraries:
* **Framework:** .NET 8 Web API
* **Database & ORM:** SQL Server 2022, Entity Framework Core
* **Validation:** FluentValidation
* **Documentation:** Swagger / OpenAPI
* **Testing:** xUnit, Moq
* **Containerization:** Docker & Docker Compose

---

## ?? Features Implemented

* **Clean Architecture Layers:** Clear separation between API, Application, Domain, and Infrastructure.
* **Database Relationships:** Configured `Product` and `Item` tables with proper foreign key relationships using EF Core.
* **CRUD Operations:** Fully functional endpoints for creating, reading, updating, and deleting products.
* **Pagination:** Server-side pagination (`pageNumber` and `pageSize`) on collection endpoints.
* **Request Validation:** Automated input validation powered by FluentValidation.
* **Security & Performance:** Configured JWT Authentication, CORS policy, and Response Compression.
* **Global Exception Handling:** Custom exception middleware for centralized error responses.
* **Unit Testing:** Comprehensive unit tests for business services using xUnit and Moq.
* **Containerization:** Fully containerized setup via `Dockerfile` and `docker-compose`.

---

## ?? Getting Started Locally

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.
* SQL Server or Docker Desktop.

### 1. Clone the Repository
```bash
git clone [https://github.com/varad-28/CrnTechnicalAssessment.git](https://github.com/varad-28/CrnTechnicalAssessment.git)
cd CrnTechnicalAssessment