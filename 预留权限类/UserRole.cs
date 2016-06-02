using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// �û�ӵ�еĽ�ɫ
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
        /// �û�ID
        /// </summary>
        public Guid UserID
        {
            get { return userID; }
        }
        Guid roleID;

        /// <summary>
        /// ��ɫID
        /// </summary>
        public Guid RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        /// <summary>
        /// ���캯��
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
