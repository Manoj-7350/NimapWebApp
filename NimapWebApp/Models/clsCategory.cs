using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NimapWebApp.Models
{
    public class clsCategory
    {


        [Display(Name = "Id")]
        public int Categoryid { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string CategoryName { get; set; }

        public string CategoryType { get; set; }


    }
}
