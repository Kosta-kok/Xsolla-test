using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class PromotionResult: BaseObject
    {
        public int id;

        public GetProjectResult project;

        public string technical_name;

        public bool read_only;

        public bool enabled;

        public bool is_active;

        public Period datetime;
    }
    public class Promotion : NewPromotion
    {
        public int id;

        public bool read_only;

        public bool enabled;      
    }

    public class NewPromotion : BaseObject
    {
        //Техническое название акции.
        public string technical_name;
        //Массив локализованных лэйблов, будут показаны в платежном интерфейсе.
        public LocalStrings label;
        //Массив локализованных названий акции.
        public LocalStrings name;
        //Массив локализованных описаний акции.
        public LocalStrings description;
        //ID проекта, для которого будет действовать акция.
        public int project_id;
    }

    public class NewPromotionResult : BaseObject
    {
        public int id;
    }
}
