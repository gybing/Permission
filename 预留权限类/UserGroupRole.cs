using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// �û���ӵ�еĽ�ɫ
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
        /// �û���ID
        /// </summary>
        public Guid UserGroupID
        {
            get { return userGroupID; }
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
