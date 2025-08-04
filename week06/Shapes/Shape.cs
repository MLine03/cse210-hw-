public abstract class Shape
{
    protected string color;

    public Shape(string color)
    {
        this.color = color;
    }

    public string GetColor()
    {
        return color;
    }

    public abstract double GetArea();
}
