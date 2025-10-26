using System;

// this class represents one single word in the scripture
public class Word
{
    // private variables
    private string _text;   // the word itself
    private bool _hidden;   // true if the word is hidden

    // constructor - makes a new word and sets it as visible
    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    // hides the word
    public void Hide()
    {
        _hidden = true;
    }

    // checks if the word is hidden
    public bool IsHidden()
    {
        return _hidden;
    }

    // shows either the word or underscores if it's hidden
    public string GetDisplayText()
    {
        if (_hidden)
        {
            // make underscores the same length as the word
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
