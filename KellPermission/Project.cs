using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��Ŀ����
    /// </summary>
    [Serializable]
    public class Project : IArchitecture
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Project()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        public Project(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            roles = new RoleCollection();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        public Project(string name, RoleCollection roles)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            if (roles == null)
                this.roles = new RoleCollection();
            else
                this.roles = roles;
        }

        Guid id;

        /// <summary>
        /// ��Ŀ��ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// ��Ŀ��ӵ�еĽ�ɫ����
        /// </summary>
        public RoleCollection Roles
        {
            get { return roles; }
            set
            {
                if (value != null)
                    roles = value;
            }
        }
        string name = "δ������Ŀ��";

        /// <summary>
        /// ��Ŀ������
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value.Trim() != "")
                    name = value;
            }
        }
        string description;

        /// <summary>
        /// ��Ŀ������
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// ���ػ����ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
