﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InventarioEntities : DbContext
    {
        public InventarioEntities()
            : base("name=InventarioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Tipos> Tipos { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Boleteras> Boleteras { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual ObjectResult<sp_getAllInvetory_Result> sp_getAllInvetory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAllInvetory_Result>("sp_getAllInvetory");
        }
    
        public virtual ObjectResult<ps_getMarcas_Result> ps_getMarcas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ps_getMarcas_Result>("ps_getMarcas");
        }
    
        public virtual ObjectResult<sp_getAllTipos_Result> sp_getAllTipos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAllTipos_Result>("sp_getAllTipos");
        }
    
        public virtual ObjectResult<sp_getAllRol_Result> sp_getAllRol()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAllRol_Result>("sp_getAllRol");
        }
    
        public virtual ObjectResult<SP_getAllPeople_Result> SP_getAllPeople()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_getAllPeople_Result>("SP_getAllPeople");
        }
    
        public virtual ObjectResult<sp_getAllRol1_Result> sp_getAllRol1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getAllRol1_Result>("sp_getAllRol1");
        }
    }
}
