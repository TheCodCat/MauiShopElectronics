using MauiShopElectronics.Models.models;

namespace MauiShopElectronics.Pages;

public partial class CatalogCardComponent : ContentView
{
	private readonly static BindableProperty ProductsListProperty = BindableProperty.Create(nameof(ProductsList), typeof(List<Product>), typeof(CatalogCardComponent), new List<Product>());

    public List<Product> ProductsList
	{
		get => (List<Product>)GetValue(ProductsListProperty);
		set => SetValue(ProductsListProperty, value);
	}
	public CatalogCardComponent()
	{
		InitializeComponent();
	}
}