//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using ApaGroup.Framework.Basis.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Securities.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using System;
using System.Runtime.Serialization;

namespace ApaGroup.Framework.Dal.DataStructure.Securities.DataModels
{
    
    public partial class SecurityPrivacyAccountPermissionGroupDataModel : DataModelBase
    {
    	#region Private Fields
    
    	private int _Id;
    
    	private byte[] _RowVersion;
    
    	private int _AccountId;
    
    	private int _PrivacyPermisionGroupId;
    
    	#endregion
    
    	#region Public Properties
    
    	
        public override int Id { get{ return _Id; } set{ SetValue("Id", ref _Id, value); } }
    
    	
        public override byte[] RowVersion { get{ return _RowVersion; } set{ SetValue("RowVersion", ref _RowVersion, value); } }
    
    	
        public int AccountId { get{ return _AccountId; } set{ SetValue("AccountId", ref _AccountId, value); } }
    
    	
        public int PrivacyPermisionGroupId { get{ return _PrivacyPermisionGroupId; } set{ SetValue("PrivacyPermisionGroupId", ref _PrivacyPermisionGroupId, value); } }
    
    	#endregion
    }
}
