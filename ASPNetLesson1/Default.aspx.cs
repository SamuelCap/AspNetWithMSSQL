using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNetLesson1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("<center><h1>Read data from a database </h1></center>");
                Response.Write("<br/>");
                string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                string sqlStringDropDownList = "select Country from customers";
                SqlCommand cmd2 = new SqlCommand(sqlStringDropDownList, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read() == true)
                {
                    DropDownList1.Items.Add(new ListItem(dr2["Country"].ToString(),dr2["Country"].ToString()));
                }
                dr2.Close();
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database </ h1 ></ center >");
            Response.Write("<br/>");
            string txtValue = TextBox1.Text;
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "select * from customers where Country=@Country";
            SqlCommand cmd = new SqlCommand(sqlString, con);
            //to prevent sql injection
            cmd.Parameters.AddWithValue("@Country", txtValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<br/>");
                string txtValue = DropDownList1.SelectedValue.ToString();
                string s =ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "select * from customers where Country=@Country";
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Parameters.AddWithValue("@Country", txtValue);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database </ h1 ></ center >");
            Response.Write("<br/>");
            string txtValueId = TextBox2.Text;
            string txtValueCity = TextBox3.Text;
            string txtValueCountry = TextBox4.Text;
            string s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection con = new SqlConnection(s);
            string sqlString = "INSERT INTO customers VALUES(@Id, 'Berglunds snabbköp', 'Christina Berglund', 'Order Administrator', 'Berguvsvägen  8', @City, 'Nv', 'S-958 22', @Country, '0921-12 34 65', '0921-12 34 67')";
            SqlCommand cmd = new SqlCommand(sqlString, con);
            //to prevent sql injection
            cmd.Parameters.AddWithValue("@Country", txtValueCountry);
            cmd.Parameters.AddWithValue("@City", txtValueCity);
            cmd.Parameters.AddWithValue("@Id", txtValueId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }
    }
}
//CustomerID(5 letters)	CompanyName (123)	ContactName (Phil)	ContactTitle(Owner)	Address (23 Outlook)	City()	Region (NV)	PostalCode (RQ3 PR1 )	Country()	Phone((171) 555-7788)	Fax((171) 555-7788)