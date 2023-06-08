using System.Diagnostics.CodeAnalysis;

namespace Tofu.Model
{
    public class Supplier: BaseModel
    {
        public string Name { get; set; }
        
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int CVRNumber { get; set; }
        [AllowNull]
        public int PhoneNumber { get; set; }
    }
}
