using System;
using System.Collections;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 表示由Role对象组成的集合
    /// </summary>
    [Serializable]
    public class RoleCollection : ICollection, IArchitecture
    {
        private ArrayList list = new ArrayList();
        /// <summary>
        /// 构造函数
        /// </summary>
        public RoleCollection()
        {
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Role this[int index]
        {
            get
            {
                return (Role)this.list[index];
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
        public int Add(Role item)
        {
            return this.list.Add(item);
        }

        /// <summary>
        /// 从集合中移出指定元素
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Role item)
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
