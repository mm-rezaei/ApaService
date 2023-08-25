using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;

namespace ApaGroup.Framework.Dal.Context.Cores.Contexts
{
    public abstract class ContextBase<TConstantType> : ApaGroupBase<TConstantType>
        where TConstantType : ConstantBase, new()
    {
    }
}