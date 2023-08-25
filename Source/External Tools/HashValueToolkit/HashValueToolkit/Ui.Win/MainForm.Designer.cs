namespace HashValueToolkit.Ui.Win
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.comboBoxHashCount = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelHashCount = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonHash = new System.Windows.Forms.Button();
            this.textBoxStringResult = new System.Windows.Forms.TextBox();
            this.textBoxArrayResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxStringResult, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxArrayResult, 0, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(584, 362);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.comboBoxHashCount);
            this.panelTop.Controls.Add(this.textBoxPassword);
            this.panelTop.Controls.Add(this.labelHashCount);
            this.panelTop.Controls.Add(this.labelPassword);
            this.panelTop.Controls.Add(this.buttonHash);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(13, 13);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(558, 74);
            this.panelTop.TabIndex = 0;
            // 
            // comboBoxHashCount
            // 
            this.comboBoxHashCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHashCount.FormattingEnabled = true;
            this.comboBoxHashCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxHashCount.Location = new System.Drawing.Point(83, 35);
            this.comboBoxHashCount.Name = "comboBoxHashCount";
            this.comboBoxHashCount.Size = new System.Drawing.Size(341, 21);
            this.comboBoxHashCount.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxPassword.Location = new System.Drawing.Point(83, 5);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(462, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // labelHashCount
            // 
            this.labelHashCount.AutoSize = true;
            this.labelHashCount.Location = new System.Drawing.Point(8, 38);
            this.labelHashCount.Name = "labelHashCount";
            this.labelHashCount.Size = new System.Drawing.Size(69, 13);
            this.labelHashCount.TabIndex = 2;
            this.labelHashCount.Text = "Hash Count :";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(8, 8);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 0;
            this.labelPassword.Text = "Passwod :";
            // 
            // buttonHash
            // 
            this.buttonHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHash.Location = new System.Drawing.Point(430, 33);
            this.buttonHash.Name = "buttonHash";
            this.buttonHash.Size = new System.Drawing.Size(115, 23);
            this.buttonHash.TabIndex = 4;
            this.buttonHash.Text = "Hash";
            this.buttonHash.UseVisualStyleBackColor = true;
            this.buttonHash.Click += new System.EventHandler(this.buttonHash_Click);
            // 
            // textBoxStringResult
            // 
            this.textBoxStringResult.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxStringResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStringResult.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxStringResult.Location = new System.Drawing.Point(20, 100);
            this.textBoxStringResult.Margin = new System.Windows.Forms.Padding(10);
            this.textBoxStringResult.Multiline = true;
            this.textBoxStringResult.Name = "textBoxStringResult";
            this.textBoxStringResult.ReadOnly = true;
            this.textBoxStringResult.Size = new System.Drawing.Size(544, 111);
            this.textBoxStringResult.TabIndex = 1;
            // 
            // textBoxArrayResult
            // 
            this.textBoxArrayResult.BackColor = System.Drawing.Color.MediumTurquoise;
            this.textBoxArrayResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxArrayResult.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxArrayResult.Location = new System.Drawing.Point(20, 231);
            this.textBoxArrayResult.Margin = new System.Windows.Forms.Padding(10);
            this.textBoxArrayResult.Multiline = true;
            this.textBoxArrayResult.Name = "textBoxArrayResult";
            this.textBoxArrayResult.ReadOnly = true;
            this.textBoxArrayResult.Size = new System.Drawing.Size(544, 111);
            this.textBoxArrayResult.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "MainForm";
            this.Text = "Hash Value Toolkit";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ComboBox comboBoxHashCount;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelHashCount;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonHash;
        private System.Windows.Forms.TextBox textBoxStringResult;
        private System.Windows.Forms.TextBox textBoxArrayResult;
    }
}