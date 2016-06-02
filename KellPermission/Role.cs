using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��ɫ��
    /// </summary>
    [Serializable]
    public class Role : IArchitecture
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Role()
        {
            id = Guid.NewGuid();
        }

        /// <summary>
        /// ���캯��
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
        /// ���캯��
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
        /// ��ɫID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        string name = "δ������ɫ";

        /// <summary>
        /// ��ɫ����
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
        /// ��ɫӵ�е�Ȩ�޼���
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
        /// ��ɫ����
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
