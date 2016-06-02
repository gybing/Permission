using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 用户除了自身的角色外，拥有的特殊权限
    /// </summary>
    public class UserPermission
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
        Guid permissionID;

        /// <summary>
        /// 用户拥有的特殊权限
        /// </summary>
        public Guid PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="permissionID"></param>
        public UserPermission(Guid userID, Guid permissionID)
        {
            id = Guid.NewGuid();
            this.userID = userID;
            this.permissionID = permissionID;
        }
    }
}
