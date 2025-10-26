using System;
using System.Collections.Generic;

// this class stores the full scripture and manages hiding words
public class Scripture
{
    private Reference _reference;       // the reference (book, chapter, verse)
    private List<Word> _words = new List<Word>();  // all the words in the scripture

    // constructor - builds the scripture and splits the text into words
    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // split the text by spaces and make each part a Word object
        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    // hides a few random words from the list
    public void HideRandomWords(int count)
    {
        Random rand = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = rand.Next(0, _words.Count);
            _words[index].Hide();
        }
    }

    // checks if every word is hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false; // at least one word still showing
            }
        }
        return true; // all hidden
    }

    // shows the reference and the words (some may be hidden)
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n\n";

        // add each word (with spaces)
        foreach (Word w in _words)
        {
            result += w.GetDisplayText() + " ";
        }

        return result;
    }
}
