using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest1.Models
{
    public class Subscriptions
    {
        public List<Id> plans = new List<Id>();
        public List<int> products = new List<int>();
        public int? max_charges_count;
    }
}
