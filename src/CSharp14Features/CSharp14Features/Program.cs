// =============================================================
// C# 14 New Features Demo
// Mississauga .NET User Group - November 27, 2025
// =============================================================

Console.WriteLine("===========================================");
Console.WriteLine("  C# 14 New Features Demo");
Console.WriteLine("  Mississauga .NET User Group");
Console.WriteLine("  November 27, 2025");
Console.WriteLine("===========================================\n");

// Demo 1: Field Keyword
Console.WriteLine("1. FIELD KEYWORD");
Console.WriteLine("-------------------------------------------");
FieldKeywordDemo.Run();
Console.WriteLine();

// Demo 2: Null-Conditional Assignment
Console.WriteLine("2. NULL-CONDITIONAL ASSIGNMENT");
Console.WriteLine("-------------------------------------------");
NullConditionalAssignmentDemo.Run();
Console.WriteLine();

// Demo 3: Extension Types (Preview)
Console.WriteLine("3. EXTENSION MEMBERS");
Console.WriteLine("-------------------------------------------");
ExtensionMembersDemo.Run();
Console.WriteLine();

// Demo 4: Unbound Generic Types in nameof
Console.WriteLine("4. UNBOUND GENERIC TYPES IN NAMEOF");
Console.WriteLine("-------------------------------------------");
UnboundGenericNameofDemo.Run();
Console.WriteLine();

// Demo 5: First-class Span Support
Console.WriteLine("5. FIRST-CLASS SPAN SUPPORT");
Console.WriteLine("-------------------------------------------");
SpanSupportDemo.Run();
Console.WriteLine();

Console.WriteLine("===========================================");
Console.WriteLine("  Demo Complete!");
Console.WriteLine("===========================================");

// =============================================================
// Demo 1: Field Keyword (Preview Feature)
// The 'field' keyword provides access to the compiler-generated 
// backing field in property accessors. This feature requires
// <LangVersion>preview</LangVersion> in the project file.
// =============================================================
public static class FieldKeywordDemo
{
    public static void Run()
    {
        var person = new PersonWithField("John", "Doe");
        Console.WriteLine($"Initial Name: {person.FirstName} {person.LastName}");

        // This will trigger validation in the setter
        try
        {
            person.FirstName = "";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Validation caught: {ex.Message}");
        }

        person.FirstName = "Jane";
        Console.WriteLine($"Updated Name: {person.FirstName} {person.LastName}");
    }
}

// Using the 'field' keyword to access backing field directly (C# 13+ preview feature)
public class PersonWithField
{
    public PersonWithField(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    // Using 'field' keyword - automatically creates backing field
    public string FirstName
    {
        get => field;
        set => field = !string.IsNullOrWhiteSpace(value) 
            ? value 
            : throw new ArgumentException("First name cannot be empty", nameof(FirstName));
    }

    public string LastName
    {
        get => field;
        set => field = !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentException("Last name cannot be empty", nameof(LastName));
    }
}

// =============================================================
// Demo 2: Null-Conditional Assignment
// Assign to a target only if it's not null
// =============================================================
public static class NullConditionalAssignmentDemo
{
    public static void Run()
    {
        Customer? customer = new Customer { Name = "Alice", Orders = ["Order1", "Order2"] };
        
        Console.WriteLine($"Customer orders before: {string.Join(", ", customer.Orders)}");
        
        // Add an order only if customer is not null
        customer?.Orders?.Add("Order3");
        
        Console.WriteLine($"Customer orders after: {string.Join(", ", customer?.Orders ?? [])}");
        
        // With null customer
        Customer? nullCustomer = null;
        nullCustomer?.Orders?.Add("Order4"); // This safely does nothing
        Console.WriteLine($"Null customer handled safely (no exception thrown)");
    }
}

public class Customer
{
    public string Name { get; set; } = "";
    public List<string> Orders { get; set; } = [];
}

// =============================================================
// Demo 3: Extension Members
// Extension methods have been enhanced
// =============================================================
public static class ExtensionMembersDemo
{
    public static void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        
        Console.WriteLine($"Original list: {string.Join(", ", numbers)}");
        Console.WriteLine($"Sum using extension: {numbers.Sum()}");
        Console.WriteLine($"Average using extension: {numbers.Average():F2}");
        
        // String extensions
        string text = "Hello, Mississauga!";
        Console.WriteLine($"Original: {text}");
        Console.WriteLine($"Word count: {text.WordCount()}");
        Console.WriteLine($"Reversed: {text.ReverseString()}");
    }
}

public static class ListExtensions
{
    public static int Sum(this List<int> list)
    {
        int sum = 0;
        foreach (var item in list)
        {
            sum += item;
        }
        return sum;
    }
    
    public static double Average(this List<int> list)
    {
        if (list.Count == 0) return 0;
        return (double)list.Sum() / list.Count;
    }
}

public static class StringExtensions
{
    public static int WordCount(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split([' ', '\t', '\n'], StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    public static string ReverseString(this string text)
    {
        var charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

// =============================================================
// Demo 4: Unbound Generic Types in nameof
// Can now use nameof with unbound generic types
// =============================================================
public static class UnboundGenericNameofDemo
{
    public static void Run()
    {
        // In C# 14, you can use nameof with unbound generic types
        Console.WriteLine($"Generic type name: {nameof(Dictionary<,>)}");
        Console.WriteLine($"Generic type name: {nameof(List<>)}");
        Console.WriteLine($"Generic type name: {nameof(Tuple<,>)}");
        Console.WriteLine($"Concrete type name: {nameof(Dictionary<string, int>)}");
    }
}

// =============================================================
// Demo 5: First-class Span Support
// Better support for Span<T> and ReadOnlySpan<T>
// =============================================================
public static class SpanSupportDemo
{
    public static void Run()
    {
        // First-class Span support in LINQ-like patterns
        ReadOnlySpan<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        
        Console.WriteLine($"Span: {SpanToString(numbers)}");
        
        // Slice operations
        ReadOnlySpan<int> firstHalf = numbers[..5];
        ReadOnlySpan<int> lastHalf = numbers[5..];
        
        Console.WriteLine($"First half: {SpanToString(firstHalf)}");
        Console.WriteLine($"Last half: {SpanToString(lastHalf)}");
        
        // Span patterns with strings
        ReadOnlySpan<char> text = "Hello, World!";
        Console.WriteLine($"Span length: {text.Length}");
        Console.WriteLine($"Span slice (0..5): {text[..5].ToString()}");
    }
    
    private static string SpanToString<T>(ReadOnlySpan<T> span)
    {
        var items = new List<string>();
        foreach (var item in span)
        {
            items.Add(item?.ToString() ?? "null");
        }
        return string.Join(", ", items);
    }
}
