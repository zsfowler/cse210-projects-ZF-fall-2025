using System;

// this class stores the scripture reference (book, chapter, and verse numbers)
public class Reference
{
    // private variables
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    // constructor for one verse (like John 3:16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = verse;
    }

    // constructor for a verse range (like Proverbs 3:5-6)
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    // returns the reference as a string (ex: "Proverbs 3:5-6")
    public string GetDisplayText()
    {
        if (_verseStart == _verseEnd)
        {
            return _book + " " + _chapter + ":" + _verseStart;
        }
        else
        {
            return _book + " " + _chapter + ":" + _verseStart + "-" + _verseEnd;
        }
    }
}
