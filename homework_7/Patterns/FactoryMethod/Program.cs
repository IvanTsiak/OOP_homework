using System;
using System.Text;
namespace FactoryMethodExample
{
    public abstract class CoffeeMachine
    {
        public abstract Coffee BrewCoffee(int type);
    }

    public class Barista : CoffeeMachine
    {
        public override Coffee BrewCoffee(int type)
        {
            switch (type)
            {
                case 1:
                    return new Espresso();
                case 2:
                    return new Latte();
                case 3:
                    return new Cappuccino();
                default:
                    return null;
            }
        }
    }

    public abstract class Coffee
    {
        public abstract void Taste();
    }

    public class Espresso : Coffee
    {
        public override void Taste()
        {
            Console.WriteLine("Міцне, неначе камінь, еспресо");
        }
    }

    public class Latte : Coffee
    {
        public override void Taste()
        {
            Console.WriteLine("Смачненьке з молочком латте");
        }
    }

    public class Cappuccino : Coffee
    {
        public override void Taste()
        {
            Console.WriteLine("Капучино, що тримає баланс кави та молока");
        }
    }
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            CoffeeMachine barista = new Barista();

            for (int i = 1; i <= 3; i++)
            {
                Coffee coffeeCup = barista.BrewCoffee(i);

                Console.WriteLine($"Бариста приготував {coffeeCup.GetType().Name}");
                coffeeCup.Taste();
            }

            Console.ReadKey();
        }
    }
}

