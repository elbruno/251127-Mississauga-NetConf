# .NET Aspire with Python Demo

This folder contains a .NET Aspire application that demonstrates orchestrating Python services alongside .NET services.

## Overview

This demo shows how .NET Aspire can orchestrate polyglot applications, combining .NET and Python services in a unified development experience. The application includes a FastAPI Python backend with Redis caching and a React/Vite TypeScript frontend.

## Project Structure

```
aspire-app/
├── apphost.cs              # The AppHost that orchestrates all services
├── apphost.run.json        # Run configuration
├── app/                    # Python FastAPI backend
│   ├── main.py            # FastAPI application with weather forecast API
│   ├── telemetry.py       # OpenTelemetry configuration
│   └── pyproject.toml     # Python dependencies (uv)
└── frontend/              # React + Vite TypeScript frontend
    ├── src/               # React source files
    ├── vite.config.ts     # Vite configuration
    └── package.json       # Node.js dependencies
```

## Application Components

### AppHost (apphost.cs)

The orchestrator that manages all services using the new file-based Aspire AppHost SDK:

- **Redis Cache** - Caching layer for weather forecast data
- **Python Backend** - Uvicorn app running FastAPI with UV package manager
- **Vite Frontend** - React TypeScript frontend with hot module replacement

### Python Backend (app/)

A FastAPI application featuring:

- `/api/weatherforecast` - Returns weather forecast data with Redis caching (5s TTL)
- `/health` - Health check endpoint with Redis connectivity verification
- OpenTelemetry instrumentation for distributed tracing
- Redis integration for response caching

### Frontend (frontend/)

A React 19 + TypeScript frontend built with Vite 7:

- Modern React with TypeScript
- Vite for fast development and optimized builds
- Connects to the Python backend for weather data

## Prerequisites

- .NET 10 SDK
- Python 3.x with [uv](https://docs.astral.sh/uv/) package manager
- Node.js (for frontend)
- Docker Desktop (for Redis)

## Running the Demo

Navigate to the `aspire-app` folder and run:

```bash
cd aspire-app
dotnet run apphost.cs
```

This will start:

- The Aspire Dashboard (for observability)
- Redis cache container
- Python FastAPI backend (Uvicorn)
- React/Vite frontend with HMR

## Key Features Demonstrated

1. **Polyglot Orchestration** - Running Python (FastAPI) alongside JavaScript (Vite/React)
2. **File-Based AppHost** - Using the new `#:sdk` and `#:package` directives
3. **Service Communication** - Cross-language service discovery with automatic environment variable injection
4. **Redis Integration** - Shared caching between services
5. **Unified Observability** - OpenTelemetry tracing across all services in the Aspire Dashboard
6. **Container Publishing** - `PublishWithContainerFiles` for production deployment

## Resources

- [.NET Aspire with Python](https://learn.microsoft.com/dotnet/aspire/get-started/build-aspire-apps-with-python)
- [.NET Aspire Documentation](https://learn.microsoft.com/dotnet/aspire)
- [FastAPI Documentation](https://fastapi.tiangolo.com/)
- [uv - Python Package Manager](https://docs.astral.sh/uv/)
