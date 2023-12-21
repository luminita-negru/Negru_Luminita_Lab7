using Negru_Luminita_Lab7.Models;
namespace Negru_Luminita_Lab7;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)BindingContext;
        await App.Database.SaveShopAsync(shop);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var shop = (Shop)BindingContext;
            var address = shop.Adress;
            var locations = await Geocoding.GetLocationsAsync(address);

            var options = new MapLaunchOptions { Name = "Magazinul meu preferat" };

            var location = locations?.FirstOrDefault();
            var myLocation = new Location(46.7731796289, 23.6213886738);

            await Map.OpenAsync(location, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting locations: {ex.Message}");
            // You may also consider displaying an error message to the user.
        }
    }



}