﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVCContext : DbContext
    {
        public MVCContext()
            : base("name=MVC;Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public virtual DbSet<Empleyes> Empleyes { get; set; }
        public virtual DbSet<Pedidoes> Pedidoes { get; set; }
        public virtual DbSet<Productoes> Productoes { get; set; }
        public virtual DbSet<ProveedoresProductoes> ProveedoresProductoes { get; set; }
        public virtual DbSet<Proveedors> Proveedors { get; set; }
        public virtual DbSet<TipoDocumentoes> TipoDocumentoes { get; set; }
    }
}
