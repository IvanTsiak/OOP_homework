using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

class PublishingHouseCl
{
    public PublishingHouseCl() { }
    public PublishingHouseCl(int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}
class Book
{
    public Book() { }
    public Book(string title, PublishingHouseCl publishingHouse)
    {
        PublishingHouse = publishingHouse;
        Title = title;
        PublishingHouseId = PublishingHouse.Id;
    }
    public int PublishingHouseId { get; set; }
    public string Title { get; set; }
    public PublishingHouseCl PublishingHouse { get; set; }
}

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        string path = "C:/projects/OOP_homework/homework_5/homework_5/coolfile.json";
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
            foreach (var book in books)
            {
                Console.WriteLine($"Назва: {book.Title}\n ID Видавництва: {book.PublishingHouseId}");
                Console.WriteLine($"Видавництво: {book.PublishingHouse.Name}\n Адреса: {book.PublishingHouse.Adress}\n");
            }
        }
        Console.ReadKey();

    }
}