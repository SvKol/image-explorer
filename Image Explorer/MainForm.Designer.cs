namespace Image_Explorer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ShowHideButton = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_loadFolder = new System.Windows.Forms.Button();
            this.panelMenus = new System.Windows.Forms.Panel();
            this.buttonFocusFolder = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.buttonAscDesc = new System.Windows.Forms.Button();
            this.buttonSearchOF = new System.Windows.Forms.Button();
            this.buttonSearchWF = new System.Windows.Forms.Button();
            this.labelOrderBy = new System.Windows.Forms.Label();
            this.dropdownOrderBy = new System.Windows.Forms.ComboBox();
            this.buttonClearSearch = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.button_unloadDirectory = new System.Windows.Forms.Button();
            this.button_loadDirectory = new System.Windows.Forms.Button();
            this.infoButton = new System.Windows.Forms.Button();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.buttonImageTags = new System.Windows.Forms.Button();
            this.button_manageTags = new System.Windows.Forms.Button();
            this.button_unloadFolder = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelPage = new System.Windows.Forms.Panel();
            this.labelPage = new System.Windows.Forms.TextBox();
            this.buttonDeselect = new System.Windows.Forms.Button();
            this.pageForward = new System.Windows.Forms.Button();
            this.pageBack = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.panelImageList = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tagsFilterLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonUntagged = new System.Windows.Forms.Button();
            this.panelResetFilters = new System.Windows.Forms.Panel();
            this.buttonShowConditions = new System.Windows.Forms.Button();
            this.buttonCloseFilters = new System.Windows.Forms.Button();
            this.buttonResetFilters = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.buttonClosePreview = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelExtension = new System.Windows.Forms.Label();
            this.labelModifiedDate = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.labelModified = new System.Windows.Forms.Label();
            this.labelCreated = new System.Windows.Forms.Label();
            this.labelSizeData = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelImageSize = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelKeywords = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonArtist = new System.Windows.Forms.Button();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.labelArtist = new System.Windows.Forms.Label();
            this.buttonRename = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelImageName = new System.Windows.Forms.Label();
            this.panelTags = new System.Windows.Forms.Panel();
            this.tagsFilterPanel = new System.Windows.Forms.Panel();
            this.panelFilterButtons = new System.Windows.Forms.Panel();
            this.buttonCloseCondition = new System.Windows.Forms.Button();
            this.buttonNotCondition = new System.Windows.Forms.Button();
            this.buttonOrCondition = new System.Windows.Forms.Button();
            this.buttonAndCondition = new System.Windows.Forms.Button();
            this.tagsImagePanel = new System.Windows.Forms.Panel();
            this.tagsImageLayout = new Image_Explorer.SmoothFlowLayoutPanel();
            this.tagsManagePanel = new System.Windows.Forms.Panel();
            this.tagsManageList = new System.Windows.Forms.FlowLayoutPanel();
            this.button_addTag = new System.Windows.Forms.Button();
            this.imageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createShortcutAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTagsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filteredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.createShortcutAtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelMenus.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tagsFilterLayout.SuspendLayout();
            this.panelResetFilters.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelTags.SuspendLayout();
            this.tagsFilterPanel.SuspendLayout();
            this.panelFilterButtons.SuspendLayout();
            this.tagsImagePanel.SuspendLayout();
            this.tagsManagePanel.SuspendLayout();
            this.imageContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowHideButton
            // 
            this.ShowHideButton.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ShowHideButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ShowHideButton.ImageStream")));
            this.ShowHideButton.TransparentColor = System.Drawing.Color.Transparent;
            this.ShowHideButton.Images.SetKeyName(0, "Hide.png");
            this.ShowHideButton.Images.SetKeyName(1, "Show.png");
            // 
            // button_loadFolder
            // 
            this.button_loadFolder.FlatAppearance.BorderSize = 0;
            this.button_loadFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_loadFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button_loadFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loadFolder.Image = global::Image_Explorer.Properties.Resources.Add_Folder;
            this.button_loadFolder.Location = new System.Drawing.Point(10, 27);
            this.button_loadFolder.Name = "button_loadFolder";
            this.button_loadFolder.Size = new System.Drawing.Size(50, 50);
            this.button_loadFolder.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_loadFolder, "Add Folder");
            this.button_loadFolder.UseVisualStyleBackColor = true;
            this.button_loadFolder.Click += new System.EventHandler(this.button_loadFolder_Click);
            // 
            // panelMenus
            // 
            this.panelMenus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelMenus.Controls.Add(this.buttonFocusFolder);
            this.panelMenus.Controls.Add(this.saveButton);
            this.panelMenus.Controls.Add(this.buttonAscDesc);
            this.panelMenus.Controls.Add(this.buttonSearchOF);
            this.panelMenus.Controls.Add(this.buttonSearchWF);
            this.panelMenus.Controls.Add(this.labelOrderBy);
            this.panelMenus.Controls.Add(this.dropdownOrderBy);
            this.panelMenus.Controls.Add(this.buttonClearSearch);
            this.panelMenus.Controls.Add(this.buttonSearch);
            this.panelMenus.Controls.Add(this.searchBox);
            this.panelMenus.Controls.Add(this.buttonRefresh);
            this.panelMenus.Controls.Add(this.button_unloadDirectory);
            this.panelMenus.Controls.Add(this.button_loadDirectory);
            this.panelMenus.Controls.Add(this.infoButton);
            this.panelMenus.Controls.Add(this.MinimizeButton);
            this.panelMenus.Controls.Add(this.RestoreButton);
            this.panelMenus.Controls.Add(this.ExitButton);
            this.panelMenus.Controls.Add(this.buttonImageTags);
            this.panelMenus.Controls.Add(this.button_manageTags);
            this.panelMenus.Controls.Add(this.button_unloadFolder);
            this.panelMenus.Controls.Add(this.button_loadFolder);
            this.panelMenus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenus.Location = new System.Drawing.Point(0, 0);
            this.panelMenus.Name = "panelMenus";
            this.panelMenus.Size = new System.Drawing.Size(1134, 80);
            this.panelMenus.TabIndex = 0;
            this.panelMenus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenus_MouseDown);
            // 
            // buttonFocusFolder
            // 
            this.buttonFocusFolder.FlatAppearance.BorderSize = 0;
            this.buttonFocusFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonFocusFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonFocusFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFocusFolder.Image = global::Image_Explorer.Properties.Resources.FocusFolder;
            this.buttonFocusFolder.Location = new System.Drawing.Point(231, 27);
            this.buttonFocusFolder.Name = "buttonFocusFolder";
            this.buttonFocusFolder.Size = new System.Drawing.Size(50, 50);
            this.buttonFocusFolder.TabIndex = 22;
            this.toolTip1.SetToolTip(this.buttonFocusFolder, "Focus Folder");
            this.buttonFocusFolder.UseVisualStyleBackColor = true;
            this.buttonFocusFolder.Click += new System.EventHandler(this.buttonFocusFolder_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = global::Image_Explorer.Properties.Resources.save;
            this.saveButton.Location = new System.Drawing.Point(287, 28);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(48, 48);
            this.saveButton.TabIndex = 21;
            this.toolTip1.SetToolTip(this.saveButton, "Save (Ctrl+S)");
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // buttonAscDesc
            // 
            this.buttonAscDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAscDesc.Location = new System.Drawing.Point(910, 44);
            this.buttonAscDesc.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAscDesc.MaximumSize = new System.Drawing.Size(75, 23);
            this.buttonAscDesc.MinimumSize = new System.Drawing.Size(75, 23);
            this.buttonAscDesc.Name = "buttonAscDesc";
            this.buttonAscDesc.Size = new System.Drawing.Size(75, 23);
            this.buttonAscDesc.TabIndex = 20;
            this.buttonAscDesc.Text = "Ascending";
            this.buttonAscDesc.UseCompatibleTextRendering = true;
            this.buttonAscDesc.UseVisualStyleBackColor = true;
            this.buttonAscDesc.Click += new System.EventHandler(this.buttonAscDesc_Click);
            // 
            // buttonSearchOF
            // 
            this.buttonSearchOF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSearchOF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonSearchOF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonSearchOF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonSearchOF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchOF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearchOF.Image = global::Image_Explorer.Properties.Resources.go;
            this.buttonSearchOF.Location = new System.Drawing.Point(449, 37);
            this.buttonSearchOF.Name = "buttonSearchOF";
            this.buttonSearchOF.Size = new System.Drawing.Size(30, 30);
            this.buttonSearchOF.TabIndex = 19;
            this.toolTip1.SetToolTip(this.buttonSearchOF, "Search, using only filters");
            this.buttonSearchOF.UseCompatibleTextRendering = true;
            this.buttonSearchOF.UseVisualStyleBackColor = false;
            this.buttonSearchOF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_toggleTags_Click);
            // 
            // buttonSearchWF
            // 
            this.buttonSearchWF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSearchWF.FlatAppearance.BorderSize = 0;
            this.buttonSearchWF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonSearchWF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonSearchWF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchWF.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearchWF.Image = global::Image_Explorer.Properties.Resources.SearchFiltered;
            this.buttonSearchWF.Location = new System.Drawing.Point(742, 37);
            this.buttonSearchWF.Name = "buttonSearchWF";
            this.buttonSearchWF.Size = new System.Drawing.Size(30, 30);
            this.buttonSearchWF.TabIndex = 18;
            this.toolTip1.SetToolTip(this.buttonSearchWF, "Search with filters");
            this.buttonSearchWF.UseCompatibleTextRendering = true;
            this.buttonSearchWF.UseVisualStyleBackColor = false;
            this.buttonSearchWF.Click += new System.EventHandler(this.buttonSearchWF_Click);
            // 
            // labelOrderBy
            // 
            this.labelOrderBy.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelOrderBy.Location = new System.Drawing.Point(818, 25);
            this.labelOrderBy.Name = "labelOrderBy";
            this.labelOrderBy.Size = new System.Drawing.Size(121, 19);
            this.labelOrderBy.TabIndex = 16;
            this.labelOrderBy.Text = "Sort By:";
            this.labelOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelOrderBy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenus_MouseDown);
            // 
            // dropdownOrderBy
            // 
            this.dropdownOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownOrderBy.FormattingEnabled = true;
            this.dropdownOrderBy.Items.AddRange(new object[] {
            "Name",
            "Artist",
            "Location",
            "Size",
            "Created",
            "Modified"});
            this.dropdownOrderBy.Location = new System.Drawing.Point(820, 44);
            this.dropdownOrderBy.Margin = new System.Windows.Forms.Padding(0);
            this.dropdownOrderBy.MaximumSize = new System.Drawing.Size(90, 0);
            this.dropdownOrderBy.MinimumSize = new System.Drawing.Size(90, 0);
            this.dropdownOrderBy.Name = "dropdownOrderBy";
            this.dropdownOrderBy.Size = new System.Drawing.Size(90, 23);
            this.dropdownOrderBy.TabIndex = 15;
            this.dropdownOrderBy.SelectedIndexChanged += new System.EventHandler(this.dropdownOrderBy_SelectedIndexChanged);
            // 
            // buttonClearSearch
            // 
            this.buttonClearSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClearSearch.FlatAppearance.BorderSize = 0;
            this.buttonClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonClearSearch.Location = new System.Drawing.Point(719, 43);
            this.buttonClearSearch.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClearSearch.MaximumSize = new System.Drawing.Size(12, 21);
            this.buttonClearSearch.MinimumSize = new System.Drawing.Size(12, 21);
            this.buttonClearSearch.Name = "buttonClearSearch";
            this.buttonClearSearch.Size = new System.Drawing.Size(12, 21);
            this.buttonClearSearch.TabIndex = 14;
            this.buttonClearSearch.Text = "x";
            this.buttonClearSearch.UseCompatibleTextRendering = true;
            this.buttonClearSearch.UseVisualStyleBackColor = false;
            this.buttonClearSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSearch.Image = global::Image_Explorer.Properties.Resources.SearchOnly;
            this.buttonSearch.Location = new System.Drawing.Point(778, 37);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(30, 30);
            this.buttonSearch.TabIndex = 13;
            this.toolTip1.SetToolTip(this.buttonSearch, "Search, ignoring filters");
            this.buttonSearch.UseCompatibleTextRendering = true;
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FilterPotentialDuplicates);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(530, 42);
            this.searchBox.MaximumSize = new System.Drawing.Size(200, 23);
            this.searchBox.MinimumSize = new System.Drawing.Size(200, 23);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(200, 23);
            this.searchBox.TabIndex = 12;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::Image_Explorer.Properties.Resources.Refresh;
            this.buttonRefresh.Location = new System.Drawing.Point(485, 37);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(30, 30);
            this.buttonRefresh.TabIndex = 11;
            this.toolTip1.SetToolTip(this.buttonRefresh, "Refresh");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.RefreshImages);
            // 
            // button_unloadDirectory
            // 
            this.button_unloadDirectory.FlatAppearance.BorderSize = 0;
            this.button_unloadDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_unloadDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button_unloadDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_unloadDirectory.Image = global::Image_Explorer.Properties.Resources.Remove_Directory;
            this.button_unloadDirectory.Location = new System.Drawing.Point(175, 27);
            this.button_unloadDirectory.Name = "button_unloadDirectory";
            this.button_unloadDirectory.Size = new System.Drawing.Size(50, 50);
            this.button_unloadDirectory.TabIndex = 10;
            this.toolTip1.SetToolTip(this.button_unloadDirectory, "Remove Directory");
            this.button_unloadDirectory.UseVisualStyleBackColor = true;
            this.button_unloadDirectory.Click += new System.EventHandler(this.button_unloadDirectory_Click);
            // 
            // button_loadDirectory
            // 
            this.button_loadDirectory.FlatAppearance.BorderSize = 0;
            this.button_loadDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_loadDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button_loadDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_loadDirectory.Image = global::Image_Explorer.Properties.Resources.Add_Directory;
            this.button_loadDirectory.Location = new System.Drawing.Point(120, 27);
            this.button_loadDirectory.Name = "button_loadDirectory";
            this.button_loadDirectory.Size = new System.Drawing.Size(50, 50);
            this.button_loadDirectory.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button_loadDirectory, "Add Directory");
            this.button_loadDirectory.UseVisualStyleBackColor = true;
            this.button_loadDirectory.Click += new System.EventHandler(this.button_loadDirectory_Click);
            // 
            // infoButton
            // 
            this.infoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.infoButton.BackColor = System.Drawing.Color.DimGray;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoButton.ForeColor = System.Drawing.SystemColors.Info;
            this.infoButton.Location = new System.Drawing.Point(1059, 66);
            this.infoButton.Margin = new System.Windows.Forms.Padding(0);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(75, 15);
            this.infoButton.TabIndex = 8;
            this.infoButton.Text = "I n f o";
            this.toolTip1.SetToolTip(this.infoButton, "Open info panel (Ctrl+I)");
            this.infoButton.UseCompatibleTextRendering = true;
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.MinimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.MinimizeButton.Location = new System.Drawing.Point(1044, 0);
            this.MinimizeButton.MaximumSize = new System.Drawing.Size(30, 20);
            this.MinimizeButton.MinimumSize = new System.Drawing.Size(30, 20);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(30, 20);
            this.MinimizeButton.TabIndex = 7;
            this.MinimizeButton.Text = "__";
            this.MinimizeButton.UseCompatibleTextRendering = true;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.RestoreButton.FlatAppearance.BorderSize = 0;
            this.RestoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.RestoreButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.RestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.RestoreButton.Location = new System.Drawing.Point(1074, 0);
            this.RestoreButton.MaximumSize = new System.Drawing.Size(30, 20);
            this.RestoreButton.MinimumSize = new System.Drawing.Size(30, 20);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(30, 20);
            this.RestoreButton.TabIndex = 6;
            this.RestoreButton.Text = "O";
            this.RestoreButton.UseCompatibleTextRendering = true;
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ExitButton.Location = new System.Drawing.Point(1104, 0);
            this.ExitButton.MaximumSize = new System.Drawing.Size(30, 20);
            this.ExitButton.MinimumSize = new System.Drawing.Size(30, 20);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 20);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "X";
            this.ExitButton.UseCompatibleTextRendering = true;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // buttonImageTags
            // 
            this.buttonImageTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonImageTags.FlatAppearance.BorderSize = 0;
            this.buttonImageTags.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonImageTags.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonImageTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImageTags.Image = global::Image_Explorer.Properties.Resources.Image_Tags;
            this.buttonImageTags.Location = new System.Drawing.Point(363, 37);
            this.buttonImageTags.Name = "buttonImageTags";
            this.buttonImageTags.Size = new System.Drawing.Size(30, 30);
            this.buttonImageTags.TabIndex = 4;
            this.toolTip1.SetToolTip(this.buttonImageTags, "Image tags");
            this.buttonImageTags.UseVisualStyleBackColor = false;
            this.buttonImageTags.Click += new System.EventHandler(this.buttonImageTags_Click);
            // 
            // button_manageTags
            // 
            this.button_manageTags.FlatAppearance.BorderSize = 0;
            this.button_manageTags.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_manageTags.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button_manageTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_manageTags.Image = global::Image_Explorer.Properties.Resources.Manage_Tags;
            this.button_manageTags.Location = new System.Drawing.Point(399, 37);
            this.button_manageTags.Name = "button_manageTags";
            this.button_manageTags.Size = new System.Drawing.Size(30, 30);
            this.button_manageTags.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button_manageTags, "Manage tags");
            this.button_manageTags.UseVisualStyleBackColor = true;
            this.button_manageTags.Click += new System.EventHandler(this.button_manageTags_Click);
            // 
            // button_unloadFolder
            // 
            this.button_unloadFolder.FlatAppearance.BorderSize = 0;
            this.button_unloadFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.button_unloadFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button_unloadFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_unloadFolder.Image = global::Image_Explorer.Properties.Resources.Remove_Folder;
            this.button_unloadFolder.Location = new System.Drawing.Point(65, 27);
            this.button_unloadFolder.Name = "button_unloadFolder";
            this.button_unloadFolder.Size = new System.Drawing.Size(50, 50);
            this.button_unloadFolder.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_unloadFolder, "Remove Folder");
            this.button_unloadFolder.UseVisualStyleBackColor = true;
            this.button_unloadFolder.Click += new System.EventHandler(this.button_unloadFolder_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLeft.Controls.Add(this.panelPage);
            this.panelLeft.Controls.Add(this.buttonDeselect);
            this.panelLeft.Controls.Add(this.pageForward);
            this.panelLeft.Controls.Add(this.pageBack);
            this.panelLeft.Controls.Add(this.buttonSelectAll);
            this.panelLeft.Controls.Add(this.panelImageList);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 80);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeft.MaximumSize = new System.Drawing.Size(375, 0);
            this.panelLeft.MinimumSize = new System.Drawing.Size(375, 300);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panelLeft.Size = new System.Drawing.Size(375, 481);
            this.panelLeft.TabIndex = 1;
            // 
            // panelPage
            // 
            this.panelPage.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelPage.Controls.Add(this.labelPage);
            this.panelPage.Location = new System.Drawing.Point(151, 0);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(68, 25);
            this.panelPage.TabIndex = 4;
            // 
            // labelPage
            // 
            this.labelPage.BackColor = System.Drawing.SystemColors.Desktop;
            this.labelPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelPage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPage.ForeColor = System.Drawing.Color.Silver;
            this.labelPage.Location = new System.Drawing.Point(0, 5);
            this.labelPage.Margin = new System.Windows.Forms.Padding(0);
            this.labelPage.MaxLength = 4;
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(68, 16);
            this.labelPage.TabIndex = 4;
            this.labelPage.Text = "0/0";
            this.labelPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.labelPage.Enter += new System.EventHandler(this.labelPage_Enter);
            this.labelPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.labelPage_KeyDown);
            this.labelPage.Leave += new System.EventHandler(this.labelPage_Leave);
            // 
            // buttonDeselect
            // 
            this.buttonDeselect.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttonDeselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDeselect.ForeColor = System.Drawing.Color.Red;
            this.buttonDeselect.Location = new System.Drawing.Point(220, 0);
            this.buttonDeselect.Name = "buttonDeselect";
            this.buttonDeselect.Size = new System.Drawing.Size(68, 25);
            this.buttonDeselect.TabIndex = 0;
            this.buttonDeselect.Text = "Deselect";
            this.buttonDeselect.UseVisualStyleBackColor = false;
            this.buttonDeselect.Click += new System.EventHandler(this.buttonDeselect_Click);
            // 
            // pageForward
            // 
            this.pageForward.BackColor = System.Drawing.SystemColors.Desktop;
            this.pageForward.Enabled = false;
            this.pageForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageForward.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageForward.ForeColor = System.Drawing.Color.Silver;
            this.pageForward.Location = new System.Drawing.Point(288, 0);
            this.pageForward.Margin = new System.Windows.Forms.Padding(0);
            this.pageForward.Name = "pageForward";
            this.pageForward.Size = new System.Drawing.Size(68, 25);
            this.pageForward.TabIndex = 3;
            this.pageForward.Text = ">>";
            this.pageForward.UseCompatibleTextRendering = true;
            this.pageForward.UseVisualStyleBackColor = false;
            this.pageForward.Click += new System.EventHandler(this.pageForward_Click);
            // 
            // pageBack
            // 
            this.pageBack.BackColor = System.Drawing.SystemColors.Desktop;
            this.pageBack.Enabled = false;
            this.pageBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pageBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pageBack.ForeColor = System.Drawing.Color.Silver;
            this.pageBack.Location = new System.Drawing.Point(15, 0);
            this.pageBack.Margin = new System.Windows.Forms.Padding(0);
            this.pageBack.Name = "pageBack";
            this.pageBack.Size = new System.Drawing.Size(68, 25);
            this.pageBack.TabIndex = 2;
            this.pageBack.Text = "<<";
            this.pageBack.UseCompatibleTextRendering = true;
            this.pageBack.UseVisualStyleBackColor = false;
            this.pageBack.Click += new System.EventHandler(this.pageBack_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectAll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSelectAll.ForeColor = System.Drawing.Color.LimeGreen;
            this.buttonSelectAll.Location = new System.Drawing.Point(83, 0);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(68, 25);
            this.buttonSelectAll.TabIndex = 1;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // panelImageList
            // 
            this.panelImageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelImageList.AutoScroll = true;
            this.panelImageList.Location = new System.Drawing.Point(15, 30);
            this.panelImageList.Margin = new System.Windows.Forms.Padding(10);
            this.panelImageList.Name = "panelImageList";
            this.panelImageList.Size = new System.Drawing.Size(360, 436);
            this.panelImageList.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 451);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.openOriginalImage);
            // 
            // tagsFilterLayout
            // 
            this.tagsFilterLayout.Controls.Add(this.buttonUntagged);
            this.tagsFilterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsFilterLayout.Location = new System.Drawing.Point(0, 30);
            this.tagsFilterLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tagsFilterLayout.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsFilterLayout.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsFilterLayout.Name = "tagsFilterLayout";
            this.tagsFilterLayout.Size = new System.Drawing.Size(200, 421);
            this.tagsFilterLayout.TabIndex = 0;
            // 
            // buttonUntagged
            // 
            this.buttonUntagged.BackColor = System.Drawing.Color.Transparent;
            this.buttonUntagged.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonUntagged.FlatAppearance.BorderSize = 0;
            this.buttonUntagged.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonUntagged.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUntagged.Font = new System.Drawing.Font("Centaur", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonUntagged.ForeColor = System.Drawing.Color.PeachPuff;
            this.buttonUntagged.Location = new System.Drawing.Point(0, 0);
            this.buttonUntagged.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUntagged.MaximumSize = new System.Drawing.Size(200, 30);
            this.buttonUntagged.MinimumSize = new System.Drawing.Size(200, 30);
            this.buttonUntagged.Name = "buttonUntagged";
            this.buttonUntagged.Size = new System.Drawing.Size(200, 30);
            this.buttonUntagged.TabIndex = 0;
            this.buttonUntagged.Text = "Untagged";
            this.buttonUntagged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUntagged.UseCompatibleTextRendering = true;
            this.buttonUntagged.UseVisualStyleBackColor = false;
            this.buttonUntagged.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tag_RegisterButton);
            this.buttonUntagged.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tag_MouseTrack);
            this.buttonUntagged.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tag_ChangeState);
            // 
            // panelResetFilters
            // 
            this.panelResetFilters.Controls.Add(this.buttonShowConditions);
            this.panelResetFilters.Controls.Add(this.buttonCloseFilters);
            this.panelResetFilters.Controls.Add(this.buttonResetFilters);
            this.panelResetFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResetFilters.Location = new System.Drawing.Point(0, 0);
            this.panelResetFilters.Name = "panelResetFilters";
            this.panelResetFilters.Size = new System.Drawing.Size(200, 30);
            this.panelResetFilters.TabIndex = 1;
            // 
            // buttonShowConditions
            // 
            this.buttonShowConditions.Location = new System.Drawing.Point(98, 5);
            this.buttonShowConditions.Name = "buttonShowConditions";
            this.buttonShowConditions.Size = new System.Drawing.Size(80, 20);
            this.buttonShowConditions.TabIndex = 2;
            this.buttonShowConditions.Text = "Conditions";
            this.buttonShowConditions.UseCompatibleTextRendering = true;
            this.buttonShowConditions.UseVisualStyleBackColor = true;
            this.buttonShowConditions.Click += new System.EventHandler(this.buttonShowConditions_Click);
            // 
            // buttonCloseFilters
            // 
            this.buttonCloseFilters.Location = new System.Drawing.Point(184, 0);
            this.buttonCloseFilters.Name = "buttonCloseFilters";
            this.buttonCloseFilters.Size = new System.Drawing.Size(16, 16);
            this.buttonCloseFilters.TabIndex = 1;
            this.buttonCloseFilters.Text = "X";
            this.buttonCloseFilters.UseCompatibleTextRendering = true;
            this.buttonCloseFilters.UseVisualStyleBackColor = true;
            this.buttonCloseFilters.Click += new System.EventHandler(this.buttonCloseFilters_Click);
            // 
            // buttonResetFilters
            // 
            this.buttonResetFilters.Location = new System.Drawing.Point(13, 5);
            this.buttonResetFilters.Name = "buttonResetFilters";
            this.buttonResetFilters.Size = new System.Drawing.Size(80, 20);
            this.buttonResetFilters.TabIndex = 0;
            this.buttonResetFilters.Text = "Reset Filters";
            this.buttonResetFilters.UseCompatibleTextRendering = true;
            this.buttonResetFilters.UseVisualStyleBackColor = true;
            this.buttonResetFilters.Click += new System.EventHandler(this.buttonResetFilters_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelPreview);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Controls.Add(this.panelTags);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(375, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(759, 481);
            this.panelMain.TabIndex = 2;
            // 
            // panelPreview
            // 
            this.panelPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelPreview.Controls.Add(this.buttonClosePreview);
            this.panelPreview.Controls.Add(this.pictureBox1);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(200, 0);
            this.panelPreview.Margin = new System.Windows.Forms.Padding(0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Padding = new System.Windows.Forms.Padding(15);
            this.panelPreview.Size = new System.Drawing.Size(359, 481);
            this.panelPreview.TabIndex = 2;
            // 
            // buttonClosePreview
            // 
            this.buttonClosePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClosePreview.BackColor = System.Drawing.Color.RosyBrown;
            this.buttonClosePreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClosePreview.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClosePreview.ForeColor = System.Drawing.Color.White;
            this.buttonClosePreview.Location = new System.Drawing.Point(344, 0);
            this.buttonClosePreview.Name = "buttonClosePreview";
            this.buttonClosePreview.Size = new System.Drawing.Size(15, 15);
            this.buttonClosePreview.TabIndex = 1;
            this.buttonClosePreview.Text = "X";
            this.buttonClosePreview.UseCompatibleTextRendering = true;
            this.buttonClosePreview.UseVisualStyleBackColor = false;
            this.buttonClosePreview.Visible = false;
            this.buttonClosePreview.Click += new System.EventHandler(this.ClosePreview);
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelInfo.Controls.Add(this.labelExtension);
            this.panelInfo.Controls.Add(this.labelModifiedDate);
            this.panelInfo.Controls.Add(this.labelCreatedDate);
            this.panelInfo.Controls.Add(this.labelModified);
            this.panelInfo.Controls.Add(this.labelCreated);
            this.panelInfo.Controls.Add(this.labelSizeData);
            this.panelInfo.Controls.Add(this.labelSize);
            this.panelInfo.Controls.Add(this.labelImageSize);
            this.panelInfo.Controls.Add(this.labelResolution);
            this.panelInfo.Controls.Add(this.labelPath);
            this.panelInfo.Controls.Add(this.labelLocation);
            this.panelInfo.Controls.Add(this.labelKeywords);
            this.panelInfo.Controls.Add(this.listBox1);
            this.panelInfo.Controls.Add(this.buttonArtist);
            this.panelInfo.Controls.Add(this.textBoxArtist);
            this.panelInfo.Controls.Add(this.labelArtist);
            this.panelInfo.Controls.Add(this.buttonRename);
            this.panelInfo.Controls.Add(this.textBoxName);
            this.panelInfo.Controls.Add(this.labelImageName);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInfo.Location = new System.Drawing.Point(559, 0);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(10);
            this.panelInfo.MaximumSize = new System.Drawing.Size(200, 0);
            this.panelInfo.MinimumSize = new System.Drawing.Size(200, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(10, 20, 10, 15);
            this.panelInfo.Size = new System.Drawing.Size(200, 481);
            this.panelInfo.TabIndex = 1;
            // 
            // labelExtension
            // 
            this.labelExtension.Location = new System.Drawing.Point(140, 122);
            this.labelExtension.Name = "labelExtension";
            this.labelExtension.Size = new System.Drawing.Size(60, 23);
            this.labelExtension.TabIndex = 18;
            this.labelExtension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelModifiedDate
            // 
            this.labelModifiedDate.Location = new System.Drawing.Point(91, 293);
            this.labelModifiedDate.Name = "labelModifiedDate";
            this.labelModifiedDate.Size = new System.Drawing.Size(72, 15);
            this.labelModifiedDate.TabIndex = 17;
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.Location = new System.Drawing.Point(91, 269);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(72, 15);
            this.labelCreatedDate.TabIndex = 16;
            // 
            // labelModified
            // 
            this.labelModified.Location = new System.Drawing.Point(10, 293);
            this.labelModified.Name = "labelModified";
            this.labelModified.Size = new System.Drawing.Size(76, 15);
            this.labelModified.TabIndex = 15;
            this.labelModified.Text = "Modified On:";
            this.labelModified.UseCompatibleTextRendering = true;
            // 
            // labelCreated
            // 
            this.labelCreated.Location = new System.Drawing.Point(10, 269);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(76, 15);
            this.labelCreated.TabIndex = 14;
            this.labelCreated.Text = "Created On:";
            this.labelCreated.UseCompatibleTextRendering = true;
            // 
            // labelSizeData
            // 
            this.labelSizeData.Location = new System.Drawing.Point(91, 244);
            this.labelSizeData.Name = "labelSizeData";
            this.labelSizeData.Size = new System.Drawing.Size(72, 15);
            this.labelSizeData.TabIndex = 13;
            // 
            // labelSize
            // 
            this.labelSize.Location = new System.Drawing.Point(10, 244);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(76, 15);
            this.labelSize.TabIndex = 12;
            this.labelSize.Text = "Size:";
            // 
            // labelImageSize
            // 
            this.labelImageSize.Location = new System.Drawing.Point(91, 220);
            this.labelImageSize.Name = "labelImageSize";
            this.labelImageSize.Size = new System.Drawing.Size(72, 15);
            this.labelImageSize.TabIndex = 11;
            // 
            // labelResolution
            // 
            this.labelResolution.Location = new System.Drawing.Point(10, 220);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(76, 15);
            this.labelResolution.TabIndex = 10;
            this.labelResolution.Text = "Resolution:";
            // 
            // labelPath
            // 
            this.labelPath.Location = new System.Drawing.Point(10, 35);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(180, 47);
            this.labelPath.TabIndex = 9;
            // 
            // labelLocation
            // 
            this.labelLocation.Location = new System.Drawing.Point(10, 20);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(180, 15);
            this.labelLocation.TabIndex = 8;
            this.labelLocation.Text = "Location:";
            // 
            // labelKeywords
            // 
            this.labelKeywords.Location = new System.Drawing.Point(10, 317);
            this.labelKeywords.Name = "labelKeywords";
            this.labelKeywords.Size = new System.Drawing.Size(180, 15);
            this.labelKeywords.TabIndex = 6;
            this.labelKeywords.Text = "Keywords:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(10, 335);
            this.listBox1.MinimumSize = new System.Drawing.Size(180, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(180, 107);
            this.listBox1.TabIndex = 7;
            // 
            // buttonArtist
            // 
            this.buttonArtist.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArtist.Location = new System.Drawing.Point(50, 185);
            this.buttonArtist.MaximumSize = new System.Drawing.Size(90, 0);
            this.buttonArtist.MinimumSize = new System.Drawing.Size(0, 23);
            this.buttonArtist.Name = "buttonArtist";
            this.buttonArtist.Size = new System.Drawing.Size(90, 23);
            this.buttonArtist.TabIndex = 5;
            this.buttonArtist.Text = "Update";
            this.buttonArtist.UseCompatibleTextRendering = true;
            this.buttonArtist.UseVisualStyleBackColor = false;
            this.buttonArtist.Click += new System.EventHandler(this.buttonArtist_Click);
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxArtist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxArtist.Location = new System.Drawing.Point(10, 163);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(180, 16);
            this.textBoxArtist.TabIndex = 4;
            this.textBoxArtist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxArtist_KeyDown);
            // 
            // labelArtist
            // 
            this.labelArtist.Location = new System.Drawing.Point(10, 145);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Size = new System.Drawing.Size(38, 15);
            this.labelArtist.TabIndex = 3;
            this.labelArtist.Text = "Artist:";
            // 
            // buttonRename
            // 
            this.buttonRename.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRename.Location = new System.Drawing.Point(50, 122);
            this.buttonRename.MaximumSize = new System.Drawing.Size(90, 0);
            this.buttonRename.MinimumSize = new System.Drawing.Size(0, 23);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(90, 23);
            this.buttonRename.TabIndex = 2;
            this.buttonRename.Text = "Rename";
            this.buttonRename.UseCompatibleTextRendering = true;
            this.buttonRename.UseVisualStyleBackColor = false;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Location = new System.Drawing.Point(10, 100);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 16);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // labelImageName
            // 
            this.labelImageName.Location = new System.Drawing.Point(10, 82);
            this.labelImageName.Name = "labelImageName";
            this.labelImageName.Size = new System.Drawing.Size(180, 15);
            this.labelImageName.TabIndex = 1;
            this.labelImageName.Text = "Name:";
            // 
            // panelTags
            // 
            this.panelTags.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTags.Controls.Add(this.tagsFilterPanel);
            this.panelTags.Controls.Add(this.tagsImagePanel);
            this.panelTags.Controls.Add(this.tagsManagePanel);
            this.panelTags.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTags.Location = new System.Drawing.Point(0, 0);
            this.panelTags.MaximumSize = new System.Drawing.Size(200, 0);
            this.panelTags.MinimumSize = new System.Drawing.Size(200, 0);
            this.panelTags.Name = "panelTags";
            this.panelTags.Size = new System.Drawing.Size(200, 481);
            this.panelTags.TabIndex = 0;
            // 
            // tagsFilterPanel
            // 
            this.tagsFilterPanel.Controls.Add(this.tagsFilterLayout);
            this.tagsFilterPanel.Controls.Add(this.panelFilterButtons);
            this.tagsFilterPanel.Controls.Add(this.panelResetFilters);
            this.tagsFilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsFilterPanel.Location = new System.Drawing.Point(0, 0);
            this.tagsFilterPanel.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsFilterPanel.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsFilterPanel.Name = "tagsFilterPanel";
            this.tagsFilterPanel.Size = new System.Drawing.Size(200, 481);
            this.tagsFilterPanel.TabIndex = 2;
            // 
            // panelFilterButtons
            // 
            this.panelFilterButtons.Controls.Add(this.buttonCloseCondition);
            this.panelFilterButtons.Controls.Add(this.buttonNotCondition);
            this.panelFilterButtons.Controls.Add(this.buttonOrCondition);
            this.panelFilterButtons.Controls.Add(this.buttonAndCondition);
            this.panelFilterButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFilterButtons.Location = new System.Drawing.Point(0, 451);
            this.panelFilterButtons.Name = "panelFilterButtons";
            this.panelFilterButtons.Size = new System.Drawing.Size(200, 30);
            this.panelFilterButtons.TabIndex = 2;
            // 
            // buttonCloseCondition
            // 
            this.buttonCloseCondition.Location = new System.Drawing.Point(165, 3);
            this.buttonCloseCondition.Name = "buttonCloseCondition";
            this.buttonCloseCondition.Size = new System.Drawing.Size(25, 23);
            this.buttonCloseCondition.TabIndex = 25;
            this.buttonCloseCondition.Text = ")";
            this.buttonCloseCondition.UseVisualStyleBackColor = true;
            this.buttonCloseCondition.Click += new System.EventHandler(this.buttonCloseCondition_Click);
            // 
            // buttonNotCondition
            // 
            this.buttonNotCondition.Location = new System.Drawing.Point(55, 3);
            this.buttonNotCondition.Name = "buttonNotCondition";
            this.buttonNotCondition.Size = new System.Drawing.Size(50, 23);
            this.buttonNotCondition.TabIndex = 2;
            this.buttonNotCondition.Text = "Not(*";
            this.buttonNotCondition.UseVisualStyleBackColor = true;
            this.buttonNotCondition.Click += new System.EventHandler(this.buttonNotCondition_Click);
            // 
            // buttonOrCondition
            // 
            this.buttonOrCondition.Location = new System.Drawing.Point(105, 3);
            this.buttonOrCondition.Name = "buttonOrCondition";
            this.buttonOrCondition.Size = new System.Drawing.Size(50, 23);
            this.buttonOrCondition.TabIndex = 1;
            this.buttonOrCondition.Text = "Or(*";
            this.buttonOrCondition.UseVisualStyleBackColor = true;
            this.buttonOrCondition.Click += new System.EventHandler(this.buttonOrCondition_Click);
            // 
            // buttonAndCondition
            // 
            this.buttonAndCondition.Location = new System.Drawing.Point(3, 3);
            this.buttonAndCondition.Name = "buttonAndCondition";
            this.buttonAndCondition.Size = new System.Drawing.Size(50, 23);
            this.buttonAndCondition.TabIndex = 0;
            this.buttonAndCondition.Text = "And(*";
            this.buttonAndCondition.UseVisualStyleBackColor = true;
            this.buttonAndCondition.Click += new System.EventHandler(this.buttonAndCondition_Click);
            // 
            // tagsImagePanel
            // 
            this.tagsImagePanel.Controls.Add(this.tagsImageLayout);
            this.tagsImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsImagePanel.Location = new System.Drawing.Point(0, 0);
            this.tagsImagePanel.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsImagePanel.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsImagePanel.Name = "tagsImagePanel";
            this.tagsImagePanel.Size = new System.Drawing.Size(200, 481);
            this.tagsImagePanel.TabIndex = 0;
            this.tagsImagePanel.Visible = false;
            // 
            // tagsImageLayout
            // 
            this.tagsImageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsImageLayout.Location = new System.Drawing.Point(0, 0);
            this.tagsImageLayout.Margin = new System.Windows.Forms.Padding(0);
            this.tagsImageLayout.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsImageLayout.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsImageLayout.Name = "tagsImageLayout";
            this.tagsImageLayout.Size = new System.Drawing.Size(200, 481);
            this.tagsImageLayout.TabIndex = 2;
            // 
            // tagsManagePanel
            // 
            this.tagsManagePanel.Controls.Add(this.tagsManageList);
            this.tagsManagePanel.Controls.Add(this.button_addTag);
            this.tagsManagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsManagePanel.Location = new System.Drawing.Point(0, 0);
            this.tagsManagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.tagsManagePanel.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsManagePanel.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsManagePanel.Name = "tagsManagePanel";
            this.tagsManagePanel.Size = new System.Drawing.Size(200, 481);
            this.tagsManagePanel.TabIndex = 1;
            this.tagsManagePanel.Visible = false;
            // 
            // tagsManageList
            // 
            this.tagsManageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsManageList.Location = new System.Drawing.Point(0, 23);
            this.tagsManageList.MaximumSize = new System.Drawing.Size(200, 0);
            this.tagsManageList.MinimumSize = new System.Drawing.Size(200, 0);
            this.tagsManageList.Name = "tagsManageList";
            this.tagsManageList.Size = new System.Drawing.Size(200, 458);
            this.tagsManageList.TabIndex = 1;
            // 
            // button_addTag
            // 
            this.button_addTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_addTag.Location = new System.Drawing.Point(0, 0);
            this.button_addTag.Name = "button_addTag";
            this.button_addTag.Size = new System.Drawing.Size(200, 23);
            this.button_addTag.TabIndex = 0;
            this.button_addTag.Text = "Add Tag";
            this.button_addTag.UseVisualStyleBackColor = true;
            this.button_addTag.Click += new System.EventHandler(this.button_addTag_Click);
            // 
            // imageContextMenu
            // 
            this.imageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.moveToToolStripMenuItem,
            this.copyToToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.selectedToolStripMenuItem,
            this.filteredToolStripMenuItem});
            this.imageContextMenu.Name = "imageContextMenu";
            this.imageContextMenu.Size = new System.Drawing.Size(140, 224);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.SelectImage);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenImage);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenDirectory);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameImage);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteImage);
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.moveToToolStripMenuItem.Text = "Move To";
            this.moveToToolStripMenuItem.Click += new System.EventHandler(this.MoveImageTo);
            // 
            // copyToToolStripMenuItem
            // 
            this.copyToToolStripMenuItem.Name = "copyToToolStripMenuItem";
            this.copyToToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyToToolStripMenuItem.Text = "Copy To";
            this.copyToToolStripMenuItem.Click += new System.EventHandler(this.CopyImageTo);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.DuplicateImage);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToToolStripMenuItem1,
            this.moveToToolStripMenuItem2,
            this.copyToToolStripMenuItem1,
            this.createShortcutAtToolStripMenuItem,
            this.resetTagsToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectedToolStripMenuItem.Text = "Selected";
            // 
            // moveToToolStripMenuItem1
            // 
            this.moveToToolStripMenuItem1.Name = "moveToToolStripMenuItem1";
            this.moveToToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.moveToToolStripMenuItem1.Text = "Deselect";
            this.moveToToolStripMenuItem1.Click += new System.EventHandler(this.buttonDeselect_Click);
            // 
            // moveToToolStripMenuItem2
            // 
            this.moveToToolStripMenuItem2.Name = "moveToToolStripMenuItem2";
            this.moveToToolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.moveToToolStripMenuItem2.Text = "Move To";
            this.moveToToolStripMenuItem2.Click += new System.EventHandler(this.MoveSelected);
            // 
            // copyToToolStripMenuItem1
            // 
            this.copyToToolStripMenuItem1.Name = "copyToToolStripMenuItem1";
            this.copyToToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.copyToToolStripMenuItem1.Text = "Copy To";
            this.copyToToolStripMenuItem1.Click += new System.EventHandler(this.CopySelected);
            // 
            // createShortcutAtToolStripMenuItem
            // 
            this.createShortcutAtToolStripMenuItem.Name = "createShortcutAtToolStripMenuItem";
            this.createShortcutAtToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.createShortcutAtToolStripMenuItem.Text = "Create Shortcut At";
            this.createShortcutAtToolStripMenuItem.Click += new System.EventHandler(this.ShortcutSelected);
            // 
            // resetTagsToolStripMenuItem1
            // 
            this.resetTagsToolStripMenuItem1.Name = "resetTagsToolStripMenuItem1";
            this.resetTagsToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.resetTagsToolStripMenuItem1.Text = "Reset Tags";
            this.resetTagsToolStripMenuItem1.Click += new System.EventHandler(this.SelectedResetTags);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteSelected);
            // 
            // filteredToolStripMenuItem
            // 
            this.filteredToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToToolStripMenuItem3,
            this.copyToToolStripMenuItem2,
            this.createShortcutAtToolStripMenuItem1,
            this.resetTagsToolStripMenuItem,
            this.deleteToolStripMenuItem2});
            this.filteredToolStripMenuItem.Name = "filteredToolStripMenuItem";
            this.filteredToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.filteredToolStripMenuItem.Text = "Filtered";
            // 
            // moveToToolStripMenuItem3
            // 
            this.moveToToolStripMenuItem3.Name = "moveToToolStripMenuItem3";
            this.moveToToolStripMenuItem3.Size = new System.Drawing.Size(171, 22);
            this.moveToToolStripMenuItem3.Text = "Move To";
            this.moveToToolStripMenuItem3.Click += new System.EventHandler(this.MoveFiltered);
            // 
            // copyToToolStripMenuItem2
            // 
            this.copyToToolStripMenuItem2.Name = "copyToToolStripMenuItem2";
            this.copyToToolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.copyToToolStripMenuItem2.Text = "Copy To";
            this.copyToToolStripMenuItem2.Click += new System.EventHandler(this.CopyFiltered);
            // 
            // createShortcutAtToolStripMenuItem1
            // 
            this.createShortcutAtToolStripMenuItem1.Name = "createShortcutAtToolStripMenuItem1";
            this.createShortcutAtToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.createShortcutAtToolStripMenuItem1.Text = "Create Shortcut At";
            this.createShortcutAtToolStripMenuItem1.Click += new System.EventHandler(this.ShortcutFiltered);
            // 
            // resetTagsToolStripMenuItem
            // 
            this.resetTagsToolStripMenuItem.Name = "resetTagsToolStripMenuItem";
            this.resetTagsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.resetTagsToolStripMenuItem.Text = "Reset Tags";
            this.resetTagsToolStripMenuItem.Click += new System.EventHandler(this.FilteredResetTags);
            // 
            // deleteToolStripMenuItem2
            // 
            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
            this.deleteToolStripMenuItem2.Text = "Delete";
            this.deleteToolStripMenuItem2.Click += new System.EventHandler(this.DeleteFiltered);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelMenus);
            this.MinimumSize = new System.Drawing.Size(1150, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.panelMenus.ResumeLayout(false);
            this.panelMenus.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelPage.ResumeLayout(false);
            this.panelPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tagsFilterLayout.ResumeLayout(false);
            this.panelResetFilters.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelTags.ResumeLayout(false);
            this.tagsFilterPanel.ResumeLayout(false);
            this.panelFilterButtons.ResumeLayout(false);
            this.tagsImagePanel.ResumeLayout(false);
            this.tagsManagePanel.ResumeLayout(false);
            this.imageContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public FolderBrowserDialog folderBrowserDialog1;
        public Button button_loadFolder;
        public Panel panelMenus;
        public Panel panelLeft;
        public FlowLayoutPanel panelImageList;
        public PictureBox pictureBox1;
        public Button button_unloadFolder;
        public FlowLayoutPanel tagsFilterLayout;
        public Panel panelMain;
        public Panel panelPreview;
        public Panel panelTags;
        public Button button_manageTags;
        public Panel tagsManagePanel;
        public FlowLayoutPanel tagsManageList;
        public Button button_addTag;
        public Button buttonImageTags;
        public SmoothFlowLayoutPanel tagsImageLayout;
        public Button ExitButton;
        public Button RestoreButton;
        public Button MinimizeButton;
        public Panel tagsImagePanel;
        public Button buttonSelectAll;
        public Button buttonDeselect;
        public Button pageForward;
        public Button pageBack;
        private Panel panelInfo;
        private Button infoButton;
        private Label labelImageName;
        private TextBox textBoxName;
        private ListBox listBox1;
        private Label labelKeywords;
        private Button buttonArtist;
        private TextBox textBoxArtist;
        private Label labelArtist;
        private Button buttonRename;
        private Label labelPath;
        private Label labelLocation;
        private Button buttonClosePreview;
        public Button button_unloadDirectory;
        public Button button_loadDirectory;
        private Button buttonRefresh;
        private Button buttonSearch;
        private TextBox searchBox;
        private Button buttonClearSearch;
        private ContextMenuStrip imageContextMenu;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem moveToToolStripMenuItem;
        private ToolStripMenuItem copyToToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ComboBox dropdownOrderBy;
        private Label labelOrderBy;
        private TextBox labelPage;
        private Panel panelPage;
        private ToolStripMenuItem selectToolStripMenuItem;
        private ToolStripMenuItem duplicateToolStripMenuItem;
        private ToolTip toolTip1;
        private ToolStripMenuItem selectedToolStripMenuItem;
        private ToolStripMenuItem moveToToolStripMenuItem1;
        private ToolStripMenuItem moveToToolStripMenuItem2;
        private ToolStripMenuItem copyToToolStripMenuItem1;
        private ToolStripMenuItem createShortcutAtToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripMenuItem filteredToolStripMenuItem;
        private ToolStripMenuItem moveToToolStripMenuItem3;
        private ToolStripMenuItem copyToToolStripMenuItem2;
        private ToolStripMenuItem createShortcutAtToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem2;
        private Label labelSizeData;
        private Label labelSize;
        private Label labelImageSize;
        private Label labelResolution;
        private Button buttonSearchWF;
        private Button buttonSearchOF;
        private Panel panelResetFilters;
        private Button buttonResetFilters;
        private Panel tagsFilterPanel;
        private Button buttonAscDesc;
        private Label labelModifiedDate;
        private Label labelCreatedDate;
        private Label labelModified;
        private Label labelCreated;
        public Button saveButton;
        private Button buttonCloseFilters;
        public Button buttonFocusFolder;
        public ImageList ShowHideButton;
        private ToolStripMenuItem resetTagsToolStripMenuItem1;
        private ToolStripMenuItem resetTagsToolStripMenuItem;
        public Button buttonUntagged;
        private Label labelExtension;
        private Panel panelFilterButtons;
        private Button buttonCloseCondition;
        private Button buttonNotCondition;
        private Button buttonOrCondition;
        private Button buttonAndCondition;
        private Button buttonShowConditions;
    }
}