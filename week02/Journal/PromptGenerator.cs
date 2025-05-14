using System;
public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public string GetRandomPrompt()
    {
        Random randomNumber = new Random();
        int index = randomNumber.Next(0, _prompts.Count());
        return _prompts[index];
    }


}