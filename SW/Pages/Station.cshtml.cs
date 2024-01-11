using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SW.models;
using System.Data.SqlClient;

namespace SW.Pages
{
    public class StationModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public StationModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public models.station satation { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (Convert.ToInt32(satation.Age) < 0)
            {
                satation.ErrorMessage = "Age cannot be negative.";

            }

            if (Convert.ToInt32(satation.Age) > 100)
            {
                satation.ErrorMessage = "Age too large.";
            }

            switch (satation.UserType)
            {
                case "POD":
                    satation.priorty = 3;
                    break;
                case "SP":
                    satation.priorty = 2;
                    break;
                case "NP":
                    satation.priorty = 1;
                    break;
            }

            switch (satation.UserType)
            {
                case "POD":
                    satation.Capacity = 10;
                    break;
                case "SP":
                    satation.Capacity = 15;
                    break;
                case "NP":
                    satation.Capacity = 25;
                    break;
            }

            Console.WriteLine(satation.UserType);
            Console.WriteLine(satation.Age);
            Console.WriteLine("Price");
            Console.WriteLine(satation.Price);
            Console.WriteLine(satation.Station);
            Console.WriteLine("Capacity");
            Console.WriteLine(satation.Capacity);
            Console.WriteLine(satation.TripTime);

            string connectionString = "Data Source=LAPTOP-OH72TN5U;Initial Catalog=SW;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Insert the user data into the database
                string query = $"insert into Station (UserType, Age, priorty , Price, Station ,Capacity,TripTime) " +
                $"values('{satation.UserType}', '{satation.Age}', '{satation.priorty}, '{satation.Price}', '{satation.Station}', '{satation.Capacity}', '{satation.TripTime}')";
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    return RedirectToPage("/Thanks");


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


        }
    }
}
