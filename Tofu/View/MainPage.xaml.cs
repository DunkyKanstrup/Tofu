using Tofu.Model;
using Tofu.View;

namespace Tofu;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void NavigatePage(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AnimalPage());
		
	}

   
}

