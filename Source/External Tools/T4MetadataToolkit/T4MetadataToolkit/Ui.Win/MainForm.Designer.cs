namespace T4MetadataToolkit.Ui.Win
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelConnectionString = new System.Windows.Forms.Panel();
            this.labelT4TableKeyFile = new System.Windows.Forms.Label();
            this.labelT4MetaDataFile = new System.Windows.Forms.Label();
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxCsharpTableKeyFile = new System.Windows.Forms.TextBox();
            this.bindingSourceTableMetaData = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxT4MetaDataFile = new System.Windows.Forms.TextBox();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelInformation = new System.Windows.Forms.TableLayoutPanel();
            this.labelTableList = new System.Windows.Forms.Label();
            this.labelColumns = new System.Windows.Forms.Label();
            this.panelTableColumns = new System.Windows.Forms.Panel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTableColumns = new System.Windows.Forms.DataGridView();
            this.columnOrdinalPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNullable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMaximumLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPropertyDefaultValueAtt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnChangePreventerAdministratorAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnValueChangePreventerRequirementAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnValueChangePreventerBuyerAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnValueChangePreventerSellerAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnDataMemberAtt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnSecureIdAtt = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnSetAttribute = new System.Windows.Forms.DataGridViewButtonColumn();
            this.columnAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTableAttribute = new System.Windows.Forms.Panel();
            this.textBoxWorkflowProperty = new System.Windows.Forms.TextBox();
            this.bindingSourceColumnsMetaData = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxWorkflowProperty = new System.Windows.Forms.ComboBox();
            this.comboBoxDataContract = new System.Windows.Forms.ComboBox();
            this.comboBoxEntityType = new System.Windows.Forms.ComboBox();
            this.labelWorkflowProperty = new System.Windows.Forms.Label();
            this.textBoxTableAttribute = new System.Windows.Forms.TextBox();
            this.labelDataContract = new System.Windows.Forms.Label();
            this.labelEntityType = new System.Windows.Forms.Label();
            this.labelTableAttribute = new System.Windows.Forms.Label();
            this.textBoxTableAlias = new System.Windows.Forms.TextBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.labelTableAlias = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonDuplicateTable = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panelTableList = new System.Windows.Forms.Panel();
            this.treeViewTableList = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelConnectionString.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTableMetaData)).BeginInit();
            this.tableLayoutPanelInformation.SuspendLayout();
            this.panelTableColumns.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableColumns)).BeginInit();
            this.panelTableAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceColumnsMetaData)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelTableList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.panelConnectionString, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelInformation, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(983, 477);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelConnectionString
            // 
            this.panelConnectionString.Controls.Add(this.labelT4TableKeyFile);
            this.panelConnectionString.Controls.Add(this.labelT4MetaDataFile);
            this.panelConnectionString.Controls.Add(this.labelConnectionString);
            this.panelConnectionString.Controls.Add(this.textBoxCsharpTableKeyFile);
            this.panelConnectionString.Controls.Add(this.textBoxT4MetaDataFile);
            this.panelConnectionString.Controls.Add(this.textBoxConnectionString);
            this.panelConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConnectionString.Location = new System.Drawing.Point(4, 4);
            this.panelConnectionString.Name = "panelConnectionString";
            this.panelConnectionString.Size = new System.Drawing.Size(975, 99);
            this.panelConnectionString.TabIndex = 0;
            // 
            // labelT4TableKeyFile
            // 
            this.labelT4TableKeyFile.AutoSize = true;
            this.labelT4TableKeyFile.Location = new System.Drawing.Point(8, 71);
            this.labelT4TableKeyFile.Name = "labelT4TableKeyFile";
            this.labelT4TableKeyFile.Size = new System.Drawing.Size(97, 13);
            this.labelT4TableKeyFile.TabIndex = 2;
            this.labelT4TableKeyFile.Text = "C# Table Key File :";
            // 
            // labelT4MetaDataFile
            // 
            this.labelT4MetaDataFile.AutoSize = true;
            this.labelT4MetaDataFile.Location = new System.Drawing.Point(8, 43);
            this.labelT4MetaDataFile.Name = "labelT4MetaDataFile";
            this.labelT4MetaDataFile.Size = new System.Drawing.Size(82, 13);
            this.labelT4MetaDataFile.TabIndex = 2;
            this.labelT4MetaDataFile.Text = "Meta Data File :";
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(8, 15);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(97, 13);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String :";
            // 
            // textBoxCsharpTableKeyFile
            // 
            this.textBoxCsharpTableKeyFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCsharpTableKeyFile.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxCsharpTableKeyFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTableMetaData, "CsharpTableKeyFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCsharpTableKeyFile.Location = new System.Drawing.Point(111, 68);
            this.textBoxCsharpTableKeyFile.Name = "textBoxCsharpTableKeyFile";
            this.textBoxCsharpTableKeyFile.Size = new System.Drawing.Size(854, 20);
            this.textBoxCsharpTableKeyFile.TabIndex = 2;
            // 
            // bindingSourceTableMetaData
            // 
            this.bindingSourceTableMetaData.DataSource = typeof(T4MetadataToolkit.Bol.TableMetaDataCollection);
            // 
            // textBoxT4MetaDataFile
            // 
            this.textBoxT4MetaDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxT4MetaDataFile.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxT4MetaDataFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTableMetaData, "MetaDataFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxT4MetaDataFile.Location = new System.Drawing.Point(111, 40);
            this.textBoxT4MetaDataFile.Name = "textBoxT4MetaDataFile";
            this.textBoxT4MetaDataFile.Size = new System.Drawing.Size(854, 20);
            this.textBoxT4MetaDataFile.TabIndex = 1;
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxConnectionString.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTableMetaData, "ConnectionString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxConnectionString.Location = new System.Drawing.Point(111, 12);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(854, 20);
            this.textBoxConnectionString.TabIndex = 0;
            // 
            // tableLayoutPanelInformation
            // 
            this.tableLayoutPanelInformation.ColumnCount = 2;
            this.tableLayoutPanelInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanelInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInformation.Controls.Add(this.labelTableList, 0, 0);
            this.tableLayoutPanelInformation.Controls.Add(this.labelColumns, 1, 0);
            this.tableLayoutPanelInformation.Controls.Add(this.panelTableColumns, 1, 1);
            this.tableLayoutPanelInformation.Controls.Add(this.panelTableList, 0, 1);
            this.tableLayoutPanelInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInformation.Location = new System.Drawing.Point(4, 110);
            this.tableLayoutPanelInformation.Name = "tableLayoutPanelInformation";
            this.tableLayoutPanelInformation.RowCount = 2;
            this.tableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInformation.Size = new System.Drawing.Size(975, 363);
            this.tableLayoutPanelInformation.TabIndex = 0;
            // 
            // labelTableList
            // 
            this.labelTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelTableList.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTableList.Location = new System.Drawing.Point(3, 0);
            this.labelTableList.Name = "labelTableList";
            this.labelTableList.Size = new System.Drawing.Size(344, 30);
            this.labelTableList.TabIndex = 0;
            this.labelTableList.Text = "Tables List";
            this.labelTableList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelColumns
            // 
            this.labelColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelColumns.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelColumns.Location = new System.Drawing.Point(353, 0);
            this.labelColumns.Name = "labelColumns";
            this.labelColumns.Size = new System.Drawing.Size(619, 30);
            this.labelColumns.TabIndex = 1;
            this.labelColumns.Text = "Table Columns";
            this.labelColumns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTableColumns
            // 
            this.panelTableColumns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTableColumns.Controls.Add(this.tableLayoutPanelRight);
            this.panelTableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableColumns.Location = new System.Drawing.Point(353, 33);
            this.panelTableColumns.Name = "panelTableColumns";
            this.panelTableColumns.Size = new System.Drawing.Size(619, 327);
            this.panelTableColumns.TabIndex = 3;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.dataGridViewTableColumns, 0, 0);
            this.tableLayoutPanelRight.Controls.Add(this.panelTableAttribute, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.panelButtons, 0, 2);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 3;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(617, 325);
            this.tableLayoutPanelRight.TabIndex = 0;
            // 
            // dataGridViewTableColumns
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTableColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTableColumns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTableColumns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTableColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTableColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnOrdinalPosition,
            this.columnFieldName,
            this.columnType,
            this.columnDefault,
            this.columnNullable,
            this.columnMaximumLength,
            this.columnPropertyDefaultValueAtt,
            this.columnChangePreventerAdministratorAtt,
            this.columnValueChangePreventerRequirementAtt,
            this.columnValueChangePreventerBuyerAtt,
            this.columnValueChangePreventerSellerAtt,
            this.columnDataMemberAtt,
            this.columnSecureIdAtt,
            this.columnSetAttribute,
            this.columnAttribute});
            this.dataGridViewTableColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTableColumns.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTableColumns.MultiSelect = false;
            this.dataGridViewTableColumns.Name = "dataGridViewTableColumns";
            this.dataGridViewTableColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTableColumns.Size = new System.Drawing.Size(611, 59);
            this.dataGridViewTableColumns.TabIndex = 0;
            this.dataGridViewTableColumns.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTableColumns_ColumnHeaderMouseDoubleClick);
            // 
            // columnOrdinalPosition
            // 
            this.columnOrdinalPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnOrdinalPosition.DataPropertyName = "OrdinalPosition";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.columnOrdinalPosition.DefaultCellStyle = dataGridViewCellStyle3;
            this.columnOrdinalPosition.Frozen = true;
            this.columnOrdinalPosition.HeaderText = "Position";
            this.columnOrdinalPosition.Name = "columnOrdinalPosition";
            this.columnOrdinalPosition.ReadOnly = true;
            this.columnOrdinalPosition.Width = 69;
            // 
            // columnFieldName
            // 
            this.columnFieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnFieldName.DataPropertyName = "ColumnName";
            this.columnFieldName.FillWeight = 150F;
            this.columnFieldName.Frozen = true;
            this.columnFieldName.HeaderText = "Field";
            this.columnFieldName.Name = "columnFieldName";
            this.columnFieldName.Width = 54;
            // 
            // columnType
            // 
            this.columnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnType.DataPropertyName = "DataType";
            this.columnType.Frozen = true;
            this.columnType.HeaderText = "Type";
            this.columnType.Name = "columnType";
            this.columnType.ReadOnly = true;
            this.columnType.Width = 56;
            // 
            // columnDefault
            // 
            this.columnDefault.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnDefault.DataPropertyName = "Default";
            this.columnDefault.HeaderText = "Default";
            this.columnDefault.Name = "columnDefault";
            this.columnDefault.ReadOnly = true;
            this.columnDefault.Width = 66;
            // 
            // columnNullable
            // 
            this.columnNullable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnNullable.DataPropertyName = "Nullable";
            this.columnNullable.HeaderText = "Nullable";
            this.columnNullable.Name = "columnNullable";
            this.columnNullable.ReadOnly = true;
            this.columnNullable.Width = 70;
            // 
            // columnMaximumLength
            // 
            this.columnMaximumLength.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnMaximumLength.DataPropertyName = "MaximumLength";
            this.columnMaximumLength.HeaderText = "Length";
            this.columnMaximumLength.Name = "columnMaximumLength";
            this.columnMaximumLength.ReadOnly = true;
            this.columnMaximumLength.Width = 65;
            // 
            // columnPropertyDefaultValueAtt
            // 
            this.columnPropertyDefaultValueAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.columnPropertyDefaultValueAtt.DataPropertyName = "PropertyDefaultValueAtt";
            this.columnPropertyDefaultValueAtt.HeaderText = "PropertyDefaultValue";
            this.columnPropertyDefaultValueAtt.Name = "columnPropertyDefaultValueAtt";
            this.columnPropertyDefaultValueAtt.Width = 132;
            // 
            // columnChangePreventerAdministratorAtt
            // 
            this.columnChangePreventerAdministratorAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnChangePreventerAdministratorAtt.DataPropertyName = "ValueChangePreventerAdministratorAtt";
            this.columnChangePreventerAdministratorAtt.HeaderText = "Value.C.P. Administrator";
            this.columnChangePreventerAdministratorAtt.Name = "columnChangePreventerAdministratorAtt";
            this.columnChangePreventerAdministratorAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnChangePreventerAdministratorAtt.Width = 132;
            // 
            // columnValueChangePreventerRequirementAtt
            // 
            this.columnValueChangePreventerRequirementAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnValueChangePreventerRequirementAtt.DataPropertyName = "ValueChangePreventerRequirementAtt";
            this.columnValueChangePreventerRequirementAtt.HeaderText = "Value.C.P. Requirement";
            this.columnValueChangePreventerRequirementAtt.Name = "columnValueChangePreventerRequirementAtt";
            this.columnValueChangePreventerRequirementAtt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnValueChangePreventerRequirementAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnValueChangePreventerRequirementAtt.Width = 132;
            // 
            // columnValueChangePreventerBuyerAtt
            // 
            this.columnValueChangePreventerBuyerAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnValueChangePreventerBuyerAtt.DataPropertyName = "ValueChangePreventerBuyerAtt";
            this.columnValueChangePreventerBuyerAtt.HeaderText = "Value.C.P. Buyer";
            this.columnValueChangePreventerBuyerAtt.Name = "columnValueChangePreventerBuyerAtt";
            this.columnValueChangePreventerBuyerAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnValueChangePreventerBuyerAtt.Width = 103;
            // 
            // columnValueChangePreventerSellerAtt
            // 
            this.columnValueChangePreventerSellerAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnValueChangePreventerSellerAtt.DataPropertyName = "ValueChangePreventerSellerAtt";
            this.columnValueChangePreventerSellerAtt.HeaderText = "Value.C.P. Seller";
            this.columnValueChangePreventerSellerAtt.Name = "columnValueChangePreventerSellerAtt";
            this.columnValueChangePreventerSellerAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnValueChangePreventerSellerAtt.Width = 102;
            // 
            // columnDataMemberAtt
            // 
            this.columnDataMemberAtt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnDataMemberAtt.DataPropertyName = "DataMemberAtt";
            this.columnDataMemberAtt.HeaderText = "DataMember";
            this.columnDataMemberAtt.Name = "columnDataMemberAtt";
            this.columnDataMemberAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDataMemberAtt.Width = 93;
            // 
            // columnSecureIdAtt
            // 
            this.columnSecureIdAtt.DataPropertyName = "SecureIdAtt";
            this.columnSecureIdAtt.HeaderText = "SecureId";
            this.columnSecureIdAtt.Name = "columnSecureIdAtt";
            this.columnSecureIdAtt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnSecureIdAtt.Width = 150;
            // 
            // columnSetAttribute
            // 
            this.columnSetAttribute.FillWeight = 30F;
            this.columnSetAttribute.HeaderText = "...";
            this.columnSetAttribute.Name = "columnSetAttribute";
            this.columnSetAttribute.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnSetAttribute.Text = "...";
            this.columnSetAttribute.UseColumnTextForButtonValue = true;
            this.columnSetAttribute.Width = 30;
            // 
            // columnAttribute
            // 
            this.columnAttribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnAttribute.DataPropertyName = "ManualAtt";
            this.columnAttribute.HeaderText = "Attributes";
            this.columnAttribute.Name = "columnAttribute";
            this.columnAttribute.Width = 2000;
            // 
            // panelTableAttribute
            // 
            this.panelTableAttribute.Controls.Add(this.textBoxWorkflowProperty);
            this.panelTableAttribute.Controls.Add(this.comboBoxWorkflowProperty);
            this.panelTableAttribute.Controls.Add(this.comboBoxDataContract);
            this.panelTableAttribute.Controls.Add(this.comboBoxEntityType);
            this.panelTableAttribute.Controls.Add(this.labelWorkflowProperty);
            this.panelTableAttribute.Controls.Add(this.textBoxTableAttribute);
            this.panelTableAttribute.Controls.Add(this.labelDataContract);
            this.panelTableAttribute.Controls.Add(this.labelEntityType);
            this.panelTableAttribute.Controls.Add(this.labelTableAttribute);
            this.panelTableAttribute.Controls.Add(this.textBoxTableAlias);
            this.panelTableAttribute.Controls.Add(this.labelHelp);
            this.panelTableAttribute.Controls.Add(this.labelTableAlias);
            this.panelTableAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableAttribute.Location = new System.Drawing.Point(3, 68);
            this.panelTableAttribute.Name = "panelTableAttribute";
            this.panelTableAttribute.Size = new System.Drawing.Size(611, 194);
            this.panelTableAttribute.TabIndex = 0;
            // 
            // textBoxWorkflowProperty
            // 
            this.textBoxWorkflowProperty.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxWorkflowProperty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceColumnsMetaData, "WorkflowPropertyNameAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxWorkflowProperty.Location = new System.Drawing.Point(100, 140);
            this.textBoxWorkflowProperty.Name = "textBoxWorkflowProperty";
            this.textBoxWorkflowProperty.Size = new System.Drawing.Size(157, 20);
            this.textBoxWorkflowProperty.TabIndex = 12;
            // 
            // bindingSourceColumnsMetaData
            // 
            this.bindingSourceColumnsMetaData.DataSource = typeof(T4MetadataToolkit.Bol.TableMetaData);
            // 
            // comboBoxWorkflowProperty
            // 
            this.comboBoxWorkflowProperty.BackColor = System.Drawing.Color.MediumTurquoise;
            this.comboBoxWorkflowProperty.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceColumnsMetaData, "WorkflowPropertySaveOtherChangesAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxWorkflowProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkflowProperty.FormattingEnabled = true;
            this.comboBoxWorkflowProperty.Location = new System.Drawing.Point(263, 139);
            this.comboBoxWorkflowProperty.Name = "comboBoxWorkflowProperty";
            this.comboBoxWorkflowProperty.Size = new System.Drawing.Size(92, 21);
            this.comboBoxWorkflowProperty.TabIndex = 13;
            // 
            // comboBoxDataContract
            // 
            this.comboBoxDataContract.BackColor = System.Drawing.Color.MediumTurquoise;
            this.comboBoxDataContract.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceColumnsMetaData, "DataContractAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxDataContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataContract.FormattingEnabled = true;
            this.comboBoxDataContract.Location = new System.Drawing.Point(100, 113);
            this.comboBoxDataContract.Name = "comboBoxDataContract";
            this.comboBoxDataContract.Size = new System.Drawing.Size(255, 21);
            this.comboBoxDataContract.TabIndex = 10;
            // 
            // comboBoxEntityType
            // 
            this.comboBoxEntityType.BackColor = System.Drawing.Color.MediumTurquoise;
            this.comboBoxEntityType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSourceColumnsMetaData, "EntityTypeAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEntityType.FormattingEnabled = true;
            this.comboBoxEntityType.Location = new System.Drawing.Point(100, 87);
            this.comboBoxEntityType.Name = "comboBoxEntityType";
            this.comboBoxEntityType.Size = new System.Drawing.Size(255, 21);
            this.comboBoxEntityType.TabIndex = 6;
            // 
            // labelWorkflowProperty
            // 
            this.labelWorkflowProperty.AutoSize = true;
            this.labelWorkflowProperty.Location = new System.Drawing.Point(3, 143);
            this.labelWorkflowProperty.Name = "labelWorkflowProperty";
            this.labelWorkflowProperty.Size = new System.Drawing.Size(97, 13);
            this.labelWorkflowProperty.TabIndex = 11;
            this.labelWorkflowProperty.Text = "WorkflowProperty :";
            // 
            // textBoxTableAttribute
            // 
            this.textBoxTableAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTableAttribute.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxTableAttribute.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceColumnsMetaData, "ManualAtt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxTableAttribute.Location = new System.Drawing.Point(100, 62);
            this.textBoxTableAttribute.Name = "textBoxTableAttribute";
            this.textBoxTableAttribute.Size = new System.Drawing.Size(508, 20);
            this.textBoxTableAttribute.TabIndex = 4;
            // 
            // labelDataContract
            // 
            this.labelDataContract.AutoSize = true;
            this.labelDataContract.Location = new System.Drawing.Point(3, 116);
            this.labelDataContract.Name = "labelDataContract";
            this.labelDataContract.Size = new System.Drawing.Size(76, 13);
            this.labelDataContract.TabIndex = 9;
            this.labelDataContract.Text = "DataContract :";
            // 
            // labelEntityType
            // 
            this.labelEntityType.AutoSize = true;
            this.labelEntityType.Location = new System.Drawing.Point(3, 90);
            this.labelEntityType.Name = "labelEntityType";
            this.labelEntityType.Size = new System.Drawing.Size(63, 13);
            this.labelEntityType.TabIndex = 5;
            this.labelEntityType.Text = "EntityType :";
            // 
            // labelTableAttribute
            // 
            this.labelTableAttribute.AutoSize = true;
            this.labelTableAttribute.Location = new System.Drawing.Point(3, 65);
            this.labelTableAttribute.Name = "labelTableAttribute";
            this.labelTableAttribute.Size = new System.Drawing.Size(90, 13);
            this.labelTableAttribute.TabIndex = 3;
            this.labelTableAttribute.Text = "Manual Attribute :";
            // 
            // textBoxTableAlias
            // 
            this.textBoxTableAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTableAlias.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxTableAlias.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceColumnsMetaData, "TableAlias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxTableAlias.Location = new System.Drawing.Point(100, 37);
            this.textBoxTableAlias.Name = "textBoxTableAlias";
            this.textBoxTableAlias.Size = new System.Drawing.Size(508, 20);
            this.textBoxTableAlias.TabIndex = 2;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.ForeColor = System.Drawing.Color.Gray;
            this.labelHelp.Location = new System.Drawing.Point(88, 15);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(496, 13);
            this.labelHelp.TabIndex = 0;
            this.labelHelp.Text = "You can use \'A/B/...\' in table alias textbox, when a table was supplied more than" +
    " one entity(DataModel).";
            // 
            // labelTableAlias
            // 
            this.labelTableAlias.AutoSize = true;
            this.labelTableAlias.Location = new System.Drawing.Point(3, 40);
            this.labelTableAlias.Name = "labelTableAlias";
            this.labelTableAlias.Size = new System.Drawing.Size(65, 13);
            this.labelTableAlias.TabIndex = 1;
            this.labelTableAlias.Text = "Table Alias :";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonDuplicateTable);
            this.panelButtons.Controls.Add(this.buttonSaveToFile);
            this.panelButtons.Controls.Add(this.buttonReset);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(3, 268);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(611, 54);
            this.panelButtons.TabIndex = 2;
            // 
            // buttonDuplicateTable
            // 
            this.buttonDuplicateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDuplicateTable.Location = new System.Drawing.Point(287, 5);
            this.buttonDuplicateTable.Name = "buttonDuplicateTable";
            this.buttonDuplicateTable.Size = new System.Drawing.Size(103, 40);
            this.buttonDuplicateTable.TabIndex = 2;
            this.buttonDuplicateTable.Text = "Duplicate Table";
            this.buttonDuplicateTable.UseVisualStyleBackColor = true;
            this.buttonDuplicateTable.Click += new System.EventHandler(this.buttonDuplicateTable_Click);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveToFile.Location = new System.Drawing.Point(505, 5);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(103, 40);
            this.buttonSaveToFile.TabIndex = 0;
            this.buttonSaveToFile.Text = "Save";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(396, 5);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(103, 40);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Read MetaData";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // panelTableList
            // 
            this.panelTableList.BackColor = System.Drawing.Color.White;
            this.panelTableList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTableList.Controls.Add(this.treeViewTableList);
            this.panelTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTableList.Location = new System.Drawing.Point(3, 33);
            this.panelTableList.Name = "panelTableList";
            this.panelTableList.Size = new System.Drawing.Size(344, 327);
            this.panelTableList.TabIndex = 0;
            // 
            // treeViewTableList
            // 
            this.treeViewTableList.BackColor = System.Drawing.Color.MediumTurquoise;
            this.treeViewTableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.treeViewTableList.ForeColor = System.Drawing.Color.Black;
            this.treeViewTableList.FullRowSelect = true;
            this.treeViewTableList.Location = new System.Drawing.Point(0, 0);
            this.treeViewTableList.Name = "treeViewTableList";
            this.treeViewTableList.Size = new System.Drawing.Size(342, 325);
            this.treeViewTableList.TabIndex = 0;
            this.treeViewTableList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewTableList_BeforeSelect);
            this.treeViewTableList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTableList_AfterSelect);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 487);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "T4 Metadata Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelConnectionString.ResumeLayout(false);
            this.panelConnectionString.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTableMetaData)).EndInit();
            this.tableLayoutPanelInformation.ResumeLayout(false);
            this.panelTableColumns.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableColumns)).EndInit();
            this.panelTableAttribute.ResumeLayout(false);
            this.panelTableAttribute.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceColumnsMetaData)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelTableList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelConnectionString;
        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInformation;
        private System.Windows.Forms.Label labelTableList;
        private System.Windows.Forms.Label labelColumns;
        private System.Windows.Forms.Panel panelTableColumns;
        private System.Windows.Forms.Panel panelTableList;
        private System.Windows.Forms.Label labelT4MetaDataFile;
        private System.Windows.Forms.TextBox textBoxT4MetaDataFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.DataGridView dataGridViewTableColumns;
        private System.Windows.Forms.Panel panelTableAttribute;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxTableAlias;
        private System.Windows.Forms.Label labelTableAlias;
        private System.Windows.Forms.TextBox textBoxTableAttribute;
        private System.Windows.Forms.Label labelTableAttribute;
        private System.Windows.Forms.BindingSource bindingSourceColumnsMetaData;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.TreeView treeViewTableList;
        private System.Windows.Forms.Button buttonDuplicateTable;
        private System.Windows.Forms.BindingSource bindingSourceTableMetaData;
        private System.Windows.Forms.ComboBox comboBoxDataContract;
        private System.Windows.Forms.ComboBox comboBoxEntityType;
        private System.Windows.Forms.Label labelDataContract;
        private System.Windows.Forms.Label labelEntityType;
        private System.Windows.Forms.Label labelWorkflowProperty;
        private System.Windows.Forms.TextBox textBoxWorkflowProperty;
        private System.Windows.Forms.ComboBox comboBoxWorkflowProperty;
        private System.Windows.Forms.Label labelT4TableKeyFile;
        private System.Windows.Forms.TextBox textBoxCsharpTableKeyFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdinalPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMaximumLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPropertyDefaultValueAtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnChangePreventerAdministratorAtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnValueChangePreventerRequirementAtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnValueChangePreventerBuyerAtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnValueChangePreventerSellerAtt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnDataMemberAtt;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnSecureIdAtt;
        private System.Windows.Forms.DataGridViewButtonColumn columnSetAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAttribute;
    }
}

