﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Data.DBModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BankAccountEntities : DbContext
    {
        public BankAccountEntities()
            : base("name=BankAccountEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<Incomes> Incomes { get; set; }
        public virtual DbSet<Outcomes> Outcomes { get; set; }
    }
}
