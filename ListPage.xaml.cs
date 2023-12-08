using Negru_Luminita_Lab7.Models;
namespace Negru_Luminita_Lab7;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
        {
            BindingContext = new Product()
        });
    }

    async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        var selectedProduct = (Product)((MenuItem)sender).CommandParameter;

        await App.Database.DeleteProductAsync(selectedProduct);


        var shopList = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopList = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        var selectedProduct = (Product)listView.SelectedItem;

        if (selectedProduct != null)
        {
            await App.Database.DeleteProductAsync(selectedProduct);

            var shopList = (ShopList)BindingContext;
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
        }
        else
        {
            await DisplayAlert("No Item Selected", "Please select an item to delete.", "OK");
        }
    }
}
