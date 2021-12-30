using System;
using System.Runtime.InteropServices;


public class Arifmetic
{
    public static int MyFunc(double value)
    {
        double a = Math.Ceiling(value);
        Console.WriteLine(a);
        return 0;
    }

    public static void Main()
    {
        int v = MyFunc(12.69);
    }
}