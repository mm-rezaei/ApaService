using System;

namespace ApaGroup.Framework.Identification.Cores
{
    public interface IAssemblyIdentification
    {
        #region Public Properties

        Guid Identifier { get; }

        string Version { get; }

        #endregion
    }
}