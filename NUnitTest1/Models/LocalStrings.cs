using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class LocalStrings : BaseObject
    {
        public string en;
    }

    public class LocalStringsEn : LocalStrings
    {
    }

    public class LocalStringsRu : LocalStrings
    {
        public string ru;
    }
}
