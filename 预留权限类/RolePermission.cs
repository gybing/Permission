using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 角色拥有的权限
    /// </summary>
    public class RolePermission
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        Guid roleID;

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid RoleID
        {
            get { return roleID; }
        }
        Guid permissionID;

        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="permissionID"></param>
        public RolePermission(Guid roleID, Guid permissionID)
        {
            id = Guid.NewGuid();
            this.roleID = roleID;
            this.permissionID = permissionID;
        }
    }
}
