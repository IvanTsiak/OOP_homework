using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/

interface IItem
{
    void SetPrice(double price);
}

interface IDiscountable {
    void ApplyDiscount(String discount);
    void ApplyPromocode(String promocode);
}

interface IClothes
{
    void SetColor(byte color);
    void SetSize(byte size);
}

class Book : IItem, IDiscountable
{
    public void SetPrice(double price)
    {
        Console.WriteLine($"Book price set to {price}");
    }

    public void ApplyDiscount(String discount)
    {
        Console.WriteLine($"Discount '{discount}' applied to Book");
    }
   public void ApplyPromocode(String promocode)
    {
        Console.WriteLine($"Promocode '{promocode}' applied to Book");
    }
}

class Outerwear : IItem, IDiscountable, IClothes
{
    public void SetPrice(double price)
    {
        Console.WriteLine($"Outerwear price set to {price}");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"Discount '{discount}' applied to Outerwear");
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine($"Promocode '{promocode}' applied to Outerwear");
    }

    public void SetColor(byte color)
    {
        Console.WriteLine($"Outerwear color set to {color}");
    }

    public void SetSize(byte size)
    {
        Console.WriteLine($"Outerwear size set to {size}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book myBook = new Book();
        myBook.SetPrice(250);
        myBook.ApplyDiscount("WinterSale");

        Outerwear jacket = new Outerwear();
        jacket.SetPrice(3000);
        jacket.SetSize(42);
        jacket.SetColor(1);

        Console.ReadKey();
    }
}