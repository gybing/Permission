using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ְλ��
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public Position()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }
        /// <summary>
        /// ��ָ�������ƴ�����ְλ
        /// </summary>
        /// <param name="name"></param>
        public Position(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            roles = new RoleCollection();
        }

        /// <summary>
        /// ��ָ�������ƺͽ�ɫ���ϴ�����ְλ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        public Position(string name, RoleCollection roles)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            if (roles == null)
                this.roles = new RoleCollection();
            else
                this.roles = roles;
        }

        /// <summary>
        /// ��ָ�������ƺ��ϼ�ְλ������ְλ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        public Position(string name, Position parent)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.parent = parent;
            roles = new RoleCollection();
        }

        /// <summary>
        /// ��ָ�������ơ���ɫ���Ϻ��ϼ�ְλ������ְλ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <param name="parent"></param>
        public Position(string name, RoleCollection roles, Position parent)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.parent = parent;
            if (roles == null)
                this.roles = new RoleCollection();
            else
                this.roles = roles;
        }

        /// <summary>
        /// ��ָ�������ƴ�����ְλ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Position CreateSubPosition(string name)
        {
            return new Position(name, this);
        }

        /// <summary>
        /// ��ָ�������ƺͽ�ɫ���ϴ�����ְλ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public Position CreateSubPosition(string name, RoleCollection roles)
        {
            return new Position(name, roles, this);
        }

        Guid id;

        /// <summary>
        /// ְλID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// ְλӵ�еĽ�ɫ����
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
        string name = "δ����ְλ";

        /// <summary>
        /// ְλ����
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

        Position parent;

        /// <summary>
        /// �ϼ�ְλ
        /// </summary>
        public Position Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        string description;

        /// <summary>
        /// ְλ����
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
