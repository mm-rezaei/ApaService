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
    [DatabaseObject("Location")][DataModel][DataContract(IsReference = true)]
    public partial class AdministratorLocationDataModel : ApasDataModelBase
    {
    	#region Private Fields
    
    	private int _Id;
    
    	private byte[] _RowVersion;
    
    	private Nullable<int> _ParentId;
    
    	private string _HierarchyCode;
    
    	private string _Title;
    
    	private Nullable<System.Guid> _LogoIdentifier;
    
    	#endregion
    
    	#region Public Properties
    
    	[DataMember]
        public override int Id { get{ return _Id; } set{ SetValue("Id", ref _Id, value); } }
    
    	[DataMember]
        public override byte[] RowVersion { get{ return _RowVersion; } set{ SetValue("RowVersion", ref _RowVersion, value); } }
    
    	[DataMember]
        public Nullable<int> ParentId { get{ return _ParentId; } set{ SetValue("ParentId", ref _ParentId, value); } }
    
    	[DataMember]
        public string HierarchyCode { get{ return _HierarchyCode; } set{ SetValue("HierarchyCode", ref _HierarchyCode, value); } }
    
    	[DataMember]
        public string Title { get{ return _Title; } set{ SetValue("Title", ref _Title, value); } }
    
    	[PropertyDefaultValue(null)][DataMember]
        public Nullable<System.Guid> LogoIdentifier { get{ return _LogoIdentifier; } set{ SetValue("LogoIdentifier", ref _LogoIdentifier, value); } }
    
    	#endregion
    }
}
