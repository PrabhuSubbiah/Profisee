using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeSpokedApp.Models
{
    public class SalesPersonViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter first name.")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Please enter address.")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter phone.")]
        [Phone]
        public string phone { get; set; }

        [Required(ErrorMessage = "Please enter start date.")]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2025", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2025")]
        public System.DateTime start_date { get; set; }

        [Required(ErrorMessage = "Please enter termination date.")]
        [Range(typeof(DateTime), "1/1/2000", "12/31/2025", ErrorMessage = "Date must be between 01/01/2000 and 12/31/2025")]
        public System.DateTime termination_date { get; set; }

        [Required(ErrorMessage = "Please enter Manager.")]
        public int manager_id { get; set; }
    }
}