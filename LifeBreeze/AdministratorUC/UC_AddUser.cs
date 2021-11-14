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
    public partial class UC_AddUser : UserControl
    {
        function fn = new function();
        string query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            AdminAddUser adm = new AdminAddUser();
            adm.UserRole = txtUserRole.Text;
            adm.Name = txtName.Text;
            adm.Dob = txtDob.Text;
            adm.Mobile = Int64.Parse(txtMobileNo.Text);
            adm.Email = txtEmail.Text;
            adm.Username = txtUsername.Text;
            adm.Password = txtPassword.Text;
               adm.AddUser_SignUp();
            //string role = txtUserRole.Text;
            //string name = txtName.Text;
            //string dob = txtDob.Text;
            //Int64 mobile = Int64.Parse(txtMobileNo.Text);
            //string email = txtEmail.Text;
            //string username = txtUsername.Text;
            //string pass = txtPassword.Text;
            //try
            //{
            //    query = "insert into users(userrole,name,dob,mobile,email,username,pass) values('" + role + "','" + name + "','" + dob + "','" + mobile + "','" + email + "','" + username + "','" + pass + "')";
            //    fn.setData(query, "Sign Up Succesfully");

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Username Already Exist","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtEmail.Clear();
            txtMobileNo.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUserRole.SelectedIndex = -1;
        }
    }

    //private void btnReset_Click(object sender, EventArgs e)
    //{
    //    clearAll();
    //}
   
}

