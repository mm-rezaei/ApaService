using ApaGroup.Framework.Basis.Cores.Constants;

namespace ApaGroup.Framework.Dal.DataStructure.Constants
{
    public class ApaGroupFrameworkBolDataStructureConstant : ConstantBase
    {
        #region Private Fields

        private static readonly ApaGroupFrameworkBolDataStructureConstant _Instance = new ApaGroupFrameworkBolDataStructureConstant();

        #endregion

        #region Internal Properties

        public static ApaGroupFrameworkBolDataStructureConstant Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}