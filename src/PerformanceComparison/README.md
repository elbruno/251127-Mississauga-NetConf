# Performance Comparison: .NET 8 vs .NET 10

This folder contains console applications that demonstrate performance improvements between .NET 8 and .NET 10 using [BenchmarkDotNet](https://benchmarkdotnet.org/).

## 🚀 Quick Start - Run Commands

### Run .NET 8 Benchmarks

```bash
cd src/PerformanceComparison/PerformanceDemo.Net8
dotnet run -c Release
```

### Run .NET 10 Benchmarks

```bash
cd src/PerformanceComparison/PerformanceDemo.Net10
dotnet run -c Release
```

> **Note**: Each benchmark run is optimized for live demos and should complete within 60 seconds per framework.

## 📚 Reference Resources

- [Performance Improvements in .NET 10](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-10/) - Stephen Toub's comprehensive blog post
- [.NET Performance Video](https://www.youtube.com/watch?v=snnULnTWcNM) - Performance improvements video
- [BenchmarkDotNet Documentation](https://benchmarkdotnet.org/)
- [BenchmarkDotNet NuGet Package](https://www.nuget.org/packages/BenchmarkDotNet)

## Benchmarks Included

1. **String Concatenation** - Tests string concatenation operations with loop
2. **List Add & Sum** - Tests list creation, adding elements, and iteration sum
3. **Dictionary Operations** - Tests dictionary creation and lookups
4. **LINQ Operations** - Tests LINQ query performance (Where, Select, Sum)
5. **Array Fill, Sort & Search** - Tests array filling, sorting and binary search
6. **Span Operations** - Tests Span<T> fill and search operations
7. **Task Operations** - Tests parallel task execution (100 tasks)
8. **Regex Matching** - Tests regular expression matching performance

## About BenchmarkDotNet

BenchmarkDotNet is a powerful .NET library for benchmarking. It handles:

- Warm-up iterations
- Statistical analysis
- Memory allocation tracking (via `[MemoryDiagnoser]`)
- Multiple runtime comparisons
- Detailed result reports

## Expected Results

.NET 10 typically shows improvements in:
- JIT compilation and code generation
- GC performance and memory allocation
- LINQ query optimization
- Span and memory operations
- Regex engine improvements

Run both demos and compare the results to see the performance differences!
