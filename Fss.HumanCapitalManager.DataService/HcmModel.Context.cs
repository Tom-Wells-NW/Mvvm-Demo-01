﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fss.HumanCapitalManager.DataService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HcmEntities : DbContext
    {
        public HcmEntities()
            : base("name=HcmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Associate> Associates { get; set; }
        public virtual DbSet<AssociateRoleLink> AssociateRoleLinks { get; set; }
        public virtual DbSet<AssociateSkillLink> AssociateSkillLinks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
    }
}