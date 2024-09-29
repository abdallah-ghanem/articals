using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace articals.Core
{
    public class Catigory
    {
        [Required]
        [Display(Name ="ID")]
        public int id {  get; set; }
        [Required(ErrorMessage ="This section is required")]
        [Display(Name = "Name of Artical")]
        [MaxLength(100,ErrorMessage ="Max Length=100")]
        [MinLength(5, ErrorMessage = "Min Length=5")]
        [DataType(DataType.Text)]
        public string name { get; set; }
    }
}
