using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��Ŀ���Ӧ�Ľ�ɫ
    /// </summary>
    public class ProjectRole
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        Guid projectID;

        /// <summary>
        /// ��Ŀ��ID
        /// </summary>
        public Guid ProjectID
        {
            get { return projectID; }
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
        /// <param name="projectID"></param>
        /// <param name="roleID"></param>
        public ProjectRole(Guid projectID, Guid roleID)
        {
            id = Guid.NewGuid();
            this.projectID = projectID;
            this.roleID = roleID;
        }
    }
}
