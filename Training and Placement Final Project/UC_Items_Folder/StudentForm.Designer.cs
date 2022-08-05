namespace Training_and_Placement_Final_Project.UC_Items_Folder
{
    partial class StudentForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.StudTxtFilePath = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StudBtnImport = new Guna.UI2.WinForms.Guna2Button();
            this.StudBtnSave = new Guna.UI2.WinForms.Guna2Button();
            this.StudBtnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.StudentDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ClearBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudTxtFilePath
            // 
            this.StudTxtFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StudTxtFilePath.DefaultText = "";
            this.StudTxtFilePath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.StudTxtFilePath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.StudTxtFilePath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StudTxtFilePath.DisabledState.Parent = this.StudTxtFilePath;
            this.StudTxtFilePath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.StudTxtFilePath.FocusedState.BorderColor = System.Drawing.Color.Orange;
            this.StudTxtFilePath.FocusedState.Parent = this.StudTxtFilePath;
            this.StudTxtFilePath.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudTxtFilePath.ForeColor = System.Drawing.Color.Black;
            this.StudTxtFilePath.HoverState.BorderColor = System.Drawing.Color.Orange;
            this.StudTxtFilePath.HoverState.Parent = this.StudTxtFilePath;
            this.StudTxtFilePath.Location = new System.Drawing.Point(183, 38);
            this.StudTxtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.StudTxtFilePath.Name = "StudTxtFilePath";
            this.StudTxtFilePath.PasswordChar = '\0';
            this.StudTxtFilePath.PlaceholderText = "";
            this.StudTxtFilePath.SelectedText = "";
            this.StudTxtFilePath.ShadowDecoration.Parent = this.StudTxtFilePath;
            this.StudTxtFilePath.Size = new System.Drawing.Size(864, 35);
            this.StudTxtFilePath.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.StudTxtFilePath.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 33;
            this.label2.Text = "File Path";
            // 
            // StudBtnImport
            // 
            this.StudBtnImport.AutoRoundedCorners = true;
            this.StudBtnImport.BorderRadius = 21;
            this.StudBtnImport.CheckedState.Parent = this.StudBtnImport;
            this.StudBtnImport.CustomImages.Parent = this.StudBtnImport;
            this.StudBtnImport.FillColor = System.Drawing.Color.Orange;
            this.StudBtnImport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudBtnImport.ForeColor = System.Drawing.Color.White;
            this.StudBtnImport.HoverState.Parent = this.StudBtnImport;
            this.StudBtnImport.Location = new System.Drawing.Point(1122, 97);
            this.StudBtnImport.Name = "StudBtnImport";
            this.StudBtnImport.ShadowDecoration.Parent = this.StudBtnImport;
            this.StudBtnImport.Size = new System.Drawing.Size(134, 44);
            this.StudBtnImport.TabIndex = 44;
            this.StudBtnImport.Text = "Import";
            this.StudBtnImport.Click += new System.EventHandler(this.StudBtnImport_Click);
            // 
            // StudBtnSave
            // 
            this.StudBtnSave.AutoRoundedCorners = true;
            this.StudBtnSave.BorderRadius = 21;
            this.StudBtnSave.CheckedState.Parent = this.StudBtnSave;
            this.StudBtnSave.CustomImages.Parent = this.StudBtnSave;
            this.StudBtnSave.FillColor = System.Drawing.Color.Orange;
            this.StudBtnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudBtnSave.ForeColor = System.Drawing.Color.White;
            this.StudBtnSave.HoverState.Parent = this.StudBtnSave;
            this.StudBtnSave.Location = new System.Drawing.Point(1122, 669);
            this.StudBtnSave.Name = "StudBtnSave";
            this.StudBtnSave.ShadowDecoration.Parent = this.StudBtnSave;
            this.StudBtnSave.Size = new System.Drawing.Size(134, 44);
            this.StudBtnSave.TabIndex = 43;
            this.StudBtnSave.Text = "Save";
            this.StudBtnSave.Click += new System.EventHandler(this.StudBtnSave_Click);
            // 
            // StudBtnBrowse
            // 
            this.StudBtnBrowse.AutoRoundedCorners = true;
            this.StudBtnBrowse.BorderRadius = 21;
            this.StudBtnBrowse.CheckedState.Parent = this.StudBtnBrowse;
            this.StudBtnBrowse.CustomImages.Parent = this.StudBtnBrowse;
            this.StudBtnBrowse.FillColor = System.Drawing.Color.Orange;
            this.StudBtnBrowse.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudBtnBrowse.ForeColor = System.Drawing.Color.White;
            this.StudBtnBrowse.HoverState.Parent = this.StudBtnBrowse;
            this.StudBtnBrowse.Location = new System.Drawing.Point(1122, 38);
            this.StudBtnBrowse.Name = "StudBtnBrowse";
            this.StudBtnBrowse.ShadowDecoration.Parent = this.StudBtnBrowse;
            this.StudBtnBrowse.Size = new System.Drawing.Size(134, 44);
            this.StudBtnBrowse.TabIndex = 42;
            this.StudBtnBrowse.Text = "Browse";
            this.StudBtnBrowse.Click += new System.EventHandler(this.StudBtnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // StudentDataGridView
            // 
            this.StudentDataGridView.AllowUserToAddRows = false;
            this.StudentDataGridView.AllowUserToDeleteRows = false;
            this.StudentDataGridView.AllowUserToResizeColumns = false;
            this.StudentDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.StudentDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.StudentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.StudentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.StudentDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.StudentDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StudentDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StudentDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StudentDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.StudentDataGridView.ColumnHeadersHeight = 42;
            this.StudentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.StudentDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.StudentDataGridView.EnableHeadersVisualStyles = false;
            this.StudentDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.StudentDataGridView.Location = new System.Drawing.Point(26, 155);
            this.StudentDataGridView.Name = "StudentDataGridView";
            this.StudentDataGridView.ReadOnly = true;
            this.StudentDataGridView.RowHeadersVisible = false;
            this.StudentDataGridView.RowHeadersWidth = 51;
            this.StudentDataGridView.RowTemplate.Height = 24;
            this.StudentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentDataGridView.Size = new System.Drawing.Size(1277, 508);
            this.StudentDataGridView.TabIndex = 92;
            this.StudentDataGridView.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Orange;
            this.StudentDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(225)))), ((int)(((byte)(184)))));
            this.StudentDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.StudentDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.StudentDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.StudentDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.StudentDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.StudentDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(218)))), ((int)(((byte)(171)))));
            this.StudentDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.StudentDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.StudentDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.StudentDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.StudentDataGridView.ThemeStyle.HeaderStyle.Height = 42;
            this.StudentDataGridView.ThemeStyle.ReadOnly = true;
            this.StudentDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(235)))), ((int)(((byte)(207)))));
            this.StudentDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.StudentDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Berlin Sans FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.StudentDataGridView.ThemeStyle.RowsStyle.Height = 24;
            this.StudentDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(189)))), ((int)(((byte)(97)))));
            this.StudentDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // ClearBtn
            // 
            this.ClearBtn.AutoRoundedCorners = true;
            this.ClearBtn.BorderRadius = 21;
            this.ClearBtn.CheckedState.Parent = this.ClearBtn;
            this.ClearBtn.CustomImages.Parent = this.ClearBtn;
            this.ClearBtn.FillColor = System.Drawing.Color.Orange;
            this.ClearBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.HoverState.Parent = this.ClearBtn;
            this.ClearBtn.Location = new System.Drawing.Point(959, 669);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.ShadowDecoration.Parent = this.ClearBtn;
            this.ClearBtn.Size = new System.Drawing.Size(134, 44);
            this.ClearBtn.TabIndex = 93;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.StudentDataGridView);
            this.Controls.Add(this.StudBtnImport);
            this.Controls.Add(this.StudBtnSave);
            this.Controls.Add(this.StudBtnBrowse);
            this.Controls.Add(this.StudTxtFilePath);
            this.Controls.Add(this.label2);
            this.Name = "StudentForm";
            this.Size = new System.Drawing.Size(1333, 723);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StudentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox StudTxtFilePath;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button StudBtnImport;
        private Guna.UI2.WinForms.Guna2Button StudBtnSave;
        private Guna.UI2.WinForms.Guna2Button StudBtnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2DataGridView StudentDataGridView;
        private Guna.UI2.WinForms.Guna2Button ClearBtn;
    }
}
