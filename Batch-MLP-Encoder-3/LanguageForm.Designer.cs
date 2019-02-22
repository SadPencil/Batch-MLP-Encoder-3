namespace SadPencil.BatchMLPEncoder3
{
    partial class LanguageForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "en-US",
            "English (United States)"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "es-ES",
            "Spanish (Spain)"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "zh-CN",
            "Chinese (Simplified, PRC)"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageForm));
            this.LanguageListView = new System.Windows.Forms.ListView();
            this.LanguageIDColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LanguageEnglishNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExitButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LanguageListView
            // 
            this.LanguageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LanguageIDColumnHeader,
            this.LanguageEnglishNameColumnHeader});
            this.LanguageListView.FullRowSelect = true;
            this.LanguageListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.LanguageListView.Location = new System.Drawing.Point(12, 12);
            this.LanguageListView.MultiSelect = false;
            this.LanguageListView.Name = "LanguageListView";
            this.LanguageListView.Size = new System.Drawing.Size(307, 104);
            this.LanguageListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LanguageListView.TabIndex = 0;
            this.LanguageListView.UseCompatibleStateImageBehavior = false;
            this.LanguageListView.View = System.Windows.Forms.View.Details;
            this.LanguageListView.SelectedIndexChanged += new System.EventHandler(this.LanguageListView_SelectedIndexChanged);
            // 
            // LanguageIDColumnHeader
            // 
            this.LanguageIDColumnHeader.Text = "ID";
            // 
            // LanguageEnglishNameColumnHeader
            // 
            this.LanguageEnglishNameColumnHeader.Text = "Name";
            this.LanguageEnglishNameColumnHeader.Width = 241;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ExitButton.Location = new System.Drawing.Point(233, 123);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 31);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OKButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OKButton.Location = new System.Drawing.Point(141, 123);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(86, 31);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // LanguageForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(331, 157);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.LanguageListView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch MLP Encoder - Select Langauge";
            this.Load += new System.EventHandler(this.LanguageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LanguageListView;
        private System.Windows.Forms.ColumnHeader LanguageIDColumnHeader;
        private System.Windows.Forms.ColumnHeader LanguageEnglishNameColumnHeader;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OKButton;
    }
}