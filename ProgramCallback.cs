using System;
using System.Runtime.InteropServices;

public class MyMath
{
    public int Ceiling(double value)
    {
        return 13;
    }
}

public class Arifmetic
{
    public static int MyFunc(double value, MyMath mymath)
    {
        double a = mymath.Ceiling(value);
        Console.WriteLine(a);
        return 0;
    }

    public static void Main()
    {
        MyMath math = new MyMath();
        int v = MyFunc(12.69, math);
    }
}