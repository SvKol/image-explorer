using Microsoft.VisualBasic.FileIO;
using System.Collections.Concurrent;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;

namespace Image_Explorer
{
    //Environment.CurrentDirectory - project path

    public partial class MainForm : Form
    {
        const int ITEMS_PER_PAGE = 54;
        public int imagePreviewColumns = 2;
        private static int currentPage = 1;
        public static MainForm mainForm;
        public static ConcurrentDictionary<string, ImageData> images = new ConcurrentDictionary<string, ImageData>();
        public static ConcurrentDictionary<ImageData, bool> toBeLoaded = new ConcurrentDictionary<ImageData, bool>();
        private static List<ImageData> loadedImages = new List<ImageData>();
        public static List<string> validTags = new List<string>();
        public static List<string> tagGroups = new List<string>();
        private string imageFilter = @".+\.(?:jpg|bmp|png|jfif)$";
        //private readonly static Regex imgFormatRx = new Regex(@"^image:([\w_:\. \d-\(\)%',]+) \| path:([\w_\\:\. \d-\(\)%',]+) \| artist:([\w \d\(\),'-]*) \| keywords:([\w;_'\.\(\)]*)$");
        private static List<string> searchFor = new List<string>();
        private static List<string> alwaysAdd = new List<string>();
        private static List<string> filterOut = new List<string>();
        private ImageContainer[] imageList = new ImageContainer[ITEMS_PER_PAGE];

        //public static Dictionary<string, int> selectedKeywords = new Dictionary<string, int>();
        private static string selectedCache = String.Empty;
        public static string searchWord = String.Empty;
        public static bool applyFilters = false;
        public static bool applySearch = false;
        public static bool duplicateSearch = false;
        public static bool isRefresh = false;

        private bool _changes = false;

        private static Thread imageLoader = new Thread(PrepareImages);
        private static AutoResetEvent resetLoader = new AutoResetEvent(false);
        private static bool exit = false;

        public static FiltersBuilder conditions = new FiltersBuilder();
        private static bool changedByCode = false;

