using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest1.Models
{
    public class Subject: NewSubject
    {
        public int id;
    }

    public class NewSubject : BaseObject
    {

        public bool purchase;

        public List<Sku> items = new List<Sku>();

        public List<float?> packages = new List<float?>();

        public Subscriptions subscriptions;

        public List<DigitalContents> digital_contents = new List<DigitalContents>();
    }
}
