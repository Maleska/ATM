//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boleteras
    {
        public int Id { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Firma { get; set; }
    }
}