namespace BustersMCUpdaterApp
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssOverallProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgressTotal = new System.Windows.Forms.ToolStripProgressBar();
            this.tssCurrentFileProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgressFile = new System.Windows.Forms.ToolStripProgressBar();
            this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbCheckForUpdates = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveLocalManifest = new System.Windows.Forms.ToolStripButton();
            this.tsbDownBranch = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbAppUpdate = new System.Windows.Forms.ToolStripButton();
            this.cbInstances = new System.Windows.Forms.ComboBox();
            this.tabsInstance = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvInstanceMods = new System.Windows.Forms.ListView();
            this.headerLeftFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerLeftStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerLeftMD5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvInstanceConfigs = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitFileLists = new System.Windows.Forms.SplitContainer();
            this.tabsRepository = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvBranchMods = new System.Windows.Forms.ListView();
            this.headerRightFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerRightStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerRightMD5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lvBranchConfigs = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bRefreshInstance = new System.Windows.Forms.Button();
            this.cbRemotePackVersion = new System.Windows.Forms.ComboBox();
            this.cbModpacks = new System.Windows.Forms.ComboBox();
            this.bRefreshRepository = new System.Windows.Forms.Button();
            this.btnBrowseRepositoryPath = new System.Windows.Forms.Button();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.tcBottomPanel = new System.Windows.Forms.TabControl();
            this.tabQueue = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lvChangesPending = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbPathInstance = new System.Windows.Forms.TextBox();
            this.bBrowseInstancePath = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnApplyRepoURI = new System.Windows.Forms.Button();
            this.eConnectionHTTPUri = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lVersionThis = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lVersionOnline = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radConnectionLocal = new System.Windows.Forms.RadioButton();
            this.radConnectionFTP = new System.Windows.Forms.RadioButton();
            this.radConnectionHTTP = new System.Windows.Forms.RadioButton();
            this.gbSettingsPaths = new System.Windows.Forms.GroupBox();
            this.tbPathLocalRepo = new System.Windows.Forms.TextBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tabChangelog = new System.Windows.Forms.TabPage();
            this.tbChangelog = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbBlacklist = new System.Windows.Forms.TextBox();
            this.fdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControlMode = new System.Windows.Forms.TabControl();
            this.tabPageUPDATER = new System.Windows.Forms.TabPage();
            this.lCurrentFile = new System.Windows.Forms.Label();
            this.pbProgressFile2 = new System.Windows.Forms.ProgressBar();
            this.pbProgressTotal2 = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lRemoteModFiles = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lFilesToDownload = new System.Windows.Forms.Label();
            this.lLocalModFiles = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lFilesToRemove = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnUpdateSelected = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabsInstance.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitFileLists)).BeginInit();
            this.splitFileLists.Panel1.SuspendLayout();
            this.splitFileLists.Panel2.SuspendLayout();
            this.splitFileLists.SuspendLayout();
            this.tabsRepository.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tcBottomPanel.SuspendLayout();
            this.tabQueue.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbSettingsPaths.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabChangelog.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlMode.SuspendLayout();
            this.tabPageUPDATER.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssOverallProgress,
            this.pbProgressTotal,
            this.tssCurrentFileProgress,
            this.pbProgressFile,
            this.lStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(628, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssOverallProgress
            // 
            this.tssOverallProgress.Name = "tssOverallProgress";
            this.tssOverallProgress.Size = new System.Drawing.Size(0, 17);
            // 
            // pbProgressTotal
            // 
            this.pbProgressTotal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgressTotal.Name = "pbProgressTotal";
            this.pbProgressTotal.Size = new System.Drawing.Size(200, 16);
            this.pbProgressTotal.Visible = false;
            // 
            // tssCurrentFileProgress
            // 
            this.tssCurrentFileProgress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssCurrentFileProgress.Name = "tssCurrentFileProgress";
            this.tssCurrentFileProgress.Size = new System.Drawing.Size(0, 17);
            this.tssCurrentFileProgress.Visible = false;
            // 
            // pbProgressFile
            // 
            this.pbProgressFile.Name = "pbProgressFile";
            this.pbProgressFile.Size = new System.Drawing.Size(100, 16);
            this.pbProgressFile.Visible = false;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = false;
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(613, 17);
            this.lStatus.Spring = true;
            this.lStatus.Text = "Launched!";
            this.lStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCheckForUpdates,
            this.tsbSaveLocalManifest,
            this.tsbDownBranch,
            this.tsbUpdate,
            this.toolStripButton1,
            this.tsbAppUpdate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(628, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbCheckForUpdates
            // 
            this.tsbCheckForUpdates.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheckForUpdates.Image")));
            this.tsbCheckForUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckForUpdates.Name = "tsbCheckForUpdates";
            this.tsbCheckForUpdates.Size = new System.Drawing.Size(114, 22);
            this.tsbCheckForUpdates.Text = "Check && Update";
            this.tsbCheckForUpdates.ToolTipText = "Gracefully checks for missed steps before updating.";
            this.tsbCheckForUpdates.Click += new System.EventHandler(this.tsbCheckForUpdates_Click);
            // 
            // tsbSaveLocalManifest
            // 
            this.tsbSaveLocalManifest.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSaveLocalManifest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveLocalManifest.Image = global::BustersMCUpdaterApp.Properties.Resources.save16;
            this.tsbSaveLocalManifest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveLocalManifest.Name = "tsbSaveLocalManifest";
            this.tsbSaveLocalManifest.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveLocalManifest.Text = "Save manifest";
            this.tsbSaveLocalManifest.Click += new System.EventHandler(this.tsbSaveLocalManifest_Click);
            // 
            // tsbDownBranch
            // 
            this.tsbDownBranch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDownBranch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDownBranch.Enabled = false;
            this.tsbDownBranch.Image = ((System.Drawing.Image)(resources.GetObject("tsbDownBranch.Image")));
            this.tsbDownBranch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDownBranch.Name = "tsbDownBranch";
            this.tsbDownBranch.Size = new System.Drawing.Size(23, 22);
            this.tsbDownBranch.Text = "Download Branch";
            this.tsbDownBranch.Click += new System.EventHandler(this.tsbDownBranch_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdate.Enabled = false;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(23, 22);
            this.tsbUpdate.Text = "Local Update";
            this.tsbUpdate.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // tsbAppUpdate
            // 
            this.tsbAppUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAppUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAppUpdate.Enabled = false;
            this.tsbAppUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbAppUpdate.ForeColor = System.Drawing.Color.Red;
            this.tsbAppUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbAppUpdate.Image")));
            this.tsbAppUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAppUpdate.Name = "tsbAppUpdate";
            this.tsbAppUpdate.Size = new System.Drawing.Size(130, 22);
            this.tsbAppUpdate.Text = "App Update Available";
            this.tsbAppUpdate.Click += new System.EventHandler(this.tsbAppUpdate_Click);
            // 
            // cbInstances
            // 
            this.cbInstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInstances.FormattingEnabled = true;
            this.cbInstances.Location = new System.Drawing.Point(6, 19);
            this.cbInstances.Name = "cbInstances";
            this.cbInstances.Size = new System.Drawing.Size(178, 21);
            this.cbInstances.TabIndex = 1;
            this.cbInstances.SelectedIndexChanged += new System.EventHandler(this.cbInstances_SelectedIndexChanged);
            // 
            // tabsInstance
            // 
            this.tabsInstance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsInstance.Controls.Add(this.tabPage1);
            this.tabsInstance.Controls.Add(this.tabPage2);
            this.tabsInstance.Location = new System.Drawing.Point(3, 3);
            this.tabsInstance.Name = "tabsInstance";
            this.tabsInstance.SelectedIndex = 0;
            this.tabsInstance.Size = new System.Drawing.Size(295, 209);
            this.tabsInstance.TabIndex = 0;
            this.tabsInstance.SelectedIndexChanged += new System.EventHandler(this.tabsInstance_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvInstanceMods);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(287, 183);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mods";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvInstanceMods
            // 
            this.lvInstanceMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInstanceMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerLeftFilename,
            this.headerLeftStatus,
            this.headerLeftMD5});
            this.lvInstanceMods.FullRowSelect = true;
            this.lvInstanceMods.GridLines = true;
            this.lvInstanceMods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInstanceMods.Location = new System.Drawing.Point(4, 3);
            this.lvInstanceMods.Name = "lvInstanceMods";
            this.lvInstanceMods.Size = new System.Drawing.Size(281, 177);
            this.lvInstanceMods.TabIndex = 0;
            this.lvInstanceMods.UseCompatibleStateImageBehavior = false;
            this.lvInstanceMods.View = System.Windows.Forms.View.Details;
            this.lvInstanceMods.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvInstanceMods_ColumnWidthChanged);
            this.lvInstanceMods.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvInstanceMods_ColumnWidthChanging);
            this.lvInstanceMods.SelectedIndexChanged += new System.EventHandler(this.lvInstanceMods_SelectedIndexChanged);
            // 
            // headerLeftFilename
            // 
            this.headerLeftFilename.Text = "Filename";
            this.headerLeftFilename.Width = 150;
            // 
            // headerLeftStatus
            // 
            this.headerLeftStatus.Text = "Status";
            this.headerLeftStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.headerLeftStatus.Width = 63;
            // 
            // headerLeftMD5
            // 
            this.headerLeftMD5.Text = "MD5";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvInstanceConfigs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(287, 183);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvInstanceConfigs
            // 
            this.lvInstanceConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInstanceConfigs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader10});
            this.lvInstanceConfigs.FullRowSelect = true;
            this.lvInstanceConfigs.GridLines = true;
            this.lvInstanceConfigs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInstanceConfigs.Location = new System.Drawing.Point(3, 3);
            this.lvInstanceConfigs.Name = "lvInstanceConfigs";
            this.lvInstanceConfigs.Size = new System.Drawing.Size(280, 177);
            this.lvInstanceConfigs.TabIndex = 1;
            this.lvInstanceConfigs.UseCompatibleStateImageBehavior = false;
            this.lvInstanceConfigs.View = System.Windows.Forms.View.Details;
            this.lvInstanceConfigs.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvInstanceConfigs_ColumnWidthChanged);
            this.lvInstanceConfigs.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvInstanceConfigs_ColumnWidthChanging);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Filename";
            this.columnHeader6.Width = 136;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Checksum";
            this.columnHeader10.Width = 123;
            // 
            // splitFileLists
            // 
            this.splitFileLists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitFileLists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitFileLists.Location = new System.Drawing.Point(0, 0);
            this.splitFileLists.Name = "splitFileLists";
            // 
            // splitFileLists.Panel1
            // 
            this.splitFileLists.Panel1.AutoScroll = true;
            this.splitFileLists.Panel1.Controls.Add(this.tabsInstance);
            this.splitFileLists.Panel1MinSize = 300;
            // 
            // splitFileLists.Panel2
            // 
            this.splitFileLists.Panel2.AutoScroll = true;
            this.splitFileLists.Panel2.AutoScrollMinSize = new System.Drawing.Size(300, 0);
            this.splitFileLists.Panel2.Controls.Add(this.tabsRepository);
            this.splitFileLists.Panel2MinSize = 300;
            this.splitFileLists.Size = new System.Drawing.Size(612, 217);
            this.splitFileLists.SplitterDistance = 303;
            this.splitFileLists.TabIndex = 3;
            // 
            // tabsRepository
            // 
            this.tabsRepository.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsRepository.Controls.Add(this.tabPage3);
            this.tabsRepository.Controls.Add(this.tabPage4);
            this.tabsRepository.Location = new System.Drawing.Point(3, 3);
            this.tabsRepository.Name = "tabsRepository";
            this.tabsRepository.SelectedIndex = 0;
            this.tabsRepository.Size = new System.Drawing.Size(298, 209);
            this.tabsRepository.TabIndex = 0;
            this.tabsRepository.SelectedIndexChanged += new System.EventHandler(this.tabsRepository_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvBranchMods);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(290, 183);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Mods";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvBranchMods
            // 
            this.lvBranchMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBranchMods.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerRightFilename,
            this.headerRightStatus,
            this.headerRightMD5});
            this.lvBranchMods.FullRowSelect = true;
            this.lvBranchMods.GridLines = true;
            this.lvBranchMods.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBranchMods.Location = new System.Drawing.Point(3, 3);
            this.lvBranchMods.Name = "lvBranchMods";
            this.lvBranchMods.Size = new System.Drawing.Size(284, 177);
            this.lvBranchMods.TabIndex = 0;
            this.lvBranchMods.UseCompatibleStateImageBehavior = false;
            this.lvBranchMods.View = System.Windows.Forms.View.Details;
            this.lvBranchMods.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvBranchMods_ColumnWidthChanged);
            this.lvBranchMods.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvBranchMods_ColumnWidthChanging);
            // 
            // headerRightFilename
            // 
            this.headerRightFilename.Text = "Filename";
            this.headerRightFilename.Width = 160;
            // 
            // headerRightStatus
            // 
            this.headerRightStatus.Text = "Status";
            this.headerRightStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // headerRightMD5
            // 
            this.headerRightMD5.Text = "MD5";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lvBranchConfigs);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(290, 183);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Configs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lvBranchConfigs
            // 
            this.lvBranchConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBranchConfigs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader11});
            this.lvBranchConfigs.FullRowSelect = true;
            this.lvBranchConfigs.GridLines = true;
            this.lvBranchConfigs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBranchConfigs.Location = new System.Drawing.Point(4, 3);
            this.lvBranchConfigs.Name = "lvBranchConfigs";
            this.lvBranchConfigs.Size = new System.Drawing.Size(281, 149);
            this.lvBranchConfigs.TabIndex = 2;
            this.lvBranchConfigs.UseCompatibleStateImageBehavior = false;
            this.lvBranchConfigs.View = System.Windows.Forms.View.Details;
            this.lvBranchConfigs.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvBranchConfigs_ColumnWidthChanged);
            this.lvBranchConfigs.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvBranchConfigs_ColumnWidthChanging);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Filename";
            this.columnHeader7.Width = 126;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Checksum";
            this.columnHeader11.Width = 134;
            // 
            // bRefreshInstance
            // 
            this.bRefreshInstance.Image = global::BustersMCUpdaterApp.Properties.Resources.refresh;
            this.bRefreshInstance.Location = new System.Drawing.Point(190, 18);
            this.bRefreshInstance.Name = "bRefreshInstance";
            this.bRefreshInstance.Size = new System.Drawing.Size(27, 23);
            this.bRefreshInstance.TabIndex = 3;
            this.bRefreshInstance.UseVisualStyleBackColor = true;
            this.bRefreshInstance.Click += new System.EventHandler(this.bRefreshInstance_Click);
            // 
            // cbRemotePackVersion
            // 
            this.cbRemotePackVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemotePackVersion.Enabled = false;
            this.cbRemotePackVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRemotePackVersion.FormattingEnabled = true;
            this.cbRemotePackVersion.ItemHeight = 12;
            this.cbRemotePackVersion.Items.AddRange(new object[] {
            "1.7.10 - 2.5.10.11"});
            this.cbRemotePackVersion.Location = new System.Drawing.Point(6, 88);
            this.cbRemotePackVersion.Name = "cbRemotePackVersion";
            this.cbRemotePackVersion.Size = new System.Drawing.Size(178, 20);
            this.cbRemotePackVersion.TabIndex = 1;
            // 
            // cbModpacks
            // 
            this.cbModpacks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModpacks.FormattingEnabled = true;
            this.cbModpacks.Location = new System.Drawing.Point(6, 61);
            this.cbModpacks.Name = "cbModpacks";
            this.cbModpacks.Size = new System.Drawing.Size(178, 21);
            this.cbModpacks.TabIndex = 4;
            this.cbModpacks.SelectedIndexChanged += new System.EventHandler(this.cbModpacks_SelectedIndexChanged);
            // 
            // bRefreshRepository
            // 
            this.bRefreshRepository.Image = global::BustersMCUpdaterApp.Properties.Resources.refresh;
            this.bRefreshRepository.Location = new System.Drawing.Point(190, 61);
            this.bRefreshRepository.Name = "bRefreshRepository";
            this.bRefreshRepository.Size = new System.Drawing.Size(27, 23);
            this.bRefreshRepository.TabIndex = 5;
            this.bRefreshRepository.UseVisualStyleBackColor = true;
            this.bRefreshRepository.Click += new System.EventHandler(this.bRefreshRepository_Click);
            // 
            // btnBrowseRepositoryPath
            // 
            this.btnBrowseRepositoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseRepositoryPath.Enabled = false;
            this.btnBrowseRepositoryPath.Location = new System.Drawing.Point(259, 17);
            this.btnBrowseRepositoryPath.Name = "btnBrowseRepositoryPath";
            this.btnBrowseRepositoryPath.Size = new System.Drawing.Size(27, 23);
            this.btnBrowseRepositoryPath.TabIndex = 4;
            this.btnBrowseRepositoryPath.Text = "...";
            this.btnBrowseRepositoryPath.UseVisualStyleBackColor = true;
            this.btnBrowseRepositoryPath.Click += new System.EventHandler(this.btnBrowseRepositoryPath_Click);
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.CheckFileExists = false;
            this.ofdBrowse.CheckPathExists = false;
            // 
            // tcBottomPanel
            // 
            this.tcBottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcBottomPanel.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcBottomPanel.Controls.Add(this.tabQueue);
            this.tcBottomPanel.Controls.Add(this.tabDetails);
            this.tcBottomPanel.Controls.Add(this.tabSettings);
            this.tcBottomPanel.Controls.Add(this.tabLog);
            this.tcBottomPanel.Controls.Add(this.tabChangelog);
            this.tcBottomPanel.Controls.Add(this.tabPage5);
            this.tcBottomPanel.Location = new System.Drawing.Point(4, 173);
            this.tcBottomPanel.Name = "tcBottomPanel";
            this.tcBottomPanel.SelectedIndex = 0;
            this.tcBottomPanel.Size = new System.Drawing.Size(620, 241);
            this.tcBottomPanel.TabIndex = 4;
            // 
            // tabQueue
            // 
            this.tabQueue.Controls.Add(this.label1);
            this.tabQueue.Controls.Add(this.lvChangesPending);
            this.tabQueue.Location = new System.Drawing.Point(4, 25);
            this.tabQueue.Name = "tabQueue";
            this.tabQueue.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueue.Size = new System.Drawing.Size(612, 212);
            this.tabQueue.TabIndex = 0;
            this.tabQueue.Text = "Operations";
            this.tabQueue.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "If, after updating, configs are still mismatched... don\'t worry. It\'s just a disp" +
    "lay bug, but the configs are fine!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvChangesPending
            // 
            this.lvChangesPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChangesPending.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvChangesPending.FullRowSelect = true;
            this.lvChangesPending.GridLines = true;
            this.lvChangesPending.Location = new System.Drawing.Point(6, 25);
            this.lvChangesPending.Name = "lvChangesPending";
            this.lvChangesPending.Size = new System.Drawing.Size(600, 181);
            this.lvChangesPending.TabIndex = 0;
            this.lvChangesPending.UseCompatibleStateImageBehavior = false;
            this.lvChangesPending.View = System.Windows.Forms.View.Details;
            this.lvChangesPending.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvChangesPending_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 410;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 108;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.splitFileLists);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(612, 212);
            this.tabDetails.TabIndex = 4;
            this.tabDetails.Text = "File Details";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox7);
            this.tabSettings.Controls.Add(this.groupBox6);
            this.tabSettings.Controls.Add(this.groupBox5);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.gbSettingsPaths);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(612, 212);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.numericUpDown1);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Location = new System.Drawing.Point(305, 102);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(301, 100);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "FTP Settings";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(151, 33);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Password";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(151, 74);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(139, 20);
            this.textBox3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hostname";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbPathInstance);
            this.groupBox6.Controls.Add(this.bBrowseInstancePath);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(290, 41);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Path to instances (currently, MultiMC root directory)";
            // 
            // tbPathInstance
            // 
            this.tbPathInstance.Location = new System.Drawing.Point(6, 16);
            this.tbPathInstance.Name = "tbPathInstance";
            this.tbPathInstance.Size = new System.Drawing.Size(248, 20);
            this.tbPathInstance.TabIndex = 5;
            // 
            // bBrowseInstancePath
            // 
            this.bBrowseInstancePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowseInstancePath.Location = new System.Drawing.Point(260, 14);
            this.bBrowseInstancePath.Name = "bBrowseInstancePath";
            this.bBrowseInstancePath.Size = new System.Drawing.Size(27, 23);
            this.bBrowseInstancePath.TabIndex = 3;
            this.bBrowseInstancePath.Text = "...";
            this.bBrowseInstancePath.UseVisualStyleBackColor = true;
            this.bBrowseInstancePath.Click += new System.EventHandler(this.bBrowseInstancePath_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnApplyRepoURI);
            this.groupBox5.Controls.Add(this.eConnectionHTTPUri);
            this.groupBox5.Location = new System.Drawing.Point(6, 102);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(293, 43);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "HTTP Settings (Path)";
            // 
            // btnApplyRepoURI
            // 
            this.btnApplyRepoURI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyRepoURI.Location = new System.Drawing.Point(259, 17);
            this.btnApplyRepoURI.Name = "btnApplyRepoURI";
            this.btnApplyRepoURI.Size = new System.Drawing.Size(27, 23);
            this.btnApplyRepoURI.TabIndex = 5;
            this.btnApplyRepoURI.Text = "...";
            this.btnApplyRepoURI.UseVisualStyleBackColor = true;
            this.btnApplyRepoURI.Click += new System.EventHandler(this.btnApplyRepoURI_Click);
            // 
            // eConnectionHTTPUri
            // 
            this.eConnectionHTTPUri.Location = new System.Drawing.Point(6, 19);
            this.eConnectionHTTPUri.Name = "eConnectionHTTPUri";
            this.eConnectionHTTPUri.Size = new System.Drawing.Size(248, 20);
            this.eConnectionHTTPUri.TabIndex = 0;
            this.eConnectionHTTPUri.Text = "http://iggy.ladygardener.org.uk/minecraftrepo/";
            this.eConnectionHTTPUri.TextChanged += new System.EventHandler(this.eConnectionHTTPUri_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lVersionThis);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lVersionOnline);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(419, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Checker";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 56);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(158, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lVersionThis
            // 
            this.lVersionThis.AutoSize = true;
            this.lVersionThis.Location = new System.Drawing.Point(168, 36);
            this.lVersionThis.Name = "lVersionThis";
            this.lVersionThis.Size = new System.Drawing.Size(13, 13);
            this.lVersionThis.TabIndex = 3;
            this.lVersionThis.Text = "0";
            this.lVersionThis.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "This build number:";
            // 
            // lVersionOnline
            // 
            this.lVersionOnline.AutoSize = true;
            this.lVersionOnline.Location = new System.Drawing.Point(168, 19);
            this.lVersionOnline.Name = "lVersionOnline";
            this.lVersionOnline.Size = new System.Drawing.Size(13, 13);
            this.lVersionOnline.TabIndex = 1;
            this.lVersionOnline.Text = "0";
            this.lVersionOnline.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Online build number:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radConnectionLocal);
            this.groupBox4.Controls.Add(this.radConnectionFTP);
            this.groupBox4.Controls.Add(this.radConnectionHTTP);
            this.groupBox4.Location = new System.Drawing.Point(305, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(108, 90);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Connection Type";
            // 
            // radConnectionLocal
            // 
            this.radConnectionLocal.AutoSize = true;
            this.radConnectionLocal.Enabled = false;
            this.radConnectionLocal.Location = new System.Drawing.Point(6, 63);
            this.radConnectionLocal.Name = "radConnectionLocal";
            this.radConnectionLocal.Size = new System.Drawing.Size(75, 17);
            this.radConnectionLocal.TabIndex = 2;
            this.radConnectionLocal.Text = "Local Disk";
            this.radConnectionLocal.UseVisualStyleBackColor = true;
            // 
            // radConnectionFTP
            // 
            this.radConnectionFTP.AutoSize = true;
            this.radConnectionFTP.Enabled = false;
            this.radConnectionFTP.Location = new System.Drawing.Point(6, 41);
            this.radConnectionFTP.Name = "radConnectionFTP";
            this.radConnectionFTP.Size = new System.Drawing.Size(45, 17);
            this.radConnectionFTP.TabIndex = 1;
            this.radConnectionFTP.Text = "FTP";
            this.radConnectionFTP.UseVisualStyleBackColor = true;
            // 
            // radConnectionHTTP
            // 
            this.radConnectionHTTP.AutoSize = true;
            this.radConnectionHTTP.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.radConnectionHTTP.Checked = true;
            this.radConnectionHTTP.Location = new System.Drawing.Point(6, 19);
            this.radConnectionHTTP.Name = "radConnectionHTTP";
            this.radConnectionHTTP.Size = new System.Drawing.Size(54, 17);
            this.radConnectionHTTP.TabIndex = 0;
            this.radConnectionHTTP.TabStop = true;
            this.radConnectionHTTP.Text = "HTTP";
            this.radConnectionHTTP.UseVisualStyleBackColor = true;
            // 
            // gbSettingsPaths
            // 
            this.gbSettingsPaths.Controls.Add(this.tbPathLocalRepo);
            this.gbSettingsPaths.Controls.Add(this.btnBrowseRepositoryPath);
            this.gbSettingsPaths.Location = new System.Drawing.Point(6, 53);
            this.gbSettingsPaths.Name = "gbSettingsPaths";
            this.gbSettingsPaths.Size = new System.Drawing.Size(293, 43);
            this.gbSettingsPaths.TabIndex = 0;
            this.gbSettingsPaths.TabStop = false;
            this.gbSettingsPaths.Text = "Local mod repository (deprecated)";
            // 
            // tbPathLocalRepo
            // 
            this.tbPathLocalRepo.Enabled = false;
            this.tbPathLocalRepo.Location = new System.Drawing.Point(6, 19);
            this.tbPathLocalRepo.Name = "tbPathLocalRepo";
            this.tbPathLocalRepo.Size = new System.Drawing.Size(248, 20);
            this.tbPathLocalRepo.TabIndex = 6;
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.tbLog);
            this.tabLog.Location = new System.Drawing.Point(4, 25);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(612, 212);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tbLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.tbLog.Location = new System.Drawing.Point(6, 6);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(600, 205);
            this.tbLog.TabIndex = 0;
            // 
            // tabChangelog
            // 
            this.tabChangelog.Controls.Add(this.tbChangelog);
            this.tabChangelog.Location = new System.Drawing.Point(4, 25);
            this.tabChangelog.Name = "tabChangelog";
            this.tabChangelog.Padding = new System.Windows.Forms.Padding(3);
            this.tabChangelog.Size = new System.Drawing.Size(612, 212);
            this.tabChangelog.TabIndex = 2;
            this.tabChangelog.Text = "Changelog";
            this.tabChangelog.UseVisualStyleBackColor = true;
            // 
            // tbChangelog
            // 
            this.tbChangelog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChangelog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tbChangelog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChangelog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.tbChangelog.Location = new System.Drawing.Point(6, 6);
            this.tbChangelog.Multiline = true;
            this.tbChangelog.Name = "tbChangelog";
            this.tbChangelog.ReadOnly = true;
            this.tbChangelog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChangelog.Size = new System.Drawing.Size(600, 205);
            this.tbChangelog.TabIndex = 1;
            this.tbChangelog.Text = "This will load \'changelog.txt\' file.";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(612, 212);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "tabBlacklist";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbBlacklist);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 205);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Blacklist of Files";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(492, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbBlacklist
            // 
            this.tbBlacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tbBlacklist.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBlacklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.tbBlacklist.Location = new System.Drawing.Point(6, 19);
            this.tbBlacklist.Multiline = true;
            this.tbBlacklist.Name = "tbBlacklist";
            this.tbBlacklist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBlacklist.Size = new System.Drawing.Size(587, 180);
            this.tbBlacklist.TabIndex = 0;
            this.tbBlacklist.TextChanged += new System.EventHandler(this.tbBlacklist_TextChanged);
            // 
            // saveDialog
            // 
            this.saveDialog.Filter = "MD5 Files|*.md5";
            // 
            // tabControlMode
            // 
            this.tabControlMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMode.Controls.Add(this.tabPageUPDATER);
            this.tabControlMode.Location = new System.Drawing.Point(0, 28);
            this.tabControlMode.Name = "tabControlMode";
            this.tabControlMode.SelectedIndex = 0;
            this.tabControlMode.Size = new System.Drawing.Size(628, 143);
            this.tabControlMode.TabIndex = 5;
            // 
            // tabPageUPDATER
            // 
            this.tabPageUPDATER.Controls.Add(this.lCurrentFile);
            this.tabPageUPDATER.Controls.Add(this.pbProgressFile2);
            this.tabPageUPDATER.Controls.Add(this.pbProgressTotal2);
            this.tabPageUPDATER.Controls.Add(this.groupBox3);
            this.tabPageUPDATER.Controls.Add(this.btnUpdateSelected);
            this.tabPageUPDATER.Controls.Add(this.label7);
            this.tabPageUPDATER.Controls.Add(this.label6);
            this.tabPageUPDATER.Controls.Add(this.cbRemotePackVersion);
            this.tabPageUPDATER.Controls.Add(this.cbModpacks);
            this.tabPageUPDATER.Controls.Add(this.bRefreshInstance);
            this.tabPageUPDATER.Controls.Add(this.bRefreshRepository);
            this.tabPageUPDATER.Controls.Add(this.cbInstances);
            this.tabPageUPDATER.Location = new System.Drawing.Point(4, 22);
            this.tabPageUPDATER.Name = "tabPageUPDATER";
            this.tabPageUPDATER.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUPDATER.Size = new System.Drawing.Size(620, 117);
            this.tabPageUPDATER.TabIndex = 0;
            this.tabPageUPDATER.Text = "Updater";
            this.tabPageUPDATER.UseVisualStyleBackColor = true;
            // 
            // lCurrentFile
            // 
            this.lCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lCurrentFile.Location = new System.Drawing.Point(423, 98);
            this.lCurrentFile.Name = "lCurrentFile";
            this.lCurrentFile.Size = new System.Drawing.Size(187, 13);
            this.lCurrentFile.TabIndex = 20;
            this.lCurrentFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbProgressFile2
            // 
            this.pbProgressFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgressFile2.Location = new System.Drawing.Point(423, 85);
            this.pbProgressFile2.Name = "pbProgressFile2";
            this.pbProgressFile2.Size = new System.Drawing.Size(187, 10);
            this.pbProgressFile2.Step = 1;
            this.pbProgressFile2.TabIndex = 19;
            // 
            // pbProgressTotal2
            // 
            this.pbProgressTotal2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgressTotal2.Location = new System.Drawing.Point(423, 56);
            this.pbProgressTotal2.Name = "pbProgressTotal2";
            this.pbProgressTotal2.Size = new System.Drawing.Size(187, 23);
            this.pbProgressTotal2.Step = 1;
            this.pbProgressTotal2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgressTotal2.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lRemoteModFiles);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lFilesToDownload);
            this.groupBox3.Controls.Add(this.lLocalModFiles);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lFilesToRemove);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(223, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 102);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // lRemoteModFiles
            // 
            this.lRemoteModFiles.AutoSize = true;
            this.lRemoteModFiles.Location = new System.Drawing.Point(131, 31);
            this.lRemoteModFiles.Name = "lRemoteModFiles";
            this.lRemoteModFiles.Size = new System.Drawing.Size(27, 13);
            this.lRemoteModFiles.TabIndex = 11;
            this.lRemoteModFiles.Text = "N/A";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(20, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Local Mods:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lFilesToDownload
            // 
            this.lFilesToDownload.AutoSize = true;
            this.lFilesToDownload.Location = new System.Drawing.Point(131, 81);
            this.lFilesToDownload.Name = "lFilesToDownload";
            this.lFilesToDownload.Size = new System.Drawing.Size(27, 13);
            this.lFilesToDownload.TabIndex = 15;
            this.lFilesToDownload.Text = "N/A";
            this.lFilesToDownload.Click += new System.EventHandler(this.lFilesToDownload_Click);
            // 
            // lLocalModFiles
            // 
            this.lLocalModFiles.AutoSize = true;
            this.lLocalModFiles.Location = new System.Drawing.Point(131, 13);
            this.lLocalModFiles.Name = "lLocalModFiles";
            this.lLocalModFiles.Size = new System.Drawing.Size(27, 13);
            this.lLocalModFiles.TabIndex = 9;
            this.lLocalModFiles.Text = "N/A";
            this.lLocalModFiles.Click += new System.EventHandler(this.lLocalModFiles_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(17, 82);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "To download:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Pack Mods:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lFilesToRemove
            // 
            this.lFilesToRemove.AutoSize = true;
            this.lFilesToRemove.Location = new System.Drawing.Point(131, 63);
            this.lFilesToRemove.Name = "lFilesToRemove";
            this.lFilesToRemove.Size = new System.Drawing.Size(27, 13);
            this.lFilesToRemove.TabIndex = 13;
            this.lFilesToRemove.Text = "N/A";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "To remove:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnUpdateSelected
            // 
            this.btnUpdateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSelected.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSelected.Location = new System.Drawing.Point(423, 10);
            this.btnUpdateSelected.Name = "btnUpdateSelected";
            this.btnUpdateSelected.Size = new System.Drawing.Size(187, 40);
            this.btnUpdateSelected.TabIndex = 16;
            this.btnUpdateSelected.Text = "UPDATE";
            this.toolTip1.SetToolTip(this.btnUpdateSelected, "Forcefully updates selected instance with selected modpack.");
            this.btnUpdateSelected.UseVisualStyleBackColor = true;
            this.btnUpdateSelected.Click += new System.EventHandler(this.btnUpdateSelected_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Modpack";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Minecraft Instance";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 439);
            this.Controls.Add(this.tcBottomPanel);
            this.Controls.Add(this.tabControlMode);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(644, 232);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BustersMC Updater";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabsInstance.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitFileLists.Panel1.ResumeLayout(false);
            this.splitFileLists.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitFileLists)).EndInit();
            this.splitFileLists.ResumeLayout(false);
            this.tabsRepository.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tcBottomPanel.ResumeLayout(false);
            this.tabQueue.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbSettingsPaths.ResumeLayout(false);
            this.gbSettingsPaths.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.tabChangelog.ResumeLayout(false);
            this.tabChangelog.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControlMode.ResumeLayout(false);
            this.tabPageUPDATER.ResumeLayout(false);
            this.tabPageUPDATER.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ComboBox cbInstances;
        private System.Windows.Forms.TabControl tabsInstance;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitFileLists;
        private System.Windows.Forms.TabControl tabsRepository;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.Button bRefreshInstance;
        private System.Windows.Forms.ComboBox cbModpacks;
        private System.Windows.Forms.Button bRefreshRepository;
        private System.Windows.Forms.Button btnBrowseRepositoryPath;
        private System.Windows.Forms.TabControl tcBottomPanel;
        private System.Windows.Forms.TabPage tabQueue;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.ListView lvInstanceMods;
        private System.Windows.Forms.ColumnHeader headerLeftFilename;
        private System.Windows.Forms.ColumnHeader headerLeftStatus;
        private System.Windows.Forms.ListView lvBranchMods;
        private System.Windows.Forms.ListView lvChangesPending;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.FolderBrowserDialog fdBrowse;
        private System.Windows.Forms.ListView lvInstanceConfigs;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvBranchConfigs;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader headerRightFilename;
        private System.Windows.Forms.ColumnHeader headerRightStatus;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbSaveLocalManifest;
        private System.Windows.Forms.ToolStripButton tsbCheckForUpdates;
        private System.Windows.Forms.ToolStripProgressBar pbProgressTotal;
        private System.Windows.Forms.ToolStripStatusLabel lStatus;
        private System.Windows.Forms.ToolStripButton tsbDownBranch;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripProgressBar pbProgressFile;
        private System.Windows.Forms.ColumnHeader headerLeftMD5;
        private System.Windows.Forms.ColumnHeader headerRightMD5;
        private System.Windows.Forms.ToolStripStatusLabel tssOverallProgress;
        private System.Windows.Forms.ToolStripStatusLabel tssCurrentFileProgress;
        private System.Windows.Forms.TabPage tabChangelog;
        private System.Windows.Forms.TextBox tbChangelog;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.GroupBox gbSettingsPaths;
        private System.Windows.Forms.Button bBrowseInstancePath;
        private System.Windows.Forms.TextBox tbPathInstance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lVersionOnline;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lVersionThis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ToolStripButton tsbAppUpdate;
        private System.Windows.Forms.TabControl tabControlMode;
        private System.Windows.Forms.TabPage tabPageUPDATER;
        private System.Windows.Forms.ComboBox cbRemotePackVersion;
        private System.Windows.Forms.Label lLocalModFiles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lFilesToDownload;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lFilesToRemove;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lRemoteModFiles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateSelected;
        private System.Windows.Forms.ProgressBar pbProgressFile2;
        private System.Windows.Forms.ProgressBar pbProgressTotal2;
        private System.Windows.Forms.Label lCurrentFile;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TextBox tbPathLocalRepo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radConnectionFTP;
        private System.Windows.Forms.RadioButton radConnectionHTTP;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbBlacklist;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox eConnectionHTTPUri;
        private System.Windows.Forms.RadioButton radConnectionLocal;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnApplyRepoURI;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

