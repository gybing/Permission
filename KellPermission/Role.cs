using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 角色类
    /// </summary>
    [Serializable]
    public class Role : IArchitecture
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Role()
        {
            id = Guid.NewGuid();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public Role(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.permissions = new PermissionCollection();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="permissions"></param>
        public Role(string name, PermissionCollection permissions)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            if (permissions == null)
                this.permissions = new PermissionCollection();
            else
                this.permissions = permissions;
        }

        Guid id;

        /// <summary>
        /// 角色ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        string name = "未命名角色";

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set {
                if (value != null && value.Trim() != "")
                    name = value;
            }
        }

        PermissionCollection permissions;

        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public PermissionCollection Permissions
        {
            get { return permissions; }
            set
            {
                if (value != null)
                    permissions = value;
            }
        }

        string description;

        /// <summary>
        /// 角色描述
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
