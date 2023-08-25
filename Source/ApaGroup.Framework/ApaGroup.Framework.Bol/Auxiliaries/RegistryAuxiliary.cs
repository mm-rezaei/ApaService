using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ApaGroup.Framework.Basis.Factory;
using ApaGroup.Framework.Bol.Constants;
using ApaGroup.Framework.Bol.Cores.Auxiliaries;
using ApaGroup.Framework.Dal.DataStructure.DataObjects;
using ApaGroup.Framework.Dal.DataStructure.Enumerations;
using ApaGroup.Framework.Dal.DataStructure.InternalFactory;
using ApaGroup.Framework.IBol.Auxiliaries;
using Microsoft.Win32;

namespace ApaGroup.Framework.Bol.Auxiliaries
{
    public sealed class RegistryAuxiliary : AuxiliaryBase<ApaGroupFrameworkBolConstant, IRegistryAuxiliaryArgs>,
                                            IRegistryAuxiliary
    {
        #region Constructors

        internal RegistryAuxiliary(IRegistryAuxiliaryArgs inAuxiliaryArgs)
            : base(inAuxiliaryArgs)
        {
        }

        #endregion

        #region Private Properties

        private RegistryMainRootType MainRoot { get; set; }

        #endregion

        #region Private Methods

        private RegistryKey GetRegistryMainRootKey()
        {
            RegistryKey result = null;

            var currentRegistryKey = Registry.CurrentUser;

            if (MainRoot == RegistryMainRootType.CurrentUser)
            {
                currentRegistryKey = Registry.CurrentUser;
            }
            else if (MainRoot == RegistryMainRootType.LocalMachine)
            {
                currentRegistryKey = Registry.LocalMachine;
            }

            currentRegistryKey = currentRegistryKey.OpenSubKey("Software", true);

            if (currentRegistryKey != null &&
                currentRegistryKey.OpenSubKey(Assistant.ConstantValues.RegistryRootName, true) == null)
            {
                currentRegistryKey.CreateSubKey(Assistant.ConstantValues.RegistryRootName);
            }

            if (currentRegistryKey != null)
            {
                currentRegistryKey = currentRegistryKey.OpenSubKey(Assistant.ConstantValues.RegistryRootName, true);
            }

            if (currentRegistryKey != null)
            {
                result = currentRegistryKey;
            }

            return result;
        }

        private IList<string> GetAllPathNodes(string inRegistryKeyPath)
        {
            IList<string> result = inRegistryKeyPath.Split(Assistant.ConstantValues.RegistryPathSeparator);

            return result;
        }

        private RegistryKey GetRegistryKey(IList<string> inSubKeyNames, bool inCreateIfDoesntExist)
        {
            RegistryKey result = null;

            if (inSubKeyNames.Any())
            {
                var currentRegistryKey = GetRegistryMainRootKey();

                if (currentRegistryKey != null)
                {
                    var exists = true;

                    foreach (var key in inSubKeyNames)
                    {
                        if (currentRegistryKey != null && currentRegistryKey.OpenSubKey(key, true) == null &&
                            inCreateIfDoesntExist)
                        {
                            currentRegistryKey.CreateSubKey(key);

                            currentRegistryKey = currentRegistryKey.OpenSubKey(key, true);
                        }
                        else if (currentRegistryKey != null && currentRegistryKey.OpenSubKey(key, true) != null)
                        {
                            currentRegistryKey = currentRegistryKey.OpenSubKey(key, true);
                        }
                        else
                        {
                            exists = false;
                            break;
                        }
                    }

                    if (exists)
                    {
                        result = currentRegistryKey;
                    }
                }
            }

            return result;
        }

        #endregion

        #region Protected Methods

        protected override void InitializeFromContextArgs(IRegistryAuxiliaryArgs inAuxiliaryArgs)
        {
            MainRoot = inAuxiliaryArgs.MainRoot;
        }

        #endregion

        #region Public Methods

        public bool ExistsRegistryKey(string inRegistryKeyPath)
        {
            bool result;

            try
            {
                result = GetRegistryKey(GetAllPathNodes(inRegistryKeyPath), false) != null;
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }

            return result;
        }

        public bool ExistsRegistryValue(string inRegistryValuePath)
        {
            var result = false;

            try
            {
                var allPathNodes = GetAllPathNodes(inRegistryValuePath);

                var valueKeyName = allPathNodes[allPathNodes.Count - 1];
                allPathNodes.RemoveAt(allPathNodes.Count - 1);

                var registryKey = GetRegistryKey(allPathNodes, false);

                if (registryKey != null)
                {
                    if (registryKey.GetValue(valueKeyName) != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }

            return result;
        }

        public IRegistryValueDataObject ReadRegistryValue(string inRegistryValuePath)
        {
            IRegistryValueDataObject result = null;

            try
            {
                var allPathNodes = GetAllPathNodes(inRegistryValuePath);

                var valueKeyName = allPathNodes[allPathNodes.Count - 1];
                allPathNodes.RemoveAt(allPathNodes.Count - 1);

                var registryKey = GetRegistryKey(allPathNodes, true);

                if (registryKey != null)
                {
                    if (registryKey.GetValue(valueKeyName) != null)
                    {
                        result = DataObjectInternalFactory.GetNewRegistryValueDataObject(inRegistryValuePath, valueKeyName,
                                                                        registryKey.GetValue(valueKeyName));
                    }
                    else
                    {
                        registryKey.SetValue(valueKeyName, Assistant.ConstantValues.RegistryKeyDefaultValue);
                        result = DataObjectInternalFactory.GetNewRegistryValueDataObject(inRegistryValuePath, valueKeyName,
                                                                        registryKey.GetValue(valueKeyName));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }

            return result;
        }

        public IEnumerable<IRegistryKeyDataObject> ReadAllRegistryKeies(string inRegistryKeyPath)
        {
            IEnumerable<IRegistryKeyDataObject> result = new List<IRegistryKeyDataObject>();

            try
            {
                var readRegistryKey = GetRegistryKey(GetAllPathNodes(inRegistryKeyPath), true);

                if (readRegistryKey != null)
                {
                    result = readRegistryKey.GetSubKeyNames()
                                            .Select(
                                                key =>
                                                DataObjectInternalFactory.GetNewRegistryKeyDataObject(
                                                    inRegistryKeyPath +
                                                    Assistant.ConstantValues.RegistryPathSeparator.ToString(
                                                        CultureInfo.InvariantCulture) + key, key));
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }

            return result;
        }

        public IEnumerable<IRegistryValueDataObject> ReadAllRegistryValues(string inRegistryKeyPath)
        {
            IEnumerable<IRegistryValueDataObject> result = new List<IRegistryValueDataObject>();

            try
            {
                var readRegistryKey = GetRegistryKey(GetAllPathNodes(inRegistryKeyPath), true);

                if (readRegistryKey != null)
                {
                    result = readRegistryKey.GetValueNames()
                                            .Select(
                                                key =>
                                                DataObjectInternalFactory.GetNewRegistryValueDataObject(
                                                    inRegistryKeyPath +
                                                    Assistant.ConstantValues.RegistryPathSeparator.ToString(
                                                        CultureInfo.InvariantCulture) + key, key,
                                                    readRegistryKey.GetValue(key)));
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }

            return result;
        }

        public void SaveRegistryKey(IRegistryKeyDataObject inRegistryKey)
        {
            try
            {
                GetRegistryKey(GetAllPathNodes(inRegistryKey.RegistryKeyPath), true);
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }
        }

        public void SaveRegistryValue(IRegistryValueDataObject inRegistryValue)
        {
            try
            {
                var allPathNodes = GetAllPathNodes(inRegistryValue.RegistryValuePath);

                allPathNodes.RemoveAt(allPathNodes.Count - 1);

                var registryKey = GetRegistryKey(allPathNodes, true);

                if (registryKey != null)
                {
                    registryKey.SetValue(inRegistryValue.Name, inRegistryValue.Value);
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }
        }

        public void DeleteRegistryKey(IRegistryKeyDataObject inRegistryKey)
        {
            try
            {
                var allPathNodes = GetAllPathNodes(inRegistryKey.RegistryKeyPath);

                allPathNodes.RemoveAt(allPathNodes.Count - 1);

                var registryKey = GetRegistryKey(allPathNodes, false);

                if (registryKey != null)
                {
                    registryKey.DeleteSubKey(inRegistryKey.Name);
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }
        }

        public void DeleteRegistryValue(IRegistryValueDataObject inRegistryValue)
        {
            try
            {
                var allPathNodes = GetAllPathNodes(inRegistryValue.RegistryValuePath);

                var registryKey = GetRegistryKey(allPathNodes, false);

                if (registryKey != null)
                {
                    registryKey.DeleteValue(inRegistryValue.Name);
                }
            }
            catch (Exception ex)
            {
                throw ExceptionFactory.GetNewRegistryException(ex);
            }
        }

        public void DeleteRegistryKey(IEnumerable<IRegistryKeyDataObject> inRegistryKey)
        {
            foreach (var registryKey in inRegistryKey)
            {
                DeleteRegistryKey(registryKey);
            }
        }

        public void DeleteRegistryValue(IEnumerable<IRegistryValueDataObject> inRegistryValue)
        {
            foreach (var registryValue in inRegistryValue)
            {
                DeleteRegistryValue(registryValue);
            }
        }

        #endregion
    }
}