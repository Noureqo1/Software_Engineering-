using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.models;
using System;
using System.Data.SqlClient;

namespace SW.Pages.Pages
{


    [BindProperties(SupportsGet = true)]
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public required models.users User { get; set; }
        [BindProperty]
        public string tempData { get; set; }
        public string ErrorMessage { get; set; }


        public IActionResult OnPost()
        {
            string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=SW;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Insert the user data into the database
                string query = $"insert into Users (UserName, Email, Password, PhoneNumber) " +
               $"values('{User.Name}', '{User.Email}', '{User.Password}', '{User.PhoneNumber}')";

                SqlCommand command = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

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

                return Page();

            }

            Console.WriteLine(User.Email);
            Console.WriteLine(User.Password);

        }
        public void OnGet()
        {

        }
    }
}