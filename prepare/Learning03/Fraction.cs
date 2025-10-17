using System;

public class Fraction
{
    // these are private so no one can change them directly
    private int _top;
    private int _bottom;

    // constructor 1: no numbers given, default is 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // constructor 2: only top number given, bottom is 1
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // constructor 3: top and bottom both given
    public Fraction(int top, int bottom)
    {
        _top = top;

        // make sure bottom is not 0
        if (bottom == 0)
        {
            Console.WriteLine("You can't have 0 on the bottom. Setting it to 1.");
            _bottom = 1;
        }
        else
        {
            _bottom = bottom;
        }
    }

    // getter for top
    public int GetTop()
    {
        return _top;
    }

    // setter for top
    public void SetTop(int top)
    {
        _top = top;
    }

    // getter for bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // setter for bottom
    public void SetBottom(int bottom)
    {
        if (bottom == 0)
        {
            Console.WriteLine("Bottom can't be 0.");
        }
        else
        {
            _bottom = bottom;
        }
    }

    // show the fraction like "3/4"
    public string GetFractionString()
    {
        return _top + "/" + _bottom;
    }

    // show the decimal value like 0.75
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
