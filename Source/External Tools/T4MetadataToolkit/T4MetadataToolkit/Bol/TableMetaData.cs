using System;
using System.Collections.Generic;

namespace T4MetadataToolkit.Bol
{
    [Serializable]
    internal class TableMetaData
    {
        #region Constructors

        internal TableMetaData()
        {
            Columns = new List<ColumnMetaData>();
        }

        #endregion

        #region Public Properties

        public string TableName { get; set; }

        public string TableAlias { get; set; }

        public EntityTypeMode EntityTypeAtt { get; set; }

        public DataContractReferenceMode DataContractAtt { get; set; }

        public string WorkflowPropertyNameAtt { get; set; }

        public WorkflowPropertySaveOtherChangesMode WorkflowPropertySaveOtherChangesAtt { get; set; }

        public string ManualAtt { get; set; }

        public string DataModelAttribute
        {
            get
            {
                var result = "";

                result += string.Format("[DatabaseObject(\"{0}\")]", TableName);

                switch (EntityTypeAtt)
                {
                    case EntityTypeMode.DataModel:
                        result += "[DataModel]";
                        break;
                    case EntityTypeMode.DataView:
                        result += "[DataView]";
                        break;
                }

                switch (DataContractAtt)
                {
                    case DataContractReferenceMode.True:
                        result += "[DataContract(IsReference = true)]";
                        break;
                    case DataContractReferenceMode.False:
                        result += "[DataContract(IsReference = false)]";
                        break;
                }

                if (!string.IsNullOrWhiteSpace(WorkflowPropertyNameAtt))
                {
                    if (WorkflowPropertySaveOtherChangesAtt != WorkflowPropertySaveOtherChangesMode.None)
                    {
                        result += string.Format("[WorkflowProperty(\"{0}\", {1})]", WorkflowPropertyNameAtt, WorkflowPropertySaveOtherChangesAtt.ToString().ToLower());
                    }
                    else
                    {
                        result += string.Format("[WorkflowProperty(\"{0}\")]", WorkflowPropertyNameAtt);
                    }
                }

                result += ManualAtt;

                return result;
            }
        }

        public IList<ColumnMetaData> Columns { get; set; }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return TableName;
        }

        public TableMetaData Clone(ColumnsCloneMode inColumnsCloneMode)
        {
            var result = new TableMetaData
            {
                TableName = TableName,
                TableAlias = TableAlias,
                EntityTypeAtt = EntityTypeAtt,
                DataContractAtt = DataContractAtt,
                WorkflowPropertyNameAtt = WorkflowPropertyNameAtt,
                WorkflowPropertySaveOtherChangesAtt = WorkflowPropertySaveOtherChangesAtt,
                ManualAtt = ManualAtt
            };

            if (inColumnsCloneMode != ColumnsCloneMode.None)
            {
                foreach (var columnMetaData in Columns)
                {
                    if (inColumnsCloneMode == ColumnsCloneMode.All || !string.IsNullOrWhiteSpace(columnMetaData.PropertyAttribute))
                    {
                        result.Columns.Add(columnMetaData.Clone());
                    }
                }
            }

            return result;
        }

        public TableMetaData Clone()
        {
            return Clone(ColumnsCloneMode.All);
        }

        #endregion

        #region Public Enumeration

        public enum EntityTypeMode
        {
            None,
            DataModel,
            DataView
        }

        public enum DataContractReferenceMode
        {
            None,
            True,
            False
        }

        public enum WorkflowPropertySaveOtherChangesMode
        {
            None,
            True,
            False
        }

        public enum ColumnsCloneMode
        {
            None,
            All,
            OnlyFillColumns
        }

        #endregion

        #region Public Class

        [Serializable]
        public class ColumnMetaData
        {
            #region Public Properties

            public string OrdinalPosition { get; set; }

            public string ColumnName { get; set; }

            public string DataType { get; set; }

            public string Default { get; set; }

            public string Nullable { get; set; }

            public string MaximumLength { get; set; }

            public string PropertyDefaultValueAtt { get; set; }

            public bool ValueChangePreventerAdministratorAtt { get; set; }

            public bool ValueChangePreventerRequirementAtt { get; set; }

            public bool ValueChangePreventerBuyerAtt { get; set; }

            public bool ValueChangePreventerSellerAtt { get; set; }

            public bool DataMemberAtt { get; set; }

            public string SecureIdAtt { get; set; }

            public string ManualAtt { get; set; }

            public string PropertyAttribute
            {
                get
                {
                    var result = "";

                    result += DataMemberAtt ? "[DataMember]" : "";
                    result += !string.IsNullOrWhiteSpace(PropertyDefaultValueAtt) ? string.Format("[PropertyDefaultValue({0})]", PropertyDefaultValueAtt.Trim()) : "";

                    if (ValueChangePreventerAdministratorAtt || ValueChangePreventerRequirementAtt || ValueChangePreventerBuyerAtt || ValueChangePreventerSellerAtt)
                    {
                        var valueChangePreventerAtt = "";

                        if (ValueChangePreventerAdministratorAtt)
                        {
                            if (valueChangePreventerAtt != "")
                            {
                                valueChangePreventerAtt += " | ";
                            }

                            valueChangePreventerAtt += "AccountType.Administrator";
                        }

                        if (ValueChangePreventerRequirementAtt)
                        {
                            if (valueChangePreventerAtt != "")
                            {
                                valueChangePreventerAtt += " | ";
                            }

                            valueChangePreventerAtt += "AccountType.Requirement";
                        }

                        if (ValueChangePreventerBuyerAtt)
                        {
                            if (valueChangePreventerAtt != "")
                            {
                                valueChangePreventerAtt += " | ";
                            }

                            valueChangePreventerAtt += "AccountType.Buyer";
                        }

                        if (ValueChangePreventerSellerAtt)
                        {
                            if (valueChangePreventerAtt != "")
                            {
                                valueChangePreventerAtt += " | ";
                            }

                            valueChangePreventerAtt += "AccountType.Seller";
                        }

                        result += string.Format("[ValueChangePreventer({0})]", valueChangePreventerAtt);
                    }

                    result += !string.IsNullOrWhiteSpace(SecureIdAtt) ? string.Format("[SecureId(\"{0}\")]", SecureIdAtt.Trim()) : "";
                    result += ManualAtt;

                    return result;
                }
            }

            #endregion

            #region Public Methods

            public ColumnMetaData Clone()
            {
                var result = new ColumnMetaData
                {
                    OrdinalPosition = OrdinalPosition,
                    ColumnName = ColumnName,
                    DataType = DataType,
                    Default = Default,
                    Nullable = Nullable,
                    MaximumLength = MaximumLength,
                    PropertyDefaultValueAtt = PropertyDefaultValueAtt,
                    ValueChangePreventerAdministratorAtt = ValueChangePreventerAdministratorAtt,
                    ValueChangePreventerRequirementAtt = ValueChangePreventerRequirementAtt,
                    ValueChangePreventerBuyerAtt = ValueChangePreventerBuyerAtt,
                    ValueChangePreventerSellerAtt = ValueChangePreventerSellerAtt,
                    DataMemberAtt = DataMemberAtt,
                    SecureIdAtt = SecureIdAtt,
                    ManualAtt = ManualAtt
                };

                return result;
            }

            #endregion
        }

        #endregion
    }
}