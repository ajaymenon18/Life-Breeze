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
    public partial class UC_P_UpdateMedicine : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;

        public UC_P_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMediID.Text !="")
            {
                UpdateMedicine updateMedicine = new UpdateMedicine();
                updateMedicine.mId = txtMediID.Text;
                ds = updateMedicine.UpdateMedicine_Search();

                //query = "select * from medic where mid='" + txtMediID.Text + "'";
                //ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtMediName.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtMediNumber.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtMDate.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEDate.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtAvailabeQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtPricePerUnit.Text = ds.Tables[0].Rows[0][7].ToString();
                }
                else
                {
                    MessageBox.Show($"medicine with id {txtMediID.Text} is not found!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                clearAll();

            }
        }
        private void clearAll()
        {
            txtMediID.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtAvailabeQuantity.Clear();
            txtMDate.ResetText();
            txtEDate.ResetText();
            txtPricePerUnit.Clear();
            if (txtAddQuan.Text != "0")
            {
                txtAddQuan.Text = "0";
            }
            else
            {
                txtAddQuan.Text = "0";
            }
           
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        Int64 totalquantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMedicine updateMedicine = new UpdateMedicine();
            updateMedicine.mId = txtMediID.Text;
            updateMedicine.mName = txtMediName.Text;
            updateMedicine.mNumber = txtMediNumber.Text;
            updateMedicine.mDate = txtMDate.Text;
            updateMedicine.eDate = txtEDate.Text;
            updateMedicine.Perunit = Int64.Parse(txtPricePerUnit.Text);
            Int64 quantity = Int64.Parse(txtAvailabeQuantity.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuan.Text);
            totalquantity = quantity + addQuantity;
            updateMedicine.Qty = totalquantity;
            updateMedicine.UpdateMedicine_Update();

            //string mname = txtMediName.Text;
            //string mnumber = txtMediNumber.Text;
            //string mdate = txtMDate.Text;
            //string edate = txtEDate.Text;
            //Int64 quantity = Int64.Parse(txtAvailabeQuantity.Text);
            //Int64 addQuantity = Int64.Parse(txtAddQuan.Text);
            //Int64 unitprice = Int64.Parse(txtPricePerUnit.Text);

            //totalquantity = quantity + addQuantity;

            //query = "update medic set mname='"+mname+"',mnumber='"+mnumber+ "',mDate='"+mdate+ "',eDate='"+edate+ "',quantity="+totalquantity+ ",perUnit="+unitprice+ " where mid='"+txtMediID.Text+"'";
            //fn.setData(query, "Updated successfully");
        }
    }
}
