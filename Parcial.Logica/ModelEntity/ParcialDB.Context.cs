﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Parcial.Logica.ModelEntity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParcialEntities : DbContext
    {
        public ParcialEntities()
            : base("name=ParcialEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbCategoria> tbCategoria { get; set; }
        public virtual DbSet<tbMembresia> tbMembresia { get; set; }
        public virtual DbSet<tbProducto> tbProducto { get; set; }
        public virtual DbSet<tbProveedor> tbProveedor { get; set; }
    }
}
