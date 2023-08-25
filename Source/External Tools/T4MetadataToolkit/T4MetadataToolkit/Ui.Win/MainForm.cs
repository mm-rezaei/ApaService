using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using T4MetadataToolkit.Bol;

namespace T4MetadataToolkit.Ui.Win
{
    internal partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            comboBoxEntityType.DataSource = Enum.GetValues(typeof(TableMetaData.EntityTypeMode));
            comboBoxDataContract.DataSource = Enum.GetValues(typeof(TableMetaData.DataContractReferenceMode));
            comboBoxWorkflowProperty.DataSource = Enum.GetValues(typeof(TableMetaData.WorkflowPropertySaveOtherChangesMode));

            dataGridViewTableColumns.AutoGenerateColumns = false;
        }

        #endregion

        #region Private Properties

        private TreeNode LastSelectedTreeNode { get; set; }

        private TableMetaDataCollection MetaDataCollection { get; set; }

        #endregion

        #region Private Methods

        private IEnumerable<TreeNode> GetTreeNodes(TableMetaDataCollection inTableMetaDataCollection)
        {
            var result = new List<TreeNode>();

            foreach (var table in inTableMetaDataCollection.Tables)
            {
                var parentNode = result.FirstOrDefault(node => node.Text.ToLower() == table.TableName.ToLower());

                if (parentNode == null)
                {
                    parentNode = new TreeNode { Text = table.TableName };

                    result.Add(parentNode);
                }

                parentNode.Nodes.Add(new TreeNode { Text = table.TableAlias, ForeColor = Color.Snow, Tag = table });
            }

            return result;
        }

        private void treeViewTableList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag == null)
            {
                e.Cancel = true;
            }
        }

        private void treeViewTableList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (LastSelectedTreeNode != null)
            {
                LastSelectedTreeNode.BackColor = Color.MediumTurquoise;

                LastSelectedTreeNode.Text = ((TableMetaData)LastSelectedTreeNode.Tag).TableAlias;
            }

            LastSelectedTreeNode = e.Node;
            e.Node.BackColor = SystemColors.Highlight;

            bindingSourceColumnsMetaData.DataSource = e.Node.Tag;
            bindingSourceColumnsMetaData.ResetBindings(true);

            dataGridViewTableColumns.DataSource = ((TableMetaData)e.Node.Tag).Columns;
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            TableMetaDataHelper.SaveMetaData(MetaDataCollection);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            MetaDataCollection = TableMetaDataHelper.ReadMetaData();

            #region MetaDataCollection Configuration

            var connectionString = textBoxConnectionString.Text;
            var metaDataFile = textBoxT4MetaDataFile.Text;
            var csharpTableKeyFile = textBoxCsharpTableKeyFile.Text;

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                MetaDataCollection.ConnectionString = connectionString;
            }

            if (!string.IsNullOrWhiteSpace(metaDataFile))
            {
                MetaDataCollection.MetaDataFileName = metaDataFile;
            }

            if (!string.IsNullOrWhiteSpace(csharpTableKeyFile))
            {
                MetaDataCollection.CsharpTableKeyFileName = csharpTableKeyFile;
            }

            #endregion

            #region Fill Table ComboBox

            columnSecureIdAtt.Items.Clear();

            columnSecureIdAtt.Items.Add("");

            TableHelper.ReadTablesName(MetaDataCollection.ConnectionString).ToList().ForEach(name => columnSecureIdAtt.Items.Add(name));

            #endregion

            TableMetaDataHelper.FillTableMetaDataCollection(MetaDataCollection);

            #region DataSource Binding

            bindingSourceTableMetaData.DataSource = MetaDataCollection;
            dataGridViewTableColumns.DataSource = new List<TableMetaData.ColumnMetaData>();

            bindingSourceColumnsMetaData.Clear();
            bindingSourceColumnsMetaData.ResetBindings(false);

            treeViewTableList.Nodes.Clear();
            treeViewTableList.Nodes.AddRange(GetTreeNodes(MetaDataCollection).ToArray());

            #endregion

            LastSelectedTreeNode = null;
        }

        private void buttonDuplicateTable_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewTableList.SelectedNode;

            if (selectedNode != null && selectedNode.Tag != null)
            {
                var tableMetaData = (TableMetaData)selectedNode.Tag;

                var duplicate = tableMetaData.Clone();
                MetaDataCollection.Tables.Add(duplicate);

                var newTreeNode = new TreeNode
                {
                    Text = selectedNode.Text,
                    ForeColor = Color.Snow,
                    Tag = duplicate
                };

                selectedNode.Parent.Nodes.Add(newTreeNode);
            }
        }

        private void dataGridViewTableColumns_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 7 && e.ColumnIndex <= 11)
            {
                var currentOveralValue = true;

                for (var index = 0; index < dataGridViewTableColumns.Rows.Count; index++)
                {
                    currentOveralValue = currentOveralValue && ((bool)dataGridViewTableColumns.Rows[index].Cells[e.ColumnIndex].Value);
                }

                for (var index = 0; index < dataGridViewTableColumns.Rows.Count; index++)
                {
                    dataGridViewTableColumns.Rows[index].Cells[e.ColumnIndex].Value = !currentOveralValue;
                }

                dataGridViewTableColumns.RefreshEdit();
            }
        }

        #endregion
    }
}