﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeSpokedDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BeSpokedConStr : DbContext
    {
        public BeSpokedConStr()
            : base("name=BeSpokedConStr")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<discount> discounts { get; set; }
        public virtual DbSet<manager> managers { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<sales_person> sales_person { get; set; }
        public virtual DbSet<style> styles { get; set; }
    }
}
