using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private static readonly Random _random = new Random();
    private readonly List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What was the most challenging part of your  day?",
        "How have you seen the Lord's hand today?",
        "Describe a moment that made you smile today.",
        "What is something new you learned today?",
        "Could you help someone today? How?",
        "Write about someone who has had a positive impact on your day."
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}