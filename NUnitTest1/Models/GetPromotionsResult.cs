using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest1.Models
{
    public class GetPromotionsResult : BaseObject
    {
        public int id;
        
        public GetProjectResult project;
        //Техническое название акции.
        public string technical_name;
        //Доступность изменения акции, если True, то нельзя изменить project_id
        public bool read_only;
        //признак доступности акции. Удалить можно только если False.
        public bool enabled;
        //признак активности акции
        public bool is_active;
        //период действия
        public Period datetime;
    }
}
