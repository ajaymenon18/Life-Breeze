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
    public partial class UC_P_ViewMedicines : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;

        public UC_P_ViewMedicines()
        {
            InitializeComponent();
        }

        private void UC_P_ViewMedicines_Load(object sender, EventArgs e)
        {
            ViewMedicine viewMedicine = new ViewMedicine();
            ds = viewMedicine.ViewMedicine_LoadWindow();
            guna2DataGridView1.DataSource = ds.Tables[0];
            //query = "select * from medic";
            //setDataGridView(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ViewMedicine viewMedicine = new ViewMedicine();
            viewMedicine.mName = txtSearch.Text;
            ds = viewMedicine.ViewMedicine_UsernameTextChange();
            guna2DataGridView1.DataSource = ds.Tables[0];
            //    query = "select * from medic where mname like '" + txtSearch.Text + "%'";
            //    setDataGridView(query);
        }
        private void setDataGridView(string query)
        {
            ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
        string medicineId;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                medicineId = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch 
            {
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "delete from medic where mid ='" + medicineId + "'";
            fn.setData(query, "medicine deleted from the record!");
            UC_P_ViewMedicines_Load(this, null);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_ViewMedicines_Load(this, null);
        }
    }
}
