namespace iSteelCovers
{
    partial class Main_Form
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
            this.SearchMethod_ComboBox = new System.Windows.Forms.ComboBox();
            this.SearchQuery_TextBox = new System.Windows.Forms.TextBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.Results_DataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ArtPreview_PictureBox = new System.Windows.Forms.PictureBox();
            this.StatusStrip_MainForm = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.Results_DataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtPreview_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchMethod_ComboBox
            // 
            this.SearchMethod_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchMethod_ComboBox.FormattingEnabled = true;
            this.SearchMethod_ComboBox.Items.AddRange(new object[] {
            "Generic",
            "Artists Search",
            "Albums by Artist",
            "Albums by Name"});
            this.SearchMethod_ComboBox.Location = new System.Drawing.Point(248, 3);
            this.SearchMethod_ComboBox.Name = "SearchMethod_ComboBox";
            this.SearchMethod_ComboBox.Size = new System.Drawing.Size(176, 21);
            this.SearchMethod_ComboBox.TabIndex = 2;
            this.SearchMethod_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchMethod_ComboBox_SelectedIndexChanged);
            // 
            // SearchQuery_TextBox
            // 
            this.SearchQuery_TextBox.Location = new System.Drawing.Point(3, 3);
            this.SearchQuery_TextBox.Name = "SearchQuery_TextBox";
            this.SearchQuery_TextBox.Size = new System.Drawing.Size(239, 20);
            this.SearchQuery_TextBox.TabIndex = 3;
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(430, 1);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(75, 23);
            this.Search_Button.TabIndex = 4;
            this.Search_Button.Text = "Search";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // Results_DataGrid
            // 
            this.Results_DataGrid.AllowUserToAddRows = false;
            this.Results_DataGrid.AllowUserToResizeRows = false;
            this.Results_DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Results_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Results_DataGrid.Location = new System.Drawing.Point(12, 46);
            this.Results_DataGrid.Name = "Results_DataGrid";
            this.Results_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Results_DataGrid.Size = new System.Drawing.Size(637, 250);
            this.Results_DataGrid.TabIndex = 5;
            this.Results_DataGrid.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Results_DataGrid_RowHeaderMouseClick);
            this.Results_DataGrid.SelectionChanged += new System.EventHandler(this.Results_DataGrid_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SearchQuery_TextBox);
            this.panel1.Controls.Add(this.SearchMethod_ComboBox);
            this.panel1.Controls.Add(this.Search_Button);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 28);
            this.panel1.TabIndex = 6;
            // 
            // ArtPreview_PictureBox
            // 
            this.ArtPreview_PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ArtPreview_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ArtPreview_PictureBox.Location = new System.Drawing.Point(655, 46);
            this.ArtPreview_PictureBox.Name = "ArtPreview_PictureBox";
            this.ArtPreview_PictureBox.Size = new System.Drawing.Size(250, 250);
            this.ArtPreview_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArtPreview_PictureBox.TabIndex = 7;
            this.ArtPreview_PictureBox.TabStop = false;
            // 
            // StatusStrip_MainForm
            // 
            this.StatusStrip_MainForm.Location = new System.Drawing.Point(0, 299);
            this.StatusStrip_MainForm.Name = "StatusStrip_MainForm";
            this.StatusStrip_MainForm.Size = new System.Drawing.Size(917, 22);
            this.StatusStrip_MainForm.TabIndex = 8;
            this.StatusStrip_MainForm.Text = "statusStrip1";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 321);
            this.Controls.Add(this.StatusStrip_MainForm);
            this.Controls.Add(this.ArtPreview_PictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Results_DataGrid);
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iSteelCovers";
            ((System.ComponentModel.ISupportInitialize)(this.Results_DataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtPreview_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox SearchMethod_ComboBox;
        private System.Windows.Forms.TextBox SearchQuery_TextBox;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.DataGridView Results_DataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ArtPreview_PictureBox;
        private System.Windows.Forms.StatusStrip StatusStrip_MainForm;
    }
}

