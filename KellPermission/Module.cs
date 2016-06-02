using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ҵ��ģ����
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
        /// ҵ��ģ�������
        /// </summary>
        public KeyValuePair<string, string> ModuleContent
        {
            get { return moduleContent; }
            set { moduleContent = value; }
        }
        string name = "δ����ҵ��ģ��";

        /// <summary>
        /// ҵ��ģ�������
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
        /// ҵ��ģ�������
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public Module()
        {
            id = Guid.NewGuid();
            moduleContent = new KeyValuePair<string, string>();
        }

        /// <summary>
        /// ��ָ�������ƹ���ҵ��ģ�����
        /// </summary>
        public Module(string name)
        {
            id = Guid.NewGuid();
            moduleContent = new KeyValuePair<string, string>();
            if (name != null && name.Trim() != "")
                this.name = name;
        }

        /// <summary>
        /// ��ָ����ҵ��ģ������ҵ��ģ��ֵ����ҵ��ģ�����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public Module(string code, string value)
        {
            id = Guid.NewGuid();
            this.moduleContent = new KeyValuePair<string, string>(code, value);
        }

        /// <summary>
        /// ��ָ�������ơ�ҵ��ģ������ҵ��ģ��ֵ����ҵ��ģ�����
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
        /// ģ��������ģ��ֵ������ַ���
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
