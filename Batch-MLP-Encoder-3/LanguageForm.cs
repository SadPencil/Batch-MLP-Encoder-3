using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SadPencil.BatchMLPEncoder3 {
    public partial class LanguageForm : Form {

        public LanguageForm() {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LanguageListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.LanguageListView.SelectedItems.Count == 1) {
                this.OKButton.Enabled = true;
            }
            else {
                Debug.Assert(this.LanguageListView.SelectedItems.Count == 0);
                this.OKButton.Enabled = false;
            }
        }
        



        private void OKButton_Click(object sender, EventArgs e) {
            Debug.Assert(this.LanguageListView.SelectedItems.Count == 1);
            string languageID = this.LanguageListView.SelectedItems[0].Text;
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageID);
            Debug.WriteLine("Select Language: " + languageID);
            try {
                CultureInfo NewCultureInfo;
                if (languageID == "en-US") {
                    NewCultureInfo = CultureInfo.InvariantCulture;
                } else {
                    NewCultureInfo = new CultureInfo(languageID);
                } 

                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture = NewCultureInfo;
            }
            catch (Exception ex) {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LanguageForm_Load(object sender, EventArgs e) {
            foreach (ListViewItem item in this.LanguageListView.Items) {
                Debug.WriteLine(item.Text);
                if (item.Text == CultureInfo.InstalledUICulture.Name) {
                    this.LanguageListView.SelectedItems.Clear();
                    item.Selected = true;
                    break;
                }
            }

        }
    }
}
