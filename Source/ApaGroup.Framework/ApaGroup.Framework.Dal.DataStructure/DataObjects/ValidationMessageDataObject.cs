namespace ApaGroup.Framework.Dal.DataStructure.DataObjects
{
    public class ValidationMessageDataObject : IValidationMessageDataObject
    {
        #region Constructors

        public ValidationMessageDataObject(string inTag, string inMessage)
        {
            Tag = inTag;
            Message = inMessage;
        }

        #endregion

        #region IValidationMessage Members

        public string Tag { get; private set; }

        public string Message { get; private set; }

        #endregion
    }
}