using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // Properties to allow access for saving/loading
    public string Prompt { get { return _prompt; } }
    public string Response { get { return _response; } }
    public string Date { get { return _date; } }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_response);
    }
}
