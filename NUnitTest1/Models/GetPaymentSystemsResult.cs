using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class GetPaymentSystemsResult : BaseObject
    {
        public int id;

        public List<PaymentSystem> payment_systems;
    }
}
