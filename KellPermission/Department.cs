using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 部门类
    /// </summary>
    [Serializable]
    public class Department : IArchitecture
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Department()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// 以名称创建部门对象
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
        /// 以名称和角色集合创建部门对象
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
        /// 以名称和上级部门创建新部门对象
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
        /// 以名称、角色集合和上级部门创建新部门对象
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
        /// 以指定的名称创建子部门
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Department CreateSubDepartment(string name)
        {
            return new Department(name, this);
        }

        /// <summary>
        /// 以指定的名称创建子部门
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public Department CreateSubDepartment(string name, RoleCollection roles)
        {
            return new Department(name, roles, this);
        }

        /// <summary>
        /// 指定部门是否为我的后代
        /// </summary>
        /// <param name="dep">指定部门</param>
        /// <param name="recursion">是否递归判断后代，默认为true，只找下一代为false</param>
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
        /// 部门ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        RoleCollection roles;

        /// <summary>
        /// 部门拥有的角色集合
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
        string name = "未命名部门";

        /// <summary>
        /// 部门名称
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
        /// 上级部门
        /// </summary>
        public Department Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        string description;

        /// <summary>
        /// 部门描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 重载基类的ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
