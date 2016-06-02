using System;
using System.Collections;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 表示由User对象组成的集合
    /// </summary>
    [Serializable]
    public class UserGroup : ICollection, IArchitecture
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserGroup()
        {
            id = Guid.NewGuid();
            roles = new RoleCollection();
        }

        /// <summary>
        /// 构造函数
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
        /// 构造函数
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
        /// 重载基类的ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }

        Guid id;

        /// <summary>
        /// 用户组ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        RoleCollection roles;

        /// <summary>
        /// 用户组拥有的角色集合
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

        string name = "未命名用户组";

        /// <summary>
        /// 用户组的名称
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
        /// 用户组描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private ArrayList list = new ArrayList();

        /// <summary>
        /// 索引器
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
        /// 向集合中添加元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(User item)
        {
            return this.list.Add(item);
        }

        /// <summary>
        /// 从集合中移出指定元素
        /// </summary>
        /// <param name="item"></param>
        public void Remove(User item)
        {
            this.list.Remove(item);
        }

        /// <summary>
        /// 从集合中移出指定索引的元素
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            this.list.RemoveAt(index);
        }

        /// <summary>
        /// 取得集合元素个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        #region ICollection 成员

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

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        #endregion
    }
}
