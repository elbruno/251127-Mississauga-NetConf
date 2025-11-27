// =============================================================
// Microsoft Agent Framework - Hello Agent Sample
// Mississauga .NET User Group - November 27, 2025
// =============================================================
// This demo shows basic usage of Microsoft.Extensions.AI
// For more samples visit: https://aka.ms/genainet
// =============================================================

using Microsoft.Extensions.AI;

Console.WriteLine("===========================================");
Console.WriteLine("  Microsoft Agent Framework - Hello Agent");
Console.WriteLine("  Mississauga .NET User Group");
Console.WriteLine("  November 27, 2025");
Console.WriteLine("===========================================\n");

Console.WriteLine("This sample demonstrates the Microsoft.Extensions.AI library.");
Console.WriteLine("The library provides a unified abstraction for working with AI services.\n");

Console.WriteLine("Key Features:");
Console.WriteLine("- Unified API for different AI providers");
Console.WriteLine("- IChatClient interface for chat completions");
Console.WriteLine("- IEmbeddingGenerator for text embeddings");
Console.WriteLine("- Built-in support for function calling");
Console.WriteLine("- Middleware pipeline for extensibility\n");

// Demonstrate the ChatMessage API
Console.WriteLine("--- ChatMessage API Demo ---\n");

// Creating different types of messages
var systemMessage = new ChatMessage(ChatRole.System, "You are a helpful assistant.");
var userMessage = new ChatMessage(ChatRole.User, "Hello, how are you?");
var assistantMessage = new ChatMessage(ChatRole.Assistant, "I'm doing great! How can I help you today?");

Console.WriteLine($"System Message Role: {systemMessage.Role}");
Console.WriteLine($"System Message Content: {systemMessage.Text}\n");

Console.WriteLine($"User Message Role: {userMessage.Role}");
Console.WriteLine($"User Message Content: {userMessage.Text}\n");

Console.WriteLine($"Assistant Message Role: {assistantMessage.Role}");
Console.WriteLine($"Assistant Message Content: {assistantMessage.Text}\n");

// Demonstrate chat options
Console.WriteLine("--- ChatOptions API Demo ---\n");

var options = new ChatOptions
{
    Temperature = 0.7f,
    MaxOutputTokens = 1000,
    TopP = 0.9f,
    TopK = 50,
    FrequencyPenalty = 0.5f,
    PresencePenalty = 0.5f
};

Console.WriteLine("ChatOptions Configuration:");
Console.WriteLine($"  Temperature: {options.Temperature}");
Console.WriteLine($"  MaxOutputTokens: {options.MaxOutputTokens}");
Console.WriteLine($"  TopP: {options.TopP}");
Console.WriteLine($"  TopK: {options.TopK}");
Console.WriteLine($"  FrequencyPenalty: {options.FrequencyPenalty}");
Console.WriteLine($"  PresencePenalty: {options.PresencePenalty}\n");

// Demonstrate a simple tool/function definition
Console.WriteLine("--- Function Calling Demo ---\n");

var weatherTool = AIFunctionFactory.Create(
    (string location) => $"The weather in {location} is 22°C and sunny.",
    "get_weather",
    "Gets the current weather for a specified location");

Console.WriteLine($"Tool Name: {weatherTool.Name}");
Console.WriteLine($"Tool Description: {weatherTool.Description}");
Console.WriteLine($"Tool Parameters: location (string)\n");

// Simulate calling the tool
var arguments = new AIFunctionArguments(new Dictionary<string, object?>
{
    ["location"] = "Toronto"
});
var result = weatherTool.InvokeAsync(arguments).Result;
Console.WriteLine($"Tool Result: {result}\n");

Console.WriteLine("===========================================");
Console.WriteLine("To use with a real AI provider, add one of:");
Console.WriteLine("  - Microsoft.Extensions.AI.OpenAI");
Console.WriteLine("  - Microsoft.Extensions.AI.AzureAIInference");
Console.WriteLine("  - Or any other compatible provider");
Console.WriteLine("===========================================\n");

Console.WriteLine("For more samples and documentation, visit:");
Console.WriteLine("  https://aka.ms/genainet");
Console.WriteLine("  https://learn.microsoft.com/dotnet/ai\n");

Console.WriteLine("===========================================");
Console.WriteLine("  Demo Complete!");
Console.WriteLine("===========================================");
