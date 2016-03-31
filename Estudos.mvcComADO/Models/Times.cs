using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Estudos.MvcComADO.Models
{
    public class Times
    {
        [Display(Name ="Id")]
        public int ID_Time { get; set; }

        [Required(ErrorMessage ="Informe o Nome do Time!")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o Estado do Time!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do Time!")]
        public string Cores { get; set; }
    }
}