using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeBreeze
{

     
     
        public class Login
        {
            function fn;
            String query;
            DataSet ds;
            public string Username;
            public string Password;
            public DataSet SignIn()
            {
                fn = new function();
                query = "select * from users";
                ds = fn.getData(query);
                return ds;
            }
            public DataSet GetUserDetails()
            {
                fn = new function();
                query = "select * from users where username ='" + Username + "' and pass='" + Password + "'";
                ds = fn.getData(query);
                return ds;
            }
        }
        
     
    public class Admin
    {
        public string Id { get; set; }
        public string UserRole { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public Int64 Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

         

    }
    public class AdminAddUser : Admin
    {
        public string query;
        function fn;
       public  DataSet ds;
        public void AddUser_SignUp()
        {
            try
            {
                var fn= new function();
                query= "insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + UserRole + "','" + Name + "','" + Dob + "'," + Mobile + ",'" + Email + "','" + Username + "','" + Password + "')";
                fn.setData(query, "SignUp Successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Username Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public DataSet AddUser_UsernameTextChange()
        {
            fn = new function();
            query = "select * from users where username='" + Username + "'";
            ds = fn.getData(query);
            return ds;
        }
    }
    public class AdminViewUser : Admin
    {
        function fn;
        String query;
        DataSet ds;
        public DataSet ViewUser_WindowLoad()
        {
            fn = new function();
            query = "select * from users";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet ViewUser_UsernameTextChange()
        {
            fn = new function();
            query = "select * from users where username like '" + Username + "%'";
            ds = fn.getData(query);
            return ds;
        }
        public void ViewUser_Delete()
        {
            fn = new function();
            query = "delete from users where username='" + Username + "'";
            fn.setData(query, "User Record Deleted.");
        }
    }
    public class AdminProfile : Admin
    {
        function fn;
        String query;
        DataSet ds;
        public DataSet Profile_ShowData()
        {
            fn = new function();
            query = "select * from users where username='" + Username + "'";
            ds = fn.getData(query);
            return ds;
        }
        public void Profile_Update()
        {
            fn = new function();
            query = "update users set userRole='" + UserRole + "',name='" + Name + "',dob='" + Dob + "',mobile=" + Mobile + ",email='" + Email + "',pass='" + Password + "'where username='" + Username + "'";
            fn.setData(query, "Profile Updation Successful.");
        }
    }
    public class Pharma
    {
        public string mId { get; set; }
        public string mName { get; set; }
        public string mNumber { get; set; }
        public string mDate { get; set; }
        public string eDate { get; set; }
        public Int64 Qty { get; set; }
        public Int64 Perunit { get; set; }
        public string P_Password { get; set; }
        public string P_Username { get; set; }
          function fn;
          string query;
         DataSet ds;
    }
    public class PharmaDashboard : Pharma
    {
        function fn;
        string query;
        DataSet ds;
        public DataSet Dashboard_ValidChart()
        {
            fn = new function();
            query = "select count(mname) from medic where eDate >= '17/11/2021'";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet Dashboard_ExpireChart()
        {
            fn = new function();
            query = "select count(mname) from medic where eDate <= '17/11/2021'";
            ds = fn.getData(query);
            return ds;
        }
    }
    public class ViewMedicine : Pharma
    {
        function fn;
        string query;
        DataSet ds;
        public DataSet ViewMedicine_LoadWindow()
        {
            fn = new function();
            query = "select * from medic";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet ViewMedicine_UsernameTextChange()
        {
            fn = new function();
            query = "select * from medic where mname like '" + mName + "%'";
            ds = fn.getData(query);
            return ds;
        }
        public void ViewMedicine_Delete()
        {
            fn = new function();
            query = "delete from medic where mid='" + mId + "'";
            fn.setData(query, "Medicine Record Deleted.");
        }
    }
    public class UpdateMedicine : Pharma
    {
        function fn;
        string query;
        DataSet ds;
        public DataSet UpdateMedicine_Search()
        {
            fn = new function();
            query = "select * from medic where mid='" + mId + "'";
            ds = fn.getData(query);
            return ds;
        }
        public void UpdateMedicine_Update()
        {
            fn = new function();
            query = "update medic set mname='" + mName + "',mnumber='" + mNumber + "',mDate='" + mDate + "',eDate='" + eDate + "',quantity=" + Qty + ",perUnit='" + Perunit + "' where mid='" + mId + "' ";
            fn.setData(query, "Medicine Details Updated.");
        }
    }
    public class ValidityCheck : Pharma
    {
        function fn;
        string query;
        DataSet ds;
        public DataSet ValidMed()
        {
            fn = new function();
            query = "select * from medic where eDate >= '17/11/2021'";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet ExpireMed()
        {
            fn = new function();
            query = "select * from medic where eDate <= '17/11/2021'";
            ds = fn.getData(query);
            return ds;
        }
    }
    public class SellMedicine : Pharma
    {
        function fn;
        string query;
        DataSet ds;
        public DataSet SellMedicine_LoadWindow()
        {
            fn = new function();
            query = "select mname from medic where eDate>='17/11/2021' and quantity>'0'";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet SellMedicine_Search()
        {
            fn = new function();
            query = "select mname from medic where mname like '" + mName + "%' and eDate>='17/11/2021' and quantity>'0'";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet SellMedicine_ListItemSelect()
        {
            fn = new function();
            query = "select mid,eDate,perUnit from medic where mname='" + mName + "'";
            ds = fn.getData(query);
            return ds;
        }
        public DataSet SellMedicine_GetItem()
        {
            fn = new function();
            query = "select quantity from medic where mid='" + mId + "'";
            ds = fn.getData(query);
            return ds;
        }
        public void SellMedicine_SetItem(string msg)
        {
            fn = new function();
            query = "update medic set quantity='" + Qty + "'where mid='" + mId + "'";
            fn.setData(query, msg);
        }

    }
}
