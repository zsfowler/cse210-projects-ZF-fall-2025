using System;

// This class represents the student.
public class Student
{
    private string _name;
    private int _points;

    public Student(string name)
    {
        _name = name;
        _points = 0;
    }

    public string Name
    {
        get { return _name; }
    }

    public int Points
    {
        get { return _points; }
    }

    public void AddPoints(int amount)
    {
        _points += amount;
    }
}
