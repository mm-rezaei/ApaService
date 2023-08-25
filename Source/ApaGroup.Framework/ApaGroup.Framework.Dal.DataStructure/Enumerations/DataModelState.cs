using System;

namespace ApaGroup.Framework.Dal.DataStructure.Enumerations
{
    [Flags]
    public enum DataModelState
    {
        Unchanged = 0x1,
        Added = 0x2,
        Modified = 0x4,
        Deleted = 0x8,
        AddedDeleted = 0xA
    }
}
