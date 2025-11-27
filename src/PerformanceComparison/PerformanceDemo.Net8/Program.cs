// =============================================================
// Performance Demo - .NET 8
// Mississauga .NET User Group - November 27, 2025
// =============================================================
// This demo shows various performance benchmarks using BenchmarkDotNet
// Run with: dotnet run -c Release
// =============================================================

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text.RegularExpressions;

Console.WriteLine("===========================================");
Console.WriteLine($"  Performance Demo - .NET {Environment.Version}");
Console.WriteLine("  Mississauga .NET User Group");
Console.WriteLine("  November 27, 2025");
Console.WriteLine("  Powered by BenchmarkDotNet");
Console.WriteLine("===========================================\n");

BenchmarkRunner.Run<PerformanceBenchmarks>();

[MemoryDiagnoser]
public class PerformanceBenchmarks
{
    private const int Iterations = 10000;
    private List<int> _list = null!;
    private Dictionary<int, string> _dict = null!;
    private IEnumerable<int> _numbers = null!;
    private Regex _regex = null!;
    private string _testString = null!;
    private int[] _unsortedArray = null!;

    [GlobalSetup]
    public void Setup()
    {
        _list = new List<int>(Iterations);
        _dict = new Dictionary<int, string>(Iterations);
        _numbers = Enumerable.Range(1, Iterations);
        _regex = new Regex(@"\d+", RegexOptions.Compiled);
        _testString = "Hello 123 World 456 Test 789";
        _unsortedArray = new int[1000];

        for (int i = 0; i < Iterations; i++)
        {
            _list.Add(i);
            _dict[i] = $"Value_{i}";
        }

        for (int i = 0; i < 1000; i++)
        {
            _unsortedArray[i] = 1000 - i;
        }
    }

    [Benchmark]
    public string StringConcatenation()
    {
        return string.Concat("Hello", " ", "World", "!", "123");
    }

    [Benchmark]
    public int ListIteration()
    {
        int sum = 0;
        foreach (var item in _list)
        {
            sum += item;
        }
        return sum;
    }

    [Benchmark]
    public bool DictionaryLookup()
    {
        return _dict.TryGetValue(Iterations / 2, out _);
    }

    [Benchmark]
    public int LinqOperations()
    {
        return _numbers.Where(x => x % 2 == 0).Select(x => x * 2).Sum();
    }

    [Benchmark]
    public int ArraySortAndSearch()
    {
        var array = (int[])_unsortedArray.Clone();
        Array.Sort(array);
        return Array.BinarySearch(array, 500);
    }

    [Benchmark]
    public int SpanOperations()
    {
        Span<byte> buffer = stackalloc byte[1024];
        buffer.Fill(128);
        return buffer.IndexOf((byte)128);
    }

    [Benchmark]
    public async Task<int> TaskOperations()
    {
        var tasks = new Task<int>[10];
        for (int i = 0; i < 10; i++)
        {
            int capture = i;
            tasks[i] = Task.Run(() => capture * 2);
        }
        await Task.WhenAll(tasks);
        return tasks.Sum(t => t.Result);
    }

    [Benchmark]
    public int RegexMatching()
    {
        return _regex.Matches(_testString).Count;
    }
}
