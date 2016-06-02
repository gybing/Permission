using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 用户组拥有的角色
    /// </summary>
    public class UserGroupRole
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        Guid userGroupID;

        /// <summary>
        /// 用户组ID
        /// </summary>
        public Guid UserGroupID
        {
            get { return userGroupID; }
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
        /// <param name="userGroupID"></param>
        /// <param name="roleID"></param>
        public UserGroupRole(Guid userGroupID, Guid roleID)
        {
            id = Guid.NewGuid();
            this.userGroupID = userGroupID;
            this.roleID = roleID;
        }
    }
}
