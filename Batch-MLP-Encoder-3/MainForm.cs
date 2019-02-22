using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MediaInfoLib;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Threading;
using System.Globalization;

namespace SadPencil.BatchMLPEncoder3 {

    public partial class MainForm : Form {
        public const string Version = "3.0.6";

        public MainForm() {
            //Thread.CurrentThread.CurrentUICulture =new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }

        private string[,] Files;
        private bool _Processing;
        private bool[] eac3toOK, eac3toFailed, SurcodeFailed;
        private bool Processing {
            get {
                return this._Processing;
            }
            set {
                this._Processing = value;
                this.UpdateMainFormText();
            }

        }

        private void UpdateMainFormText() {
            if (this.Processing) {
                this.Text = "Batch MLP Encoder - " + MainFormCodeStrings.SetMainFormTextString;
            }
            else {
                this.Text = "Batch MLP Encoder - Ver." + Version;
            }
        }

        private bool eac3Processing, SurcodeProcessing;
        private bool Page1PictureBoxClicked = false;

        private class Page6WorkerReportArgument {
            public enum Orders {
                Add,
                MessageBox
            }
            private Orders _Order;
            private string _Message;
            private string _FileName;
            private string _Time;
            private bool _Stress;

            public bool Stress {
                get {
                    return this._Stress;
                }
                set {
                    this._Stress = value;
                }
            }

            public Page6WorkerReportArgument(Orders Order, string Message, string FileName, bool Stress) {
                this._Order = Order;
                this._Message = Message;
                this._FileName = FileName;
                this._Time = DateTime.Now.ToLongTimeString();
                this._Stress = Stress;
            }
            public Orders Order {
                get {
                    return this._Order;
                }
                set {
                    this._Order = value;
                }
            }

            public string FileName {
                get {
                    return this._FileName;
                }
                set {
                    this._FileName = value;
                }
            }

            public string Message {
                get {
                    return this._Message;
                }
                set {
                    this._Message = value;
                }
            }
            public string Time {
                get {
                    return this._Time;
                }
                set {
                    this._Time = value;
                }
            }

        }

        private void LoadSettings() {
            Debug.WriteLine("Load Settings...");
            //  if (!String.IsNullOrWhiteSpace(Properties.Settings.Default.SurcodeExeFullname)) {
            if (System.IO.File.Exists(Properties.Settings.Default.SurcodeExeFullname)) {
                this.Page1SurcodeTextBox.Text = Properties.Settings.Default.SurcodeExeFullname;
            }
            //     }
            if (System.IO.File.Exists(Properties.Settings.Default.Eac3toExeFullname)) {
                this.Page1eac3toTextbox.Text = Properties.Settings.Default.Eac3toExeFullname;
            }

            if (System.IO.Directory.Exists(Properties.Settings.Default.TempFolderPath)) {
                this.Page5TempTextbox.Text = Properties.Settings.Default.TempFolderPath;
            }

            if (System.IO.Directory.Exists(Properties.Settings.Default.OutputFolderPath)) {
                this.Page5SaveTextbox.Text = Properties.Settings.Default.OutputFolderPath;
            }

            //    if (System.IO.File.Exists(Properties.Settings.Default.SURCODEFULLNAME)) Page1SurcodeTextBox.Text = Properties.Settings.Default.SURCODEFULLNAME;
            //    if (System.IO.File.Exists(Properties.Settings.Default.EAC3TOFULLNAME)) Page1eac3toTextbox.Text = Properties.Settings.Default.EAC3TOFULLNAME;
            //    if (System.IO.Directory.Exists(Properties.Settings.Default.TEMPPATH)) Page5TempTextbox.Text = Properties.Settings.Default.TEMPPATH;
            //    if (System.IO.Directory.Exists(Properties.Settings.Default.SAVEPATH)) Page5SaveTextbox.Text = Properties.Settings.Default.SAVEPATH;

            //    Page5AutoCleanCheckbox.Checked = Properties.Settings.Default.AUTOCLEAN;

            //    if (Properties.Settings.Default.A > 0 & Properties.Settings.Default.A < 10000) Page4A.Value = Properties.Settings.Default.A;
            //    if (Properties.Settings.Default.B > 0 & Properties.Settings.Default.B < 10000) Page4B.Value = Properties.Settings.Default.B;
            //    if (Properties.Settings.Default.C > 0 & Properties.Settings.Default.C < 10000) Page4C.Value = Properties.Settings.Default.C;
            //    if (Properties.Settings.Default.D > 0 & Properties.Settings.Default.D < 10000) Page4D.Value = Properties.Settings.Default.D;
            //    if (Properties.Settings.Default.E > 0 & Properties.Settings.Default.E < 10000) Page4E.Value = Properties.Settings.Default.E;
            //    if (Properties.Settings.Default.F > 0 & Properties.Settings.Default.F < 10000) Page4F.Value = Properties.Settings.Default.F;

        }

        private void SaveSettings() {
            Debug.WriteLine("Save Settings...");
            //    if (System.IO.File.Exists(Page1SurcodeTextBox.Text)) Properties.Settings.Default.SURCODEFULLNAME = Page1SurcodeTextBox.Text;
            //    if (System.IO.File.Exists(Page1eac3toTextbox.Text)) Properties.Settings.Default.EAC3TOFULLNAME = Page1eac3toTextbox.Text;
            //    if (System.IO.Directory.Exists(Page5TempTextbox.Text)) Properties.Settings.Default.TEMPPATH = Page5TempTextbox.Text;
            //    if (System.IO.Directory.Exists(Page5SaveTextbox.Text)) Properties.Settings.Default.SAVEPATH = Page5SaveTextbox.Text;
            if (System.IO.File.Exists(this.Page1SurcodeTextBox.Text)) {
                Properties.Settings.Default.SurcodeExeFullname = this.Page1SurcodeTextBox.Text;
            }
            //     }
            if (System.IO.File.Exists(this.Page1eac3toTextbox.Text)) {
                Properties.Settings.Default.Eac3toExeFullname = this.Page1eac3toTextbox.Text;
            }

            if (System.IO.Directory.Exists(this.Page5TempTextbox.Text)) {
                Properties.Settings.Default.TempFolderPath = this.Page5TempTextbox.Text;
            }

            if (System.IO.Directory.Exists(this.Page5SaveTextbox.Text)) {
                Properties.Settings.Default.OutputFolderPath = this.Page5SaveTextbox.Text;
            }
            //    Properties.Settings.Default.A = Page4A.Value;
            //    Properties.Settings.Default.B = Page4B.Value;
            //    Properties.Settings.Default.C = Page4C.Value;
            //    Properties.Settings.Default.D = Page4D.Value;
            //    Properties.Settings.Default.E = Page4E.Value;
            //    Properties.Settings.Default.F = Page4F.Value;
            //    Properties.Settings.Default.AUTOCLEAN = Page5AutoCleanCheckbox.Checked;

            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            this.UpdateMainFormText();
            this.VersionLabel.Text = "Version " + Version;

            LoadSettings();

        }

        private void Page1PictureBox_Click(object sender, EventArgs e) {

            this.Page1PictureBoxClicked = !this.Page1PictureBoxClicked;
            if (this.Page1PictureBoxClicked)
                this.Page1PictureBox.Image = Properties.Resources.audiodvd256;
            else
                this.Page1PictureBox.Image = Properties.Resources.burnCD256;
        }

        private void PagesNextButton_Click(object sender, EventArgs e) {
            this.MainTabControl.SelectedIndex += 1;
        }

        private void PagesBackButton_Click(object sender, EventArgs e) {
            this.MainTabControl.SelectedIndex -= 1;
        }

        private void Page1SurcodeBrowseButton_Click(object sender, EventArgs e) {
            using (OpenFileDialog Page1OpenFileDialog = new OpenFileDialog()) {
                Page1OpenFileDialog.AutoUpgradeEnabled = true;
                Page1OpenFileDialog.CheckFileExists = true;
                Page1OpenFileDialog.Multiselect = false;
                Page1OpenFileDialog.Filter = "surcodemlp.exe|surcodemlp.exe";

                if (Page1OpenFileDialog.ShowDialog() == DialogResult.OK) {
                    this.Page1SurcodeTextBox.Text = Page1OpenFileDialog.FileName;
                    SaveSettings();
                }
            }

        }

        private void Page1eac3toBrowseButton_Click(object sender, EventArgs e) {
            using (OpenFileDialog Page1OpenFileDialog = new OpenFileDialog()) {
                Page1OpenFileDialog.AutoUpgradeEnabled = true;
                Page1OpenFileDialog.CheckFileExists = true;
                Page1OpenFileDialog.Multiselect = false;
                Page1OpenFileDialog.Filter = "eac3to.exe|eac3to.exe";

                if (Page1OpenFileDialog.ShowDialog() == DialogResult.OK) {
                    this.Page1eac3toTextbox.Text = Page1OpenFileDialog.FileName;
                    SaveSettings();
                }
            }

        }

        private void Page2AddFilesButton_Click(object sender, EventArgs e) {
            using (OpenFileDialog Page2OpenFileDialog = new OpenFileDialog()) {
                Page2OpenFileDialog.AutoUpgradeEnabled = true;
                Page2OpenFileDialog.CheckFileExists = true;
                Page2OpenFileDialog.Multiselect = true;

                if (Page2OpenFileDialog.ShowDialog() == DialogResult.OK) {
                    foreach (string FileFullName in Page2OpenFileDialog.FileNames) {
                        AddFile(FileFullName);
                    }
                }
            }

        }

        private void AddFile(string FileFullName) {

            MediaInfo MediaFile = new MediaInfo();
            string[] FileInfo = new string[6];
            FileInfo[0] = System.IO.Path.GetFileNameWithoutExtension(FileFullName);
            FileInfo[5] = FileFullName;
            string OriginalMessage = string.Empty;
            try {
                //Get the properties
                MediaFile.Open(FileFullName);
                FileInfo[2] = MediaFile.Get(StreamKind.Audio, 0, "Duration");
                FileInfo[3] = MediaFile.Get(StreamKind.Audio, 0, "SamplingRate");
                FileInfo[4] = MediaFile.Get(StreamKind.Audio, 0, "BitDepth");
                FileInfo[1] = MediaFile.Get(StreamKind.Audio, 0, "Codec");

            }
            catch (Exception ex) {
                OriginalMessage = ex.Message;
                FileInfo[2] = FileInfo[1] = string.Empty;
                FileInfo[3] = FileInfo[4] = "0";
            }
            MediaFile.Close();

            bool Canceled = false;

            CheckAndChangeProperties(ref FileInfo, OriginalMessage, false, ref Canceled);

            if (Canceled) return;
            ListViewItem FileItem = new ListViewItem(FileInfo);
            this.Page2ListView.Items.Add(FileItem);
            CheckListView();

        }

        private void CheckAndChangeProperties(ref string[] FileInfo, string OriginalMessage, bool Manually, ref bool Canceled) {

            Debug.Assert(FileInfo.Length == 6);
            bool FileInfoCorrect = !Manually;
            bool NameExists = false, SamplingRateIncorrect = false, BitDepthIncorrect = false, NameIllegal = false, DurationIncorrect = false;
            do {
                if (!FileInfoCorrect) {
                    using (PropertyForm Form = new PropertyForm()) {

                        string Message = OriginalMessage;
                        if (NameIllegal) Message += MainFormCodeStrings.CheckAndChangePropertiesNameIllegalString + Environment.NewLine;
                        if (NameExists) Message += MainFormCodeStrings.CheckAndChangePropertiesNameExistsString + Environment.NewLine;
                        if (SamplingRateIncorrect) Message += MainFormCodeStrings.CheckAndChangePropertiesSamplingRateIncorrectString + Environment.NewLine;
                        if (BitDepthIncorrect) Message += MainFormCodeStrings.CheckAndChangePropertiesBitDepthIncorrectString + Environment.NewLine;
                        if (DurationIncorrect) Message += MainFormCodeStrings.CheckAndChangePropertiesDurationIncorrectString + Environment.NewLine;

                        Canceled = false;
                        Form.ShowDialog(ref FileInfo, Message, ref Canceled);

                        if (Canceled) {
                            return;
                        }

                    }

                }

                CheckInfo(FileInfo, ref NameIllegal, ref NameExists, ref SamplingRateIncorrect, ref BitDepthIncorrect, ref DurationIncorrect);
                FileInfoCorrect = !(NameIllegal || NameExists || SamplingRateIncorrect || BitDepthIncorrect || DurationIncorrect);

            } while (!FileInfoCorrect);
        }

        private void CheckInfo(string[] FileInfo, ref bool NameIllegal, ref bool NameExists, ref bool SamplingRateIncorrect, ref bool BitDepthIncorrect, ref bool DurationIncorrect) {
            Debug.Assert(FileInfo.Length == 6);

            NameExists = false;

            if (String.IsNullOrEmpty(FileInfo[0]) || FileInfo[0].IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0) {
                NameIllegal = true;
            }

            else {
                NameIllegal = false;
                foreach (ListViewItem Item in this.Page2ListView.Items) {
                    if (Item.SubItems[0].Text == FileInfo[0]) {
                        NameExists = true;
                        break;
                    }
                }
            }

            if (Microsoft.VisualBasic.Information.IsNumeric(FileInfo[3])) {
                SamplingRateIncorrect = (Convert.ToInt32(FileInfo[3], CultureInfo.CurrentCulture) <= 0);
            }
            else {
                SamplingRateIncorrect = true;
            }

            if (Microsoft.VisualBasic.Information.IsNumeric(FileInfo[4])) {
                BitDepthIncorrect = (Convert.ToInt32(FileInfo[4], CultureInfo.CurrentCulture) <= 0);
            }
            else {
                BitDepthIncorrect = true;
            }

            if (Microsoft.VisualBasic.Information.IsNumeric(FileInfo[2])) {
                DurationIncorrect = Convert.ToInt32(FileInfo[2], CultureInfo.CurrentCulture) <= 0;
            }
            else {
                DurationIncorrect = true;
            }

        }
        //private IntPtr RunSurcode(bool Hidden, bool CloseAtOnce) {
        private IntPtr RunSurcode(bool CloseAtOnce) {
            //  Int32 WaitTimes = Decimal.ToInt32(Page4WaitTimes.Value) 

            Int32 SmallWaitInterval = Decimal.ToInt32(this.Page4B.Value);
            Int32 SmallWaitTimes = Decimal.ToInt32(this.Page4A.Value / this.Page4B.Value) + 1;
            string SurcodeFileFullName = this.Page1SurcodeTextBox.Text;
            string SurcodeFilePath = System.IO.Path.GetDirectoryName(SurcodeFileFullName);
            Debug.WriteLine(SurcodeFilePath);

            IntPtr hWnd;
            //1. looking for other window
            do {
                hWnd = NativeMethods.FindWindowExW(IntPtr.Zero, IntPtr.Zero, null, "MLP Encoder");
                if (hWnd != IntPtr.Zero) NativeMethods.SendMessageW(hWnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, string.Empty);
            } while (hWnd != IntPtr.Zero);

            if (!CloseAtOnce) {
                do {
                    hWnd = NativeMethods.FindWindowExW(IntPtr.Zero, IntPtr.Zero, null, "MLP Encoder Log File");
                    if (hWnd != IntPtr.Zero) NativeMethods.SendMessageW(hWnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, string.Empty);
                } while (hWnd != IntPtr.Zero);
            }

            //2. start surcode
            using (Process SurcodeProcess = new Process()) {
                SurcodeProcess.StartInfo.UseShellExecute = true;
                SurcodeProcess.StartInfo.FileName = SurcodeFileFullName;
                SurcodeProcess.StartInfo.Arguments = string.Empty;
                SurcodeProcess.StartInfo.WorkingDirectory = SurcodeFilePath;
                //if (Hidden) {
                //    SurcodeProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //}
                //else {
                //    SurcodeProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                //}

                try {
                    SurcodeProcess.Start();

                    for (int k = 0; k < SmallWaitTimes; ++k) {
                        Thread.Sleep(SmallWaitInterval);
                        hWnd = NativeMethods.FindWindowExW(IntPtr.Zero, IntPtr.Zero, null, "MLP Encoder");
                        if (hWnd != IntPtr.Zero) {
                            Debug.WriteLine("Start time = " + SmallWaitInterval * (k + 1) + " ms");
                            break;
                        }
                    }

                    if (hWnd == IntPtr.Zero) {
                        throw new Exception(MainFormCodeStrings.RunSurcodeTimeoutString);
                    }
                    else {
                        NativeMethods.SendMessageW(hWnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, "MLP Encoder - In Control");

                        if (CloseAtOnce) {
                            NativeMethods.SendMessageW(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                            return IntPtr.Zero;
                        }
                        else {
                            //Success
                            return hWnd;
                        }
                    }

                }
                catch (Exception ex) {
                    string Message = MainFormCodeStrings.RunSurcodeFailedString + Environment.NewLine + ex.Message;
                    //hWnd = IntPtr.Zero;
                    throw new Exception(Message);
                }
            }


            //hWnd = NativeMethods.ShellExecuteW(IntPtr.Zero, "open", SurcodeFileFullName, null, SurcodeFilePath, WindowState);
            //if (hWnd.ToInt32() <= 32) // x86 build only!
            //{
            //    string Message = "Can not start Surcode MLP Encoder. Error code " + hWnd.ToString() + "." + Environment.NewLine + ErrorCodeToString(hWnd);
            //    hWnd = IntPtr.Zero;
            //    throw new Exception(Message);
            //}
            //else {
            //    for (int k = 0; k < SmallWaitTimes; ++k) {
            //        System.Threading.Thread.Sleep(SmallWaitInterval);
            //        hWnd = NativeMethods.FindWindowExW(IntPtr.Zero, IntPtr.Zero, null, "MLP Encoder");
            //        if (hWnd != IntPtr.Zero) {
            //            Debug.WriteLine("Start time = " + SmallWaitInterval * (k + 1) + " ms");
            //            break;
            //        }
            //    }

            //    if (hWnd == IntPtr.Zero) {
            //        throw new Exception("Can not start Surcode MLP Encoder. Time's out.");
            //    }
            //    else {
            //        NativeMethods.SendMessageW(hWnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, "MLP Encoder - In Control");

            //        if (CloseAtOnce) {
            //            NativeMethods.SendMessageW(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            //            return IntPtr.Zero;
            //        }
            //        else {
            //            //Success
            //            return hWnd;
            //        }
            //    }
            //}

        }

        //private static string ErrorCodeToString(IntPtr hWnd) {
        //    switch (hWnd.ToInt32()) {
        //        case 0:
        //            return "The operating system is out of memory or resources.";
        //        case 2:
        //            return "The specified file was not found.";
        //        case 3:
        //            return "The specified path was not found.";
        //        case 11:
        //            return "The .exe file is invalid (non-Win32 .exe or error in .exe image).";
        //        case 5:
        //            return "The operating system denied access to the specified file.";
        //        case 27:
        //            return "The file name association is incomplete or invalid.";
        //        case 30:
        //            return "The DDE transaction could not be completed because other DDE transactions were being processed.";
        //        case 29:
        //            return "The DDE transaction failed.";
        //        case 28:
        //            return "The DDE transaction could not be completed because the request timed out.";
        //        case 32:
        //            return "The specified DLL was not found.";
        //        case 31:
        //            return "There is no application associated with the given file name extension. This error will also be returned if you attempt to print a file that is not printable.";
        //        case 8:
        //            return "There was not enough memory to complete the operation.";
        //        case 26:
        //            return "A sharing violation occurred.";
        //        default:
        //            return string.Empty;
        //    }
        //}
        private void OpenSurcodeOptions(IntPtr hWnd) {

            AutomationElement SurcodeElement = AutomationElement.FromHandle(hWnd);

            AutomationElement Menu2Element = SurcodeElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem), new PropertyCondition(AutomationElement.AutomationIdProperty, "Item 2")));
            if (Menu2Element == null || Menu2Element.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() != "Options") {
                throw new Exception(MainFormCodeStrings.OpenSurcodeOptionsCannotFindOptionsMenuString);
            }

