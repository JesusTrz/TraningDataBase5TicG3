﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraningDataBase5TicG3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestDbMensageriaEntities : DbContext
    {
        public TestDbMensageriaEntities()
            : base("name=TestDbMensageriaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<profesiones> profesiones { get; set; }
        public virtual DbSet<profesionespersonas> profesionespersonas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
    }
}
