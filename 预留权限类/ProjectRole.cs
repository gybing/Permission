using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 项目组对应的角色
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
        /// 项目组ID
        /// </summary>
        public Guid ProjectID
        {
            get { return projectID; }
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
