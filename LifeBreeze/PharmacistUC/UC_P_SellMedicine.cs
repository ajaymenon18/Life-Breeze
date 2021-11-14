using DGVPrinterHelper;
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
    public partial class UC_P_SellMedicine : UserControl
    {
        function fn = new function();
        string query;
        DataSet ds;

        public UC_P_SellMedicine()
        {
            InitializeComponent();
        }

        private void UC_P_SellMedicine_Load(object sender, EventArgs e)
        {
            listBoxMedicines.Items.Clear();
            SellMedicine medicine = new SellMedicine();
            ds = medicine.SellMedicine_LoadWindow();
            //query = "select mname from medic where eDate >= getdate() and quantity >'0'";
            //ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_P_SellMedicine_Load(this, null );
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //TXTBOX SEARCH EVENT

            //In the search box we are searching for the medicine 
            listBoxMedicines.Items.Clear();
            SellMedicine medicine = new SellMedicine();
            medicine.mName = txtSearch.Text;
            ds = medicine.SellMedicine_Search();
            //query = "select mname from medic where mname like '" + txtSearch.Text + "%' and eDate >= getdate() and quantity > '0'";
            //ds = fn.getData(query);

           // In ds it would be stored in row wise  

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //row is changing but the column remains the same

                listBoxMedicines.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBoxMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LISTBOX SELECTION EVENT

            //On selecting the  medicine from the list box passing the values to ALL FIELDS 

            //First clearing the number of units 
            txtNoOfUnits.Clear();

            //Extracting the name from the ListBOX that we have selected 

            string name = listBoxMedicines.GetItemText(listBoxMedicines.SelectedItem);
            txtMediName.Text = name;

            SellMedicine medicine = new SellMedicine();


           // Fetching data from the Database by the name 


            medicine.mName = name;
            ds = medicine.SellMedicine_ListItemSelect();

            //query = "select mid,eDate,perUnit from medic where mname='" + name + "'";
            //ds = fn.getData(query);
            txtMediId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtExpireDate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPricePerUnit.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtNoOfUnits_TextChanged(object sender, EventArgs e)
        {
            // Textchange event .
            if (txtNoOfUnits.Text!="") // Entering the number of units 
            {
                // if not null 
                Int64 unitPrice = Int64.Parse(txtPricePerUnit.Text);
                Int64 noOfUnit = Int64.Parse(txtNoOfUnits.Text);
                Int64 totalAmont = unitPrice * noOfUnit;
                txtTotalPrice.Text = totalAmont.ToString(); // Setting the txttotalprice unit 
            }
            else
            {
                txtTotalPrice.Clear(); // Total price is cleared 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int n, totalAmount = 0;
        protected Int64 quantity, newQuantity;

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtMediId.Text!="")
            {
                SellMedicine medicine = new SellMedicine();
                medicine.mId = txtMediId.Text;
                ds = medicine.SellMedicine_GetItem();
                //query = "select quantity from medic where mid='" + txtMediId.Text + "'";
                //ds = fn.getData(query);

                quantity =Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newQuantity = quantity - Int64.Parse(txtNoOfUnits.Text);

                if (newQuantity>=0)
                {
                    n = guna2DataGridView1.Rows.Add(); // Adding the row variable 
                    guna2DataGridView1.Rows[n].Cells[0].Value = txtMediId.Text;
                    guna2DataGridView1.Rows[n].Cells[1].Value = txtMediName.Text;
                    guna2DataGridView1.Rows[n].Cells[2].Value = txtExpireDate.Text;
                    guna2DataGridView1.Rows[n].Cells[3].Value = txtPricePerUnit.Text;
                    guna2DataGridView1.Rows[n].Cells[4].Value = txtNoOfUnits.Text;
                    guna2DataGridView1.Rows[n].Cells[5].Value = txtTotalPrice.Text;

                    totalAmount = totalAmount + int.Parse(txtTotalPrice.Text);
                    totalLabel.Text = "Rs." + totalAmount.ToString();


                    // Updating the quantity after adding it to the cart, medcine ID of the updated medicine must be added 
                    medicine.Qty = newQuantity;
                    medicine.mId = txtMediId.Text;
                    medicine.SellMedicine_SetItem("Medicine Added.");
                    //query = "update medic set quantity ='" + newQuantity + "' where mid='" + txtMediId.Text + "'";
                    //fn.setData(query, "medicine added");
                }
                else
                {
                    MessageBox.Show("Medicine is out of box!");
                }

                //clearing text box when add to kart happens 
                clearAll();

                //Loading such that the Listbox reflects the changes made in the medic table
                UC_P_SellMedicine_Load(this, null);
            }
            else
            {
                MessageBox.Show("select medicine first!");
            }
        }
        int valueAmount;
        string valueId;
        protected Int64 noOfUnit;

        

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //SELECTING THE ADDED MEDICINE FROM THE DATAGRID
            try
            {    // 
                valueAmount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()); //TOTAL PRICE IS EXTRACTED FROM THE SELECTED COLUMN 
                valueId = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // VALUE ID IS EXTRACTED            
                                                                                                       
                noOfUnit= int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()); // NO OF UNITS IS EXTRACTED     
            }
            catch (Exception)
            {
            }
        }

      

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (valueId != null) // if null then nothing is selected , if not null value is selected
            {
                try
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index); // removing the rows at the grid
                }
                catch 
                {

                }
                finally
                {
                    //query = "select quantity from medic where mid ='" + valueId + "'";
                    //ds = fn.getData(query);

                    // UPDATING THE DATABASE VALUES 

                    //first extracting the quantity, then updating it 

                    SellMedicine medicine = new SellMedicine();
                    medicine.mId = valueId;
                    ds = medicine.SellMedicine_GetItem();
                    quantity = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newQuantity = quantity + noOfUnit;

                    //query = "update medic set quantity = '" + newQuantity + "' where mid = '" + valueId + "'";
                    //fn.setData(query, "medicine removed from cart");
                    medicine.SellMedicine_SetItem("Medicine Removed.");
                    totalAmount = totalAmount - valueAmount;
                    totalLabel.Text = "Rs. " + totalAmount.ToString();
                }
                UC_P_SellMedicine_Load(this, null);
            }
        }
        private void btnPurchasePrint_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Medicine Bill";
            print.SubTitle = String.Format("Date:- {0}", DateTime.Now.Date);
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Total Payable Amount: " + totalLabel.Text;
            print.FooterSpacing = 15;
            print.PrintDataGridView(guna2DataGridView1);
            totalAmount = 0;
            totalLabel.Text = "Rs. 00";
            guna2DataGridView1.DataSource = 0;
        }

        private void clearAll()
        {
            txtMediId.Clear();
            txtMediName.Clear();
            txtExpireDate.ResetText();
            txtPricePerUnit.Clear();
            txtNoOfUnits.Clear();
        }
    }
}
