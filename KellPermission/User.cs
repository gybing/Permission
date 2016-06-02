using System;
using System.Collections.Generic;
using System.Text;

namespace KellPermission
{
    /// <summary>
    /// 用户类
    /// </summary>
    [Serializable]
    public class User : IArchitecture
    {
        Guid id;

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid ID
        {
            get { return id; }
        }
        List<Department> departments;

        /// <summary>
        /// 所在部门ID
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
        /// 所在项目组ID
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
        /// 所在用户组
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
        /// 用户拥有的角色集合
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
        /// 获取当前用户拥有的所有权限
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
        string userName = "未知用户";

        /// <summary>
        /// 用户名
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
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        DateTime lastLogTime;

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLogTime
        {
            get { return lastLogTime; }
            set { lastLogTime = value; }
        }
        bool online;

        /// <summary>
        /// 当前是否在线
        /// </summary>
        public bool Online
        {
            get { return online; }
            set { online = value; }
        }
        string description;

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 重载基类的ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.UserName;
        }

        /// <summary>
        /// 当前用户是否属于指定的部门
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
        /// 用户的默认构造函数
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
        /// 由用户名和密码构造用户对象
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
        /// 由用户名、密码和所在部门ID构造用户对象
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
        /// 由用户名、密码、所在部门ID和所在项目组ID构造用户对象
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
