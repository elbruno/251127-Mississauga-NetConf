# C# 14 New Features Demo

This console application demonstrates the new features available in C# 14.

## Features Demonstrated

### 1. Field Keyword

The `field` keyword provides direct access to auto-property backing fields:

```csharp
public string FirstName
{
    get => field;
    set => field = !string.IsNullOrWhiteSpace(value) 
        ? value 
        : throw new ArgumentException("Cannot be empty");
}
```

### 2. Null-Conditional Assignment

Safely assign values when the target is not null:

```csharp
customer?.Orders?.Add("NewOrder"); // Only adds if both are not null
```

### 3. Extension Members

Enhanced extension method capabilities for better extensibility.

### 4. Unbound Generic Types in nameof

You can now use `nameof` with open generic types:

```csharp
Console.WriteLine(nameof(Dictionary<,>)); // Outputs: Dictionary
Console.WriteLine(nameof(List<>));        // Outputs: List
```

### 5. First-class Span Support

Improved support for `Span<T>` and `ReadOnlySpan<T>` in various contexts.

## Running the Demo

```bash
cd CSharp14Features
dotnet run
```

## Prerequisites

- .NET 10 SDK
- Language version set to `preview` in the project file

## Project Configuration

The project uses `<LangVersion>preview</LangVersion>` to enable C# 14 features.

## Resources

- [What's New in C# 14](https://learn.microsoft.com/dotnet/csharp/whats-new/csharp-14)
- [C# Language Reference](https://learn.microsoft.com/dotnet/csharp/language-reference)
