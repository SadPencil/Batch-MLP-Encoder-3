namespace SadPencil.BatchMLPEncoder3
{
    partial class PropertyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyForm));
            this.Label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SamplingRateLabel = new System.Windows.Forms.Label();
            this.BitDepthLabel = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.SamplingRateTextbox = new System.Windows.Forms.TextBox();
            this.BitDepthTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DurationTextbox = new System.Windows.Forms.TextBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.PathTextbox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.ReasonGroupBox = new System.Windows.Forms.GroupBox();
            this.ReasonTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.ReasonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            // 
            // SamplingRateLabel
            // 
            resources.ApplyResources(this.SamplingRateLabel, "SamplingRateLabel");
            this.SamplingRateLabel.Name = "SamplingRateLabel";
            // 
            // BitDepthLabel
            // 
            resources.ApplyResources(this.BitDepthLabel, "BitDepthLabel");
            this.BitDepthLabel.Name = "BitDepthLabel";
            // 
            // NameTextbox
            // 
            resources.ApplyResources(this.NameTextbox, "NameTextbox");
            this.NameTextbox.Name = "NameTextbox";
            // 
            // SamplingRateTextbox
            // 
            resources.ApplyResources(this.SamplingRateTextbox, "SamplingRateTextbox");
            this.SamplingRateTextbox.Name = "SamplingRateTextbox";
            // 
            // BitDepthTextbox
            // 
            resources.ApplyResources(this.BitDepthTextbox, "BitDepthTextbox");
            this.BitDepthTextbox.Name = "BitDepthTextbox";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.DurationTextbox);
            this.groupBox1.Controls.Add(this.DurationLabel);
            this.groupBox1.Controls.Add(this.PathTextbox);
            this.groupBox1.Controls.Add(this.PathLabel);
            this.groupBox1.Controls.Add(this.NameLabel);
            this.groupBox1.Controls.Add(this.BitDepthTextbox);
            this.groupBox1.Controls.Add(this.SamplingRateLabel);
            this.groupBox1.Controls.Add(this.SamplingRateTextbox);
            this.groupBox1.Controls.Add(this.BitDepthLabel);
            this.groupBox1.Controls.Add(this.NameTextbox);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // DurationTextbox
            // 
            resources.ApplyResources(this.DurationTextbox, "DurationTextbox");
            this.DurationTextbox.Name = "DurationTextbox";
            // 
            // DurationLabel
            // 
            resources.ApplyResources(this.DurationLabel, "DurationLabel");
            this.DurationLabel.Name = "DurationLabel";
            // 
            // PathTextbox
            // 
            resources.ApplyResources(this.PathTextbox, "PathTextbox");
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.ReadOnly = true;
            // 
            // PathLabel
            // 
            resources.ApplyResources(this.PathLabel, "PathLabel");
            this.PathLabel.Name = "PathLabel";
            // 
            // ExitButton
            // 
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OKButton
            // 
            resources.ApplyResources(this.OKButton, "OKButton");
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Name = "OKButton";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ReasonGroupBox
            // 
            resources.ApplyResources(this.ReasonGroupBox, "ReasonGroupBox");
            this.ReasonGroupBox.Controls.Add(this.ReasonTextbox);
            this.ReasonGroupBox.Name = "ReasonGroupBox";
            this.ReasonGroupBox.TabStop = false;
            // 
            // ReasonTextbox
            // 
            resources.ApplyResources(this.ReasonTextbox, "ReasonTextbox");
            this.ReasonTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.ReasonTextbox.Name = "ReasonTextbox";
            this.ReasonTextbox.ReadOnly = true;
            // 
            // PropertyForm
            // 
            this.AcceptButton = this.OKButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitButton;
            this.Controls.Add(this.ReasonGroupBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ReasonGroupBox.ResumeLayout(false);
            this.ReasonGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SamplingRateLabel;
        private System.Windows.Forms.Label BitDepthLabel;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.TextBox SamplingRateTextbox;
        private System.Windows.Forms.TextBox BitDepthTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox PathTextbox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.GroupBox ReasonGroupBox;
        private System.Windows.Forms.TextBox ReasonTextbox;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.TextBox DurationTextbox;
    }
}