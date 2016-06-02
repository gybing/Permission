using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 业务模块类
    /// </summary>
    [Serializable]
    public class Module : IArchitecture
    {
        Guid id;

        /// <summary>
        /// ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }

        KeyValuePair<string, string> moduleContent;

        /// <summary>
        /// 业务模块的内容
        /// </summary>
        public KeyValuePair<string, string> ModuleContent
        {
            get { return moduleContent; }
            set { moduleContent = value; }
        }
        string name = "未命名业务模块";

        /// <summary>
        /// 业务模块的名称
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
        /// 业务模块的描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Module()
        {
            id = Guid.NewGuid();
            moduleContent = new KeyValuePair<string, string>();
        }

        /// <summary>
        /// 由指定的名称构造业务模块对象
        /// </summary>
        public Module(string name)
        {
            id = Guid.NewGuid();
            moduleContent = new KeyValuePair<string, string>();
            if (name != null && name.Trim() != "")
                this.name = name;
        }

        /// <summary>
        /// 由指定的业务模块代码和业务模块值构造业务模块对象
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Module(string code, string value)
        {
            id = Guid.NewGuid();
            this.moduleContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// 由指定的名称、业务模块代码和业务模块值构造业务模块对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Module(string name, string code, string value)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.moduleContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// 模块名称与模块值的组合字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
