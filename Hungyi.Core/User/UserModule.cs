﻿using System;
using System.Collections.Generic;
using System.Text;
using Hungyi.DataAccess.User;
using Microsoft.Extensions.Configuration;
using Hungyi.DataClass.User;

namespace Hungyi.Core.User
{
    public class UserModule : IUserModule
    {
        private IUserDao _userDao;
        public UserModule(IUserDao userDao)
        {
            this._userDao = userDao;
        }

        public bool CheckToken(string account, string token)
        {
            var result = _userDao.GetUserByAccount(account).Token;
            return result == token;
        }

        /// <summary>
        /// Users the login.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// 回傳使用者資訊
        /// </returns>
        public UserEntity UserLogin(string account, string password)
        {
            var result = _userDao.GetUserByAccount(account);
            if (result != null && result.UserPassword == password)
                return result;

            return null;
        }
    }
}
