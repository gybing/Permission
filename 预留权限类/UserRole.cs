using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 用户拥有的角色
    /// </summary>
    public class UserRole
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        Guid userID;

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid UserID
        {
            get { return userID; }
        }
        Guid roleID;

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        public UserRole(Guid userID, Guid roleID)
        {
            id = Guid.NewGuid();
            this.userID = userID;
            this.roleID = roleID;
        }
    }
}
