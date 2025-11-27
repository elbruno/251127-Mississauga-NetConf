# Performance Comparison: .NET 8 vs .NET 10

This folder contains console applications that demonstrate performance improvements between .NET 8 and .NET 10 using [BenchmarkDotNet](https://benchmarkdotnet.org/).

## 📚 Reference Resources

- [Performance Improvements in .NET 10](https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-10/) - Stephen Toub's comprehensive blog post
- [.NET Performance Video](https://www.youtube.com/watch?v=snnULnTWcNM) - Performance improvements video
- [BenchmarkDotNet Documentation](https://benchmarkdotnet.org/)
- [BenchmarkDotNet NuGet Package](https://www.nuget.org/packages/BenchmarkDotNet)

## Running the Demos

### Run .NET 8 Demo

```bash
cd PerformanceDemo.Net8
dotnet run -c Release
```

### Run .NET 10 Demo

```bash
cd PerformanceDemo.Net10
dotnet run -c Release
```

## Benchmarks Included

1. **String Concatenation** - Tests string operations
2. **List Operations** - Tests collection add and iteration
3. **Dictionary Operations** - Tests dictionary lookups
4. **LINQ Operations** - Tests LINQ query performance
5. **Array Operations** - Tests array manipulation and sorting
6. **Span Operations** - Tests Span<T> operations
7. **Task Operations** - Tests async/parallel task execution
8. **Regex Matching** - Tests regular expression performance

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
