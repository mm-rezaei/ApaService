using System;
using ApaGroup.Framework.Basis.Cores.Attributes;

namespace ApaGroup.Framework.Dal.DataStructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DataModelAttribute : AttributeBase
    {
    }
}
