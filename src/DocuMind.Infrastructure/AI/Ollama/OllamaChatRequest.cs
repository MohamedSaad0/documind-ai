

namespace DocuMind.Infrastructure.AI.Ollama
{
    public sealed record OllamaChatRequest
    (
        string Model,
        IReadOnlyList<OllamaMessage> Messages,
        bool stream = false,
        string Format = "json"
        );
}
