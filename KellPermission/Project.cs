using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 项目组类
    /// </summary>
    [Serializable]
    public class Project : IArchitecture
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Project()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// 构造函数
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
        /// 构造函数
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
        /// 项目组ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// 项目组拥有的角色集合
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
        string name = "未命名项目组";

        /// <summary>
        /// 项目组名称
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
        /// 项目组描述
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
