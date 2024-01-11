using Microsoft.AspNetCore.Mvc;

namespace SW.models
{
    public class station
    {
        [BindProperty]
        public string UserType { get; set; }
        [BindProperty]
        public int Age { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        [BindProperty]
        public int priorty { get; set; }
        [BindProperty]
        public int Capacity { get; set; }
        [BindProperty]
        public int TripTime { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public string Station { get; set; }
    }
}
