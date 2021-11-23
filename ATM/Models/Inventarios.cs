using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class Inventarios
    {
        [Required(ErrorMessage = "Favor de agregar una descripción")]
        public string nombre { get; set; }
        [Required(ErrorMessage ="Favor de agregar una cantidad")]
        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="Favor de agregar solo números")]
        public int cantidad { get; set; }

        public bool activo { get; set; }
        public string CodigoBarras { get; set; }
        public string id { get; set; }
    }
}