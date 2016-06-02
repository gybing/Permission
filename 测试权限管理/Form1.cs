using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KellPermission;

namespace 测试权限管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Serializable]
        struct TestInfo
        {
            public List<KellPermission.Permission> Pers;
            public List<KellPermission.Role> Roles;
            public List<KellPermission.User> Users;
            public List<KellPermission.Department> Deps;
            public List<KellPermission.Project> Prjs;
            public List<KellPermission.Module> Mods;
            public List<KellPermission.Action> Acts;
        }
        
        List<KellPermission.Permission> perms = new List<KellPermission.Permission>();
        List<KellPermission.Role> roles = new List<KellPermission.Role>();
        List<KellPermission.User> users = new List<KellPermission.User>();
        List<KellPermission.Department> deps = new List<KellPermission.Department>();
        List<KellPermission.Project> prjs = new List<KellPermission.Project>();
        List<KellPermission.Module> mods = new List<KellPermission.Module>();
        List<KellPermission.Action> acts = new List<KellPermission.Action>();
        int selectPerm=-1;
        int selectRole=-1;
        int selectUser=-1;
        int selectDept=-1;
        int selectProj=-1;
        int selectModu=-1;
        int selectActn=-1;

        private void RefreshAll()
        {
            RefreshUsers();
            RefreshDeps();
            RefreshPrjs();
            RefreshPrms();
            RefreshRoles();
            RefreshMods();
            RefreshActs();
        }

        private void RefreshActs(int index = -1)
        {
            comboBox10.Items.Clear();
            foreach (KellPermission.Action a in acts)
            {
                comboBox10.Items.Add(a.Name);
            }
            comboBox10.Tag = acts;
            if (index > -1)
            {
                comboBox10.SelectedIndex = index;
            }
        }

        private void RefreshMods(int index = -1)
        {
            comboBox9.Items.Clear();
            foreach (KellPermission.Module m in mods)
            {
                comboBox9.Items.Add(m.Name);
            }
            comboBox9.Tag = mods;
            if (index > -1)
            {
                comboBox9.SelectedIndex = index;
            }
        }

        private void RefreshUsers(int index = -1)
        {
            comboBox8.Items.Clear();
            comboBox4.Items.Clear();
            comboBox13.Items.Clear();
            listBoxSelecter1.AllItems = null;
            List<object> tmp = new List<object>();
            foreach (KellPermission.User u in users)
            {
                comboBox8.Items.Add(u.UserName);
                comboBox4.Items.Add(u.UserName);
                comboBox13.Items.Add(u.UserName);
                tmp.Add(u);
            }
            listBoxSelecter1.AllItems = tmp;
            comboBox4.Tag = users;
            comboBox8.Tag = users;
            comboBox13.Tag = users;
            if (index > -1)
            {
                comboBox8.SelectedIndex = index;
            }
        }

        private void RefreshDeps(int index = -1)
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox6.Items.Clear();
            comboBox11.Items.Clear();
            comboBox11.Items.Add("");
            foreach (KellPermission.Department d in deps)
            {
                comboBox1.Items.Add(d.Name);
                comboBox3.Items.Add(d.Name);
                comboBox6.Items.Add(d.Name);
                comboBox11.Items.Add(d.Name);
            }
            comboBox1.Tag = deps;
            comboBox3.Tag = deps;
            comboBox6.Tag = deps;
            comboBox11.Tag = deps;
            if (index > -1)
            {
                comboBox3.SelectedIndex = index;
            }
        }

        private void RefreshPrjs(int index = -1)
        {
            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox12.Items.Clear();
            comboBox2.Items.Add("");
            foreach (KellPermission.Project p in prjs)
            {
                comboBox2.Items.Add(p.Name);
                comboBox5.Items.Add(p.Name);
                comboBox12.Items.Add(p.Name);
            }
            comboBox2.Tag = prjs;
            comboBox5.Tag = prjs;
            comboBox12.Tag = prjs;
            if (index > -1)
            {
                comboBox12.SelectedIndex = index;
            }
        }

        private void RefreshRoles()
        {
            comboBox7.Items.Clear();
            foreach (KellPermission.Role r in roles)
               comboBox7.Items.Add(r.Name);
            comboBox7.Tag = roles;
            if (!checkBox1.Checked)
            {
                listBoxSelecter3.AllItems = null;
                List<object> tmp = new List<object>();
                foreach (KellPermission.Role role in roles)
                {
                    tmp.Add(role);
                }
                listBoxSelecter3.AllItems = tmp;
            }
        }

        private void RefreshPrms()
        {
            listBoxSelecter2.AllItems = null;
            List<object> tmp = new List<object>();
            foreach (KellPermission.Permission per in perms)
            {
                tmp.Add(per);
            }
            listBoxSelecter2.AllItems = tmp;
        }

        private void RefreshPrmsInRoleContainer()
        {
            listBoxSelecter3.AllItems = null;
            List<object> tmp = new List<object>();
            foreach (KellPermission.Permission per in perms)
            {
                tmp.Add(per);
            }
            listBoxSelecter3.AllItems = tmp;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = button10.Enabled = checkBox1.Checked;
            button4.Enabled = button5.Enabled = comboBox5.Enabled = comboBox6.Enabled = button14.Enabled = comboBox13.Enabled = !checkBox1.Checked;
            if (checkBox1.Checked)
            {
                RefreshPrmsInRoleContainer();
            }
            else
            {
                listBoxSelecter3.AllItems = null;
                List<object> tmp = new List<object>();
                foreach (KellPermission.Role role in roles)
                {
                    tmp.Add(role);
                }
                listBoxSelecter3.AllItems = tmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter1.SelectedItems)
            {
                KellPermission.User user = (KellPermission.User)obj;
                if (!user.Departments.Contains(deps[comboBox3.SelectedIndex]))
                    user.Departments.Add(deps[comboBox3.SelectedIndex]);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KellPermission.Project prj = new KellPermission.Project(textBox6.Text.Trim());
            prjs.Add(prj);
            RefreshPrjs(prjs.Count - 1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            KellPermission.Department parent = null;
            try
            {
                parent = deps[comboBox11.SelectedIndex - 1];
            }
            catch
            { }
            KellPermission.Department dep = null;
            if (parent != null)
                dep = new KellPermission.Department(textBox7.Text.Trim(), parent);
            else
                dep = new KellPermission.Department(textBox7.Text.Trim());
            deps.Add(dep);
            RefreshDeps(deps.Count - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            //List<KellPermission.Department> deps = (List<KellPermission.Department>)comboBox1.Tag;
            //List<KellPermission.Project> prjs = (List<KellPermission.Project>)comboBox2.Tag;
            if (deps != null)
            {
                Department dep = deps[comboBox1.SelectedIndex];
                string description = textBox3.Text;
                KellPermission.User user = null;
                Project prj = null;
                try
                {
                    if (prjs != null)
                        prj = prjs[comboBox2.SelectedIndex - 1];
                }
                catch
                { }
                if (prj != null)
                {
                    user = new KellPermission.User(userName, password, dep, prj);
                }
                else
                {
                    user = new KellPermission.User(userName, password, dep);
                }
                user.Description = description;
                users.Add(user);
                RefreshUsers(users.Count - 1);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //int i = comboBox8.SelectedIndex;
            //string userName = textBox1.Text.Trim();
            //string password = textBox2.Text.Trim();
            //List<KellPermission.Department> deps = (List<KellPermission.Department>)comboBox1.Tag;
            //List<KellPermission.Project> prjs = (List<KellPermission.Project>)comboBox2.Tag;
            //if (deps != null)
            //{
            //    Department dep = deps[comboBox1.SelectedIndex];
            //    string description = textBox3.Text;
            //    Project prj = null;
            //    try
            //    {
            //        if (prjs != null)
            //            prj = prjs[comboBox2.SelectedIndex - 1];
            //    }
            //    catch
            //    {
            //        users[i].Projects.Clear();
            //    }
            //    if (prj != null)
            //    {
            //        if (!users[i].Projects.Contains(prj))
            //            users[i].Projects.Add(prj);
            //    }
            //    users[i].UserName = userName;
            //    users[i].Password = password;
            //    if (!users[i].Departments.Contains(dep))
            //        users[i].Departments.Add(dep);
            //    users[i].Description = description;
            //    RefreshUsers();
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            users.RemoveAt(comboBox8.SelectedIndex);
            RefreshUsers();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text.Trim();
            string mod = comboBox9.Text;
            string act = comboBox10.Text;
            KellPermission.Module module = new KellPermission.Module(mod);
            KellPermission.Action action = new KellPermission.Action(act);
            KellPermission.Permission per = new KellPermission.Permission(name, module, action);
            perms.Add(per);
            RefreshPrms();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("");
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;
            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;
            if (comboBox5.Items.Count > 0)
                comboBox5.SelectedIndex = 0;
            if (comboBox6.Items.Count > 0)
                comboBox6.SelectedIndex = 0;
            if (comboBox7.Items.Count > 0)
                comboBox7.SelectedIndex = 0;
            if (comboBox8.Items.Count > 0)
                comboBox8.SelectedIndex = 0;
            if (comboBox9.Items.Count > 0)
                comboBox9.SelectedIndex = 0;
            if (comboBox10.Items.Count > 0)
                comboBox10.SelectedIndex = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text.Trim();
            KellPermission.Role role = new KellPermission.Role(name);
            roles.Add(role);
            RefreshRoles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //foreach (object obj in listBoxSelecter2.SelectedItems)
            //{
            //    KellPermission.Permission per = (KellPermission.Permission)obj;
            //    bool have = false;
            //    foreach (KellPermission.Permission p in users[comboBox4.SelectedIndex].Permissions)
            //    {
            //        if (p.ID == per.ID)
            //        {
            //            have = true;
            //            break;
            //        }
            //    }
            //    if (!have)
            //        users[comboBox4.SelectedIndex].Permissions.Add(per);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter2.SelectedItems)
            {
                KellPermission.Permission per = (KellPermission.Permission)obj;
                bool have = false;
                foreach (KellPermission.Permission p in roles[comboBox7.SelectedIndex].Permissions)
                {
                    if (p.ID == per.ID)
                    {
                        have = true;
                        break;
                    }
                }
                if (!have)
                    roles[comboBox7.SelectedIndex].Permissions.Add(per);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter3.SelectedItems)
            {
                KellPermission.Role role = (KellPermission.Role)obj;
                bool have = false;
                foreach (KellPermission.Role r in prjs[comboBox5.SelectedIndex].Roles)
                {
                    if (r.ID == role.ID)
                    {
                        have = true;
                        break;
                    }
                }
                if (!have)
                    prjs[comboBox5.SelectedIndex].Roles.Add(role);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter3.SelectedItems)
            {
                KellPermission.Role role = (KellPermission.Role)obj;
                bool have = false;
                foreach (KellPermission.Role r in deps[comboBox6.SelectedIndex].Roles)
                {
                    if (r.ID == role.ID)
                    {
                        have = true;
                        break;
                    }
                }
                if (!have)
                    deps[comboBox6.SelectedIndex].Roles.Add(role);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter3.SelectedItems)
            {
                KellPermission.Role role = (KellPermission.Role)obj;
                bool have = false;
                foreach (KellPermission.Role r in users[comboBox13.SelectedIndex].Roles)
                {
                    if (r.ID == role.ID)
                    {
                        have = true;
                        break;
                    }
                }
                if (!have)
                    users[comboBox13.SelectedIndex].Roles.Add(role);
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            KellPermission.User user = users[comboBox8.SelectedIndex];
            textBox1.Text = user.UserName;
            textBox2.Text = user.Password;
            textBox3.Text = user.Description;
            foreach (KellPermission.Department d in deps)
            {
                if (user.Departments.Contains(d))
                {
                    comboBox1.SelectedItem = d.Name;
                    break;
                }
            }
            bool have = false;
            foreach (KellPermission.Project p in prjs)
            {
                if (user.Projects.Contains(p))
                {
                    comboBox2.SelectedItem = p.Name;
                    have = true;
                    break;
                }
            }
            if (!have)
                comboBox2.SelectedIndex = 0;
            label14.Text = string.Format("用户[{0}]具有的权限：", user.UserName);
            listBox1.Items.Clear();
            PermissionCollection ps = user.GetAllPermissions();
            foreach (Permission p in ps)
            {
                listBox1.Items.Add(p);
            }
            selectUser = comboBox8.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.User u in users)
            {
                if (u.Departments.Contains(deps[comboBox3.SelectedIndex]))
                {
                    some.Add(u);
                }
                else
                {
                    if (u.BelongToDepart(deps[comboBox3.SelectedIndex]))
                        some.Add(u);
                }
            }
            listBoxSelecter1.SelectSome(some);
            textBox7.Text = deps[comboBox3.SelectedIndex].Name;
            selectDept = comboBox3.SelectedIndex;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.User u in users)
            {
                if (u.Projects.Contains(prjs[comboBox12.SelectedIndex]))
                    some.Add(u);
            }
            listBoxSelecter4.SelectSome(some);
            textBox6.Text = prjs[comboBox12.SelectedIndex].Name;
            selectProj = comboBox12.SelectedIndex;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<object> some = new List<object>();
            //foreach (KellPermission.Permission p in users[comboBox4.SelectedIndex].Permissions)
            //{
            //    if (perms.Contains(p))
            //        some.Add(p);
            //}
            //listBoxSelecter2.SelectSome(some);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.Permission p in roles[comboBox7.SelectedIndex].Permissions)
            {
                if (perms.Contains(p))
                    some.Add(p);
            }
            listBoxSelecter2.SelectSome(some);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.Role p in prjs[comboBox5.SelectedIndex].Roles)
            {
                if (roles.Contains(p))
                    some.Add(p);
            }
            listBoxSelecter3.SelectSome(some);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.Role p in deps[comboBox6.SelectedIndex].Roles)
            {
                if (roles.Contains(p))
                    some.Add(p);
            }
            listBoxSelecter3.SelectSome(some);
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<object> some = new List<object>();
            foreach (KellPermission.Role p in users[comboBox13.SelectedIndex].Roles)
            {
                if (roles.Contains(p))
                    some.Add(p);
            }
            listBoxSelecter3.SelectSome(some);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "权限管理测试信息|*.testInfo";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    TestInfo ti = (TestInfo)bf.Deserialize(fs);
                    if (ti.Users != null)
                        users = ti.Users;
                    if (ti.Deps != null)
                        deps = ti.Deps;
                    if (ti.Prjs != null)
                        prjs = ti.Prjs;
                    if (ti.Pers != null)
                        perms = ti.Pers;
                    if (ti.Roles != null)
                        roles = ti.Roles;
                    if (ti.Mods != null)
                        mods = ti.Mods;
                    if (ti.Acts != null)
                        acts = ti.Acts;
                    RefreshAll();
                }
            }
            openFileDialog1.Dispose();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "权限管理测试信息|*.testInfo";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write))
                {
                    TestInfo ti = new TestInfo();
                    ti.Users = users;
                    ti.Roles = roles;
                    ti.Prjs = prjs;
                    ti.Pers = perms;
                    ti.Deps = deps;
                    ti.Mods = mods;
                    ti.Acts = acts;
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, ti);
                    MessageBox.Show("保存成功！");
                }
            }
            saveFileDialog1.Dispose();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            users.Clear();
            roles.Clear();
            prjs.Clear();
            perms.Clear();
            deps.Clear();
            mods.Clear();
            acts.Clear();
            RefreshAll();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (object obj in listBoxSelecter4.SelectedItems)
            {
                KellPermission.User user = (KellPermission.User)obj;
                if (!user.Projects.Contains(prjs[comboBox12.SelectedIndex]))
                    user.Projects.Add(prjs[comboBox12.SelectedIndex]);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string moduleName = textBox8.Text.Trim();
            if (!string.IsNullOrEmpty(moduleName))
            {
                mods.Add(new Module(moduleName));
                RefreshMods(mods.Count - 1);
            }
            else
            {
                MessageBox.Show("请输入模块名！");
                textBox8.Focus();
                textBox8.SelectAll();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string actionName = textBox9.Text.Trim();
            if (!string.IsNullOrEmpty(actionName))
            {
                acts.Add(new Action(actionName));
                RefreshActs(acts.Count - 1);
            }
            else
            {
                MessageBox.Show("请输入操作名！");
                textBox9.Focus();
                textBox9.SelectAll();
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex > -1)
            {
                textBox8.Text = mods[comboBox9.SelectedIndex].Name;
            }
            selectModu = comboBox9.SelectedIndex;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //string saveName = textBox8.Text.Trim();
            //if (!string.IsNullOrEmpty(saveName))
            //{
            //    int i = comboBox9.SelectedIndex;
            //    mods[i].Name = saveName;
            //    comboBox9.Items[i] = saveName;
            //}
            //else
            //{
            //    MessageBox.Show("请输入模块名！");
            //    textBox8.Focus();
            //    textBox8.SelectAll();
            //}
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.SelectedIndex > -1)
            {
                textBox9.Text = acts[comboBox10.SelectedIndex].Name;
            }
            selectActn = comboBox10.SelectedIndex;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //string saveName = textBox9.Text.Trim();
            //if (!string.IsNullOrEmpty(saveName))
            //{
            //    int i = comboBox10.SelectedIndex;
            //    acts[i].Name = saveName;
            //    comboBox10.Items[i] = saveName;
            //}
            //else
            //{
            //    MessageBox.Show("请输入操作名！");
            //    textBox9.Focus();
            //    textBox9.SelectAll();
            //}
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //string saveName = textBox6.Text.Trim();
            //if (!string.IsNullOrEmpty(saveName))
            //{
            //    int i = comboBox12.SelectedIndex;
            //    prjs[i].Name = saveName;
            //    comboBox12.Items[i] = saveName;
            //    RefreshPrjs();
            //}
            //else
            //{
            //    MessageBox.Show("请输入项目组名！");
            //    textBox6.Focus();
            //    textBox6.SelectAll();
            //}
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = contextMenuStrip1.SourceControl;
            if (c is Button)
            {
                string name;
                Button btn = c as Button;
                switch (btn.Name)
                {
                    case "btn_Perm":
                        name = textBox11.Text.Trim();
                        string mod = comboBox9.Text;
                        string act = comboBox10.Text;
                        KellPermission.Permission per = perms[selectPerm];
                        per.Name = name;
                        per.TheModule.Name = mod;
                        per.TheAction.Name = act;
                        listBoxSelecter2.UpdateSourceItem(selectPerm, per);
                        break;
                    case "btn_Role":
                        name = textBox10.Text.Trim();
                        KellPermission.PermissionCollection pers = new KellPermission.PermissionCollection();
                        foreach (object obj in listBoxSelecter3.SelectedItems)
                        {
                            KellPermission.Permission perr = (KellPermission.Permission)obj;
                            roles[selectRole].Permissions.Add(perr);
                        }
                        roles[selectRole].Name = name;
                        listBoxSelecter3.UpdateSourceItem(selectRole, roles[selectRole]);
                        break;
                    case "btn_User":
                        string userName = textBox1.Text.Trim();
                        string password = textBox2.Text.Trim();
                        if (deps != null)
                        {
                            Department dep = deps[comboBox1.SelectedIndex];
                            string description = textBox3.Text;
                            KellPermission.User user = users[selectUser];
                            Project prj = null;
                            try
                            {
                                if (prjs != null)
                                    prj = prjs[comboBox2.SelectedIndex - 1];
                            }
                            catch
                            { }
                            if (prj != null)
                            {
                                user.Projects.Clear();
                                user.Projects.Add(prj);
                            }
                            else
                            {
                                user.Projects.Clear();
                            }
                            user.UserName = userName;
                            user.Password = password;
                            user.Departments.Clear();
                            user.Departments.Add(dep);
                            user.Description = description;
                            comboBox8.Items[selectUser] = userName;
                        }
                        break;
                    case "btn_Dept":
                        name = textBox7.Text.Trim();
                        KellPermission.Department parent = null;
                        try
                        {
                            parent = deps[comboBox11.SelectedIndex - 1];
                        }
                        catch
                        { }
                        KellPermission.Department depp = deps[selectDept];
                        if (parent != null)
                            depp.Parent = parent;
                        else
                            depp.Parent = null;
                        depp.Name = name;
                        comboBox3.Items[selectDept] = depp.Name;
                        comboBox1.Items[selectDept] = depp.Name;
                        comboBox6.Items[selectDept] = depp.Name;
                        comboBox11.Items[selectDept] = depp.Name;
                        break;
                    case "btn_Proj":
                        name = textBox6.Text.Trim();
                        prjs[selectProj].Name = name;
                        comboBox12.Items[selectProj] = name;
                        comboBox2.Items[selectProj] = name;
                        comboBox5.Items[selectProj] = name;
                        break;
                    case "btn_Modu":
                        name = textBox8.Text.Trim();
                        mods[selectModu].Name = name;
                        comboBox9.Items[selectModu] = name;
                        break;
                    case "btn_Actn":
                        name = textBox9.Text.Trim();
                        acts[selectActn].Name = name;
                        comboBox10.Items[selectActn] = name;
                        break;
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = contextMenuStrip1.SourceControl;
             if (c is Button)
             {
                 Button btn = c as Button;
                 switch (btn.Name)
                 {
                     case "btn_Perm":
                         if (selectPerm > -1)
                         {
                             perms.RemoveAt(selectPerm);
                             listBoxSelecter2.RemoveSourceItem(selectPerm);
                         }
                         break;
                     case "btn_Role":
                         if (selectRole > -1)
                         {
                             roles.RemoveAt(selectRole);
                             listBoxSelecter3.RemoveSourceItem(selectRole);
                         }
                         break;
                     case "btn_User":
                         if (selectUser > -1)
                         {
                             users.RemoveAt(selectUser);
                             comboBox8.Items.RemoveAt(selectUser);
                             comboBox4.Items.RemoveAt(selectUser);
                             comboBox13.Items.RemoveAt(selectUser);
                         }
                         break;
                     case "btn_Dept":
                         if (selectDept > -1)
                         {
                             deps.RemoveAt(selectDept);
                             comboBox3.Items.RemoveAt(selectDept);
                             comboBox1.Items.RemoveAt(selectDept);
                             comboBox6.Items.RemoveAt(selectDept);
                             comboBox11.Items.RemoveAt(selectDept);
                         }
                         break;
                     case "btn_Proj":
                         if (selectProj > -1)
                         {
                             prjs.RemoveAt(selectProj);
                             comboBox12.Items.RemoveAt(selectProj);
                             comboBox2.Items.RemoveAt(selectProj);
                             comboBox5.Items.RemoveAt(selectProj);
                         }
                         break;
                     case "btn_Modu":
                         if (selectModu > -1)
                         {
                             mods.RemoveAt(selectModu);
                             comboBox9.Items.RemoveAt(selectModu);
                         }
                         break;
                     case "btn_Actn":
                         if (selectActn > -1)
                         {
                             acts.RemoveAt(selectActn);
                             comboBox10.Items.RemoveAt(selectActn);
                         }
                         break;
                 }
             }
        }

        private void listBoxSelecter2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectPerm = listBoxSelecter2.SelectedSourceIndex;
            if (selectPerm > -1 && selectPerm < listBoxSelecter2.AllItems.Count)
                textBox11.Text = (listBoxSelecter2.AllItems[selectPerm] as KellPermission.Permission).Name;
        }

        private void listBoxSelecter3_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectRole = listBoxSelecter3.SelectedSourceIndex;
            if (selectRole > -1 && selectRole < listBoxSelecter3.AllItems.Count)
                textBox10.Text = (listBoxSelecter3.AllItems[selectRole] as KellPermission.Role).Name;
        }
    }
}