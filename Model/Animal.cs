
namespace Tofu.Model
{
    public class Animal: BaseModel
    {
        public AnimalType Type { get; set; }
        public double HotWeight { get; set; }
        public double ColdWeight { get; set; }
        public int SupplierID { get; set; }
        public DateOnly Date { get; set; }
        public TransactionTypes TransactionType { get; set; 
        public string Comments { get; set; }
    }
}
