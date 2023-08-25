using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace T4MetadataToolkit.Bol
{
    [Serializable]
    internal class TableMetaDataCollection
    {
        #region Constructors

        private TableMetaDataCollection()
        {
            Tables = new List<TableMetaData>();
        }

        #endregion

        #region Private Properties

        private static string BinaryFileName
        {
            get { return "T4MetadataToolkit.bin"; }
        }

        private static string T4TableKeyFileName
        {
            get { return "T4MetadataToolkit.xml"; }
        }

        #endregion

        #region Public Properties

        public string ConnectionString { get; set; }

        public string MetaDataFileName { get; set; }

        public string CsharpTableKeyFileName { get; set; }

        public IList<TableMetaData> Tables { get; set; }

        #endregion

        #region Public Methods

        public DataTable GetOverallDataTable()
        {
            var result = new DataTable { TableName = "T4Metadata" };

            result.Columns.Add("Name");
            result.Columns.Add("ParentName");
            result.Columns.Add("Type");
            result.Columns.Add("Attribute");

            Func<string, string, string> calculateTableName =
                (inTableName, inTableAlias) => string.IsNullOrWhiteSpace(inTableAlias) ? inTableName : inTableAlias;

            foreach (var tableMetaData in Tables)
            {
                if (!string.IsNullOrWhiteSpace(tableMetaData.DataModelAttribute))
                {
                    result.Rows.Add(calculateTableName(tableMetaData.TableName, tableMetaData.TableAlias), string.Empty, "Table", tableMetaData.DataModelAttribute);
                }

                foreach (var columnMetaData in tableMetaData.Columns)
                {
                    if (!string.IsNullOrWhiteSpace(columnMetaData.PropertyAttribute))
                    {
                        result.Rows.Add(columnMetaData.ColumnName, calculateTableName(tableMetaData.TableName, tableMetaData.TableAlias), "Column", columnMetaData.PropertyAttribute);
                    }
                }
            }

            return result;
        }

        public static TableMetaDataCollection Load()
        {
            var result = new TableMetaDataCollection();

            if (File.Exists(BinaryFileName))
            {
                var fileStream = File.OpenRead(BinaryFileName);

                IFormatter formatter = new BinaryFormatter();
                result = (TableMetaDataCollection)formatter.Deserialize(fileStream);

                fileStream.Close();
            }

            return result;
        }

        public static void Save(TableMetaDataCollection inCollection)
        {
            var collection = new TableMetaDataCollection
            {
                ConnectionString = inCollection.ConnectionString,
                MetaDataFileName = inCollection.MetaDataFileName,
                CsharpTableKeyFileName = inCollection.CsharpTableKeyFileName
            };

            #region Prepare Information

            foreach (var tableMetaData in inCollection.Tables)
            {
                var table = tableMetaData.Clone(TableMetaData.ColumnsCloneMode.OnlyFillColumns);

                if (!string.IsNullOrWhiteSpace(table.TableAlias) || !string.IsNullOrWhiteSpace(table.DataModelAttribute) || table.Columns.Count != 0)
                {
                    collection.Tables.Add(table);
                }
            }

            #endregion

            #region Save Binary

            var fileStream = File.Create(BinaryFileName);

            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, collection);

            fileStream.Close();

            #endregion

            #region Save MetaData

            var metaData = collection.GetOverallDataTable();

            metaData.WriteXml(collection.MetaDataFileName);

            #endregion

            var dataTableKey = new DataTable { TableName = "T4MetadataToolkit" };

            dataTableKey.Columns.Add("Name");
            dataTableKey.Columns.Add("Key");

            #region Save Xml TableKey File

            if (File.Exists(T4TableKeyFileName))
            {
                dataTableKey.ReadXml(T4TableKeyFileName);
            }

            var keysList = (from DataRow dataRow in dataTableKey.Rows select new Tuple<string, int>(dataRow["Name"].ToString(), Convert.ToInt32(dataRow["Key"]))).ToList();

            foreach (var table in TableHelper.ReadTablesName(collection.ConnectionString))
            {
                if (keysList.All(p => p.Item1.ToLower().Trim() != table.ToLower().Trim()))
                {
                    var key = 1;

                    if (keysList.Any())
                    {
                        key = keysList.Max(p => p.Item2) + 1;
                    }

                    dataTableKey.Rows.Add(table, key);
                    keysList.Add(new Tuple<string, int>(table, key));
                }
            }

            dataTableKey.WriteXml(T4TableKeyFileName);

            #endregion

            #region Save C# Table Keys

            var fileContent = "";

            fileContent += "using ApaGroup.Framework.Basis.Cores.Helpers;" + Environment.NewLine;
            fileContent += "using ApaGroup.Framework.Basis.Factory;" + Environment.NewLine;
            fileContent += "using ApaGroup.Framework.Basis.Locks;" + Environment.NewLine;
            fileContent += "using ApaGroup.Framework.Dal.Context.Constants;" + Environment.NewLine;
            fileContent += "using ApaGroup.Framework.Dal.DataStructure.Attributes;" + Environment.NewLine;
            fileContent += "using System;" + Environment.NewLine;
            fileContent += "using System.Collections.Concurrent;" + Environment.NewLine;
            fileContent += "using System.Collections.Generic;" + Environment.NewLine;
            fileContent += "using System.Linq;" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "namespace ApaGroup.Framework.Dal.Context.Securities.Helpers" + Environment.NewLine;
            fileContent += "{" + Environment.NewLine;
            fileContent += "    public class DatabaseObjectKeyHelper : HelperBase<ApaGroupFrameworkDalContextConstant>" + Environment.NewLine;
            fileContent += "    {" + Environment.NewLine;
            fileContent += "        #region Constructors" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        static DatabaseObjectKeyHelper()" + Environment.NewLine;
            fileContent += "        {" + Environment.NewLine;
            fileContent += "            InternalLock = new InternalLock();" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "            TableKeys = new Dictionary<string, short>" + Environment.NewLine;
            fileContent += "            {" + Environment.NewLine;

            fileContent = dataTableKey.Rows.Cast<DataRow>().Aggregate(fileContent, (current, row) => current + (string.Format("                {{\"{0}\".ToLower().Trim(), {1}}},", row["Name"].ToString(), row["Key"].ToString()) + Environment.NewLine));

            fileContent += "            };" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "            TypeKeys = new ConcurrentDictionary<Type, short>();" + Environment.NewLine;
            fileContent += "        }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        #endregion" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        #region Private Properties" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        private static InternalLock InternalLock { get; set; }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        private static Dictionary<string, short> TableKeys { get; set; }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        private static ConcurrentDictionary<Type, short> TypeKeys { get; set; }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        #endregion" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        #region Private Methods" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        public static short GetTableKey(string inTableName)" + Environment.NewLine;
            fileContent += "        {" + Environment.NewLine;
            fileContent += "            return TableKeys[inTableName.ToLower().Trim()];" + Environment.NewLine;
            fileContent += "        }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        public static short GetTypeKey(Type inType)" + Environment.NewLine;
            fileContent += "        {" + Environment.NewLine;
            fileContent += "            if (!TypeKeys.ContainsKey(inType))" + Environment.NewLine;
            fileContent += "            {" + Environment.NewLine;
            fileContent += "                lock (InternalLock)" + Environment.NewLine;
            fileContent += "                {" + Environment.NewLine;
            fileContent += "                    if (!TypeKeys.ContainsKey(inType))" + Environment.NewLine;
            fileContent += "                    {" + Environment.NewLine;
            fileContent += "                        var dataObjectAttribute = Assistant.Reflection.GetCustomAttributes<DatabaseObjectAttribute>(inType, false).FirstOrDefault();" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "                        if (dataObjectAttribute == null)" + Environment.NewLine;
            fileContent += "                        {" + Environment.NewLine;
            fileContent += "                            throw ExceptionFactory.GetNewFactoryException(null, \"The 'DatabaseObjectAttribute' object is null.\");" + Environment.NewLine;
            fileContent += "                        }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "                        if (!TypeKeys.TryAdd(inType, GetTableKey(dataObjectAttribute.DatabaseObject)))" + Environment.NewLine;
            fileContent += "                        {" + Environment.NewLine;
            fileContent += "                            throw ExceptionFactory.GetNewFactoryException(null, \"The table key could not add to the cache.\");" + Environment.NewLine;
            fileContent += "                        }" + Environment.NewLine;
            fileContent += "                    }" + Environment.NewLine;
            fileContent += "                }" + Environment.NewLine;
            fileContent += "            }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "            var result = TypeKeys[inType];" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "            return result;" + Environment.NewLine;
            fileContent += "        }" + Environment.NewLine;
            fileContent += "" + Environment.NewLine;
            fileContent += "        #endregion" + Environment.NewLine;
            fileContent += "    }" + Environment.NewLine;
            fileContent += "}" + Environment.NewLine;

            File.WriteAllText(collection.CsharpTableKeyFileName, fileContent);

            #endregion
        }

        #endregion
    }
}