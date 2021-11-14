using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeBreeze.PharmacistUC
{
    public partial class UC_P_AddMedicine : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;
        public UC_P_AddMedicine()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMediId.Text != ""&& txtMediName.Text != "" && txtMediNumber.Text !="" && txtQuantity.Text != "" && txtPricePerUnit.Text != "")
            {
                string mid = txtMediId.Text;
                string mname = txtMediName.Text;
                string mnumber = txtMediNumber.Text;
                string mdate = txtManufacturingDate.Text;
                string edate = txtExpireDate.Text;
                Int64 quantity = Int64.Parse(txtQuantity.Text);
                Int64 perunit = Int64.Parse(txtPricePerUnit.Text);

                query = "insert into medic(mid,mname,mnumber,mDate,eDate,quantity,perUnit) values('" + mid + "','" + mname + "','" + mnumber + "','" + mdate + "','" + edate + "','" + quantity + "','" + perunit + "')";
                fn.setData(query, "Medicine added successfully");

            }
            else
            {
                MessageBox.Show("Enter all datas!", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtManufacturingDate.ResetText();
            txtExpireDate.ResetText();
            txtQuantity.Clear();
            txtPricePerUnit.Clear();

        }
    }
}