            try {
                ExpandCollapsePattern Menu2Pattern = (ExpandCollapsePattern)Menu2Element.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                Menu2Pattern.Expand();
            }
            catch (Exception ex) {
                throw new Exception(MainFormCodeStrings.OpenSurcodeOptionsCannotExpandOptionsMenuString + Environment.NewLine + ex.Message);
            }

            Thread.Sleep(Convert.ToInt32(this.Page4B.Value, CultureInfo.InvariantCulture) * 10);

            AutomationElement Menu2EncoderOptionElement = Menu2Element.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem), new PropertyCondition(AutomationElement.AutomationIdProperty, "Item 32772")));
            if (Menu2EncoderOptionElement == null || Menu2EncoderOptionElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() != "Encoder Options...") {
                throw new Exception(MainFormCodeStrings.OpenSurcodeOptionsCannotFindEncoderOptionsMenuString);
            }

            try {
                InvokePattern Menu2EncoderOptionPattern = (InvokePattern)Menu2EncoderOptionElement.GetCurrentPattern(InvokePattern.Pattern);
                Menu2EncoderOptionPattern.Invoke();
            }
            catch (Exception ex) {
                throw new Exception(MainFormCodeStrings.OpenSurcodeOptionsCannotClickEncoderOptionsMenuString + Environment.NewLine + ex.Message);
            }

            NativeMethods.SendMessageW(hWnd, NativeMethods.WM_SETTEXT, IntPtr.Zero, "MLP Encoder");
        }

        private void Page4SurcodeOptionButton_Click(object sender, EventArgs e) {
            this.Page4SurcodeOptionButton.Enabled = false;
            this.Page4BackgroundWorker.RunWorkerAsync();
        }

        private void Page2RemoveButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem Item in this.Page2ListView.SelectedItems) {
                this.Page2ListView.Items.Remove(Item);
            }
            CheckListView();
        }

        private void Page2ListView_SelectedIndexChanged(object sender, EventArgs e) {
            CheckListView();
        }

        private void Page2ClearAllButton_Click(object sender, EventArgs e) {
            this.Page2ListView.Items.Clear();
            CheckListView();
        }

        private void CheckListView() {
            /* Page2NextButton.Enabled =*/
            this.Page2ClearAllButton.Enabled = this.Page2ListView.Items.Count > 0;
            if (this.Page2ListView.SelectedItems.Count == 1) {
                this.Page2RemoveButton.Enabled = this.Page2RenameButton.Enabled = this.Page2PropertyButton.Enabled = true;
            }
            else if (this.Page2ListView.SelectedItems.Count == 0) {
                this.Page2RemoveButton.Enabled = this.Page2RenameButton.Enabled = this.Page2PropertyButton.Enabled = false;
            }
            else {
                this.Page2RemoveButton.Enabled = true;
                this.Page2RenameButton.Enabled = this.Page2PropertyButton.Enabled = false;
            }

        }

        private void Page2ListView_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] FileFullnames = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string FileFullname in FileFullnames) {
                    AddFile(FileFullname);
                }

            }
        }

        private void Page2ListView_DragEnter(object sender, DragEventArgs e) {

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Page2PropertyButton_Click(object sender, EventArgs e) {
            Debug.Assert(this.Page2ListView.SelectedItems.Count == 1);
            bool Canceled = false;
            string Message = MainFormCodeStrings.Page2PropertyButtonClickMessageStringLeft + (sender as Button).Text.Replace("&", "") + MainFormCodeStrings.Page2PropertyButtonClickMessageStringRight + Environment.NewLine;
            string[] FileInfo = new string[6];
            for (int i = 0; i < 6; ++i) {
                FileInfo[i] = this.Page2ListView.SelectedItems[0].SubItems[i].Text;
                Debug.WriteLine("FileInfo[" + i.ToString(CultureInfo.InvariantCulture) + "]=" + FileInfo[i]);
            }

            //Aviod the same filename
            string OriginalFileName = this.Page2ListView.SelectedItems[0].SubItems[0].Text;
            this.Page2ListView.SelectedItems[0].SubItems[0].Text = '*' + this.Page2ListView.SelectedItems[0].SubItems[0].Text;

            CheckAndChangeProperties(ref FileInfo, Message, true, ref Canceled);

            if (!Canceled) {
                for (int i = 0; i < 6; ++i) {
                    this.Page2ListView.SelectedItems[0].SubItems[i].Text = FileInfo[i];
                }
            }
            else {
                this.Page2ListView.SelectedItems[0].SubItems[0].Text = OriginalFileName;
            }

        }

        private void Page3DownDplRadioButton_CheckedChanged(object sender, EventArgs e) {

            this.Page3DplMixlfeCheckBox.Enabled = this.Page3DplPhaseShiftCheckBox.Enabled = this.Page3DownDplRadioButton.Checked;

        }

        private void Page4CheckBox_CheckedChanged(object sender, EventArgs e) {
            this.Page4GroupBox.Enabled = this.Page4CheckBox.Checked;
        }

        //private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
        //    {
        //        // SaveSettings();
        //    }

        //}

        private void Page4BackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            string Message = string.Empty;
            e.Result = string.Empty;
            IntPtr hWnd = IntPtr.Zero;
            Int32 RetryTimes = decimal.ToInt32(this.Page4C.Value);
            for (int i = 1; i <= RetryTimes; ++i) {
                try {
                    hWnd = RunSurcode(false);
                    OpenSurcodeOptions(hWnd);
                    break;
                }
                catch (Exception ex) {
                    if (hWnd.ToInt32() > 32) {
                        NativeMethods.SendMessageW(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    }
                    Debug.WriteLine(ex.Message);
                    Message += i.ToString(CultureInfo.CurrentCulture) + ": " + ex.Message + Environment.NewLine;
                    if (i == RetryTimes) {
                        e.Result = Message;
                    }
                    else {
                        Thread.Sleep(decimal.ToInt32(this.Page4B.Value));
                    }
                }
            }
        }

        private void Page5SaveButton_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog Page5FolderDialog = new FolderBrowserDialog()) {
                Page5FolderDialog.ShowNewFolderButton = true;
                if (Page5FolderDialog.ShowDialog() == DialogResult.OK) {
                    this.Page5SaveTextbox.Text = Page5FolderDialog.SelectedPath;
                    SaveSettings();
                }
            }

        }

        private void Page5TempButton_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog Page5FolderDialog = new FolderBrowserDialog()) {
                Page5FolderDialog.ShowNewFolderButton = true;
                if (Page5FolderDialog.ShowDialog() == DialogResult.OK) {
                    this.Page5TempTextbox.Text = Page5FolderDialog.SelectedPath;
                    SaveSettings();
                }
            }
        }

        private void Page4BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!String.IsNullOrEmpty(e.Result.ToString())) {
                MessageBox.Show(e.Result.ToString(), MainFormCodeStrings.Page4BackgroundWorkerRunWorkerCompletedErrorString, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Page4SurcodeOptionButton.Enabled = true;
        }

        private void Page5StartButton_Click(object sender, EventArgs e) {
            //1. Check
            if (!System.IO.File.Exists(this.Page1SurcodeTextBox.Text)) {
                MessageBox.Show(MainFormCodeStrings.Page5StartButtonClickCannotFindSurcodeString, MainFormCodeStrings.Page5StartButtonClickMissingFileString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MainTabControl.SelectedIndex = 0;
                return;
            }
            if (!System.IO.File.Exists(this.Page1eac3toTextbox.Text)) {
                MessageBox.Show(MainFormCodeStrings.Page5StartButtonClickCannotFindEac3toString, MainFormCodeStrings.Page5StartButtonClickMissingFileString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MainTabControl.SelectedIndex = 0;
                return;
            }
            if (!System.IO.Directory.Exists(this.Page5TempTextbox.Text)) {
                MessageBox.Show(MainFormCodeStrings.Page5StartButtonClickCannotFindTempFolderString, MainFormCodeStrings.Page5StartButtonClickMissingDirectoryString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MainTabControl.SelectedIndex = 4;
                return;
            }
            if (!System.IO.Directory.Exists(this.Page5SaveTextbox.Text)) {
                MessageBox.Show(MainFormCodeStrings.Page5StartButtonClickCannotFindOutputFolderString, MainFormCodeStrings.Page5StartButtonClickMissingDirectoryString, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.MainTabControl.SelectedIndex = 4;
                return;
            }

            //2. 
            this.eac3Processing = this.SurcodeProcessing = this.Processing = true;
            this.MainTabControl.SelectedIndex = 5;
            this.Page6eac3toProgressBar.Value = this.Page6eac3toProgressBar.Minimum;
            this.Page6SurcodeProgressBar.Value = this.Page6SurcodeProgressBar.Minimum;
            this.eac3toOK = new bool[this.Page2ListView.Items.Count];
            this.eac3toFailed = new bool[this.Page2ListView.Items.Count];
            this.SurcodeFailed = new bool[this.Page2ListView.Items.Count];
            Array.Clear(this.eac3toOK, 0, this.eac3toOK.Length);
            Array.Clear(this.eac3toFailed, 0, this.eac3toFailed.Length);
            Array.Clear(this.SurcodeFailed, 0, this.SurcodeFailed.Length);
            this.Page1Panel.Enabled = this.Page2Panel.Enabled = this.Page3Panel.Enabled = this.Page4Panel.Enabled = this.Page5Panel.Enabled = false;
            this.Files = new string[this.Page2ListView.Items.Count, 6];
            for (int i = 0; i < this.Page2ListView.Items.Count; ++i)
                for (int j = 0; j < 6; ++j)
                    this.Files[i, j] = this.Page2ListView.Items[i].SubItems[j].Text;
            this.Page6CancelButton.Enabled = true;
            this.Page6eac3toListView.Items.Clear();
            this.Page6SurcodeListView.Items.Clear();

            //3. Start threads
            this.Page6eac3toBackgroundWorker.RunWorkerAsync();
            this.Page6SurcodeBackgroundWorker.RunWorkerAsync();
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e) {
            if (this.Processing) {
                if (e.TabPageIndex < 5) {
                    e.Cancel = true;
                }
            }

            else {
                if (e.TabPageIndex == 5) {
                    // e.Cancel = true;
                }
            }
        }

        private Int32 GetChosenSamplingRate() {
            if (this.Page3_44100RadioButton.Checked) return 44100;
            else if (this.Page3_48000RadioButton.Checked) return 48000;
            else if (this.Page3_88200RadioButton.Checked) return 88200;
            else if (this.Page3_96000RadioButton.Checked) return 96000;
            else if (this.Page3_176400RadioButton.Checked) return 176400;
            else if (this.Page3_192000RadioButton.Checked) return 192000;
            else {
                Debug.Assert(false);
                throw new Exception("None of the sampling rates are chosen.");
            }

        }
        private Int32 GetChosenBitDepth() {
            if (this.Page3_16RadioButton.Checked) return 16;
            else if (this.Page3_20RadioButton.Checked) return 20;
            else if (this.Page3_24RadioButton.Checked) return 24;
            else {
                Debug.Assert(false);
                throw new Exception("None of the bit depth are chosen.");
            }

        }

        private static void CreateSsfFiles(string FileName, string WavFilePath, string SsfFilePath, string MlpFilePath) {

            using (System.IO.BinaryWriter SsfFileWriter = new System.IO.BinaryWriter(new System.IO.FileStream
                (SsfFilePath + '\\' + FileName + ".ssf", System.IO.FileMode.Create))) {
                byte[] FileHeadBin = { 7, 83, 117, 114, 99, 111, 100, 101, 3, 49, 46, 48, 32, 32, 32, 32, 32, 32, 32,
                32, 1, 32, 32, 32, 1, 32, 32, 32, 1, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 1, 32, 32, 32, 1,
                32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 15, 32, 32, 32, 32, 32, 32, 32, 32,
                32, 32, 32, 1, 32, 32, 32, 27, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32,
                32, 32, 32, 7, 32, 32, 32, 7, 32, 32, 32 };
                byte[] FileEndBin = { 0, 0, 0 };

                bool FLExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".L.wav");
                bool FRExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".R.wav");
                bool CExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".C.wav");
                bool SLExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".SL.wav");
                bool SRExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".SR.wav");
                bool LfeExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".LFE.wav");
                bool SExists = System.IO.File.Exists(WavFilePath + "\\" + FileName + ".S.wav");

                byte[] WavFilePathBin = Encoding.Default.GetBytes(WavFilePath.TrimEnd('\\') + '\\');
                byte[] MlpFilePathBin = Encoding.Default.GetBytes(MlpFilePath.TrimEnd('\\') + '\\');
                byte[] MlpFileFullNameBin = Encoding.Default.GetBytes(MlpFilePath.TrimEnd('\\') + '\\' + FileName + ".mlp");

                byte[] ModeBin, FLBin, FRBin, SLBin, SRBin, CBin, LfeBin;

                if (CExists && (!(FLExists || FRExists || LfeExists || SLExists || SRExists)))
                    ModeBin = new byte[] { 0 };
                else if (FLExists && FRExists && (!(LfeExists || SLExists || SRExists || CExists)))
                    ModeBin = new byte[] { 1 };
                else if (FLExists && FRExists && SExists && (!(CExists || LfeExists || SLExists || SRExists)))
                    ModeBin = new byte[] { 2 };
                else if (FLExists && FRExists && SLExists && SRExists && (!(CExists || LfeExists)))
                    ModeBin = new byte[] { 3 };
                else if (FLExists && FRExists && LfeExists && (!(CExists || SLExists || SRExists)))
                    ModeBin = new byte[] { 4 };
                else if (FLExists && FRExists && LfeExists && SExists && (!CExists || SLExists || SRExists))
                    ModeBin = new byte[] { 5 };
                else if (FLExists && FRExists && LfeExists && SLExists && SRExists && (!(CExists)))
                    ModeBin = new byte[] { 6 };
                else if (CExists && FLExists && FRExists && (!(LfeExists || SLExists || SRExists)))
                    ModeBin = new byte[] { 7 };
                else if (CExists && FLExists && FRExists && SExists && (!(LfeExists || SLExists || SRExists)))
                    ModeBin = new byte[] { 8 };
                else if (FLExists && FRExists && CExists && SLExists && SRExists && (!LfeExists))
                    ModeBin = new byte[] { 9 };
                else if (FLExists && FRExists && CExists && LfeExists && (!(SLExists || SRExists)))
                    ModeBin = new byte[] { 10 };
                else if (FLExists && FRExists && CExists && LfeExists && SExists && (!(SLExists || SRExists)))
                    ModeBin = new byte[] { 11 };
                else if (FLExists && FRExists && CExists && LfeExists && SLExists && SRExists)
                    ModeBin = new byte[] { 12 };
                else if (FLExists && FRExists && CExists && SExists && (!(LfeExists || SRExists || SLExists)))
                    ModeBin = new byte[] { 13 };
                else if (FLExists && FRExists && CExists && SLExists && SRExists && (!LfeExists))
                    ModeBin = new byte[] { 14 };
                else if (FLExists && FRExists && CExists && LfeExists && (!(SLExists || SRExists)))
                    ModeBin = new byte[] { 15 };
                else if (FLExists && FRExists && CExists && LfeExists && SExists && (!(SLExists || SRExists)))
                    ModeBin = new byte[] { 16 };
                else if (FLExists && FRExists && CExists && LfeExists && SLExists && SRExists)
                    ModeBin = new byte[] { 17 };
                else if (FLExists && FRExists && LfeExists && SLExists && SRExists && (!CExists))
                    ModeBin = new byte[] { 18 };
                else if (FLExists && FRExists && CExists && SLExists && SRExists && (!LfeExists))
                    ModeBin = new byte[] { 19 };
                else if (FLExists && FRExists && CExists && LfeExists && SLExists && SRExists)
                    ModeBin = new byte[] { 20 };
                else {
                    throw new Exception(MainFormCodeStrings.CreateSsfFilesExceptionString);
                }

                if (FLExists)
                    FLBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".L.wav");
                else
                    FLBin = new byte[] { 0 };

                if (FRExists)
                    FRBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".R.wav");
                else
                    FRBin = new byte[] { 0 };

                if (SLExists)
                    SLBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".SL.wav");
                else if (SExists)
                    SLBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".S.wav");
                else
                    SLBin = new byte[] { 0 };

                if (SRExists)
                    SRBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".SR.wav");
                else
                    SRBin = new byte[] { 0 };

                if (LfeExists)
                    LfeBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".LFE.wav");
                else
                    LfeBin = new byte[] { 0 };

                if (CExists)
                    CBin = Encoding.Default.GetBytes(WavFilePath + "\\" + FileName + ".C.wav");
                else
                    CBin = new byte[] { 0 };

                SsfFileWriter.Write(FileHeadBin);
                SsfFileWriter.Write(Convert.ToByte(FLBin.Length));
                SsfFileWriter.Write(FLBin);
                SsfFileWriter.Write(Convert.ToByte(FRBin.Length));
                SsfFileWriter.Write(FRBin);
                SsfFileWriter.Write(Convert.ToByte(SLBin.Length));
                SsfFileWriter.Write(SLBin);
                SsfFileWriter.Write(Convert.ToByte(SRBin.Length));
                SsfFileWriter.Write(SRBin);
                SsfFileWriter.Write(Convert.ToByte(CBin.Length));
                SsfFileWriter.Write(CBin);
                SsfFileWriter.Write(Convert.ToByte(LfeBin.Length));
                SsfFileWriter.Write(LfeBin);
                SsfFileWriter.Write(Convert.ToByte(WavFilePathBin.Length));
                SsfFileWriter.Write(WavFilePathBin);
                SsfFileWriter.Write(Convert.ToByte(MlpFilePathBin.Length));
                SsfFileWriter.Write(MlpFilePathBin);
                SsfFileWriter.Write(Convert.ToByte(MlpFileFullNameBin.Length));
                SsfFileWriter.Write(MlpFileFullNameBin);
                SsfFileWriter.Write(ModeBin);
                SsfFileWriter.Write(FileEndBin);
                //SsfFileWriter.Close();

            }

        }

        private void Page6eac3toBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < this.Page2ListView.Items.Count; ++i) {
                if (this.Page6eac3toBackgroundWorker.CancellationPending) { e.Cancel = true; return; } //check the cancel button

                string Arguments = string.Empty;
                //Generate eac3to arguments
                if (this.Page4CheckBox.Checked && this.Page4eac3toCheckBox.Checked && this.Page4IgnoreCheckBox.Checked) {
                    Arguments = this.Page4eac3toTextBox.Text;
                }
                else {
                    //1. Resampling
                    if (this.Page3AlwaysResampleRadioButton.Checked) {
                        Arguments += " -resampleTo" + GetChosenSamplingRate().ToString(CultureInfo.InvariantCulture);
                    }
                    else if (this.Page3OnlyResampleRadioButton.Checked) {
                        if (!(this.Files[i, 3] == "44100" || this.Files[i, 3] == "48000" || this.Files[i, 3] == "88200" || this.Files[i, 3] == "96000" || this.Files[i, 3] == "176000" || this.Files[i, 3] == "192000")) {
                            Arguments += " -resampleTo" + GetChosenSamplingRate().ToString(CultureInfo.InvariantCulture);
                        }

                    }
                    //2. Rebit 

                    //Experimental!

                    if (this.Always16bitsRadioButton.Checked) {
                        Arguments += " -down16";
                    }

                    else if (this.Page3AlwaysRebitRadioButton.Checked) {
                        Arguments += " -down" + GetChosenBitDepth().ToString(CultureInfo.InvariantCulture);
                    }
                    else if (this.Page3OnlyRebitRadioButton.Checked) {
                        if (this.Files[i, 4] == "16") {
                            Arguments += " -down16";
                        }
                        else if (this.Files[i, 4] == "20") {
                            Arguments += " -down20";
                        }
                        else if (this.Files[i, 4] == "24") {
                            Arguments += " -down24";
                        }
                        else {
                            Arguments += " -down" + GetChosenSamplingRate().ToString(CultureInfo.InvariantCulture);
                        }

                    }

                    //3. Downmix

                    if (this.Page3Down6RadioButton.Checked) {
                        Arguments += " -down6";
                    }
                    else if (this.Page3DownDplRadioButton.Checked) {
                        Arguments += " -downDpl";
                        if (this.Page3DplMixlfeCheckBox.Checked) Arguments += " -mixlfe";
                        if (this.Page3DplPhaseShiftCheckBox.Checked) Arguments += " -phaseShift";
                    }
                    else if (this.Page3DownStereoRadioButton.Checked) {
                        Arguments += " -downStereo";
                    }

                    if (this.Page4CheckBox.Checked && this.Page4eac3toCheckBox.Checked) Arguments += " " + this.Page4eac3toTextBox.Text;

                    if (this.Page6eac3toBackgroundWorker.CancellationPending) { e.Cancel = true; return; } //check the cancel button

                    int BigWaitTime = Convert.ToInt32(this.Page4D.Value + this.Page4E.Value * Convert.ToInt32(this.Files[i, 2]), CultureInfo.CurrentCulture);
                    int BigWaitInterval = decimal.ToInt32(this.Page4F.Value);
                    int BigWaitTimes = BigWaitTime * 1000 / BigWaitInterval + 1;
                    Int32 RetryTimes = decimal.ToInt32(this.Page4C.Value);
                    for (int j = 1; j <= RetryTimes; ++j) {
                        try {
                            Debug.WriteLine("i=" + i + " j=" + j);

                            if (this.Page6eac3toBackgroundWorker.CancellationPending) { e.Cancel = true; return; } //check the cancel button

                            using (Process eac3toProcess = new Process()) {
                                //eac3toProcess.StartInfo.RedirectStandardError = true;
                                //eac3toProcess.StartInfo.RedirectStandardOutput = true;
                                eac3toProcess.StartInfo.UseShellExecute = true;
                                eac3toProcess.StartInfo.FileName = this.Page1eac3toTextbox.Text;
                                Debug.WriteLine("eac3toProcess.StartInfo.FileName = " + eac3toProcess.StartInfo.FileName);
                                eac3toProcess.StartInfo.Arguments = "\"" + this.Files[i, 5] + "\" \"" + this.Page5TempTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + ".wavs\"" + Arguments;
                                eac3toProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                Debug.WriteLine("eac3toProcess.StartInfo.Arguments = " + eac3toProcess.StartInfo.Arguments);

                                eac3toProcess.Start();

                                this.Page6eac3toBackgroundWorker.ReportProgress(i * 100 / this.Page2ListView.Items.Count, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, MainFormCodeStrings.Page6eac3toBackgroundWorkerDoWorkEac3toWorkingString, this.Files[i, 0], false));

                                bool eac3toExited = false;
                                for (int k = 0; k < BigWaitTimes; ++k) {
                                    eac3toExited = eac3toProcess.WaitForExit(BigWaitInterval);
                                    if (this.Page6eac3toBackgroundWorker.CancellationPending) { e.Cancel = true; return; } //check the cancel button
                                    if (eac3toExited) break;
                                }
                                if (!eac3toExited) {
                                    throw new Exception(MainFormCodeStrings.Page6eac3toBackgroundWorkerDoWorkEac3toTimeoutString);
                                }
                                //Debug.WriteLine("StandardOutput:");
                                //Debug.WriteLine(eac3toProcess.StandardOutput.ReadToEnd());
                                //Debug.WriteLine("StandardError:");
                                //Debug.WriteLine(eac3toProcess.StandardError.ReadToEnd());
                                try {
                                    CreateSsfFiles(this.Files[i, 0], this.Page5TempTextbox.Text, this.Page5TempTextbox.Text, this.Page5SaveTextbox.Text);
                                }
                                catch (Exception ex) {
                                    string Message = ex.Message;
                                    if (System.IO.File.Exists(this.Page5TempTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + " - Log.txt")) {
                                        using (System.IO.StreamReader Reader = new System.IO.StreamReader(this.Page5TempTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + " - Log.txt", Encoding.Default)) {
                                            Message += Environment.NewLine + "------------------------------------------------------------------------------" + Environment.NewLine + Reader.ReadToEnd();
                                            // Reader.Close();
                                        }

                                    }

                                    throw new Exception(Message);
                                }

                                this.eac3toOK[i] = true;
                                this.eac3toFailed[i] = false;

                            }

                            break;
                        }
                        catch (Exception ex) {
                            //1.Report
                            this.Page6eac3toBackgroundWorker.ReportProgress(i * 100 / this.Page2ListView.Items.Count, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, ex.Message, this.Files[i, 0], true));

                            //2. eac3toError boolean
                            if (j == RetryTimes) {
                                this.eac3toFailed[i] = true;
                                this.eac3toOK[i] = false;
                            }
                            else {
                                Thread.Sleep(BigWaitInterval);
                            }

                        }
                    }

                }

            }

        }
        private static void ExecuteReports(Page6WorkerReportArgument Report, ListView Page6ListView) {
            if (Report.Order == Page6WorkerReportArgument.Orders.MessageBox) {
                MessageBox.Show(Report.Message, MainFormCodeStrings.ExecuteReportsMessageString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Report.Order == Page6WorkerReportArgument.Orders.Add) {
                ListViewItem Item = new ListViewItem(new string[] { Report.Time, Report.FileName, Report.Message });
                if (Report.Stress) {
                    Item.ForeColor = Color.Red;
                }
                Page6ListView.Items.Add(Item);

            }
        }

        private void Page6eac3toBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled) {
                this.Page6eac3toProgressBar.Value = this.Page6eac3toProgressBar.Maximum;
            };
            this.eac3Processing = false;

            Page6BackgroundWorkers_RunWorkerCompleted(e);
        }

        private void Page6Listviews_SelectedIndexChanged(object sender, EventArgs e) {
            ListView Page6ListView = sender as ListView;
            if (Page6ListView.SelectedItems.Count > 0) {
                this.Page6DetailsTextbox.ForeColor = Page6ListView.SelectedItems[0].ForeColor;
                if (!String.IsNullOrEmpty(Page6ListView.SelectedItems[0].SubItems[1].Text)) {
                    this.Page6DetailsTextbox.Text = "[" + Page6ListView.SelectedItems[0].SubItems[1].Text + "] - ";
                }
                else {
                    this.Page6DetailsTextbox.Text = string.Empty;
                }
                this.Page6DetailsTextbox.Text += Page6ListView.SelectedItems[0].SubItems[0].Text;
                this.Page6DetailsTextbox.Text += Environment.NewLine + Page6ListView.SelectedItems[0].SubItems[2].Text;
            }
            else if (this.Page6eac3toListView.SelectedItems.Count == 0 && this.Page6SurcodeListView.SelectedItems.Count == 0) {
                this.Page6DetailsTextbox.ForeColor = SystemColors.WindowText;
                this.Page6DetailsTextbox.Text = MainFormCodeStrings.Page6ListviewsSelectedIndexChangedDefaultTextString;
            }
        }

        private void Page6eac3toBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.Page6eac3toProgressBar.Value = e.ProgressPercentage;
            MainForm.ExecuteReports(e.UserState as Page6WorkerReportArgument, this.Page6eac3toListView);
        }

        private void Page6SurcodeBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            this.Page6SurcodeProgressBar.Value = e.ProgressPercentage;
            MainForm.ExecuteReports(e.UserState as Page6WorkerReportArgument, this.Page6SurcodeListView);
            Debug.WriteLine("Progress = " + e.ProgressPercentage);
        }

        private void Page6SurcodeBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Int32 SmallWaitTimes = Decimal.ToInt32(this.Page4A.Value / this.Page4B.Value) + 1;
            int BigWaitInterval = decimal.ToInt32(this.Page4F.Value);
            int RetryTimes = decimal.ToInt32(this.Page4C.Value);
            Int32 SmallWaitInterval = Decimal.ToInt32(this.Page4B.Value);
            for (int j = 1; j <= RetryTimes; ++j) {
                try {
                    RunSurcode(true);
                    this.Page6SurcodeBackgroundWorker.ReportProgress(0, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkStartSurcodeString, string.Empty, false));
                    break;
                }
                catch (Exception ex) {
                    this.Page6SurcodeBackgroundWorker.ReportProgress(0, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, ex.Message, string.Empty, true));

                    if (j < RetryTimes) {
                        Thread.Sleep(BigWaitInterval);
                    }
                }
            }

            if (this.Page6SurcodeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }//check the cancel button

            for (int i = 0; i < this.Page2ListView.Items.Count; ++i) {
                int BigWaitTime = Convert.ToInt32(this.Page4D.Value + this.Page4E.Value * Int32.Parse(this.Files[i, 2]), CultureInfo.CurrentCulture);
                int BigWaitTimes = BigWaitTime * 1000 / BigWaitInterval + 1;

                if (this.Page6SurcodeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }//check the cancel button
                while (!(this.eac3toOK[i] || this.eac3toFailed[i]))//wait for eac3to
                {
                    Thread.Sleep(BigWaitInterval);
                    if (this.Page6SurcodeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }//check the cancel button

                }

                if (this.eac3toFailed[i]) {
                    this.Page6SurcodeBackgroundWorker.ReportProgress(i * 100 / this.Page2ListView.Items.Count, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkEac3toErrorString, this.Files[i, 0], false));
                    continue;
                }

                IntPtr hWnd = IntPtr.Zero;
                for (int j = 1; j <= RetryTimes; ++j) {
                    try {
                        hWnd = RunSurcode(false);
                        this.Page6SurcodeBackgroundWorker.ReportProgress(i * 100 / this.Page2ListView.Items.Count, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkStartSurcodeString, this.Files[i, 0], false));

                        if (this.Page6SurcodeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }//check the cancel button

                        //Opreate Surcode
                        AutomationElement SurcodeElement = AutomationElement.FromHandle(hWnd);

                        AutomationElementCollection Menu1Elements = SurcodeElement.FindAll(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem), new PropertyCondition(AutomationElement.AutomationIdProperty, "Item 1")));
                        AutomationElement Menu1Element = null;
                        bool found = false;
                        foreach (AutomationElement MenuElement in Menu1Elements) {
                            if (MenuElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() == "Setup") {
                                Menu1Element = MenuElement;
                                found = true;
                                break;
                            }

                        }
                        if (!found) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotFindSetupMenuString);
                        }

                        try {
                            ExpandCollapsePattern Menu1Pattern = Menu1Element.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                            Menu1Pattern.Expand();
                        }
                        catch (Exception ex) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotExpandSetupMenuString + Environment.NewLine + ex.Message);
                        }

                        Thread.Sleep(SmallWaitInterval);

                        AutomationElement Menu1OpenElement = Menu1Element.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem), new PropertyCondition(AutomationElement.AutomationIdProperty, "Item 57601")));
                        if (Menu1OpenElement == null || Menu1OpenElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() != "Open...") {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotFindOpenMenuString);
                        }

                        try {
                            InvokePattern Menu1OpenPattern = Menu1OpenElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                            Menu1OpenPattern.Invoke();
                        }
                        catch (Exception ex) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotExpandOpenMenuString + Environment.NewLine + ex.Message);
                        }

                        AutomationElement OpenWindowElement = null;

                        found = false;
                        //MUST WAIT FOR THE DIALOG!
                        for (int k = 0; k < SmallWaitTimes; ++k) {
                            Thread.Sleep(SmallWaitInterval);
                            OpenWindowElement = SurcodeElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "#32770"));
                            found = (OpenWindowElement != null);

                            if (found) break;
                        }

                        if (!found) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkOpenDialogTimeoutString);
                        }

                        AutomationElement TextBoxElement = OpenWindowElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, "1152"), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit), new PropertyCondition(AutomationElement.ClassNameProperty, "Edit")));
                        if (TextBoxElement == null) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotFindFilenameString);
                        }
                        AutomationElement OpenButtonElement = OpenWindowElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, "1"), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), new PropertyCondition(AutomationElement.ClassNameProperty, "Button")));
                        if (OpenButtonElement == null) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotFindOpenButtonString);
                        }

                        ValuePattern TextBoxPattern = TextBoxElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        TextBoxPattern.SetValue(this.Page5TempTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + ".ssf");

                        Thread.Sleep(SmallWaitInterval);
                        try {
                            InvokePattern OpenButtonPattern = OpenButtonElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                            OpenButtonPattern.Invoke();
                        }
                        catch (Exception ex) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotClickOpenButtonString + Environment.NewLine + ex.Message);
                        }

                        Thread.Sleep(SmallWaitInterval);

                        AutomationElement StartButtonElement = SurcodeElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, "1050"), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button), new PropertyCondition(AutomationElement.ClassNameProperty, "Button")));

                        if (StartButtonElement == null || StartButtonElement.GetCurrentPropertyValue(AutomationElement.NameProperty).ToString() != "Encode") {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotFindStartButtonString);
                        }

                        if (System.IO.File.Exists(this.Page5SaveTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + ".mlp")) {
                            System.IO.File.Delete(this.Page5SaveTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + ".mlp");
                        }
                        try {
                            InvokePattern StartButtonPattern = StartButtonElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                            StartButtonPattern.Invoke();
                        }
                        catch (Exception ex) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkCannotClickStartButtonString + Environment.NewLine + ex.Message);
                        }

                        IntPtr LogWindowhWnd = IntPtr.Zero;
                        found = false;
                        for (int k = 0; k < BigWaitTimes; ++k) {
                            Thread.Sleep(BigWaitInterval);
                            if (this.Page6SurcodeBackgroundWorker.CancellationPending) { e.Cancel = true; return; }//check the cancel button
                            LogWindowhWnd = NativeMethods.FindWindowExW(IntPtr.Zero, IntPtr.Zero, "#32770", "MLP Encoder Log File");
                            if (LogWindowhWnd != IntPtr.Zero) {
                                found = true;
                                break;
                            }
                        }

                        if (!found) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkSurcodeTimeoutString);
                        }

                        NativeMethods.SendMessageW(hWnd, NativeMethods.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

                        if (!System.IO.File.Exists(this.Page5SaveTextbox.Text.TrimEnd('\\') + '\\' + this.Files[i, 0] + ".mlp")) {
                            throw new Exception(MainFormCodeStrings.Page6SurcodeBackgroundWorkerDoWorkSurcodeFailedString);
                        }

                        break;
                    }
                    catch (Exception ex) {
                        this.Page6SurcodeBackgroundWorker.ReportProgress(i * 100 / this.Page2ListView.Items.Count, new Page6WorkerReportArgument(Page6WorkerReportArgument.Orders.Add, ex.Message, this.Files[i, 0], true));

                        if (j < RetryTimes) {
                            Thread.Sleep(BigWaitInterval);
                        }
                        else {
                            this.SurcodeFailed[i] = true;
                        }

                        hWnd = IntPtr.Zero;
                    }
                }

            }

        }

        private void Page6CancelButton_Click(object sender, EventArgs e) {
            if (this.Processing) {
                if (MessageBox.Show(MainFormCodeStrings.Page6CancelButtonClickConfirmTextString, MainFormCodeStrings.Page6CancelButtonClickConfirmCaptionString, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    this.Page6eac3toBackgroundWorker.CancelAsync();
                    this.Page6SurcodeBackgroundWorker.CancelAsync();

                    this.Page6CancelButton.Enabled = false;

                }
            }

        }

        private void Page1LanguageButton_Click(object sender, EventArgs e) {
            Form languageForm = new LanguageForm();
            languageForm.ShowDialog();
        }

        private void Page6BackgroundWorkers_RunWorkerCompleted(RunWorkerCompletedEventArgs e) {
            if (!(this.eac3Processing || this.SurcodeProcessing)) {
                this.Processing = false;
                this.Page1Panel.Enabled = this.Page2Panel.Enabled = this.Page3Panel.Enabled = this.Page4Panel.Enabled = this.Page5Panel.Enabled = true;
                this.Page6CancelButton.Enabled = false;

                if (e.Cancelled)
                    System.Media.SystemSounds.Asterisk.Play();
                else {
                    int ErrorFileCount = 0;
                    for (int i = 0; i < this.Page2ListView.Items.Count; ++i) {
                        this.SurcodeFailed[i] = this.SurcodeFailed[i] || this.eac3toFailed[i];
                        if (this.SurcodeFailed[i]) ++ErrorFileCount;
                    }
                    if (ErrorFileCount == 0) {
                        MessageBox.Show(MainFormCodeStrings.Page6BackgroundWorkersRunWorkerCompletedSuccessTextString, MainFormCodeStrings.Page6BackgroundWorkersRunWorkerCompletedSuccessCaptionString, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        if (MessageBox.Show(ErrorFileCount.ToString(CultureInfo.CurrentCulture) + " " + MainFormCodeStrings.Page6BackgroundWorkersRunWorkerCompletedErrorTextString, MainFormCodeStrings.Page6BackgroundWorkersRunWorkerCompletedErrorCaptionString, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                            this.Page2ListView.BeginUpdate();
                            int k = 0, OriginalCount = this.Page2ListView.Items.Count;
                            for (int i = 0; i < OriginalCount; ++i) {
                                if (!this.SurcodeFailed[i]) {
                                    Debug.WriteLine("Remove: " + this.Page2ListView.Items[i - k].Text + " i=" + i + " k=" + k);
                                    this.Page2ListView.Items.RemoveAt(i - k);
                                    ++k;
                                }
                            }
                            this.Page2ListView.EndUpdate();
                            this.MainTabControl.SelectedIndex = 1;

                        }
                    }

                }

            }
        }

        private void Page6SurcodeBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!e.Cancelled) {
                this.Page6SurcodeProgressBar.Value = this.Page6SurcodeProgressBar.Maximum;
            };

            this.SurcodeProcessing = false;

            Page6BackgroundWorkers_RunWorkerCompleted(e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.Processing) {
                if (MessageBox.Show(MainFormCodeStrings.MainFormFormClosingTextString, MainFormCodeStrings.MainFormFormClosingCaptionString, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
        }
    }
}
