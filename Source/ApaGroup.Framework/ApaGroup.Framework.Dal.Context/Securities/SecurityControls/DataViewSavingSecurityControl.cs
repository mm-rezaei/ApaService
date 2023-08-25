using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Basis.Helpers;
using ApaGroup.Framework.Dal.Context.Securities.Attributes;
using ApaGroup.Framework.Dal.Context.Securities.Cores.SecurityControls;
using ApaGroup.Framework.Dal.Context.Securities.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.Attributes;
using ApaGroup.Framework.Dal.DataStructure.Cores.DataModels;
using System.Linq;

namespace ApaGroup.Framework.Dal.Context.Securities.SecurityControls
{
    [SecurityControl(SecurityControlLevelNumber.Level9)]
    internal sealed class DataViewSavingSecurityControl : SecurityControlBase
    {
        #region Constructors

        private DataViewSavingSecurityControl()
        {

        }

        #endregion

        #region Private Fields

        private static readonly DataViewSavingSecurityControl _Instance = new DataViewSavingSecurityControl();

        #endregion

        #region Protected Methods

        /// <param name="inObjects">1- IDataModel</param>
        protected override void CheckSecurityOptions(params object[] inObjects)
        {
            var dataModel = (IDataModel)inObjects[0];

            var dataModelAttribute = ReflectionHelper.GetCustomAttributes<DataModelAttribute>(dataModel.GetType(), false).FirstOrDefault();

            if (dataModelAttribute == null)
            {
                throw ExceptionFactory.GetNewSecurityControlException(SecurityControlType.DataViewSavingPrevented.ToString());
            }
        }

        #endregion

        #region Public Properties

        public static DataViewSavingSecurityControl Instance
        {
            get { return _Instance; }
        }

        #endregion
    }
}
