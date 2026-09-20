using System;
using System.Collections.Generic;
using System.Text;

namespace DocuMind.Infrastructure.AI.Ollama
{
    public sealed class OllamaOptions
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Model { get; set; } =  string.Empty;
    }
}
