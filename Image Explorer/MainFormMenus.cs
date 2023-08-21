using Image_Explorer.Properties;
using System.Diagnostics;
using System.Media;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Image_Explorer
{
    partial class MainForm
    {
        private Stopwatch timestamper = new Stopwatch();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void button_loadFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataManager.ManageFolder(folderBrowserDialog1.SelectedPath);
                DataManager.SaveState();
                string[] maFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                foreach(var maFile in maFiles)
                {
                    if (Regex.Match(maFile, imageFilter, RegexOptions.IgnoreCase).Success)
                        if (images.ContainsKey(maFile)) images[maFile].managed = true;
                        else images.TryAdd(maFile, new ImageData(maFile));
                }
                changes = true;
            }
        }

        private void button_unloadFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataManager.RemoveFolder(folderBrowserDialog1.SelectedPath);
                DataManager.SaveState();
                string[] maFiles = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                foreach(var maFile in maFiles)
                {
                    if (Regex.Match(maFile, imageFilter, RegexOptions.IgnoreCase).Success)
                        if (images.ContainsKey(maFile)) images[maFile].managed = false;
                }
                changes = true;
            }
        }

        private void button_loadDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataManager.ManageDirectory(folderBrowserDialog1.SelectedPath);
                DataManager.SaveState();
                ScourFolders();
                changes = true;
            }
        }

        private void button_unloadDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                DataManager.RemoveDirectory(folderBrowserDialog1.SelectedPath);
                DataManager.SaveState();
                ScourFolders();
                changes = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveConfigurations();
        }

        private void buttonDeselect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
                imageList[i].selected = false;
            UpdateInfo();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < ITEMS_PER_PAGE; i++)
                imageList[i].selected = imageList[i].Visible;
            UpdateInfo();
        }

        private void buttonImageTags_Click(object sender, EventArgs e)
        {
            if (panelTags.Visible)
            {
                if (tagsImagePanel.Visible)
                {
                    panelTags.Hide();
                    buttonImageTags.BackColor = Color.Transparent;
                    return;
                }
                tagsFilterPanel.Visible = false;
                toolTip1.SetToolTip(buttonSearchOF, "Select filters");
                buttonSearchOF.Image = Resources.FilterOnly;
                tagsImagePanel.Visible = true;
                buttonImageTags.BackColor = Color.OliveDrab;
                tagsManagePanel.Visible = false;
                button_manageTags.BackColor = Color.Transparent;
                return;
            }
            panelTags.Show();
            tagsFilterPanel.Visible = false;
            toolTip1.SetToolTip(buttonSearchOF, "Select filters");
            buttonSearchOF.Image = Resources.FilterOnly;
            tagsImagePanel.Visible = true;
            buttonImageTags.BackColor = Color.OliveDrab;
            tagsManagePanel.Visible = false;
            button_manageTags.BackColor = Color.Transparent;
        }

        private void button_manageTags_Click(object sender, EventArgs e)
        {
            if (panelTags.Visible)
            {
                if (tagsManagePanel.Visible)
                {
                    panelTags.Hide();
                    button_manageTags.BackColor = Color.Transparent;
                    return;
                }
                tagsFilterPanel.Visible = false;
                toolTip1.SetToolTip(buttonSearchOF, "Select filters");
                buttonSearchOF.Image = Resources.FilterOnly;
                tagsImagePanel.Visible = false;
                buttonImageTags.BackColor = Color.Transparent;
                tagsManagePanel.Visible = true;
                button_manageTags.BackColor = Color.OliveDrab;
                return;
            }
            panelTags.Show();
            tagsFilterPanel.Visible = false;
            toolTip1.SetToolTip(buttonSearchOF, "Select filters");
            buttonSearchOF.Image = Resources.FilterOnly;
            tagsImagePanel.Visible = false;
            buttonImageTags.BackColor = Color.Transparent;
            tagsManagePanel.Visible = true;
            button_manageTags.BackColor = Color.OliveDrab;
        }

        private void button_toggleTags_Click(object sender, MouseEventArgs e)
        {
            if (((Int32)e.Button & 0x00300000) == 0) return; //only register left or right mouse button presses.
            if (panelTags.Visible)
            {
                if (tagsFilterPanel.Visible)
                {
                    toolTip1.SetToolTip(buttonSearchOF, "Select filters");
                    buttonSearchOF.Image = Resources.FilterOnly;
                    if (e.Button == MouseButtons.Left) buttonSearchOF_Click(sender, e);
                    else panelTags.Hide();
                    //button_toggleTags.BackColor = Color.Transparent;
                    return;
                }
                tagsFilterPanel.Visible = true;
                toolTip1.SetToolTip(buttonSearchOF, "Search, using only filters");
                buttonSearchOF.Image = Resources.go;
                //button_toggleTags.BackColor = Color.OliveDrab;
                tagsImagePanel.Visible = false;
                buttonImageTags.BackColor = Color.Transparent;
                tagsManagePanel.Visible = false;
                button_manageTags.BackColor = Color.Transparent;
                return;
            }
            panelTags.Show();
            tagsFilterPanel.Visible = true;
            toolTip1.SetToolTip(buttonSearchOF, "Search, using only filters");
            buttonSearchOF.Image = Resources.go;
            //button_toggleTags.BackColor = Color.OliveDrab;
            tagsImagePanel.Visible = false;
            buttonImageTags.BackColor = Color.Transparent;
            tagsManagePanel.Visible = false;
            button_manageTags.BackColor = Color.Transparent;
        }

        private void buttonCloseFilters_Click(object sender, EventArgs e)
        {
            panelTags.Hide();
            toolTip1.SetToolTip(buttonSearchOF, "Select filters");
            buttonSearchOF.Image = Resources.FilterOnly;
        }

        private void buttonFocusFolder_Click(object sender, EventArgs e)
        {
            if (DataManager.focusedFolder == null)
            {
                if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;
                if (!DataManager.GetManagedFolders().Contains(folderBrowserDialog1.SelectedPath))
                {
                    SystemSounds.Question.Play();
                    DialogResult dr = MessageBox.Show("This folder is not managed, would you like to add it to your managed folders?", "Unmanaged folder", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel) return;
                    if (dr == DialogResult.Yes)
                    {
                        DataManager.ManageDirectory(folderBrowserDialog1.SelectedPath);
                        changes = true;
                    }
                    else
                        MessageBox.Show("You are now previewing the folder's content, but you will not see it in your managed directories.", "Unmanaged folder", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                DataManager.focusedFolder = folderBrowserDialog1.SelectedPath;
                buttonFocusFolder.Image = Resources.UnfocusFolder;
                toolTip1.SetToolTip(buttonFocusFolder, "Cancel Focus");
            }
            else
            {
                DataManager.focusedFolder = null;
                buttonFocusFolder.Image = Resources.FocusFolder;
                toolTip1.SetToolTip(buttonFocusFolder, "Focus Folder");
            }
            ScourFolders();
            RefreshImages();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLl", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panelMenus_MouseDown(object sender, MouseEventArgs e)
        {
            if (timestamper.IsRunning)
            {
                if (timestamper.ElapsedMilliseconds < 300)
                {
                    RestoreButton_Click(sender, e);
                    timestamper.Reset();
                    return;
                } else timestamper.Restart();
            }
            else timestamper.Start();
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                MessageBox.Show("No images selected", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selected.Count > 1)
            {
                MessageBox.Show("Select a single image to rename", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxName.Text.Equals(selected[0].imageName)) return;
            if (images.TryRemove(selected[0].path, out _))
            {
                selected[0].Rename(textBoxName.Text);
                for (int i = 0; i < ITEMS_PER_PAGE; i++)
                    if (imageList[i].imageData == selected[0])
                        imageList[i].Rename(textBoxName.Text);
                images.TryAdd(selected[0].path, selected[0]);
                pictureBox1.ImageLocation = selected[0].path;
                changes = true;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bool newSearch = !searchWord.Equals(searchWord = searchBox.Text.ToLower());
            newSearch |= applySearch != (applySearch = true);
            newSearch |= applyFilters != (applyFilters = false);
            isRefresh = !newSearch;
            if (tagsFilterPanel.Visible)
            {
                panelTags.Hide();
                toolTip1.SetToolTip(buttonSearchOF, "Select filters");
                buttonSearchOF.Image = Resources.FilterOnly;
            }
            duplicateSearch = false;
            FilterImages();
            LoadImages();
        }

        private void buttonSearchWF_Click(object sender, EventArgs e)
        {
            bool newSearch = UpdateSelectedKeywords();
            newSearch |= !searchWord.Equals(searchWord = searchBox.Text.ToLower());
            newSearch |= applySearch != (applySearch = true);
            newSearch |= applyFilters != (applyFilters = true);
            isRefresh = !newSearch;
            if (tagsFilterPanel.Visible)
            {
                panelTags.Hide();
                toolTip1.SetToolTip(buttonSearchOF, "Select filters");
                buttonSearchOF.Image = Resources.FilterOnly;
            }
            duplicateSearch = false;
            FilterImages();
            LoadImages();
        }

        private void buttonSearchOF_Click(object sender, EventArgs e)
        {
            searchWord = String.Empty;
            bool newSearch = UpdateSelectedKeywords();
            newSearch |= applySearch != (applySearch = false);
            newSearch |= applyFilters != (applyFilters = true);
            isRefresh = !newSearch;
            if (tagsFilterPanel.Visible)
                panelTags.Hide();
            duplicateSearch = false;
            FilterImages();
            LoadImages();
        }

        private void buttonArtist_Click(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                textBoxArtist.Text = "";
                NoImagesSelectedPanel();
                return;
            }
            foreach (var img in selected)
            {
                if (!img.artist.Equals(textBoxArtist.Text))
                {
                    img.artist = textBoxArtist.Text;
                    changes = true;
                }
            }
        }

        private void RefreshImages(object sender = null, EventArgs e = null)
        {
            isRefresh = true;
            if (duplicateSearch) FilterPotentialDuplicates(sender, e);
            else FilterImages();
            LoadImages();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            if (panelInfo.Visible)
            {
                panelInfo.Hide();
                toolTip1.SetToolTip(infoButton, "Open info panel (Ctrl+I");
            }
            else
            {
                panelInfo.Show();
                toolTip1.SetToolTip(infoButton, "Close info panel (Ctrl+I");
            }
        }

        private void ClosePreview(object sender, EventArgs e)
        {
            ClosePreview();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ModifierKeys.Equals(Keys.Shift))
                    buttonSearch_Click(buttonSearch, e);
                else
                    buttonSearchWF_Click(buttonSearchWF, e);
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button1_Click(buttonClearSearch, e);
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonRename_Click(buttonSearch, e);
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textBoxName.Text = String.IsNullOrEmpty(pictureBox1.ImageLocation) ? "" : images[pictureBox1.ImageLocation].imageName;
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBoxArtist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonArtist_Click(buttonSearch, e);
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                textBoxArtist.Text = String.IsNullOrEmpty(pictureBox1.ImageLocation) ? "" : images[pictureBox1.ImageLocation].artist;
                panelMain.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dropdownOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            char cache = ImageComparer.comparator;
            if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Name"))
                ImageComparer.comparator = 'n';
            else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Artist"))
                ImageComparer.comparator = 'a';
            else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Location"))
                ImageComparer.comparator = 'p';
            else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Size"))
                ImageComparer.comparator = 's';
            else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Created"))
                ImageComparer.comparator = 'c';
            else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Modified"))
                ImageComparer.comparator = 'm';
            //else if (dropdownOrderBy.Items[dropdownOrderBy.SelectedIndex].ToString().Equals("Resolution"))
            //    ImageComparer.comparator = 'r';
            if (cache != ImageComparer.comparator && !changedByCode)
            {
                SortImages();
                LoadImages();
            }
        }

        private void buttonAscDesc_Click(object sender, EventArgs e)
        {
            ImageComparer.descending = !ImageComparer.descending;
            buttonAscDesc.Text = ImageComparer.descending ? "Descending" : "Ascending";
            SortImages();
            LoadImages();
        }

        private void labelPage_Enter(object sender, EventArgs e)
        {
            labelPage.Text = "";
        }

        private void labelPage_Leave(object sender, EventArgs e)
        {
            int lastPage = GetLastPage();
            labelPage.Text = loadedImages.Count == 0 ? "0/0" : $"{currentPage}/{lastPage}";
        }

        private void labelPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                labelPage_Leave(sender, e);
                e.SuppressKeyPress = true;
                panelPage.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (Int32.TryParse(labelPage.Text, out int page))
                {
                    int lastPage = GetLastPage();
                    if (page > lastPage) page = lastPage;
                    else if (page < 1) page = 1;
                    if (page != currentPage)
                    {
                        currentPage = page;
                        LoadImages();
                    }
                }
                else labelPage_Leave(sender, e);
                e.SuppressKeyPress = true;
                panelPage.Focus();
            }
        }

        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            ClearFilterColors();
            conditions.Clear();
        }

        private void FilterPotentialDuplicates(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                FilterPotentialDuplicates(sender, (EventArgs)e);
        }

        private void buttonAndCondition_Click(object sender, EventArgs e)
        {
            conditions.GoIn(0);
            ClearFilterColors();
        }

        private void buttonOrCondition_Click(object sender, EventArgs e)
        {
            conditions.GoIn(1);
            ClearFilterColors();
        }

        private void buttonCloseCondition_Click(object sender, EventArgs e)
        {
            if(conditions.GoOut())
                UpdateFilterColors();
        }

        private void buttonShowConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conditions.ToString());
        }

        private void buttonNotCondition_Click(object sender, EventArgs e)
        {
            conditions.GoIn(-1);
            ClearFilterColors();
        }
    }
}