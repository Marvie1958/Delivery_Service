using System;

class Engine
{
    private int currentLoadWeight;
    private int maxLoadCapacity = 1000;

    public int CurrentLoadWeight
    {
        get { return currentLoadWeight; }
        set
        {
            if (value < 0)
            {
                currentLoadWeight = 0;
                Console.WriteLine("Warning: Load cannot be negative. Set to 0.");
            }
            else if (value > maxLoadCapacity)
            {
                currentLoadWeight = maxLoadCapacity;
                Console.WriteLine("Warning: Load exceeded max capacity. Set to max capacity.");
            }
            else
            {
                currentLoadWeight = value;
                Console.WriteLine($"Load set to {currentLoadWeight}");
            }
        }
    }

    public virtual void StartEngine()
    {
        Console.WriteLine("Engine started successfully 🚗");
    }
}
