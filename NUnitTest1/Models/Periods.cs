using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class Periods: NewPeriods
    {
        public int id;
    }
    public class NewPeriods : BaseObject
    {
        public List<Period> periods = new List<Period>();
    }

    public class Period : BaseObject
    {
        //дата начала "2014-10-14T00:00:00+04:00"
        public string from;
        //Дата окончания "2014-10-15T00:00:00+04:00"
        public string to;
        //смещение по часовому поясу "+05:00"
        public string offset;
    }
}
