using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace SadPencil.BatchMLPEncoder3 {
    public partial class PropertyForm : Form {
        public PropertyForm() {
            //Thread.CurrentThread.CurrentUICulture = Program.UICulture;
            InitializeComponent();
        }

        public void ShowDialog(ref string[] FileInfo, string Message, ref bool Canceled) {
            Debug.Assert(FileInfo.Length == 6);

            this.NameTextbox.Text = FileInfo[0];
            this.SamplingRateTextbox.Text = FileInfo[3];
            this.BitDepthTextbox.Text = FileInfo[4];
            this.PathTextbox.Text = FileInfo[5];
            this.DurationTextbox.Text = FileInfo[2];

            this.ReasonTextbox.Text = Message;

            if (this.ShowDialog() == DialogResult.OK) {
                FileInfo[0] = this.NameTextbox.Text.Trim().TrimEnd('.');
                FileInfo[3] = this.SamplingRateTextbox.Text;
                FileInfo[4] = this.BitDepthTextbox.Text;
                FileInfo[2] = this.DurationTextbox.Text;
            }
            else {
                Canceled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }

}

