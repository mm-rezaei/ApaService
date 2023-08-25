
using System;

namespace ApaGroup.Framework.Dal.DataStructure.Enumerations
{
    [Flags]
    public enum AccountType
    {
        Administrator,
        Requirement,
        Seller,
        Buyer
    }
}
