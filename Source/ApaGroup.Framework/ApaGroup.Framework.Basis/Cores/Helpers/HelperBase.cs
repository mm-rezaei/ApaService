using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;

namespace ApaGroup.Framework.Basis.Cores.Helpers
{
    public abstract class HelperBase<TConstantType> : ApaGroupBase<TConstantType>
        where TConstantType : ConstantBase, new()
    {
    }
}