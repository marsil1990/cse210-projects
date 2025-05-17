using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            Word w = new Word(word);
            _words.Add(w);

        }

    }

    public void HideRandomWords(int numberTohide)
    {
        List<int> randomIndex = new List<int>();
        List<Word> nothiddenWords = new List<Word>();
        int index = 0;
        if (_words.Count() != 0)
        {
            foreach (Word w in _words)
            {
                if (!w.IsHidden())
                {
                    nothiddenWords.Add(w);
                    randomIndex.Add(index);
                    index++;
                }
            }
            Random random = new Random();
            int n;
            for (int i = 1; i <= numberTohide; i++)
            {
                if (!this.IsCompleteHidden())
                {
                    n = random.Next(0, randomIndex.Count());
                    nothiddenWords[randomIndex[n]].Hide();
                    randomIndex.Remove(n);
                }
                else
                {
                    break;
                }
            }
        }


    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText();
        foreach (Word w in _words)
        {
            text = text + " " + w.GetDisplayText();
        }
        return text;
    }
    public string GetOnlyText()
    {
        string text = "";
        foreach (Word w in _words)
        {
            if (text == "")
            {
                text = text + w.GetDisplayText();
            }
            else
            {
                text = text + " " + w.GetDisplayText();
            }

        }
        return text;
    }

    public bool IsCompleteHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public Reference GetReference()
    {
        return _reference;
    }
}