using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SW.Pages.Pages
{
    [BindProperties(SupportsGet = true)]
    public class SignUpModel : PageModel
    {
        public required models.users User { get; set; }
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

    //    public IActionResult OnPost()
    //    {
    //        // Validate password confirmation
    //        //if (User.Password != User.ConfirmPassword)
    //        //{
    //        //    ErrorMessage = "Password and Confirm Password do not match.";
    //        //    return Page();
    //        //}

    //        // Connect to the database
    //        string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=Project6;Integrated Security=True";
    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            // Insert the user data into the database
    //            string query = $"insert into Users(Username, Email, Password, Phone_Number) " +
    //           $"values('{User.Name}', '{User.Email}', '{User.Password}', '{User.PhoneNumber}')";

    //            SqlCommand command = new SqlCommand(query, con);

    //            try
    //            {
    //                con.Open();
    //                command.ExecuteNonQuery();

    //                return RedirectToPage("/Login");
                

    //            }
    //            catch (SqlException err)
    //            {
    //                Console.WriteLine(err.Message);
    //            }
    //            finally
    //            {
    //                con.Close();
    //            }

  
    //        }

    //        return Page();
    //    }
    }
}