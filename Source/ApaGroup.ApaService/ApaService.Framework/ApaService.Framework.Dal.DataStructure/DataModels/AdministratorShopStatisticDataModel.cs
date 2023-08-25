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
    [DatabaseObject("ShopStatistics")][DataModel][DataContract(IsReference = true)]
    public partial class AdministratorShopStatisticDataModel : ApasDataModelBase
    {
    	#region Private Fields
    
    	private int _Id;
    
    	private byte[] _RowVersion;
    
    	private string _ApaGroupRank;
    
    	private int _LikeShop;
    
    	private int _DislikeShop;
    
    	private int _BoughtCount;
    
    	#endregion
    
    	#region Public Properties
    
    	[DataMember]
        public override int Id { get{ return _Id; } set{ SetValue("Id", ref _Id, value); } }
    
    	[DataMember]
        public override byte[] RowVersion { get{ return _RowVersion; } set{ SetValue("RowVersion", ref _RowVersion, value); } }
    
    	[DataMember]
        public string ApaGroupRank { get{ return _ApaGroupRank; } set{ SetValue("ApaGroupRank", ref _ApaGroupRank, value); } }
    
    	[PropertyDefaultValue(0)][DataMember]
        public int LikeShop { get{ return _LikeShop; } set{ SetValue("LikeShop", ref _LikeShop, value); } }
    
    	[PropertyDefaultValue(0)][DataMember]
        public int DislikeShop { get{ return _DislikeShop; } set{ SetValue("DislikeShop", ref _DislikeShop, value); } }
    
    	[PropertyDefaultValue(0)][DataMember]
        public int BoughtCount { get{ return _BoughtCount; } set{ SetValue("BoughtCount", ref _BoughtCount, value); } }
    
    	#endregion
    }
}