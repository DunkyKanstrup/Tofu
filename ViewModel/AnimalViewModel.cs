using Microsoft.EntityFrameworkCore;
using System.Windows.Input;
using Tofu.Data;
using Tofu.Services;

namespace Tofu.ViewModel;


public partial class AnimalViewModel : BaseViewModel
{
	SupplierService supplierService;
	IConnectivity connection;
    private Supplier _selectedSupplier;
    private DateOnly _date;
	private readonly TofuDbContext _dbContext;


    public double _hotWeight;
    public double ColdWeight { get; private set; }
    

    public AnimalViewModel(SupplierService supplierService, IConnectivity connectivity, TofuDbContext dbContext)
	{
        Title = "New Animal";
		this.supplierService = supplierService;
		this.connection = connectivity;
        this._dbContext = dbContext;
    }

    //Updates the cold weight when the hot weight is updated.
    public double HotWeight {

		get => _hotWeight;
		set
		{
			if (_hotWeight != value) {
			_hotWeight = value;
			OnPropertyChanged(nameof(HotWeight));
				//Calls a calculator which updates the hot weight to cold weight.
			ColdWeightCalculator(_hotWeight);
			OnPropertyChanged(nameof(ColdWeight));
			}
		}
	}

	public double ColdWeightCalculator(double hotWeight)
	{
		return hotWeight * 0.98;
	}

    //Takes the selected supplier and adds them to a variable to be able to save the animal
    public Supplier SelectedSupplier
    {
        get => _selectedSupplier;
        set
        {
            _selectedSupplier = value;
            OnPropertyChanged();
        }
    }

    //Takes the selected date and adds it to a value
    public DateOnly Date
    {
        get => _date;
        set
        {
            _date = value;
            OnPropertyChanged();
        }
    }

    //Gets the suppliers and adds them to a list which can be loaded into the selecter.
    [RelayCommand]
	async Task GetSuppliers()
	{
		if(IsBusy) { return; }

		try
		{
			if(connection.NetworkAccess != NetworkAccess.Internet)
			{
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }
			IsBusy = true;
			
			var suppliers = await supplierService.GetSuppliers();
			if (suppliers.Count != 0) {
				suppliers.Clear();
			}

			foreach(var supplier in suppliers)
			{
				suppliers.Add(supplier);
			}
            
		}
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    //Takes the variables and add them a new instance of an animal.
	[RelayCommand]
    private async Task AddAnimal()
    {
        var newAnimal = new Animal
        {
            
            HotWeight = HotWeight,
            ColdWeight = ColdWeight,
            Date = Date,
            SupplierID = SelectedSupplier.Id,
			
		};

        _dbContext.Animals.Add(newAnimal);
        await _dbContext.SaveChangesAsync();
    }
}

