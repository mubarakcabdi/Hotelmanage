using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
namespace Hotelmanage.Pages.employee
{
    public class Edit_emplotyeeModel : PageModel
    {
        string connectionstring = "Data Source=DESKTOP-9GQQRHD\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;Encrypt=False;";
        public string successmsg = "";
        public string errormsg = "";
        public employeeinfo employeeinfo = new employeeinfo();
        public void OnGet()
        {
            string id = Request.Query["id"];
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            String sql = "SELECT * from employee where id='" + id + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employeeinfo.id = reader.GetInt32(0);
                employeeinfo.name = reader.GetString(1);
                employeeinfo.gender = reader.GetString(2);
                employeeinfo.address = reader.GetString(3);
                employeeinfo.phone = reader.GetInt32(4);
            }
        }
        public void OnPost()
        {
            string id = Request.Form["id"];
            string name = Request.Form["name"];
            string gender = Request.Form["gender"];
            string address = Request.Form["address"];
            string phone = Request.Form["phone"]; 
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "UPDATE employee set"+
                     "name = '" + name + "'," +
                    "gender = '" + gender + "'," +
                    "address = '" + address + "'," +
                    "phone = '" + phone + "'" +
                    "where id = '" + id + "'";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)

            {
                errormsg = ex.Message;
                return;
            }

            Response.Redirect("/employee/Index");

        }
        }
    }

