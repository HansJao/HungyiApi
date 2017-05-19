using Hungyi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.Core.User
{
    public interface IUserModule
    {
        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>回傳使用者資訊</returns>
        UserEntity UserLogin(string account);
    }
}
