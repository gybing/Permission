using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// �û���
    /// </summary>
    [Serializable]
    public class User : IArchitecture
    {
        Guid id;

        /// <summary>
        /// �û�ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        List<Department> departments;

        /// <summary>
        /// ���ڲ���ID
        /// </summary>
        public List<Department> Departments
        {
            get { return departments; }
            set
            {
                if (value != null)
                    departments = value;
            }
        }
        List<Project> projects;

        /// <summary>
        /// ������Ŀ��ID
        /// </summary>
        public List<Project> Projects
        {
            get { return projects; }
            set
            {
                if (value != null)
                    projects = value;
            }
        }
        List<UserGroup> userGroups;

        /// <summary>
        /// �����û���
        /// </summary>
        public List<UserGroup> UserGroups
        {
            get { return userGroups; }
            set
            {
                if (value != null)
                    userGroups = value;
            }
        }

        RoleCollection roles;

        /// <summary>
        /// �û�ӵ�еĽ�ɫ����
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

        /// <summary>
        /// ��ȡ��ǰ�û�ӵ�е�����Ȩ��
        /// </summary>
        public PermissionCollection GetAllPermissions()
        {
            PermissionCollection ps = new PermissionCollection();
            foreach (Role r in roles)
            {
                foreach (Permission p in r.Permissions)
                {
                    ps.Add(p);
                }
            }
            foreach (Department d in departments)
            {
                foreach (Role r in d.Roles)
                {
                    foreach (Permission p in r.Permissions)
                    {
                        ps.Add(p);
                    }
                }
            }
            foreach (Project pr in projects)
            {
                foreach (Role r in pr.Roles)
                {
                    foreach (Permission p in r.Permissions)
                    {
                        ps.Add(p);
                    }
                }
            }
            foreach (UserGroup ug in userGroups)
            {
                foreach (Role r in ug.Roles)
                {
                    foreach (Permission p in r.Permissions)
                    {
                        ps.Add(p);
                    }
                }
            }
            return ps;
        }
        string userName = "δ֪�û�";

        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value != null && value.Trim() != "")
                    userName = value;
            }
        }
        string password;

        /// <summary>
        /// ����
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        DateTime lastLogTime;

        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime LastLogTime
        {
            get { return lastLogTime; }
            set { lastLogTime = value; }
        }
        bool online;

        /// <summary>
        /// ��ǰ�Ƿ�����
        /// </summary>
        public bool Online
        {
            get { return online; }
            set { online = value; }
        }
        string description;

        /// <summary>
        /// �û�����
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
            return this.UserName;
        }

        /// <summary>
        /// ��ǰ�û��Ƿ�����ָ���Ĳ���
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool BelongToDepart(Department depart)
        {
            foreach (Department dep in this.Departments)
            {
                if (dep.ID == depart.ID)
                {
                    return true;
                }
                else
                {
                    return depart.IsMyChildren(dep);
                }
            }
            return false;
        }

        /// <summary>
        /// �û���Ĭ�Ϲ��캯��
        /// </summary>
        public User()
        {
            id = Guid.NewGuid();
            this.departments = new List<Department>();
            this.projects = new List<Project>();
            roles = new RoleCollection();
            userGroups = new List<UserGroup>();
        }

        /// <summary>
        /// ���û��������빹���û�����
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public User(string userName, string password)
        {
            id = Guid.NewGuid();
            this.departments = new List<Department>();
            this.projects = new List<Project>();
            roles = new RoleCollection();
            userGroups = new List<UserGroup>();
            if (userName != null && userName.Trim() != "")
                this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// ���û�������������ڲ���ID�����û�����
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="depart"></param>
        public User(string userName, string password, Department depart)
        {
            id = Guid.NewGuid();
            this.departments = new List<Department>();
            this.projects = new List<Project>();
            roles = new RoleCollection();
            userGroups = new List<UserGroup>();
            if (userName != null && userName.Trim() != "")
                this.userName = userName;
            this.password = password;
            this.departments.Add(depart);
        }

        /// <summary>
        /// ���û��������롢���ڲ���ID��������Ŀ��ID�����û�����
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="depart"></param>
        /// <param name="proj"></param>
        public User(string userName, string password, Department depart, Project proj)
        {
            id = Guid.NewGuid();
            this.departments = new List<Department>();
            this.projects = new List<Project>();
            roles = new RoleCollection();
            userGroups = new List<UserGroup>();
            if (userName != null && userName.Trim() != "")
                this.userName = userName;
            this.password = password;
            this.departments.Add(depart);
            this.projects.Add(proj);
        }
    }
}
