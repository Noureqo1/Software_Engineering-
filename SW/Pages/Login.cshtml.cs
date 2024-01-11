using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SW.Pages.Pages
{
    [BindProperties(SupportsGet = true)]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public models.users User { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Connect to the database
            string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=SW;Integrated Security=True";
            SqlConnection con = new SqlConnection();
            {
                con.ConnectionString = connectionString;

                // Query the database to check if the user credentials match
                string query = $"SELECT * FROM Users WHERE Password={User.Password}";
                SqlCommand command = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    dt.Load(command.ExecuteReader());
                    if (dt.Rows.Count >= 0)
                    {
                        // User credentials match, log in the user
                        // You can implement your login logic here
                        return RedirectToPage("/Station");
                    }
                    else
                    {
                        // User credentials do not match, display an error message
                        ErrorMessage = "Invalid credentials. Please try again.";
                    }
                    return RedirectToPage("/Login");


                }
                catch (SqlException err)
                {
                    Console.WriteLine(err.Message);
                }
                finally
                {
                    con.Close();
                }

      
            }

            return Page();
        }
        public void OnGet()
        {

        }
    }
}