        public bool changes
        {
            get { return _changes; }
            set
            {
                saveButton.FlatAppearance.BorderSize = value ? 2 : 0;
                _changes = value;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;
            mainForm = this;
            this.Text = String.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            buttonUntagged.Tag = "";

            tagsFilterLayout.HorizontalScroll.Maximum = 0;
            tagsFilterLayout.VerticalScroll.Maximum = 0;
            tagsFilterLayout.AutoScroll = true;
            tagsImageLayout.HorizontalScroll.Maximum = 0;
            tagsImageLayout.VerticalScroll.Maximum = 0;
            tagsImageLayout.AutoScroll = true;
            tagsManageList.HorizontalScroll.Maximum = 0;
            tagsManageList.VerticalScroll.Maximum = 0;
            tagsManageList.AutoScroll = true;

            dropdownOrderBy.SelectedIndex = 0;

            InitializeImageList();
            //pictureBox1.ContextMenuStrip = imageContextMenu;

            panelInfo.Hide();

            if (File.Exists(DataManager.ImageDataPath))
            {
                string confFile = DataManager.ImageDataPath.LoadString();
                using (StringReader reader = new StringReader(confFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        ParseImage(line);
                }
                //File.ReadLines(configurations).AsParallel()./*WithDegreeOfParallelism(8).*/ForAll(ParseImage);
            }

            DataManager.LoadState();
            ScourFolders();

            if (File.Exists(DataManager.TagsDataPath))
                ParseTags();
            new TagData(buttonUntagged);
            RefreshTags();
            imageLoader.Start();
        }

        private static void PrepareImages()
        {
            while (!exit)
            {
                while (toBeLoaded.Count > 0)
                {
                    if (exit) return;
                    IEnumerator<KeyValuePair<ImageData, bool>> iEnum = toBeLoaded.GetEnumerator();
                    iEnum.MoveNext();
                    if (toBeLoaded.TryRemove(iEnum.Current.Key, out _))
                        iEnum.Current.Key.LoadThumbnail();
                }
                resetLoader.WaitOne();
            }
        }

        private void InitializeImageList()
        {
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
            {
                imageList[i] = new ImageContainer();
                panelImageList.Controls.Add(imageList[i]);
                imageList[i].ContextMenuStrip = imageContextMenu;
                //imageList[i].Show();
            }
        }

        private void ParseImage(string line)
        {
            string[] data = line.Split('|');
            if (!File.Exists(data[0])) return;
            ImageData imageData = new ImageData(data[0]);
            if (data[2].Length > 0) imageData.SetKeywords(data[2].Split(";"));
            imageData.artist = data[1];
            images.TryAdd(data[0], imageData);
            toBeLoaded.TryAdd(imageData, true);
        }

        private void ParseTags()
        {
            string tagsFile = DataManager.TagsDataPath.LoadString();
            using (StringReader reader = new StringReader(tagsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length < 2)
                    {
                        //int val = line == "" ? 0 : line[0].ToState();
                        //if (val != -1 && !selectedKeywords.ContainsKey("")) selectedKeywords[""] = val;
                        continue;
                    }
                    TagData tag = TagData.Reconstruct(line.Split(":"));
                    validTags.Add(tag.keyword);
                }
            }
        }

        private void ScourFolders()
        {
            string[] folders = DataManager.GetFolders();
            Parallel.ForEach(folders, folder =>
            {
                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                    if (Regex.Match(file, imageFilter, RegexOptions.IgnoreCase).Success)
                        if (!images.ContainsKey(file))
                        {
                            ImageData image = new ImageData(file);
                            images.TryAdd(file, image);
                            toBeLoaded.TryAdd(image, true);
                        }
            });
            foreach (var image in images.Values) image.managed = folders.Contains(image.folder);
            resetLoader.Set();
        }

        private void RefreshTags()
        {
            List<TagData> orderedTags = TagData.OrderedTags();
            foreach (string group in tagGroups)
                if (!String.IsNullOrEmpty(group)) tagsImageLayout.Controls.Add(TagData.groups[group]);
            for (int i = 0; i < orderedTags.Count; i++)
            {
                tagsFilterLayout.Controls.Add(orderedTags[i].buttonFilter);
                tagsManageList.Controls.Add(orderedTags[i].panelManage);
                if (orderedTags[i].group.Equals("")) tagsImageLayout.Controls.Add(orderedTags[i].panelImage);
                else TagData.groups[orderedTags[i].group].Controls.Add(orderedTags[i].panelImage);
            }
        }

        public bool UpdateSelectedKeywords()
        {
            /*searchFor.Clear();
            filterOut.Clear();
            alwaysAdd.Clear();
            Dictionary<string, int> filters = new Dictionary<string, int>();
            filters[""] = TagData.Get("").state;
            foreach (var tag in validTags)
            {
                if (!TagData.Contains(tag)) continue;
                filters[tag] = TagData.Get(tag).state;
                if (filters[tag] == 1) searchFor.Add(tag);
                else if (filters[tag] == 2) filterOut.Add(tag);
                else if (filters[tag] == 3) alwaysAdd.Add(tag);
            }
            if (selectedKeywords.IsEqualTo(filters)) return false;
            selectedKeywords = filters;
            SaveTags();*/
            if (selectedCache.Equals(conditions.ToString()))
                return false;
            selectedCache = conditions.ToString();
            return true;
        }

        public void SaveConfigurations()
        {
            StringBuilder stringBuilder = new StringBuilder("", 2048);
            foreach (ImageData image in images.Values)
                stringBuilder.AppendLine(image.ToString());
            DataManager.ImageDataPath.Save(stringBuilder.ToString());
            changes = false;
            SaveTags();
        }

        private void SortImages()
        {
            loadedImages.Sort(ImageComparer.Instance);
        }

        private void FilterImages()
        {
            if (!(applyFilters || applySearch)) return;
            if (isRefresh) ScourFolders();
            else currentPage = 1;
            ConcurrentDictionary<ImageData, bool> loaded = new ConcurrentDictionary<ImageData, bool>();
            Parallel.ForEach(images.Values, image =>
            {
                if (!image.managed) return;
                if (applyFilters && !conditions.Evaluate(image)) return;
                if (applySearch && !String.IsNullOrEmpty(searchWord))
                {
                    if (image.fileName.ToLower().Contains(searchWord) || image.artist.ToLower().Contains(searchWord)) 
                        loaded.TryAdd(image, true);
                }
                else loaded.TryAdd(image, true);
            });
            loadedImages.Clear();
            foreach (var img in loaded.Keys) loadedImages.Add(img);
            ClosePreview();
            SortImages();
        }

        public void FilterPotentialDuplicates(object sender, EventArgs e)
        {
            duplicateSearch = true;
            ConcurrentDictionary<(long, Point), ConcurrentBag<ImageData>> duplicates = new ConcurrentDictionary<(long, Point), ConcurrentBag<ImageData>>();
            ConcurrentDictionary<long, ConcurrentBag<ImageData>> potentialDuplicates = new ConcurrentDictionary<long, ConcurrentBag<ImageData>>();
            Parallel.ForEach(images.Values, image =>
            {
                if (image.managed)
                {
                    if (!potentialDuplicates.ContainsKey(image.size))
                        potentialDuplicates.TryAdd(image.size, new ConcurrentBag<ImageData>());
                    potentialDuplicates[image.size].Add(image);
                }
            });
            Parallel.ForEach(potentialDuplicates.Values, imageList =>
            {
                if(imageList.Count > 1)
                {
                    foreach(var image in imageList)
                    {
                        image.LoadThumbnail();
                        if (!duplicates.ContainsKey((image.size, image.imageSize)))
                            duplicates.TryAdd((image.size, image.imageSize), new ConcurrentBag<ImageData>());
                        duplicates[(image.size, image.imageSize)].Add(image);
                    }
                }
            });

            loadedImages.Clear();
            foreach (var imgList in duplicates.Values)
            {
                if (imgList.Count > 1)
                    foreach(var img in imgList)
                        loadedImages.Add(img);
            }
            ClosePreview();
            TagData.ClearColors();
            changedByCode = true;
            dropdownOrderBy.SelectedIndex = dropdownOrderBy.Items.IndexOf("Size");
            changedByCode = false;
            SortImages();
            LoadImages();
        }

        private int GetLastPage()
        {
            return loadedImages.Count % ITEMS_PER_PAGE > 0 ? 1 + loadedImages.Count / ITEMS_PER_PAGE : loadedImages.Count / ITEMS_PER_PAGE;
        }

        private void LoadImages()
        {
            //imageLoader.Abort();
            int lastPage = GetLastPage();
            if (currentPage > lastPage) currentPage = lastPage;
            if (currentPage < 1) currentPage = 1;
            int startIndex = ITEMS_PER_PAGE * (currentPage - 1);
            int endIndex = ITEMS_PER_PAGE * currentPage;
            labelPage.Text = loadedImages.Count == 0 ? "0/0" : $"{currentPage}/{lastPage}";
            labelOrderBy.Focus();
            pageForward.Enabled = endIndex < loadedImages.Count;
            pageBack.Enabled = currentPage > 1;
            panelImageList.AutoScrollPosition = new Point(0, 0);
            Parallel.For(startIndex, endIndex, i => {
                if (i < loadedImages.Count)
                    if (toBeLoaded.TryRemove(loadedImages[i], out _))
                        loadedImages[i].LoadThumbnail();
            });
            for(int i = startIndex; i < endIndex; i++)
            {
                if (i < loadedImages.Count)
                {
                    imageList[i - startIndex].LoadImage(loadedImages[i]);
                    imageList[i - startIndex].Show();
                }
                else
                    imageList[i - startIndex].Hide();
            }
            buttonDeselect_Click(null, null);
            //imageLoader.Start();
        }

        private void openOriginalImage(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(pictureBox1.ImageLocation) { UseShellExecute = true });
        }

