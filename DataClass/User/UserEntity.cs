using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataClass.User
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Gender { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserCellphone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Token { get; set; }
    }
}
