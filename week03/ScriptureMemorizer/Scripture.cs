using System;


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
                if (!w.IsHidden())         //   0       1        2       3    
                {                          // dadsad asdadasd mother dsdsd
                    nothiddenWords.Add(w); // 
                    randomIndex.Add(index); // randomIndex.Add(0) randomIndex.Add(1)  randomIndex.Add(2) randomIndex.Add(3)    
                    index++;
                }
            }
            Random random = new Random();
            int n;
            for (int i = 1; i <= numberTohide; i++)
            {
                if (!this.IsCompleteHidden())
                {
                    n = random.Next(0, randomIndex.Count()); //random.Next(0, 4) 0, 1, 2, 3 = 2
                    nothiddenWords[randomIndex[n]].Hide(); // nothiddenWord[2].hidden() mother -> true 
                    randomIndex.Remove(n); // 0  1  3
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