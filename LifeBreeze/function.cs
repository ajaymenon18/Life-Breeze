using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeBreeze
{
    class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data Source = DESKTOP-53Q160P\\SQLEXPRESS;database = Pharma;integrated security = True";
            return con;
        }
        public DataSet getData(string query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setData(string query, string msg)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg,"informaton",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
