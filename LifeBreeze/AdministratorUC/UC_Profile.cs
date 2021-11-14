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
    public partial class UC_Profile : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;
        public UC_Profile()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { userNameLabel.Text = value; }
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            AdminProfile adm = new AdminProfile();
            adm.Username = userNameLabel.Text;
            ds = adm.Profile_ShowData();
            txtUserRole.Text = ds.Tables[0].Rows[0][1].ToString();
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDob.Text = ds.Tables[0].Rows[0][3].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();
            //    query="select * from users where username='" + userNameLabel.Text + "'";
            //    DataSet ds=fn.getData(query);

            //    txtUserRole.Text = ds.Tables[0].Rows[0][1].ToString();
            //    txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            //    txtDob.Text = ds.Tables[0].Rows[0][3].ToString();
            //    txtMobile.Text = ds.Tables[0].Rows[0][4].ToString();
            //    txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
            //    txtPassword.Text = ds.Tables[0].Rows[0][7].ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UC_Profile_Enter(this, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminProfile adm = new AdminProfile();
            adm.UserRole = txtUserRole.Text;
            adm.Name = txtName.Text;
            adm.Dob = txtDob.Text;
            adm.Mobile = Int64.Parse(txtMobile.Text);
            adm.Email = txtEmail.Text;
            adm.Username = userNameLabel.Text;
            adm.Password = txtPassword.Text;
            adm.Profile_Update();
            //string role = txtUserRole.Text;
            //string name = txtName.Text;
            //string dob = txtDob.Text;
            //Int64 mobile = Int64.Parse(txtMobile.Text);
            //string email = txtEmail.Text;
            //string username = userNameLabel.Text;
            //string pass = txtPassword.Text;


            //query = "update users set userRole='" + role + "' ,name='" + name + "',dob='" + dob + "',mobile='" + mobile + "',email='" + email + "',pass='" + pass + "' where username='" + username + "'";
            //fn.setData(query, "profile updated succesfully!");

        }

        
    }
}
