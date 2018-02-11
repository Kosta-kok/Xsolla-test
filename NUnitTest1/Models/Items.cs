using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest1.Models
{
    public class Items
    {
        public Sku sku;// = new List<Sku>();
    }

    public class Item : BaseObject
    {
        public List<Discount> discount = new List<Discount>();

        public List<Bonus> bonus = new List<Bonus>();
    }
}
