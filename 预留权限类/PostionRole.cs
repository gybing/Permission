using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ְλ��Ӧ�Ľ�ɫ
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
        /// ְλID
        /// </summary>
        public Guid PositionID
        {
            get { return positionID; }
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
