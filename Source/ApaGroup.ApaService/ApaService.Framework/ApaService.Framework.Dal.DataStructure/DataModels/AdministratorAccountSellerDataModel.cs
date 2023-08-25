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
    [DatabaseObject("AccountSeller")][DataModel][DataContract(IsReference = true)]
    public partial class AdministratorAccountSellerDataModel : AdministratorAccountDataModelBase
    {
    	#region Private Fields
    
    	private int _MinimumChargeAmountForSelling;
    
    	#endregion
    
    	#region Public Properties
    
    	[PropertyDefaultValue(0)][DataMember]
        public int MinimumChargeAmountForSelling { get{ return _MinimumChargeAmountForSelling; } set{ SetValue("MinimumChargeAmountForSelling", ref _MinimumChargeAmountForSelling, value); } }
    
    	#endregion
    }
}
