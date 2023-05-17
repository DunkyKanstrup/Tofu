using Tofu.Services;

namespace Tofu.ViewModel;


public partial class AnimalViewModel : BaseViewModel
{
	public ObservableCollection<Animal> Animals { get; } = new();
	readonly AnimalService AnimalService;
	public AnimalViewModel(AnimalService animalService)
	{
		Title = "Animals";
		this.AnimalService = animalService;
	}

	[RelayCommand]
	async Task GetAnimalsAsync()
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;

			var animals = await AnimalService.GetAnimals();

			if (animals.Count != 0)
			{
				Animals.Clear();
			}
			foreach (var animal in animals)
			{
				Animals.Add(animal);
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine("Unable to get Animal " + ex.Message);
			await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
		}
		finally { IsBusy = false; }
	}

	[RelayCommand]
	async Task goToAnimal(string text)
	{
		if(text == null) return;

		await Shell.Current.GoToAsync
	}
}