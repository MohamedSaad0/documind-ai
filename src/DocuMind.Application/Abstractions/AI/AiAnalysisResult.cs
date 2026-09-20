using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DocuMind.Application.Abstractions.AI
{
    public sealed record AiAnalysisResult
    (
        bool IsRelevant,
        string Explanation
        );
}
