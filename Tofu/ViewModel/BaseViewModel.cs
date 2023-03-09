using CommunityToolkit.Mvvm.ComponentModel;

namespace Tofu.ViewModel;

public partial class BaseViewModel : ObservableObject
{
	public BaseViewModel() { }

	[ObservableProperty]
	bool isBusy;

}