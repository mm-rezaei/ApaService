using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;
using ApaService.Framework.IBol.Cores.Auxiliaries;

namespace ApaService.Framework.Bol.Cores.Auxiliaries
{
    public abstract class ApasAuxiliaryBase<TConstantType, TAuxiliaryArgsType> : AuxiliaryBase<TConstantType, TAuxiliaryArgsType>, IApasAuxiliary
        where TConstantType : ConstantBase, new()
        where TAuxiliaryArgsType : IAuxiliaryArgs
    {
        #region Constructors

        protected ApasAuxiliaryBase(TAuxiliaryArgsType inAuxiliaryArgs)
            : base(inAuxiliaryArgs)
        {
        }

        #endregion
    }
}
