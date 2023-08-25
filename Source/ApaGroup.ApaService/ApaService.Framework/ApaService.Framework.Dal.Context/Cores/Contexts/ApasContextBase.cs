using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Dal.Context.Cores.Contexts;

namespace ApaService.Framework.Dal.Context.Cores.Contexts
{
    public abstract class ApasContextBase<TConstantType> : DatabaseContextBase<TConstantType>
        where TConstantType : ConstantBase, new()
    {
    }
}
