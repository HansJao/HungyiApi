using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataAccess.Models;
using Hungyi.DataAccess.User;

namespace Hungyi.Core.User
{
    class UserModule : IUserModule
    {
        private IUserDao _userDao;
        public UserModule(IUserDao userDao)
        {
            this._userDao = userDao;
        }
        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>
        /// 回傳使用者資訊
        /// </returns>
        public UserEntity UserLogin(string account)
        {
            var result = _userDao.GetUserByAccount(account);
            return result;
        }
    }
}
