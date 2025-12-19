using System;

namespace DeliveryServiceAssignment
{
    public interface IDeliverable
    {
        bool RequiresSpecialDocking { get; }
        void LoadCargo(int weight);
        void UnloadCargo(int weight);
    }

    public class DeliveryTruck : IDeliverable
    {
        private string truckName;
        private int currentLoadWeight;
        private int maxLoadCapacity;

        public DeliveryTruck(string name, int capacity)
        {
            truckName = name;
            maxLoadCapacity = capacity;
            currentLoadWeight = 0;
        }

        public string TruckName
        {
            get { return truckName; }
        }

        public int CurrentLoadWeight
        {
            get { return currentLoadWeight; }
            set
            {
                if (value < 0)
                {
                    currentLoadWeight = 0;
                    Console.WriteLine("[Warning] Load cannot be negative. Setting load to 0.");
                }
                else if (value > maxLoadCapacity)
                {
                    currentLoadWeight = maxLoadCapacity;
                    Console.WriteLine("[Warning] Load exceeds max capacity. Setting load to max capacity.");
                }
                else
                {
                    currentLoadWeight = value;
                }
            }
        }

        public virtual void StartEngine()
        {
            Console.WriteLine("DeliveryTruck engine started.");
        }

        public virtual bool RequiresSpecialDocking
        {
            get { return false; }
        }

        public void LoadCargo(int weight)
        {
            CurrentLoadWeight += weight;
            Console.WriteLine($"{TruckName} loaded {weight} kg.");
        }

        public void UnloadCargo(int weight)
        {
            CurrentLoadWeight -= weight;
            Console.WriteLine($"{TruckName} unloaded {weight} kg.");
        }
    }

    public class RefrigeratedTruck : DeliveryTruck
    {
        public RefrigeratedTruck(string name, int capacity) : base(name, capacity) { }

        public override void StartEngine()
        {
            Console.WriteLine("RefrigeratedTruck engine started. Cooling system is now on.");
        }
    }

    public class LuxuryCourierVan : DeliveryTruck
    {
        private bool hasPremiumInterior;

        public LuxuryCourierVan(string name, int capacity, bool premiumInterior)
            : base(name, capacity)
        {
            hasPremiumInterior = premiumInterior;
        }

        public void ActivateClimateControl()
        {
            if (hasPremiumInterior)
                Console.WriteLine("Climate control on.");
            else
                Console.WriteLine("Standard AC on.");
        }

        public override void StartEngine()
        {
            Console.WriteLine("LuxuryCourierVan engine started smoothly.");
        }

        public override bool RequiresSpecialDocking
        {
            get { return true; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DeliveryTruck truck1 = new DeliveryTruck("Standard Truck", 200);
            RefrigeratedTruck truck2 = new RefrigeratedTruck("Cold Truck", 150);
            LuxuryCourierVan truck3 = new LuxuryCourierVan("Luxury Van", 100, true);

            truck1.StartEngine();
            truck2.StartEngine();
            truck3.StartEngine();

            truck1.LoadCargo(9999);
            truck1.UnloadCargo(9999);

            IDeliverable[] myFleet = { truck1, truck2, truck3 };

            foreach (IDeliverable vehicle in myFleet)
            {
                vehicle.LoadCargo(50);
                Console.WriteLine(vehicle.RequiresSpecialDocking);
            }
        }
    }
}
