using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Remark { get; set; }
    }
}
