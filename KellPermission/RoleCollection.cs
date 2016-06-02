using System;
using System.Collections;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// ��ʾ��Role������ɵļ���
    /// </summary>
    [Serializable]
    public class RoleCollection : ICollection, IArchitecture
    {
        private ArrayList list = new ArrayList();
        /// <summary>
        /// ���캯��
        /// </summary>
        public RoleCollection()
        {
        }

        /// <summary>
        /// ������
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
        /// �򼯺������Ԫ��
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Add(Role item)
        {
            return this.list.Add(item);
        }

        /// <summary>
        /// �Ӽ������Ƴ�ָ��Ԫ��
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Role item)
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
