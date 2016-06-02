using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 职位类
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Position()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }
        /// <summary>
        /// 以指定的名称创建新职位
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
        /// 以指定的名称和角色集合创建新职位
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
        /// 以指定的名称和上级职位创建新职位
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
        /// 以指定的名称、角色集合和上级职位创建新职位
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
        /// 以指定的名称创建子职位
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Position CreateSubPosition(string name)
        {
            return new Position(name, this);
        }

        /// <summary>
        /// 以指定的名称和角色集合创建子职位
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
        /// 职位ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// 职位拥有的角色集合
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
        string name = "未命名职位";

        /// <summary>
        /// 职位名称
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
        /// 上级职位
        /// </summary>
        public Position Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        string description;

        /// <summary>
        /// 职位描述
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
