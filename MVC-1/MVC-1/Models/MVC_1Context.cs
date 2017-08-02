using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC_1.Models
{
    public class MVC_1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MVC_1Context() : base("name=MVC_1Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<MVC_1.Models.Producto> Productos { get; set; }

        public System.Data.Entity.DbSet<MVC_1.Models.TipoDocumento> TipoDocumentoes { get; set; }


        public System.Data.Entity.DbSet<MVC_1.Models.Empleye> Empleyes { get; set; }

        public System.Data.Entity.DbSet<MVC_1.Models.Proveedor> Proveedors { get; set; }

        public System.Data.Entity.DbSet<MVC_1.Models.Cliente> Clientes { get; set; }

        //public System.Data.Entity.DbSet<MVC_1.Models.Empleado> Empleadoes { get; set; }
    }
}
