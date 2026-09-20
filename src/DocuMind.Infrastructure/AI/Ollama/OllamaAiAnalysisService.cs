using Azure;
using DocuMind.Application.Abstractions.AI;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace DocuMind.Infrastructure.AI.Ollama
{
    public sealed class OllamaAiAnalysisService : IAiAnalysisService
    {
        private readonly HttpClient _httpClient;
        private readonly OllamaOptions _options;

        public OllamaAiAnalysisService(HttpClient HttpClient, IOptions<OllamaOptions> options)
        {
            _httpClient = HttpClient;
            _options = options.Value;
        }


        public async Task<AiAnalysisResult> AnalyzeAsync(string documentContent,
        string question,
        CancellationToken cancellationToken = default)
        {
            var request = new OllamaChatRequest(
                _options.Model,
                [new OllamaMessage(
        "user",
        $$$"""
        Analyze the following document against the question.
        Document:
        {documentContent}
        Question:
        {question}
        Return JSON with exactly these properties:
        {{
            "isRelevant": true,
            "explanation": "your explanation"
        }}
        """)
                ]);


            using var response = await _httpClient.PostAsJsonAsync("/api/chat", request, cancellationToken);

            response.EnsureSuccessStatusCode();

            var ollamaResponse = await response.Content.ReadFromJsonAsync<OllamaChatResponse>(cancellationToken);

            if (ollamaResponse is null)
            {
                throw new InvalidOperationException("Ollama returned an empty response.");
            }

            var analysis = JsonSerializer.Deserialize<OllamaAnalysisResponse>(ollamaResponse.message.Content);

            if (analysis is null)
            {
                throw new InvalidOperationException(
                    "Ollama returned an invalid analysis response.");
            }

            return new AiAnalysisResult(
                    analysis.IsRelevant,
                    analysis.Explanation
                );


        }
    }
}
