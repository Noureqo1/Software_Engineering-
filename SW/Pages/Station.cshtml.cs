using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SW.Pages
{
    public class StationModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public StationModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string UserType { get; set; }
        public int Age { get; set; }
        public string ErrorMessage { get; set; }

        public int priorty { get; set; }


        public void OnGet()
        {

        }

        public void OnPost()
        {
            UserType = Request.Form["userType"];

            Age = Convert.ToInt32(Request.Form["age"]);
            if (Age < 0)
            {
                ErrorMessage = "Age cannot be negative.";
                return;
            }

            if (Age > 100)
            {
                ErrorMessage = "Age too large.";
                return;
            }

            switch (UserType)
            {
                case "POD":
                    priorty = 3;
                    break;
                case "SP":
                    priorty = 2;
                    break;
                case "NP":
                    priorty = 1;
                    break;

                default:
                    ErrorMessage = "user type is invalid.";
                    break;
            }
            Console.WriteLine(UserType);
            Console.WriteLine(Age);
        }
    }
}
