using Hungyi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataAccess.User
{
    public interface IUserDao
    {
        int InsertUser(UserEntity userEntity);
    }
}
