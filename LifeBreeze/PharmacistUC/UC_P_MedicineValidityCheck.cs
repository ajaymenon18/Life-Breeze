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
    public partial class UC_P_MedicineValidityCheck : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;

        public UC_P_MedicineValidityCheck()
        {
            InitializeComponent();
        }

        private void txtCheck_SelectedIndexChanged(object sender, EventArgs e)
        {

            ValidityCheck meds = new ValidityCheck();
            ViewMedicine medicines = new ViewMedicine();
            if (txtCheck.SelectedIndex == 0)
            {
                //query = "select * from medic where eDate >= getdate()"; //valid medicine
                //ds=fn.getData(query);
                ds = meds.ValidMed();
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Valid medicine";
            }
            else if (txtCheck.SelectedIndex == 1)
            {
                //query = "select * from medic where eDate <= getdate()"; //expired medicine
                //ds = fn.getData(query);
                ds = meds.ExpireMed();
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "Expired medicine";
            }
            else if (txtCheck.SelectedIndex == 2)
            {
                //query = "select * from medic";
                //ds = fn.getData(query);
                ds = medicines.ViewMedicine_LoadWindow();
                guna2DataGridView1.DataSource = ds.Tables[0];
                setLabel.Text = "All medicine";
            }
        }

    }
}
