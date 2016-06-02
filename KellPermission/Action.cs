using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ������
    /// </summary>
    [Serializable]
    public class Action : IArchitecture
    {
        Guid id;

        /// <summary>
        /// ����ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }

        KeyValuePair<string, string> actionContent;

        /// <summary>
        /// ����������
        /// </summary>
        public KeyValuePair<string, string> ActionContent
        {
            get { return actionContent; }
            set { actionContent = value; }
        }
        string name = "δ��������";

        /// <summary>
        /// ����������
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
        /// ����������
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public Action()
        {
            id = Guid.NewGuid();
            actionContent = new KeyValuePair<string, string>();
        }

        /// <summary>
        /// ��ָ�������ƹ����������
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
        /// ��ָ���Ĳ�������Ͳ���ֵ�����������
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Action(string code, string value)
        {
            id = Guid.NewGuid();
            this.actionContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// ��ָ�������ơ���������Ͳ���ֵ�����������
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
        /// �������������ֵ������ַ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
