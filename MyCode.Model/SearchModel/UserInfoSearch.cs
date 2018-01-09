using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.Model.SearchModel
{
    public class UserInfoSearch
    {        
        public string Name { get; set; }       
        public DateTime? CreateTimeStart { get; set; }
        public DateTime? CreateTimeEnd { get; set; }
    }
}
