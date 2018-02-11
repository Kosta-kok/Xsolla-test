using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class PaymentSystemsResult : PaymentSystems
    {
        public int id;
    }

    public class PaymentSystems : BaseObject
    {
        public List<PaymentSystem> payment_systems = new List<PaymentSystem>();
    }

    public class NewPaymentSystem : BaseObject
    {
        public int id;
    }
    public class PaymentSystem : NewPaymentSystem
    {
        public string name;
    }
}
