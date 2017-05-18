using Hungyi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hungyi.DataAccess.User
{
    public interface IUserDao
    {
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>回傳成功筆數</returns>
        int InsertUser(UserEntity userEntity);

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>回傳所有UserData</returns>
        IEnumerable<UserEntity> GetAllUser();

        /// <summary>
        /// 依據UserID更新User
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns>
        /// 回傳成功筆數
        /// </returns>
        int UpdateUserByID(UserEntity userEntity);
    }
}
