using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��ɫӵ�е�Ȩ��
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
        /// ��ɫID
        /// </summary>
        public Guid RoleID
        {
            get { return roleID; }
        }
        Guid permissionID;

        /// <summary>
        /// Ȩ��ID
        /// </summary>
        public Guid PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        /// <summary>
        /// ���캯��
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
