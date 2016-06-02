using System;
using System.Collections;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��ʾ��User������ɵļ���
    /// </summary>
    [Serializable]
    public class UserGroup : ICollection, IArchitecture
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public UserGroup()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        public UserGroup(string name)
        {
            id = Guid.NewGuid();
            if (name != null && name.Trim() != "")
                this.name = name;
            roles = new RoleCollection();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roles"></param>
        public UserGroup(string name, RoleCollection roles)
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
        /// ���ػ����ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }

        Guid id;

        /// <summary>
        /// �û���ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// �û���ӵ�еĽ�ɫ����
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

        string name = "δ�����û���";

        /// <summary>
        /// �û��������
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
        /// �û�������
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private ArrayList list = new ArrayList();

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public User this[int index]
        {
            get
            {
                return (User)this.list[index];
            }
            set
            {
                this.list[index] = value;
            }
        }

        /// <summary>
        /// �򼯺������Ԫ��
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(User item)
        {
            return this.list.Add(item);
        }

        /// <summary>
        /// �Ӽ������Ƴ�ָ��Ԫ��
        /// </summary>
        /// <param name="item"></param>
        public void Remove(User item)
        {
            this.list.Remove(item);
        }

        /// <summary>
        /// �Ӽ������Ƴ�ָ��������Ԫ��
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        /// <summary>
        /// ȡ�ü���Ԫ�ظ���
        /// </summary>
        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        #region ICollection ��Ա

        void ICollection.CopyTo(Array array, int index)
        {
            this.list.CopyTo(array, index);
        }

        int ICollection.Count
        {
            get { return this.list.Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return this.list.IsSynchronized; }
        }

        object ICollection.SyncRoot
        {
            get { return this.list.SyncRoot; }
        }

        #endregion

        #region IEnumerable ��Ա

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion
    }
}
