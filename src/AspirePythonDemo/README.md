# .NET Aspire with Python Demo

This folder contains a .NET Aspire application that demonstrates orchestrating Python services alongside .NET services.

## Overview

This demo shows how .NET Aspire can orchestrate polyglot applications, combining .NET and Python services in a unified development experience.

## Projects

- **apphost.cs** - The AppHost that orchestrates all services
- **app/** - Python backend application
- **frontend/** - JavaScript frontend application

## Prerequisites

- .NET 10 SDK
- Python 3.x
- Node.js (for frontend)
- Docker Desktop

## Running the Demo

```bash
dotnet run
```

This will start:
- The Aspire Dashboard
- Python backend service
- JavaScript frontend

## Key Features Demonstrated

1. **Polyglot Orchestration** - Running Python alongside .NET
2. **Service Communication** - Cross-language service discovery
3. **Unified Observability** - Single dashboard for all services
4. **Development Experience** - Hot reload and debugging across languages

## Resources

- [.NET Aspire with Python](https://learn.microsoft.com/dotnet/aspire/get-started/build-aspire-apps-with-python)
- [.NET Aspire Documentation](https://learn.microsoft.com/dotnet/aspire)
