# DocuMind AI

AI-powered document management and inquiry API built with **.NET 10, C#, Clean Architecture, EF Core, SQL Server, and Ollama**.

DocuMind AI is a learning and portfolio project designed to explore modern .NET application architecture while integrating a locally hosted Large Language Model through Ollama.

The project focuses on building a maintainable backend application using clear separation of concerns, relational persistence, RESTful APIs, and local AI inference.

---

## Project Goals

DocuMind AI was built to gain practical experience with:

- Modern .NET and C#
- ASP.NET Core Web API
- Clean Architecture
- Domain-Driven Design fundamentals
- Entity Framework Core
- SQL Server
- Code First migrations
- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- REST API design
- DTOs and application services
- Input validation and error handling
- Automated testing
- HTTP client integration
- Local LLM inference with Ollama
- AI-assisted document processing

The project intentionally prioritizes understanding the architecture and implementation decisions rather than simply integrating as many technologies as possible.

---

## Architecture

The solution follows a Clean Architecture structure:

```text
DocuMind
│
├── DocuMind.Domain
│   └── Entities and domain rules
│
├── DocuMind.Application
│   ├── Use cases
│   ├── DTOs
│   └── Application abstractions
│
├── DocuMind.Infrastructure
│   ├── EF Core
│   ├── SQL Server
│   ├── Repository implementations
│   ├── Unit of Work
│   └── External service integrations
│
└── DocuMind.API
    ├── Controllers
    ├── HTTP endpoints
    └── API configuration
```

### Dependency Direction

```text
API
 │
 ▼
Application
 │
 ▼
Domain

Infrastructure ─────► Application
Infrastructure ─────► Domain
```

The core application layers do not depend on Infrastructure implementations.

Infrastructure implements the abstractions defined by the Application layer.

---

## Current Features

### Document Management

- Create documents
- Retrieve documents
- Retrieve document collections
- Update documents
- Delete documents
- Persist documents using SQL Server
- EF Core Code First migrations

### Persistence

- Entity Framework Core
- SQL Server
- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- Scoped DbContext lifetime
- Change tracking
- No-tracking read queries where appropriate

### API

- ASP.NET Core Web API
- RESTful endpoints
- DTO-based request/response models
- HTTP status codes
- OpenAPI
- Scalar API documentation

### AI Integration

DocuMind integrates with **Ollama** to provide locally hosted LLM inference.

The AI layer is designed behind an application abstraction so that the application does not need to know the implementation details of the underlying AI provider.

The V1 AI functionality focuses on document-related processing rather than attempting to build a complete RAG or multi-provider AI platform.

---

## Technology Stack

| Technology | Purpose |
|---|---|
| .NET 10 | Application platform |
| C# | Programming language |
| ASP.NET Core | Web API |
| EF Core | ORM / data access |
| SQL Server | Relational database |
| Scalar | API documentation |
| Ollama | Local LLM inference |
| xUnit | Automated testing |
| Git | Version control |

---

## API

The API exposes document-management operations under:

```text
/api/documents
```

Example:

```http
POST /api/documents
```

Example request:

```json
{
  "title": "Introduction to Clean Architecture",
  "content": "Clean Architecture separates business rules from infrastructure concerns.",
  "documentType": "article"
}
```

A successful creation returns:

```http
201 Created
```

along with the created document information and a location for retrieving the resource.

---

## Getting Started

### Prerequisites

Install:

- .NET 10 SDK
- SQL Server
- Ollama
- Git

Verify .NET:

```powershell
dotnet --version
```

Verify Ollama:

```powershell
ollama --version
```

---

## Database Configuration

Configure the SQL Server connection string in the API configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DocuMind;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Do not commit credentials or secrets to source control.

For real deployments, use environment variables, user secrets, or another secure configuration provider.

---

## Database Setup

From the solution directory:

```powershell
dotnet ef database update --project DocuMind.Infrastructure --startup-project DocuMind.API
```

This applies the existing EF Core migrations to the configured SQL Server database.

---

## Running the Application

From the solution directory:

```powershell
dotnet run --project DocuMind.API
```

Once the API is running, use the Scalar documentation interface exposed by the application to explore and test the endpoints.

---

## Ollama

DocuMind uses Ollama for local LLM inference.

Make sure Ollama is running before using the AI functionality.

A compatible model can be installed using:

```powershell
ollama pull <model>
```

The exact model configuration is application-specific and should be configured rather than hard-coded into the application.

---

## Testing

Run the complete solution build:

```powershell
dotnet build
```

Run automated tests:

```powershell
dotnet test
```

The project aims to keep domain and application logic independently testable while using integration testing where interaction with infrastructure is important.

---

## Engineering Concepts Demonstrated

This project intentionally demonstrates several concepts relevant to enterprise .NET development:

### Clean Architecture

Separates business/application concerns from infrastructure and delivery mechanisms.

### Repository Pattern

Provides an abstraction around persistence operations.

### Unit of Work

Coordinates persistence changes and provides a single commit boundary for a use case.

### Dependency Injection

Infrastructure implementations are registered through the .NET dependency injection container.

### Entity Framework Core

Used for relational persistence, change tracking, querying, and Code First migrations.

### DTOs

API contracts are separated from domain entities to prevent the HTTP layer from directly exposing the domain model.

### Application Services

Use cases are represented by application-level services rather than placing business workflows directly inside controllers.

### CancellationToken

Request cancellation is propagated through the application and persistence layers for asynchronous operations.

### Ollama Integration

AI inference is treated as an external dependency behind an abstraction, keeping the application layer independent from the specific AI provider.

---

## Project Scope

DocuMind AI intentionally focuses on a single, complete V1 implementation.

The scope includes:

```text
Clean Architecture
        ↓
Domain Model
        ↓
EF Core + SQL Server
        ↓
Repository + Unit of Work
        ↓
REST API
        ↓
Validation + Error Handling
        ↓
Testing
        ↓
Ollama Integration
        ↓
Documentation
```

The project does **not** currently aim to implement a multi-version AI platform, Semantic Kernel orchestration, ONNX inference, or cloud-provider-specific AI infrastructure.

This keeps the project focused on producing a coherent and understandable .NET application rather than expanding the technology stack unnecessarily.

---

## Project Status

**V1 — In Development**

The core architecture, persistence layer, and initial document API are implemented.

Remaining work includes completing the document operations, validation/error handling, inquiry functionality, Ollama integration, testing, and final documentation.

---

## License

This project is intended primarily as a learning and portfolio project.