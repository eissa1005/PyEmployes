﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PYEmployeeEntities : DbContext
    {
        public PYEmployeeEntities()
            : base("name=PYEmployeeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Employees> tbl_Employees { get; set; }
        public virtual DbSet<tbl_PyInOut> tbl_PyInOut { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
    }
}
