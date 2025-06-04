using System;
using System.Runtime.CompilerServices;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;

    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden && _text.Length > 0)
        {
            string text;
            char s = _text[_text.Length - 1];
            if (s == '.' || s == ',' || s == '?' || s == '!')
            {
                text = new string('_', _text.Length - 1);  
                return text + s;
            }
            else
            {
                text = new string('_', _text.Length);
                return text;
            }

        }
        else
        {
            return _text; 
        }

    }
}