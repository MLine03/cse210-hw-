using System;

class Program
{
    static void Main(string[] args)
    {
        // Test default constructor (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());   // Output: 1/1
        Console.WriteLine(f1.GetDecimalValue());     // Output: 1

        // Test one-parameter constructor (5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());   // Output: 5/1
        Console.WriteLine(f2.GetDecimalValue());     // Output: 5

        // Test two-parameter constructor (3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());   // Output: 3/4
        Console.WriteLine(f3.GetDecimalValue());     // Output: 0.75

        // Another test (1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());   // Output: 1/3
        Console.WriteLine(f4.GetDecimalValue());     // Output: 0.333...

        // Use setters
        f1.SetTop(7);
        f1.SetBottom(8);
        Console.WriteLine(f1.GetFractionString());   // Output: 7/8
        Console.WriteLine(f1.GetDecimalValue());     // Output: 0.875
    }
}
