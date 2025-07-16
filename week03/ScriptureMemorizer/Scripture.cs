using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string w in splitWords)
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        int hiddenCount = 0;

        while (hiddenCount < count && !_words.TrueForAll(w => w.IsHidden()))
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public bool AllWordsHidden()
    {
        return _words.TrueForAll(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " - ";

        foreach (var word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }
}
