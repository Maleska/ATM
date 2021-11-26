using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Favor de agregar un usuario")]
        public string usuario { get; set; }

        [Required(ErrorMessage ="Favor de agregar una contraseña")]
        [DataType(DataType.Password)]
        [StringLength(8,ErrorMessage ="La contraseña debe de tener 6 caracteres ",MinimumLength =6)]
        public string password { get; set; }


    }
}