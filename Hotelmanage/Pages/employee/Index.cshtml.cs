using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Hotelmanage.Pages.employee
{
   
    public class IndexModel : PageModel
    {
        public String errormsg = "";

        string connectionstring = "Data Source=DESKTOP-9GQQRHD\\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True;Encrypt=False;";
        public List<employeeinfo>employeelist = new  List<employeeinfo>();
        public void OnGet()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql = "SELECT * from  employee";
                SqlCommand command = new SqlCommand(sql,connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    employeeinfo employeeinfo = new employeeinfo();
                    employeeinfo.id = reader.GetInt32(0);
                    employeeinfo.name = reader.GetString(1);
                    employeeinfo.gender = reader.GetString(2);
                    employeeinfo.address = reader.GetString(3);
                    employeeinfo.phone = reader.GetInt32(4);
                    employeelist.Add(employeeinfo);
                }
            }
             catch (Exception ex)
            {
                errormsg = ex.Message;
                return;

            }

        }
    }
    public class employeeinfo
    {
        public int id;
        public string name;
        public string gender;
        public string address;
        public int phone;     
    }
}

