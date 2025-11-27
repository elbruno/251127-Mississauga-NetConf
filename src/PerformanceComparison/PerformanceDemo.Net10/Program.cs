// =============================================================
// Performance Demo - .NET 10
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
    private int[] _array = null!;
    private List<int> _list = null!;
    private Dictionary<int, string> _dict = null!;
    private IEnumerable<int> _numbers = null!;
    private Regex _regex = null!;
    private string _testString = null!;

    [GlobalSetup]
    public void Setup()
    {
        _array = new int[Iterations];
        _list = new List<int>(Iterations);
        _dict = new Dictionary<int, string>(Iterations);
        _numbers = Enumerable.Range(1, Iterations);
        _regex = new Regex(@"\d+", RegexOptions.Compiled);
        _testString = "Hello 123 World 456 Test 789";

        for (int i = 0; i < Iterations; i++)
        {
            _list.Add(i);
            _dict[i] = $"Value_{i}";
        }
    }

    [Benchmark]
    public string StringConcatenation()
    {
        return string.Concat("Hello", " ", "World", "!", "123");
    }

    [Benchmark]
    public int ListAddAndSum()
    {
        var list = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            list.Add(i);
        }
        int sum = 0;
        foreach (var item in list)
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
        var array = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            array[i] = 1000 - i;
        }
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
