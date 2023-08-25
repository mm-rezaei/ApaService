using ApaGroup.Framework.Basis.Cores.Constants;
using ApaGroup.Framework.Basis.Cores.Systems;
using ApaGroup.Framework.IBol.Cores.Auxiliaries;

namespace ApaGroup.Framework.Bol.Cores.Auxiliaries
{
    public abstract class AuxiliaryBase<TConstantType, TAuxiliaryArgsType> : ApaGroupBase<TConstantType>,
                                                                             IAuxiliary
        where TConstantType : ConstantBase, new()
        where TAuxiliaryArgsType : IAuxiliaryArgs
    {
        #region Constructors

        protected AuxiliaryBase(TAuxiliaryArgsType inAuxiliaryArgs)
        {
            InitializeProperties(inAuxiliaryArgs);
        }

        #endregion

        #region Private Methods

        private void InitializeProperties(TAuxiliaryArgsType inAuxiliaryArgs)
        {
            InitializeFromContextArgs(inAuxiliaryArgs);
        }

        #endregion

        #region Protected Methods

        protected abstract void InitializeFromContextArgs(TAuxiliaryArgsType inAuxiliaryArgs);

        #endregion
    }
}