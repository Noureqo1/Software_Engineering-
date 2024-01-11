using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.X86;
using System.Reflection;

namespace SW.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public models.station satation { get; set; }
        public void OnPost()
        {
            string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=SW;Integrated Security=True";
            using SqlConnection con = new SqlConnection(connectionString);

            string query = $"select * from Station";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                dt.Load(cmd.ExecuteReader());

                // handle not found employee
                if (dt.Rows.Count == 0)
                {

                }

                // transfer data from returned datatable into employee object
                satation.Capacity = ((string)dt.Rows[0]["Capacity"])[0];
                satation.priorty = ((string)dt.Rows[0]["priorty"])[0];
                satation.Station = dt.Rows[0]["Station"].ToString();
                satation.Age = ((string)dt.Rows[0]["Age"])[0];  // minit is coming from db as string, but it's a char in the Employee.cs, so I'm just converting from string to char here.

            }
            finally
            {
                con.Close();
            }

        }
    }
}
