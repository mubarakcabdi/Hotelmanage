using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Hotelmanage.Pages.employee
{
    public class Add_employeeModel : PageModel
    {
        public string successmsg = "";
        public string errormsg = "";
        public void OnGet()
        {
        }
        
        public void OnPost()
        {

            string name = Request.Form["name"];
            string gender = Request.Form["gender"];
            string address = Request.Form["address"];
            string phone = Request.Form["phone"];
            try
            {
                string connectionstring ="Data Source=DESKTOP-9GQQRHD\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;Encrypt=False;";
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "insert into employee"+ 
                    "(name, gender, address, phone) values"+
                "(  '"+ name +"', '"+ gender +"', '"+ address +"', '"+ phone +"')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                successmsg = "saved successfuly";
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
