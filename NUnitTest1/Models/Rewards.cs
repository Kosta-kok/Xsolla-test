using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest1.Models
{
    public class Rewards: NewRewards
    {
        public int id;
    }

    public class NewRewards : BaseObject
    {
        public Purchase purchase;

        public Package package;

        public Item item = new Item();

        public Subscription subscription;
    }
}
