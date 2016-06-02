using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    public class Department : IArchitecture
    {
        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public Department()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// �����ƴ������Ŷ���
        /// </summary>
        /// <param name="name"></param>
        public Department(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            roles = new RoleCollection();
        }

        /// <summary>
        /// �����ƺͽ�ɫ���ϴ������Ŷ���
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        public Department(string name, RoleCollection roles)
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
        /// �����ƺ��ϼ����Ŵ����²��Ŷ���
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parent"></param>
        public Department(string name, Department parent)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.parent = parent;
            roles = new RoleCollection();
        }

        /// <summary>
        /// �����ơ���ɫ���Ϻ��ϼ����Ŵ����²��Ŷ���
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <param name="parent"></param>
        public Department(string name, RoleCollection roles, Department parent)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            if (roles == null)
                this.roles = new RoleCollection();
            else
                this.roles = roles;
            this.parent = parent;
        }

        /// <summary>
        /// ��ָ�������ƴ����Ӳ���
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Department CreateSubDepartment(string name)
        {
            return new Department(name, this);
        }

        /// <summary>
        /// ��ָ�������ƴ����Ӳ���
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public Department CreateSubDepartment(string name, RoleCollection roles)
        {
            return new Department(name, roles, this);
        }

        /// <summary>
        /// ָ�������Ƿ�Ϊ�ҵĺ��
        /// </summary>
        /// <param name="dep">ָ������</param>
        /// <param name="recursion">�Ƿ�ݹ��жϺ����Ĭ��Ϊtrue��ֻ����һ��Ϊfalse</param>
        /// <returns></returns>
        public bool IsMyChildren(Department dep, bool recursion = true)
        {
            if (dep.Parent != null)
            {
                if (dep.Parent.ID == this.ID)//dep=1.2,this=1
                    return true;//dep.parent=1

                if (recursion)//dep=1.2.3
                {
                    return this.IsMyChildren(dep.Parent, true);//dep=1.2.3,this=1.2
                }
            }
            return false;
        }

        Guid id;

        /// <summary>
        /// ����ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        RoleCollection roles;

        /// <summary>
        /// ����ӵ�еĽ�ɫ����
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
        string name = "δ��������";

        /// <summary>
        /// ��������
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

        Department parent;

        /// <summary>
        /// �ϼ�����
        /// </summary>
        public Department Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        string description;

        /// <summary>
        /// ��������
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
