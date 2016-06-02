using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// �û���������Ľ�ɫ�⣬ӵ�е�����Ȩ��
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
        /// �û�ID
        /// </summary>
        public Guid UserID
        {
            get { return userID; }
        }
        Guid permissionID;

        /// <summary>
        /// �û�ӵ�е�����Ȩ��
        /// </summary>
        public Guid PermissionID
        {
            get { return permissionID; }
            set { permissionID = value; }
        }

        /// <summary>
        /// ���캯��
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
