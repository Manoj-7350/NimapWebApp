using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NimapWebApp.Models
{
    public class clsProduct
    {

        [Display(Name = "Id")]
        public int Productid { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public string ProductColor { get; set; }
        //[Required(ErrorMessage = "City is required.")]
        //public string City { get; set; }

        //[Required(ErrorMessage = "Address is required.")]
        //public string Address { get; set; }
    }
}
