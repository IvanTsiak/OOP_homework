using System;
using System.ComponentModel;
using System.Text;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            SimpleChristmasTree tree = new SimpleChristmasTree();
            Console.WriteLine("Просто ялинка:");
            tree.Display();
            Console.WriteLine("\n");

            OrnamentsDecorator treeWithToys = new OrnamentsDecorator();
            treeWithToys.SetTree(tree);
            Console.WriteLine("Ялинка з прикрасами:");
            treeWithToys.Display();
            Console.WriteLine("\n");

            GarlandDecorator treeWithLights = new GarlandDecorator();
            treeWithLights.SetTree(treeWithToys);
            Console.WriteLine("Ялинка з прикрасами та гірляндами:");
            treeWithLights.Display();

            Console.Read();
        }
    }

    abstract class ChristmasTree
    {
        public abstract void Display();
    }
    
    class SimpleChristmasTree : ChristmasTree
    {
        public override void Display()
        {
            Console.Write("Ялиночка");
        }
    }

    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetTree (ChristmasTree tree)
        {
            this.tree = tree;
        }

        public override void Display()
        {
            if (tree != null)
            {
                tree.Display();
            }
        }
    }

    class OrnamentsDecorator : TreeDecorator
    {
        public override void Display()
        {
            base.Display();
            AddOrnaments();
        }

        private void AddOrnaments()
        {
            Console.Write(" + прикраси (кульки, дощик)");
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        public override void Display()
        {
            base.Display();
            Glow();
        }

        private void Glow()
        {
            Console.Write(" + гірлянди (красиво світяться)");
        }
    }
}