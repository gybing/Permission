using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ����ӵ�еĽ�ɫ��
    /// </summary>
    public class DepartmentRole
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }

        Guid departmentID;

        /// <summary>
        /// ����ID
        /// </summary>
        public Guid DepartmentID
        {
            get { return departmentID; }
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
        /// <param name="departmentID"></param>
        /// <param name="roleID"></param>
        public DepartmentRole(Guid departmentID, Guid roleID)
        {
            id = Guid.NewGuid();
            this.departmentID = departmentID;
            this.roleID = roleID;
        }
    }
}
