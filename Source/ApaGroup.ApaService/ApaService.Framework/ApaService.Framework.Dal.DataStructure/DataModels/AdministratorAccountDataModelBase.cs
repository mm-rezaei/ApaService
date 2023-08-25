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
using ApaService.Framework.Dal.DataStructure.Cores.DataModels;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using System;
using System.Runtime.Serialization;

namespace ApaService.Framework.Dal.DataStructure.DataModels
{
    [DatabaseObject("Account")][DataModel][DataContract(IsReference = true)]
    public partial class AdministratorAccountDataModelBase : ApasDataModelBase
    {
    	#region Private Fields
    
    	private int _Id;
    
    	private byte[] _RowVersion;
    
    	private System.DateTime _CreateDate;
    
    	private System.DateTime _UpdateDate;
    
    	private int _UserId;
    
    	private Nullable<System.Guid> _Image;
    
    	private int _ChargeAmount;
    
    	private bool _Enable;
    
    	#endregion
    
    	#region Public Properties
    
    	[DataMember]
        public override int Id { get{ return _Id; } set{ SetValue("Id", ref _Id, value); } }
    
    	[DataMember]
        public override byte[] RowVersion { get{ return _RowVersion; } set{ SetValue("RowVersion", ref _RowVersion, value); } }
    
    	[ValueChangePreventer][DataMember]
        public System.DateTime CreateDate { get{ return _CreateDate; } set{ SetValue("CreateDate", ref _CreateDate, value); } }
    
    	[DataMember]
        public System.DateTime UpdateDate { get{ return _UpdateDate; } set{ SetValue("UpdateDate", ref _UpdateDate, value); } }
    
    	[ValueChangePreventer][DataMember]
        public int UserId { get{ return _UserId; } set{ SetValue("UserId", ref _UserId, value); } }
    
    	[DataMember]
        public Nullable<System.Guid> Image { get{ return _Image; } set{ SetValue("Image", ref _Image, value); } }
    
    	[PropertyDefaultValue(0)][DataMember]
        public int ChargeAmount { get{ return _ChargeAmount; } set{ SetValue("ChargeAmount", ref _ChargeAmount, value); } }
    
    	[PropertyDefaultValue(true)][DataMember]
        public bool Enable { get{ return _Enable; } set{ SetValue("Enable", ref _Enable, value); } }
    
    	#endregion
    }
}
