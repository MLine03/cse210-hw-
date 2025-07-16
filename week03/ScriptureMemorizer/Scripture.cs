using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords()
    {
        Random rand = new Random();
        int wordsToHide = 3;

        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        for (int i = 0; i < wordsToHide && visibleIndexes.Count > 0; i++)
        {
            int index = rand.Next(visibleIndexes.Count);
            _words[visibleIndexes[index]].Hide();
            visibleIndexes.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string display = _reference.GetDisplayText() + " - ";

        foreach (Word word in _words)
        {
            display += word.GetDisplayText() + " ";
        }

        return display.TrimEnd();
    }
}
