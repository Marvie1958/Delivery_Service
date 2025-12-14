using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("MAIN TASK IS RUNNING 🔥");

        Engine engine = new Engine();

        engine.CurrentLoadWeight = -10;
        engine.CurrentLoadWeight = 2000;
        engine.CurrentLoadWeight = 500;

        engine.StartEngine();
    }
}

