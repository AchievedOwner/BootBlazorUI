using System;
using Markdig;
using Markdig.SyntaxHighlighting;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.Docs
{
    public static class Code
    {
        public static MarkupString GetCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value cannot be null or white space", nameof(value));
            }

            return new MarkupString(Markdown.ToHtml(value, new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSyntaxHighlighting().Build()));
        }
    }
}
