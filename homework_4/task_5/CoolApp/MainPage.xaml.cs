using System.Collections.ObjectModel; 
namespace CoolApp;

public class Item
{
	public double Price { get; set; }
	public string? CountryOfOrigin { get; set; }
	public string? Name { get; set; }
	public DateTime PackingDate { get; set; }
	public string? Description { get; set; }
}

public class Products : Item
{
	public DateTime ExpirationDate { get; set; }
	public double Amount { get; set; }
	//Їй Богу, перекладав ці назви в перекладачі (тавтологія)
	public string? UnitOfMeasurement { get; set; }
}

public class Books : Item
{
	public int NumberOfPages { get; set; }
	public string? Publisher { get; set; }
	public List<string>? Authors { get; set; }
}

public partial class MainPage : ContentPage
{
	public ObservableCollection<Item> ProductsList { get; set; }

	public MainPage()
	{
		ProductsList = new ObservableCollection<Item>();

		LoadInitialData();

		InitializeComponent();

		productsCollectionView.ItemsSource = ProductsList;
	}

	private void LoadInitialData()
	{
		ProductsList.Add(new Products
		{
			Name = "Молоко 'Чарівне'",
			Price = 80,
			CountryOfOrigin = "Україна",
			PackingDate = DateTime.Now.AddDays(-365),
			Description = "Молоко настільки чарівне, що гріх не купити",
			Amount = 1,
			UnitOfMeasurement = "L",
			ExpirationDate = DateTime.Now.AddDays(-10)
		});

		ProductsList.Add(new Books
		{
			Name = "Кобзар",
			Price = 1000,
			CountryOfOrigin = "Україна",
			PackingDate = new DateTime(1965, 6, 12),
			Description = "У кожного українця в хаті має бути Кобзар і Біблія",
			NumberOfPages = 750,
			Publisher = "Tempora",
			Authors = new List<string> { "Тарас Шевченко" }
		});
	}

	private void OnAddClicked(object sender, EventArgs e)
	{
		ProductsList.Add(new Books
		{
			Name = "Соняшник",
			Price = 146,
			CountryOfOrigin = "Україна",
			PackingDate = new DateTime(2007, 6, 12),
			Description = "Книга прекрасного поета Драча, який уміє поєднати в поеції " +
			 		"соняшник, випрані штани, відро та часник (за що ми з ним не дружим)",
			NumberOfPages = 367,
			Publisher = "Фоліо",
			Authors = new List<string> { "Іван Драч" }
		});
	}

	private void OnRemoveClicked(object sender, EventArgs e)
	{
		var selectedProduct = productsCollectionView.SelectedItem as Item;
		if (selectedProduct != null)
		{
			ProductsList.Remove(selectedProduct);
		}
	}
}

