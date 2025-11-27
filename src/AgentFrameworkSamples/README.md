# Microsoft Agent Framework Samples

This folder contains samples demonstrating the Microsoft Agent Framework (Microsoft.Extensions.AI).

## Overview

The Microsoft.Extensions.AI library provides a unified abstraction for working with various AI services. It offers a common interface for:

- Chat completions (IChatClient)
- Text embeddings (IEmbeddingGenerator)
- Function calling (AIFunction)
- Middleware extensibility

## Samples

### HelloAgent

A basic sample that demonstrates:
- ChatMessage API for creating messages
- ChatOptions for configuring AI requests
- AIFunctionFactory for creating callable tools
- Function invocation

## Getting Started

### Run the HelloAgent Sample

```bash
cd HelloAgent
dotnet run
```

### Using with Real AI Providers

To use with actual AI services, add one of the provider packages:

```bash
# For OpenAI
dotnet add package Microsoft.Extensions.AI.OpenAI

# For Azure AI Inference
dotnet add package Microsoft.Extensions.AI.AzureAIInference
```

Then configure your client:

```csharp
using Microsoft.Extensions.AI;
using OpenAI;

// Create an OpenAI client
var openAIClient = new OpenAIClient("your-api-key");
IChatClient chatClient = openAIClient.AsChatClient("gpt-4");

// Use the chat client
var response = await chatClient.GetResponseAsync("Hello, how are you?");
Console.WriteLine(response.Text);
```

## Resources

- [Microsoft.Extensions.AI Documentation](https://learn.microsoft.com/dotnet/ai)
- [GenAI .NET Samples](https://aka.ms/genainet)
- [Semantic Kernel](https://learn.microsoft.com/semantic-kernel)

## Key Concepts

### IChatClient

The `IChatClient` interface is the core abstraction for chat-based AI interactions:

```csharp
public interface IChatClient
{
    Task<ChatResponse> GetResponseAsync(
        IEnumerable<ChatMessage> messages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(
        IEnumerable<ChatMessage> messages,
        ChatOptions? options = null,
        CancellationToken cancellationToken = default);
}
```

### AIFunction

Use `AIFunctionFactory` to create functions that can be called by AI models:

```csharp
var weatherTool = AIFunctionFactory.Create(
    (string location) => $"Weather in {location}: 22°C, sunny",
    "get_weather",
    "Gets current weather for a location");
```

### ChatOptions

Configure AI request parameters:

```csharp
var options = new ChatOptions
{
    Temperature = 0.7f,
    MaxOutputTokens = 1000,
    TopP = 0.9f
};
```
