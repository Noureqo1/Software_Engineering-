using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SW.models
{
    [BindProperties(SupportsGet = true)]
    public class users
    {
        [Required]
        public required string ID { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public String? Email { get; set; }
        public int? Password { get; internal set; }
        public int? ConfirmPassword { get; internal set; }
        public String? Name { get; internal set; }
        public int? PhoneNumber { get; internal set; }
    }
}
