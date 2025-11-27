// =============================================================
// Performance Demo - .NET 8
// Mississauga .NET User Group - November 27, 2025
// =============================================================
// This demo shows various performance benchmarks to compare
// between .NET 8 and .NET 10
// =============================================================

using System.Diagnostics;

Console.WriteLine("===========================================");
Console.WriteLine($"  Performance Demo - .NET {Environment.Version}");
Console.WriteLine("  Mississauga .NET User Group");
Console.WriteLine("  November 27, 2025");
Console.WriteLine("===========================================\n");

// Warm-up
Console.WriteLine("Warming up...\n");
RunBenchmarks(warmup: true);

Console.WriteLine("Running benchmarks...\n");
RunBenchmarks(warmup: false);

Console.WriteLine("===========================================");
Console.WriteLine("  Benchmark Complete!");
Console.WriteLine("===========================================");

static void RunBenchmarks(bool warmup)
{
    int iterations = warmup ? 100 : 1000000;
    
    // Benchmark 1: String Concatenation
    var sw = Stopwatch.StartNew();
    for (int i = 0; i < iterations; i++)
    {
        _ = string.Concat("Hello", " ", "World", "!", i.ToString());
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"1. String Concatenation ({iterations:N0} iterations): {sw.ElapsedMilliseconds}ms");

    // Benchmark 2: List Operations
    sw.Restart();
    var list = new List<int>();
    for (int i = 0; i < iterations; i++)
    {
        list.Add(i);
    }
    int sum = 0;
    foreach (var item in list)
    {
        sum += item;
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"2. List Add & Sum ({iterations:N0} iterations): {sw.ElapsedMilliseconds}ms");

    // Benchmark 3: Dictionary Operations
    sw.Restart();
    var dict = new Dictionary<int, string>();
    for (int i = 0; i < iterations / 10; i++)
    {
        dict[i] = $"Value_{i}";
    }
    for (int i = 0; i < iterations / 10; i++)
    {
        _ = dict.TryGetValue(i, out _);
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"3. Dictionary Operations ({iterations / 10:N0} iterations): {sw.ElapsedMilliseconds}ms");

    // Benchmark 4: LINQ Operations
    sw.Restart();
    var numbers = Enumerable.Range(1, iterations / 100);
    for (int i = 0; i < 100; i++)
    {
        _ = numbers.Where(x => x % 2 == 0).Select(x => x * 2).Sum();
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"4. LINQ Operations ({iterations / 100:N0} items x 100): {sw.ElapsedMilliseconds}ms");

    // Benchmark 5: Array Operations
    sw.Restart();
    int[] array = new int[iterations];
    for (int i = 0; i < iterations; i++)
    {
        array[i] = i;
    }
    Array.Sort(array);
    int searchResult = Array.BinarySearch(array, iterations / 2);
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"5. Array Fill, Sort & Search ({iterations:N0} items): {sw.ElapsedMilliseconds}ms");

    // Benchmark 6: Span Operations
    sw.Restart();
    Span<byte> buffer = stackalloc byte[1024];
    for (int i = 0; i < iterations / 100; i++)
    {
        buffer.Fill((byte)(i % 256));
        _ = buffer.IndexOf((byte)128);
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"6. Span Operations ({iterations / 100:N0} iterations): {sw.ElapsedMilliseconds}ms");

    // Benchmark 7: Task/Async Operations
    sw.Restart();
    var tasks = new Task<int>[100];
    for (int i = 0; i < 100; i++)
    {
        int capture = i;
        tasks[i] = Task.Run(() => capture * 2);
    }
    Task.WaitAll(tasks);
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"7. Task Operations (100 tasks): {sw.ElapsedMilliseconds}ms");

    // Benchmark 8: Regex
    sw.Restart();
    var regex = new System.Text.RegularExpressions.Regex(@"\d+");
    string testString = "Hello 123 World 456 Test 789";
    for (int i = 0; i < iterations / 100; i++)
    {
        _ = regex.Matches(testString);
    }
    sw.Stop();
    if (!warmup)
        Console.WriteLine($"8. Regex Matching ({iterations / 100:N0} iterations): {sw.ElapsedMilliseconds}ms");

    if (!warmup)
        Console.WriteLine();
}