        public void subform_Click(ImageData image)
        {
            pictureBox1.ImageLocation = image.path;
            pictureBox1.ContextMenuStrip = imageContextMenu;
            UpdateInfo();
            UpdateTagColors();
        }

        public bool SelectSingleImageContainer(ImageData image)
        {
            bool selected = false;
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
            {
                imageList[i].selected = imageList[i].imageData == image;
                selected |= imageList[i].selected;
            }
            return selected;
        }

        public void AddImageContainerRange(ImageData image)
        {
            int min = -1;
            int max = -1;
            int img = -1;
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
            {
                if (imageList[i].imageData == image) img = i;
                if (imageList[i].selected)
                {
                    if (min < 0) min = i;
                    max = i;
                }
            }
            if (img < 0) return;
            if (min < 0) imageList[img].selected = true;
            else if (img < min)
                for (int i = img; i < max; i++)
                    imageList[i].selected = true;
            else if (img > max)
                for (int i = min + 1; i <= img; i++)
                    imageList[i].selected = true;
            else
                for (int i = min + 1; i < max; i++)
                    imageList[i].selected = true;
        }

        private void ClosePreview()
        {
            if (String.IsNullOrEmpty(pictureBox1.ImageLocation)) return;
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
            {
                if (imageList[i].imageData == null) break;
                if (imageList[i].imageData.path.Equals(pictureBox1.ImageLocation))
                    imageList[i].selected = false;
            }
            UpdateInfo();
            pictureBox1.ImageLocation = null;
            pictureBox1.ContextMenuStrip = null;
            buttonClosePreview.Visible = false;
        }

