using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Infrastructure.AI.Ollama
{
    public sealed record OllamaMessage
    (
        string Role,
        string Content
        );
}
