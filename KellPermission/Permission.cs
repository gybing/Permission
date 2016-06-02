using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 权限类
    /// </summary>
    [Serializable]
    public class Permission : IArchitecture
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Permission()
        {
            id = Guid.NewGuid();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Permission(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
        }

        /// <summary>
        /// 由业务模块和操作构造权限对象
        /// </summary>
        /// <param name="module"></param>
        /// <param name="action"></param>
        public Permission(Module module, Action action)
        {
            id = Guid.NewGuid();
            this.module = module;
            this.action = action;
        }

        /// <summary>
        /// 由业务模块和操作构造权限对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        /// <param name="action"></param>
        public Permission(string name, Module module, Action action)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.module = module;
            this.action = action;
        }

        Guid id;

        /// <summary>
        /// 权限ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        string name = "未命名权限";

        /// <summary>
        /// 权限的名称
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
        /// 权限描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        
        Module module;

        /// <summary>
        /// 权限的业务模块
        /// </summary>
        public Module TheModule
        {
            get { return module; }
            set { module = value; }
        }
        Action action;

        /// <summary>
        /// 权限的操作
        /// </summary>
        public Action TheAction
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// 权限代码
        /// </summary>
        public string PermissionCode
        {
            get
            {
                if (module != null && action != null)
                {
                    return module.ModuleContent.Key + action.ActionContent.Key;
                }
                else
                {
                    if (module == null)
                    {
                        throw new Exception("Module is Null!");
                    }
                    else
                    {
                        throw new Exception("Action is Null!");
                    }
                }
            }
        }

        /// <summary>
        /// 权限的值
        /// </summary>
        public string PermissionValue
        {
            get
            {
                if (module != null && action != null)
                {
                    return module.ModuleContent.Value + action.ActionContent.Value;
                }
                else
                {
                    if (module == null)
                    {
                        throw new Exception("Module is Null!");
                    }
                    else
                    {
                        throw new Exception("Action is Null!");
                    }
                }
            }
        }

        /// <summary>
        /// 权限名称与权限值的组合字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
