using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeBreeze.AdministratorUC
{
    
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;
        string currentuser;

        public UC_ViewUser()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { currentuser = value; }
        }
        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            AdminViewUser adm = new AdminViewUser();
            ds = adm.ViewUser_WindowLoad();
            guna2DataGridView1.DataSource = ds.Tables[0];
            //query = "select * from users";
            //ds= fn.getData(query);
            //guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            AdminViewUser adm = new AdminViewUser();
            adm.Username = txtUserName.Text;
            ds = adm.ViewUser_UsernameTextChange();
            guna2DataGridView1.DataSource = ds.Tables[0];
            //query = "select * from users where username like '" + txtUserName.Text + "'";
            //ds = fn.getData(query);
            //guna2DataGridView1.DataSource = ds.Tables[0];
        }
        string userName;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch 
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentuser != userName)
            {
                AdminViewUser adm = new AdminViewUser();
                adm.Username = userName;
                adm.ViewUser_Delete();
                UC_ViewUser_Load(this, null);

                //    query = "delete from users where username='" + userName + "'";
                //    fn.setData(query,"user record deleted!");
                //    UC_ViewUser_Load(this, null); // reload
            }
            else
            {
                MessageBox.Show("you can't delete your own profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this, null);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
