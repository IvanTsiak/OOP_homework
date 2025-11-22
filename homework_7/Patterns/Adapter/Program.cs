using System;
using System.Reflection.Emit;
namespace AdapterExample
{
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }
    
    class AmericanElectricitySystem
    {
        public string Get110Volt()
        {
            return "110V American system";
        }
    }
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }

    class Adapter : INewElectricitySystem
    {
        private readonly OldElectricitySystem _adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    class AmericanAdapter : INewElectricitySystem
    {
        private readonly AmericanElectricitySystem _adaptee;
        public AmericanAdapter(AmericanElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }

        public string MatchWideSocket()
        {
            return _adaptee.Get110Volt();
        }
    }

     class  ElectricityConsumer
    {
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }

    public class AdapterDemo
    {
        static void Main()
        {
            var newElectricitySystem = new NewElectricitySystem();
            Console.Write("New System: ");
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            Console.Write("Old System: ");
            ElectricityConsumer.ChargeNotebook(adapter);

            var americanSystem = new AmericanElectricitySystem();
            var americanAdapter = new AmericanAdapter(americanSystem);
            Console.Write("American System: ");
            ElectricityConsumer.ChargeNotebook(americanAdapter);

            Console.ReadKey();
        }
    }
}
