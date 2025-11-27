// =============================================================
// Performance Demo - .NET 10
// Mississauga .NET User Group - November 27, 2025
// =============================================================
// This demo shows various performance benchmarks using BenchmarkDotNet
// Run with: dotnet run -c Release
// =============================================================

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
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
[Config(typeof(FastConfig))]
public class PerformanceBenchmarks
{
    private const int Iterations = 1000000;
    private const int DictIterations = 100000;
    private const int LinqItems = 10000;
    private const int SpanIterations = 10000;
    private const int RegexIterations = 10000;

    private List<int> _list = null!;
    private Dictionary<int, string> _dict = null!;
    private IEnumerable<int> _numbers = null!;
    private Regex _regex = null!;
    private string _testString = null!;
    private int[] _array = null!;

    [GlobalSetup]
    public void Setup()
    {
        _list = new List<int>(Iterations);
        _dict = new Dictionary<int, string>(DictIterations);
        _numbers = Enumerable.Range(1, LinqItems);
        _regex = new Regex(@"\d+", RegexOptions.Compiled);
        _testString = "Hello 123 World 456 Test 789";
        _array = new int[Iterations];

        for (int i = 0; i < Iterations; i++)
        {
            _list.Add(i);
            _array[i] = i;
        }

        for (int i = 0; i < DictIterations; i++)
        {
            _dict[i] = $"Value_{i}";
        }
    }

    [Benchmark(Description = "1. String Concatenation")]
    public string StringConcatenation()
    {
        string result = "";
        for (int i = 0; i < 1000; i++)
        {
            result = string.Concat("Hello", " ", "World", "!", i.ToString());
        }
        return result;
    }

    [Benchmark(Description = "2. List Add & Sum")]
    public int ListAddAndSum()
    {
        var list = new List<int>();
        for (int i = 0; i < 10000; i++)
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

    [Benchmark(Description = "3. Dictionary Operations")]
    public bool DictionaryOperations()
    {
        var dict = new Dictionary<int, string>();
        for (int i = 0; i < 1000; i++)
        {
            dict[i] = $"Value_{i}";
        }
        bool found = false;
        for (int i = 0; i < 1000; i++)
        {
            found = dict.TryGetValue(i, out _);
        }
        return found;
    }

    [Benchmark(Description = "4. LINQ Operations")]
    public int LinqOperations()
    {
        return _numbers.Where(x => x % 2 == 0).Select(x => x * 2).Sum();
    }

    [Benchmark(Description = "5. Array Fill, Sort & Search")]
    public int ArrayFillSortSearch()
    {
        int[] array = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            array[i] = 10000 - i;
        }
        Array.Sort(array);
        return Array.BinarySearch(array, 5000);
    }

    [Benchmark(Description = "6. Span Operations")]
    public int SpanOperations()
    {
        Span<byte> buffer = stackalloc byte[1024];
        int result = 0;
        for (int i = 0; i < 100; i++)
        {
            buffer.Fill((byte)(i % 256));
            result = buffer.IndexOf((byte)128);
        }
        return result;
    }

    [Benchmark(Description = "7. Task Operations")]
    public int TaskOperations()
    {
        var tasks = new Task<int>[100];
        for (int i = 0; i < 100; i++)
        {
            int capture = i;
            tasks[i] = Task.Run(() => capture * 2);
        }
        Task.WaitAll(tasks);
        return tasks.Sum(t => t.Result);
    }

    [Benchmark(Description = "8. Regex Matching")]
    public int RegexMatching()
    {
        int count = 0;
        for (int i = 0; i < 100; i++)
        {
            count = _regex.Matches(_testString).Count;
        }
        return count;
    }
}

public class FastConfig : ManualConfig
{
    public FastConfig()
    {
        AddJob(Job.ShortRun
            .WithWarmupCount(1)
            .WithIterationCount(3));
    }
}
