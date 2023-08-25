using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace T4MetadataToolkit.Bol
{
    internal class TableHelper
    {
        #region Public Methods

        public static IEnumerable<string> ReadTablesName(string inConnectionString)
        {
            IList<string> result = new List<string>();

            using (var connention = new SqlConnection(inConnectionString))
            {
                try
                {
                    connention.Open();

                    const string objectName = "Tables";

                    var tableList = connention.GetSchema(objectName);

                    if (tableList != null)
                    {
                        for (var index = 0; index < tableList.Rows.Count; index++)
                        {
                            var tableName = tableList.Rows[index].ItemArray[2].ToString();

                            if (tableName.ToLower().Trim() != "sysdiagrams")
                            {
                                result.Add(tableName);
                            }
                        }
                    }

                    connention.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Connection Error");
                }
            }

            return result.OrderBy(p => p);
        }

        #endregion
    }
}
