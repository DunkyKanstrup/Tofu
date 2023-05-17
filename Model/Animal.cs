using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tofu.Model
{
    public class Animal: BaseModel
    {
        public float HotWeight { get; set; }
        public float ColdWeight { get; set; }
        public int SupplierID { get; set; }
    }
}
