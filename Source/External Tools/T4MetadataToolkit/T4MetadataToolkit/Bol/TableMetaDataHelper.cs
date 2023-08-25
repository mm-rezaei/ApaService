using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace T4MetadataToolkit.Bol
{
    internal static class TableMetaDataHelper
    {
        #region Private Methods

        private static IEnumerable<DataRow> ReadTableInformation(string inConnectionString, string inTableName)
        {
            var table = new DataTable();

            table.Columns.Add("OrdinalPosition");
            table.Columns.Add("FieldName");
            table.Columns.Add("DataType");
            table.Columns.Add("Default");
            table.Columns.Add("Nullable");
            table.Columns.Add("MaximumLength");

            using (var connection = new SqlConnection(inConnectionString))
            {
                try
                {
                    connection.Open();

                    var fields = connection.GetSchema("Columns");

                    foreach (DataRow row in fields.Rows)
                    {
                        if (row["TABLE_NAME"].ToString().ToLower() == inTableName.ToLower())
                        {
                            table.Rows.Add(row["ORDINAL_POSITION"].ToString().PadLeft(2, '0'), row["COLUMN_NAME"],
                                row["DATA_TYPE"], row["COLUMN_DEFAULT"], row["IS_NULLABLE"],
                                row["CHARACTER_MAXIMUM_LENGTH"]);
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Connection Error");
                }
            }

            var result = table.Select("", "OrdinalPosition");

            return result;
        }

        #endregion

        #region Public Methods

        internal static TableMetaDataCollection ReadMetaData()
        {
            var result = TableMetaDataCollection.Load();

            return result;
        }

        internal static void FillTableMetaDataCollection(TableMetaDataCollection inCollection)
        {
            var tables = inCollection.Tables;

            inCollection.Tables = new List<TableMetaData>();

            var allTableNames = TableHelper.ReadTablesName(inCollection.ConnectionString).ToArray();

            foreach (var tableName in allTableNames)
            {
                IList<TableMetaData> allExistingTables = tables.Where(p => p.TableName.ToLower().Trim() == tableName.ToLower().Trim()).ToList();

                if (!allExistingTables.Any())
                {
                    allExistingTables.Add(null);
                }

                foreach (var existingTable in allExistingTables)
                {
                    var table = existingTable == null ? new TableMetaData {TableName = tableName, TableAlias = tableName} : existingTable.Clone(TableMetaData.ColumnsCloneMode.None);

                    inCollection.Tables.Add(table);

                    #region Fill The Table Columns

                    var columns = ReadTableInformation(inCollection.ConnectionString, tableName);

                    foreach (var columnRow in columns)
                    {
                        TableMetaData.ColumnMetaData existingColumn = null;

                        if (existingTable != null)
                        {
                            existingColumn =
                                existingTable.Columns.FirstOrDefault(
                                    p =>
                                        p.ColumnName.ToLower().Trim() ==
                                        columnRow["FieldName"].ToString().ToLower().Trim());
                        }

                        TableMetaData.ColumnMetaData column;

                        if (existingColumn == null)
                        {
                            column = new TableMetaData.ColumnMetaData {ColumnName = columnRow["FieldName"].ToString()};
                        }
                        else
                        {
                            column = existingColumn.Clone();
                            column.ColumnName = columnRow["FieldName"].ToString();
                        }

                        table.Columns.Add(column);

                        if (column.SecureIdAtt != null)
                        {
                            if (
                                !allTableNames.Select(name => name.ToLower().Trim()).Contains(column.SecureIdAtt.ToLower().Trim()))
                            {
                                column.SecureIdAtt = "";
                            }
                        }

                        column.OrdinalPosition = columnRow["OrdinalPosition"].ToString();
                        column.DataType = columnRow["DataType"].ToString();
                        column.Default = columnRow["Default"].ToString();
                        column.Nullable = columnRow["Nullable"].ToString();
                        column.MaximumLength = columnRow["MaximumLength"].ToString();
                    }

                    #endregion
                }
            }
        }

        internal static void SaveMetaData(TableMetaDataCollection inCollection)
        {
            TableMetaDataCollection.Save(inCollection);
        }

        #endregion
    }
}