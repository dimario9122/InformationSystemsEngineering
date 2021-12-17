using System;

namespace Lab
{
	class Program
{
    static void Main(string[] args)
    {
        Baker baker = new CreamBaker("КремВсем");
        Cake cake = baker.Bake();
        
        Console.WriteLine();
         
        baker = new FruitBaker("ФруктНашПродукт");
        Cake cake2 = baker.Bake();
 
        Console.ReadLine();
    }
}
	
abstract class Baker
{
    public string Name { get; set; }
 
    public Baker (string n)
    { 
        Name = n; 
    }
    
    abstract public Cake Bake();
}

class CreamBaker : Baker
{
    public CreamBaker(string n) : base(n)
    { }
 
    public override Cake Bake()
    {
        return new CreamCake();
    }
}

class FruitBaker : Baker
{ 
    public FruitBaker(string n) : base(n)
    { }
 
    public override Cake Bake()
    {
        return new FruitCake();
    }
}
 
abstract class Cake
{ }
 
class FruitCake : Cake 
{ 
    public FruitCake()
    {
        Console.WriteLine("Фруктовый торт испечен");
    }
}
class CreamCake : Cake
{ 
    public CreamCake()
    {
        Console.WriteLine("Кремовый торт испечен");
    }
}
}