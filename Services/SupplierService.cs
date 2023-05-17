
namespace Tofu.Services
{
    public class SupplierService
    {
        List<Supplier> suppliers;
        HttpClient httpClient;

        public SupplierService()
        {
            httpClient= new HttpClient();
        }


        public async Task<List<Supplier>> GetSuppliers()
        {
            var response = await httpClient.GetAsync("");

            if(response.IsSuccessStatusCode)
            {
                var suppliers = await httpClient.GetAsync(" ");
            }
            else
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("mockSupplier.json");
                var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();

                suppliers = JsonSerializer.Deserialize<List<Supplier>>(contents);
            }
            return suppliers;
        }

    }
}
