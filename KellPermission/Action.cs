using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 操作类
    /// </summary>
    [Serializable]
    public class Action : IArchitecture
    {
        Guid id;

        /// <summary>
        /// 操作ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }

        KeyValuePair<string, string> actionContent;

        /// <summary>
        /// 操作的内容
        /// </summary>
        public KeyValuePair<string, string> ActionContent
        {
            get { return actionContent; }
            set { actionContent = value; }
        }
        string name = "未命名操作";

        /// <summary>
        /// 操作的名称
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
        /// 操作的描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Action()
        {
            id = Guid.NewGuid();
            actionContent = new KeyValuePair<string, string>();
        }

        /// <summary>
        /// 由指定的名称构造操作对象
        /// </summary>
        /// <param name="name"></param>
        public Action(string name)
        {
            id = Guid.NewGuid();
            actionContent = new KeyValuePair<string, string>();
            if (name != null && name.Trim() != "")
                this.name = name;
        }

        /// <summary>
        /// 由指定的操作代码和操作值构造操作对象
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Action(string code, string value)
        {
            id = Guid.NewGuid();
            this.actionContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// 由指定的名称、操作代码和操作值构造操作对象
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Action(string name, string code, string value)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            this.actionContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// 操作名称与操作值的组合字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
