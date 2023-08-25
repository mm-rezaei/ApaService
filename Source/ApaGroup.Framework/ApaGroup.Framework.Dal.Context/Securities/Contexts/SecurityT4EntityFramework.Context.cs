﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApaGroup.Framework.Dal.Context.Securities.Contexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using ApaGroup.Framework.Dal.DataStructure.Securities.DataModels;
    
    public partial class SecurityEntities : DbContext
    {
        public SecurityEntities()
            : base("name=SecurityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SecurityAccountDataModelBase> SecurityAccountDataModelBases { get; set; }
        public virtual DbSet<SecurityPrivacyAccountPermissionGroupDataModel> SecurityPrivacyAccountPermissionGroupDataModels { get; set; }
        public virtual DbSet<SecurityPrivacyGroupDataModel> SecurityPrivacyGroupDataModels { get; set; }
        public virtual DbSet<SecurityPrivacyPermissionDataModel> SecurityPrivacyPermissionDataModels { get; set; }
        public virtual DbSet<SecurityPrivacyPermissionGroupDataModel> SecurityPrivacyPermissionGroupDataModels { get; set; }
        public virtual DbSet<SecurityPrivacySecureDataDataModel> SecurityPrivacySecureDataDataModels { get; set; }
        public virtual DbSet<SecurityPrivacyAccountPermissionDataModel> SecurityPrivacyAccountPermissionDataModels { get; set; }
        public virtual DbSet<SecurityUserDataModel> SecurityUserDataModels { get; set; }
        public virtual DbSet<SecurityUserLoginDataModel> SecurityUserLoginDataModels { get; set; }
    }
}
