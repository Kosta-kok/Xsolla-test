using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest1.Models
{
    public class Discount : Sku
    {
        public int? max_amount;

        public float discount_percent;
    }
}
