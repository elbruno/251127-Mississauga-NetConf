# Copilot Instructions for Mississauga .NET User Group Repository

This repository contains demos and resources for the Mississauga .NET User Group conference (November 27, 2025), showcasing .NET 10, C# 14, and related technologies.

## Repository Structure

```
src/
├── CSharp14Features/          # C# 14 new features demo (console app)
├── AspireDemo/                # .NET Aspire demo (multi-project solution)
├── AspirePythonDemo/          # .NET Aspire with Python demo
├── PerformanceComparison/     # .NET 8 vs .NET 10 performance benchmarks
└── AgentFrameworkSamples/     # Microsoft Agent Framework samples
```

## Technology Stack

- **.NET Version**: .NET 10 (with .NET 8 for performance comparisons)
- **Language**: C# 14 with `<LangVersion>preview</LangVersion>` for new features
- **Frameworks**: ASP.NET Core 10, .NET Aspire, .NET MAUI 10
- **Additional**: Microsoft Agent Framework, BenchmarkDotNet

## Coding Conventions

### C# Style

- Use file-scoped namespaces
- Enable nullable reference types (`<Nullable>enable</Nullable>`)
- Enable implicit usings (`<ImplicitUsings>enable</ImplicitUsings>`)
- Use `var` when the type is obvious from the right-hand side
- Use collection expressions (e.g., `[]` for empty collections, `[item1, item2]` for initialized collections)
- Use target-typed `new()` expressions when the type is clear
- Prefer expression-bodied members for simple one-line methods and properties

### Naming Conventions

- Use PascalCase for public members, types, and methods
- Use camelCase for private fields and local variables
- Prefix interface names with `I` (e.g., `ICustomerService`)
- Use meaningful, descriptive names

### Project Organization

- Each demo has its own subfolder under `src/`
- Include a `README.md` in each demo folder explaining the demo purpose and how to run it
- Use solution files (`.sln`) for multi-project demos (like AspireDemo)

## Build Commands

### Build individual projects

```bash
cd src/<ProjectFolder>/<ProjectName>
dotnet build
```

### Build entire solution (for multi-project demos)

```bash
cd src/AspireDemo
dotnet build AspireDemo.sln
```

### Run console applications

```bash
cd src/CSharp14Features/CSharp14Features
dotnet run
```

### Run benchmarks

```bash
cd src/PerformanceComparison/PerformanceDemo.Net10
dotnet run -c Release
```

## Testing

- Use xUnit for unit tests when adding test projects
- Follow the naming convention: `<ProjectName>.Tests`
- Test method names should describe the scenario: `MethodName_Scenario_ExpectedBehavior`

## Documentation

- Update the main `README.md` when adding new demos
- Include comments in demo code explaining the features being demonstrated
- Use XML documentation comments for public APIs

## Prerequisites

When contributing, ensure you have:

- .NET 10 SDK installed
- .NET 8 SDK installed (for performance comparisons)
- Docker (for Aspire demos)
- Visual Studio 2026 Preview or VS Code with C# Dev Kit

## Key C# 14 Features in Use

When working with the C# 14 demos, be aware of these new features:

1. **Field keyword**: Direct access to backing fields in properties
2. **Null-conditional assignment**: Safe assignment when target is not null
3. **Extension members**: Enhanced extension method capabilities
4. **Unbound generic types in nameof**: Use `nameof(List<>)` syntax
5. **First-class Span support**: Improved Span<T> and ReadOnlySpan<T> support
