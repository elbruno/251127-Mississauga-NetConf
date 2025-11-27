# .NET Aspire Demo

This folder contains a complete .NET Aspire application demonstrating cloud-native development patterns.

## Overview

.NET Aspire is a cloud-ready stack for building observable, production-ready, distributed applications.

## Projects

- **AspireDemo.AppHost** - The application host that orchestrates services
- **AspireDemo.ServiceDefaults** - Shared service configuration
- **AspireDemo.ApiService** - A backend API service
- **AspireDemo.Web** - A Blazor web frontend

## Prerequisites

- .NET 10 SDK
- Docker Desktop (for containerized services)

## Running the Demo

```bash
cd AspireDemo.AppHost
dotnet run
```

This will start:
- The Aspire Dashboard (for observability)
- The API service
- The web frontend

## Key Features Demonstrated

1. **Service Discovery** - Services automatically discover each other
2. **Health Checks** - Built-in health monitoring
3. **OpenTelemetry** - Integrated distributed tracing and metrics
4. **Resilience** - Retry policies and circuit breakers
5. **Configuration** - Unified configuration management

## Resources

- [.NET Aspire Documentation](https://learn.microsoft.com/dotnet/aspire)
- [Aspire Samples Repository](https://github.com/dotnet/aspire-samples)
