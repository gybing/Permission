using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 职位对应的角色
    /// </summary>
    public class PostionRole
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        Guid positionID;

        /// <summary>
        /// 职位ID
        /// </summary>
        public Guid PositionID
        {
            get { return positionID; }
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
        /// <param name="positionID"></param>
        /// <param name="roleID"></param>
        public PostionRole(Guid positionID, Guid roleID)
        {
            id = Guid.NewGuid();
            this.positionID = positionID;
            this.roleID = roleID;
        }
    }
}
