namespace Tofu.View;

public partial class AnimalPage : ContentPage
{
	public AnimalPage(AnimalViewModel viewModel)
	{
		InitializeComponent();
		BindingContext= viewModel;
	}
}