        private void UpdateInfo()
        {
            listBox1.Items.Clear();
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                labelPath.Text = String.Empty;
                textBoxName.Text = String.Empty;
                textBoxArtist.Text = String.Empty;
                labelSizeData.Text = String.Empty;
                labelImageSize.Text = String.Empty;
                labelCreatedDate.Text = String.Empty;
                labelModifiedDate.Text = String.Empty;
                labelExtension.Text = String.Empty;
                TagData.ClearColors();
                buttonClosePreview.Hide();
                return;
            }
            buttonClosePreview.Show();
            UpdateTagColors();
            if (selected.Count == 1)
            {
                labelPath.Text = selected[0].path;
                textBoxName.Text = selected[0].imageName;
                textBoxArtist.Text = selected[0].artist;
                labelImageSize.Text = selected[0].imageSize.AsString();
                labelSizeData.Text = selected[0].size.AsString();
                labelCreatedDate.Text = selected[0].fileInfo.CreationTime.ToString("yyyy-MM-dd");
                labelModifiedDate.Text = selected[0].fileInfo.LastWriteTime.ToString("yyyy-MM-dd");
                labelExtension.Text = selected[0].fileInfo.Extension;
                selected[0].keywords.ForEach(kw => listBox1.Items.Add(kw.Replace("_", " ")));
                return;
            }
            labelPath.Text = "########";
            textBoxName.Text = "########";
            string artist = selected[0].artist;
            foreach (ImageData image in selected)
                if (!artist.Equals(image.artist))
                {
                    artist = "########";
                    break;
                }
            textBoxArtist.Text = artist;
            labelCreatedDate.Text = String.Empty;
            labelModifiedDate.Text = String.Empty;
            List<string> keywords = new List<string>(selected[0].keywords);
            if (keywords.Count > 0)
                for (int i = 1; i < selected.Count; i++)
                    for(int j = 0; j < keywords.Count; j++)
                        if (!selected[i].keywords.Contains(keywords[j]))
                        {
                            keywords.RemoveAt(j);
                            if (keywords.Count == 0) goto noKeywordsRemaining;
                            j--;
                        }

            noKeywordsRemaining:
            keywords.ForEach(kw => listBox1.Items.Add(kw.Replace("_", " ")));
            long size = 0;
            selected.ForEach(img => size += img.size);
            labelSizeData.Text = size.AsString();
            string resolution = selected[0].imageSize.AsString();
            string extension = selected[0].fileInfo.Extension;
            for(int i = 1; i < selected.Count; i++)
                if (!selected[i].fileInfo.Extension.Equals(extension))
                {
                    extension = ".*";
                    break;
                }
            labelExtension.Text = extension;
            for (int i = 1; i < selected.Count; i++)
                if (!resolution.Equals(selected[i].imageSize.AsString()))
                {
                    resolution = "####x####";
                    break;
                }
            labelImageSize.Text = resolution;
        }

