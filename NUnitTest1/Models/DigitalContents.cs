using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class DigitalContents : BaseObject
    {
        public int id;
        public string localized_name;
        public List<Drm> drm = new List<Drm>();
    }
}
