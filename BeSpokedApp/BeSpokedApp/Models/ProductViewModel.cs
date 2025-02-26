using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BeSpokedApp.Models
{
    public class ProductViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter manufacturer.")]
        public string manufacturer { get; set; }

        [Required(ErrorMessage = "Please select style.")]
        public int style_id { get; set; }

        [Required(ErrorMessage = "Please enter purchase price.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]+)?$", ErrorMessage = "Please enter a valid decimal number.")]
        public decimal purchase_price { get; set; }

        [Required(ErrorMessage = "Please enter purchase price.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]+)?$", ErrorMessage = "Please enter a valid decimal number.")]
        public decimal sales_price { get; set; }

        [Required(ErrorMessage = "Please enter Quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer number")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Please enter commission percentage.")]
        [RegularExpression(@"^[0-9]+(\.[0-9]+)?$", ErrorMessage = "Please enter a valid decimal number.")]
        public decimal commission { get; set; }

    }
}