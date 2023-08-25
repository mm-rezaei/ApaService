namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    public interface IValidationMessageDataObject
    {
        #region Public Properties

        string Tag { get; }

        string Message { get; }

        #endregion
    }
}