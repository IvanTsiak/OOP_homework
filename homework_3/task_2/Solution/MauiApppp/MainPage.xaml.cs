namespace MauiApppp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        string input = NumberEntry.Text;
        DisplayAlert("Result", $"You entered the number {input}", "OK");
    }
}
