﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SerhatPoturCV.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SerhatPoturCVEntities : DbContext
    {
        public SerhatPoturCVEntities()
            : base("name=SerhatPoturCVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Hakkımda> Hakkımda { get; set; }
        public virtual DbSet<Kariyer> Kariyer { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Projeler> Projeler { get; set; }
        public virtual DbSet<Yetenekler> Yetenekler { get; set; }
    }
}