        public void UpdateTagColors()
        {
            List<ImageData> selected = GetSelected();
            Dictionary<string, int> counter = new Dictionary<string, int>();
            int max = selected.Count;
            foreach (ImageData img in selected)
            {
                foreach (string tag in img.keywords)
                {
                    if (counter.ContainsKey(tag))
                        counter[tag]++;
                    else counter[tag] = 1;
                }
            }
            foreach(string tag in validTags)
            {
                if (counter.ContainsKey(tag))
                {
                    if (counter[tag] == max)
                        TagData.Get(tag).SetColor(Color.DarkGreen);
                    else
                        TagData.Get(tag).SetColor(Color.Tan);
                }
                else
                    TagData.Get(tag).SetColor(TagData.defaultColor);
            }
        }

        public bool AddNewTag(string tag, string group)
        {
            if (validTags.Contains(tag)) return false;
            validTags.Add(tag);
            //selectedKeywords[tag] = 0x00;
            if (!tagGroups.Contains(group))
                tagGroups.Add(group);
            new TagData(tag, group);
            changes = true;
            RefreshTags();
            return true;
        }

        public void SaveTags()
        {
            tagGroups = tagGroups.Where(grp => !String.IsNullOrEmpty(grp)).ToList();
            StringBuilder stringBuilder = new StringBuilder("", 256);
            stringBuilder.AppendLine(/*selectedKeywords[""].EncodeState()*/);
            foreach (var tag in TagData.OrderedTags())
                stringBuilder.AppendLine(tag.ToString());
            DataManager.TagsDataPath.Save(stringBuilder.ToString());
            tagGroups.Insert(0, "");

            /*using (ResXResourceWriter resx = new ResXResourceWriter($"{Environment.CurrentDirectory}/TagsList.resx"))
            {
                int i = 0;
                foreach(string tag in validTags)
                {
                    TagData td = TagData.Get(tag);
                    resx.AddResource($"Group{i}", td.group);
                    resx.AddResource($"Keyword{i}", td.keyword);
                    int j = 0;
                    foreach(var link in td.parentTags)
                    {
                        resx.AddResource($"Links{i},{j}", link.keyword);
                        j++;
                    }
                    resx.AddResource($"State{i}", selectedKeywords[tag]);
                    i++;
                }
            }*/
        }

        public int ItemsOnThePage()
        {
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
                if (!imageList[i].Visible) return i;
            return ITEMS_PER_PAGE;
        }

        public int GetPreviewedIndex()
        {
            if (String.IsNullOrEmpty(pictureBox1.ImageLocation))
                return -1;
            ImageData id = images[pictureBox1.ImageLocation];
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
                if (imageList[i].imageData == id) return i;
            return -1;
        }

        public ImageData GetPreviewed()
        {
            if (String.IsNullOrEmpty(pictureBox1.ImageLocation))
                return null;
            return images[pictureBox1.ImageLocation];
        }

        public bool SelectPreviewed(out ImageData previewed)
        {
            previewed = GetPreviewed();
            if (previewed == null) return false;
            if (!SelectSingleImageContainer(previewed)) return false;
            subform_Click(previewed);
            return true;
        }

        public List<ImageData> GetSelected()
        {
            List<ImageData> selected = new List<ImageData>();
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
            {
                if (!imageList[i].Visible) return selected;
                if (imageList[i].selected)
                    selected.Add(imageList[i].imageData);
            }
            return selected;
        }

        public int GetFirstSelected()
        {
            for (int i = 0; i < ITEMS_PER_PAGE; i++)
                if (imageList[i].selected)
                    return i;
            return -1;
        }

        public int GetLastSelected()
        {
            for (int i = ITEMS_PER_PAGE - 1; i > -1; i--)
                if (imageList[i].selected)
                    return i;
            return -1;
        }

