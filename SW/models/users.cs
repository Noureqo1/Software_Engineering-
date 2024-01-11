using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SW.models
{
    [BindProperties(SupportsGet = true)]
    public class users
    {
        public users()
        {
           
        }
        [BindProperty]
        public String Email { get; set; }
        [BindProperty]
        public int Password { get; set; }
        [BindProperty]
        public int ConfirmPassword { get; set; }
        [BindProperty]
        public String Name { get; set; } 
        [BindProperty]
        public int PhoneNumber { get; set; }
    }
}
