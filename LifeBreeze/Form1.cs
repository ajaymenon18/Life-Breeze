using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeBreeze
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {



            query = "select * from users ";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0) //onlly when users table is empty
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from users where username='" + txtUsername.Text + "' and pass='" + txtPassword.Text + "'";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    string role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        Administrator admin = new Administrator(txtUsername.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Pharmacist")
                    {
                        Pharmacist pharm = new Pharmacist();
                        pharm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("wrong username or password!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                //if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                //{
                //    Administrator ad = new Administrator();
                //    ad.Show();
                //    this.Hide();

                //}
                //else
                //{
                //    MessageBox.Show("Wrong Username And Password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