        public void NoImagesSelectedPanel()
        {
            SystemSounds.Exclamation.Play();
            MessageBox.Show("No images were selected", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void DeleteImage(ImageData image)
        {
            images.TryRemove(image.path, out _);
            if (!File.Exists(image.path))
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshImages();
                return;
            }
            SystemSounds.Question.Play();
            DialogResult delete;
            bool permanent = false;
            if (ModifierKeys.Equals(Keys.Shift))
                permanent = true;
            else
            {
                delete = MessageBox.Show("Are you sure you want to delete " + image.fileName + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (delete == DialogResult.No) return;
            }
            if (image.path == pictureBox1.ImageLocation)
            {
                pictureBox1.ImageLocation = null;
                pictureBox1.ContextMenuStrip = null;
            }
            if (permanent)
            {
                try
                {
                    FileSystem.DeleteFile(image.path, UIOption.AllDialogs, RecycleOption.DeletePermanently);
                }
                catch (Exception ex) { }
            }
            else
                FileSystem.DeleteFile(image.path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            RefreshImages();
        }

        public void MoveImages(List<ImageData> imgList, string directory)
        {
            int count = 0;
            bool manage = DataManager.GetFolders().Contains(directory);
            imgList.ForEach(img =>
            {
                string path = img.path;
                if (!img.Move(directory)) return;
                count++;
                images.TryRemove(path, out _);
                img.managed = manage;
                images.TryAdd(img.path, img);
            });
            if (count > 0)
            {
                changes = true;
                RefreshImages();
                SystemSounds.Beep.Play();
                MessageBox.Show($"{count}/{imgList.Count} moved successfully to {directory}.", "Move Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No images were moved!", "Move Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CopyImages(List<ImageData> imgList, string directory)
        {
            int count = 0;
            bool manage = DataManager.GetManagedFolders().Contains(directory);
            imgList.ForEach(img =>
            {
                ImageData copy = img.Copy(directory);
                if (copy == null) return;
                count++;
                copy.managed = manage;
                images.TryAdd(copy.path, copy);
            });
            if (count > 0)
            {
                if (manage)
                {
                    changes = true;
                    RefreshImages();
                }
                SystemSounds.Beep.Play();
                MessageBox.Show($"{count}/{imgList.Count} copied successfully to {directory}.", "Copy Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No images were copied!", "Copy Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void ShortcutImages(List<ImageData> imgList, string directory)
        {
            imgList.ForEach(img => img.CreateShortcut(directory));
            SystemSounds.Beep.Play();
            MessageBox.Show($"{imgList.Count} shortcuts created at {directory}.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void DeleteImages(List<ImageData> imgList)
        {
            DialogResult dr;
            SystemSounds.Question.Play();
            if (ModifierKeys.Equals(Keys.Shift))
            {
                dr = MessageBox.Show($"Are you sure you want to permanently delete {imgList.Count} images?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (dr == DialogResult.Yes)
                {
                    foreach (ImageData img in imgList)
                    {
                        images.TryRemove(img.path, out _);
                        img.fileInfo.Delete();
                    }
                    RefreshImages();
                }
                return;
            }
            dr = MessageBox.Show($"Are you sure you want to delete {imgList.Count} images?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                foreach (ImageData img in imgList)
                {
                    images.TryRemove(img.path, out _);
                    FileSystem.DeleteFile(img.path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                }
                RefreshImages();
            }
        }

        public void ImagesRemoveTags(List<ImageData> imgList)
        {
            foreach (var img in imgList) img.keywords.Clear();
            changes = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                Form infoWindow = HelpWindow.Get();
                infoWindow.Show();
                return true;
            }
            if (keyData == Keys.F5)
            {
                RefreshImages();
                return true;
            }
            if (keyData == (Keys.Control | Keys.S))
            {
                if (changes)
                    SaveConfigurations();
                return true;
            }
            if (keyData == (Keys.Control | Keys.R))
            {
                List<ImageData> selected = GetSelected();
                if (selected.Count != 1)
                    if (!SelectPreviewed(out _ )) return base.ProcessCmdKey(ref msg, keyData);
                if (!panelInfo.Visible)
                    panelInfo.Show();
                textBoxName.Select();
                textBoxName.SelectionStart = 0;
                textBoxName.SelectionLength = textBoxName.Text.Length;
                return true;
            }
            if (keyData == (Keys.Control | Keys.F))
            {
                if (!tagsFilterPanel.Visible) button_toggleTags_Click(null, null);
                searchBox.Select();
                searchBox.SelectionStart = 0;
                searchBox.SelectionLength = searchBox.Text.Length;
                return true;
            }
            if (searchBox.Focused || textBoxArtist.Focused || textBoxName.Focused) return false;
            if (keyData == (Keys.Control | Keys.A))
            {
                buttonSelectAll_Click(null, null);
                return true;
            }
            if (keyData == Keys.Delete || keyData == (Keys.Delete | Keys.Shift))
            {
                List<ImageData> selected = GetSelected();
                if (selected.Count < 1) return false;
                if (selected.Count == 1)
                    DeleteImage(selected[0]);
                else
                    DeleteImages(selected);
                return true;
            }
            if (keyData == (Keys.Control | Keys.I))
            {
                infoButton_Click(null, null);
                return true;
            }
            if (keyData == Keys.Left)
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, - 1, false)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == Keys.Right)
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, + 1, false)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == Keys.Up)
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, - imagePreviewColumns, false)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == Keys.Down)
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, + imagePreviewColumns, false)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == (Keys.Left | Keys.Shift))
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, - 1, true)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == (Keys.Right | Keys.Shift))
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, + 1, true)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == (Keys.Up | Keys.Shift))
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, - imagePreviewColumns, true)) SystemSounds.Beep.Play();
                return true;
            }
            if (keyData == (Keys.Down | Keys.Shift))
            {
                int idx = GetPreviewedIndex();
                if (!MoveToImageIndex(idx, + imagePreviewColumns, true)) SystemSounds.Beep.Play();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool MoveToImageIndex(int idx, int offset, bool shift)
        {
            if (idx < 0) return false;
            idx += offset;
            if (idx < 0 || idx >= ItemsOnThePage()) return false;
            if (!shift)
                buttonDeselect_Click(null, null);
            else if (offset > 1 || offset < -1)
            {
                int direction = -Math.Sign(offset);
                for (int i = idx; i != idx - offset; i += direction)
                    imageList[i].selected = true;
            }
            imageList[idx].selected = true;
            subform_Click(imageList[idx].imageData);
            int h1 = imageList[idx].Location.Y;
            int h2 = imageList[idx].Height;
            int h3 = -panelImageList.AutoScrollPosition.Y;
            int h4 = panelImageList.Height;
            if (h4 < h1 + h2) panelImageList.AutoScrollPosition = new Point(0, h3 + h1 + h2 - h4);
            else if (h1 < 0) panelImageList.AutoScrollPosition = new Point(0, h3 + h1) ;
            return true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.F1Size.Width == 0 || Properties.Settings.Default.F1Size.Height == 0)
            {
                // first start
                // optional: add default values
            }
            else
            {
                this.WindowState = (FormWindowState)Properties.Settings.Default.F1State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.F1Location;
                this.Size = Properties.Settings.Default.F1Size;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit = true;
            Properties.Settings.Default.F1State = (ushort)this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.F1Location = this.Location;
                Properties.Settings.Default.F1Size = this.Size;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.F1Location = this.RestoreBounds.Location;
                Properties.Settings.Default.F1Size = this.RestoreBounds.Size;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
            if (changes)
            {
                DialogResult dr = MessageBox.Show("Save changes before quitting?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Cancel) return;
                if (dr == DialogResult.Yes)
                    SaveConfigurations();
            }
            resetLoader.Set();
            imageLoader.Join();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                this.FormBorderStyle = FormBorderStyle.None;
            else
                this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void ClearFilterColors()
        {
            TagData[] tags = TagData.GetAll();
            foreach (TagData tag in tags)
                tag.state = 0;
        }

        private void UpdateFilterColors()
        {
            TagData[] tags = TagData.GetAll();
            Dictionary<string, int> filterStates = conditions.GetCurrentLevelFilters();
            foreach (TagData tag in tags)
            {
                if (filterStates.ContainsKey(tag.keyword))
                {
                    if (filterStates[tag.keyword] < 0)
                    {
                        if (tag.state != 2) tag.state = 2;
                    }
                    else if (filterStates[tag.keyword] > 0)
                    {
                        if (tag.state != 3) tag.state = 3;
                    }
                    else if (tag.state != 1)
                        tag.state = 1;
                }
                else
                    tag.state = 0;
            }
        }
    }
}