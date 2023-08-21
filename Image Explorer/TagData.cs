using Image_Explorer.Properties;
using System.Linq;
using System.Windows.Forms.VisualStyles;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_Explorer
{
    public class TagData
    {
        private static Dictionary<string, TagData> _tags = new Dictionary<string, TagData>();
        public static Dictionary<string, Panel> groups = new Dictionary<string, Panel>();

        public static readonly Color defaultColor = Color.FromArgb(0,0,0,0);

        public string keyword;
        public string group;

        public Button buttonFilter;
        public Panel? panelImage;
        public Panel? panelManage;

        public List<TagData> parentTags = new List<TagData>();

        private int _state = 0;

        public int state {
            get { return _state; }
            set {
                if (value == 0)
                {
                    buttonFilter.BackColor = Color.Transparent;
                    buttonFilter.FlatAppearance.MouseOverBackColor = Color.Gray;
                    MainForm.conditions.RemoveCondition(keyword);
                }
                else if (value == 1)
                {
                    buttonFilter.BackColor = Color.DarkOliveGreen;
                    buttonFilter.FlatAppearance.MouseOverBackColor = Color.Green;
                    MainForm.conditions.AddCondition(keyword, 0);
                }
                else if (value == 2)
                {
                    buttonFilter.BackColor = Color.DarkRed;
                    buttonFilter.FlatAppearance.MouseOverBackColor = Color.Red;
                    MainForm.conditions.AddCondition(keyword, -1);
                }
                else if (value == 3)
                { 
                    buttonFilter.BackColor = Color.Tan;
                    buttonFilter.FlatAppearance.MouseOverBackColor = Color.Yellow;
                    MainForm.conditions.AddCondition(keyword, 1);
                }
                _state = value;
            }
        }

        public string keywordText
        {
            get { return keyword.Replace("_", " "); }
        }

        public TagData(string tag, string group)
        {
            keyword = tag;
            this.group = group;

            if (!groups.ContainsKey(group) && !String.IsNullOrEmpty(group))
                groups.Add(group, CreateGroupPanels());

            buttonFilter = CreateTagFilter(tag);
            //if (MainForm.selectedKeywords.ContainsKey(tag)) state = MainForm.selectedKeywords[tag];

            panelManage = CreateTagControl();
            panelManage.Controls.Add(CreateLabel());
            panelManage.Controls.Add(CreateEditRemoveTagButton(false));
            panelManage.Controls.Add(CreateEditRemoveTagButton(true));

            panelImage = CreateTagControl(true);
            panelImage.Controls.Add(CreateAddRemoveButton());
            //panelImage.Controls.Add(CreateAddRemoveButton(true));
            //panelImage.Controls.Add(CreateAddRemoveButton(false))
            //panelImage.Controls.Add(CreateLabel());
            //if (!group.Equals(""))
            //    groups[group].Controls.Add(panelImage);

            if (AddTagsForm.hasForm)
                foreach (string subTag in AddTagsForm.getForm().checkedListBox1.CheckedItems)
                    parentTags.Add(_tags[subTag.Replace(" ", "_")]);

            _tags.Add(tag, this);
            this.group = group;
        }

        public TagData(Button filter)
        {
            keyword = "";
            group = "";
            buttonFilter = filter;
            //if (MainForm.selectedKeywords.ContainsKey("")) state = MainForm.selectedKeywords[""];
            //else MainForm.selectedKeywords.Add("", 0);
            _tags.Add("", this);
        }

        public static bool Contains(string keyword)
        {
            return _tags.ContainsKey(keyword);
        }

        public static TagData Get(string tag)
        {
            if (_tags.ContainsKey(tag))
                return _tags[tag];
            return null;
        }

        public static TagData[] GetAll()
        {
            TagData[] result = new TagData[_tags.Count];
            int i = 0;
            foreach(var tag in _tags.Values)
            {
                result[i] = tag;
                i++;
            }
            return result;
        }

        public override string ToString()
        {
            string grp = String.IsNullOrEmpty(group) ? "" : $"{{{MainForm.tagGroups.IndexOf(group)}|{group}}}";
            string result = $"{grp}{keyword}"; //{MainForm.selectedKeywords[keyword].EncodeState()}
            foreach (var parent in parentTags)
                result += $":{parent.keyword}";
            return result;
        }

        public static TagData Reconstruct(string[] tags)
        {
            int state = 0;
            if (tags[0].StartsWith("+")) state = 1;
            else if (tags[0].StartsWith("-")) state = 2;
            else if (tags[0].StartsWith("*")) state = 3;

            string group = "";
            string sidx = "";

            int position = state > 0 ? 1 : 0;
            if (tags[0][position] == '{')
            {
                bool isIdx = true;
                while (++position < tags[0].Length)
                {
                    if (tags[0][position] == '}') break;
                    if (isIdx)
                    {
                        if (tags[0][position] == '|')
                        {
                            isIdx = false;
                            continue;
                        }
                        sidx += tags[0][position];
                    }
                    else group += tags[0][position];
                }
                if (group.Equals("") && !sidx.Equals(""))
                {
                    group = sidx;
                    sidx = "0";
                }
                if (++position > tags[0].Length)
                {
                    position = state > 0 ? 1 : 0;
                    group = "";
                }
            }

            if (!MainForm.tagGroups.Contains(group))
            {
                if (Int32.TryParse(sidx, out int index))
                {
                    if (index < 0) index = 0;
                    MainForm.tagGroups.Replace(index, group);
                }
                else MainForm.tagGroups.Insert(0, group);
            }

            string main = position > 0 ? tags[0].Substring(position) : tags[0];
            //MainForm.selectedKeywords[main] = state;
            if (_tags.ContainsKey(main))
            {
                //_tags[main].state = state;
                _tags[main].group = group;
                return _tags[main];
            }
            TagData td = new TagData(main, group);
            for (int i = 1; i < tags.Length; i++)
            {
                TagData p = _tags.ContainsKey(tags[i]) ? _tags[tags[i]] : new TagData(tags[i], "");
                td.parentTags.Add(p);
            }
            return td;
        }

        private Panel CreateGroupPanels()
        {
            Panel panelMain = new Panel();
            Panel panel = new Panel();
            panelMain.Controls.Add(panel);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(0, 0);
            panelMain.Size = new Size(200, 30);
            panelMain.AutoSize = true;
            panelMain.MinimumSize = new Size(200, 30);
            panelMain.MaximumSize = new Size(200, 0);
            panelMain.Padding = new Padding(0);
            panelMain.Margin = new Padding(0);
            panelMain.BackColor = Color.Gray;
            Label label = new Label();
            Button showHide = new Button();
            Button up = new Button();
            Button down = new Button();
            panel.BackColor = Color.Silver;
            panel.Controls.Add(label);
            panel.Controls.Add(up);
            panel.Controls.Add(down);
            panel.Controls.Add(showHide);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.MinimumSize = new Size(200, 30);
            panel.MaximumSize = new Size(200, 30);
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(0);
            panel.BorderStyle = BorderStyle.FixedSingle;
            label.BackColor = Color.FromArgb(0, 0, 0, 0);
            label.Dock = DockStyle.Left;
            label.FlatStyle = FlatStyle.Flat;
            label.Font = new Font("Centaur", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label.ForeColor = Color.SpringGreen;
            label.Location = new Point(20, 0);
            label.Name = "groupLabel";
            label.Size = new Size(165, 30);
            label.TabIndex = 3;
            label.Text = group;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            showHide.Dock = DockStyle.Left;
            showHide.FlatAppearance.BorderSize = 0;
            showHide.FlatStyle = FlatStyle.Flat;
            showHide.ImageIndex = 0;
            showHide.ImageList = MainForm.mainForm.ShowHideButton;
            showHide.Location = new Point(0, 0);
            showHide.Margin = new Padding(0);
            showHide.Name = "buttonShowHide";
            showHide.Size = new Size(20, 30);
            showHide.TabIndex = 0;
            showHide.Tag = group;
            showHide.UseVisualStyleBackColor = true;
            showHide.Click += new EventHandler(MainForm.mainForm.HideShowGroup);
            up.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            up.FlatAppearance.BorderSize = 0;
            up.FlatStyle = FlatStyle.Flat;
            up.Image = Resources.Up;
            up.Location = new Point(185, 0);
            up.Margin = new Padding(0);
            up.Name = "buttonUp";
            up.MaximumSize = new Size(15, 15);
            up.MinimumSize = up.MaximumSize;
            up.TabIndex = 1;
            up.UseVisualStyleBackColor = true;
            up.Tag = group;
            up.Click += new EventHandler(MainForm.mainForm.MoveGroupUp);
            down.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            down.FlatAppearance.BorderSize = 0;
            down.FlatStyle = FlatStyle.Flat;
            down.Image = Resources.Down;
            down.Location = new Point(185, 15);
            down.Margin = new Padding(0);
            down.Name = "buttonDown";
            down.MaximumSize = new Size(15, 15);
            down.MinimumSize = down.MaximumSize;
            down.TabIndex = 2;
            down.UseVisualStyleBackColor = true;
            down.Tag = group;
            down.Click += new EventHandler(MainForm.mainForm.MoveGroupDown);
            return panelMain;
        }

        private void UpdatePanel(Panel panel)
        {
            panel.Tag = keyword;
            foreach (Control child in panel.Controls)
            {
                child.Tag = keyword;
                Label lbl = child as Label;
                if (lbl != null)
                    lbl.Text = keyword.Replace("_", " ");
            }
        }

        private void UpdateFilter(Button button)
        {
            button.Tag = keyword;
            button.Text = keyword.Replace("_", " ");
        }

        public bool ChangeKeyword(string newKeyword)
        {
            if (newKeyword.Equals("Untagged") || newKeyword.Length < 1) return false;
            if (Contains(newKeyword)) return false;

            Parallel.ForEach(MainForm.images.Values, image =>
            {
                int index = image.keywords.FindIndex(s => s.Equals(keyword));
                if (index > -1) image.keywords[index] = newKeyword;
            });

            int index = MainForm.validTags.FindIndex(s => s.Equals(keyword));
            if (index > -1) MainForm.validTags[index] = newKeyword;

            _tags.Remove(keyword);

            keyword = newKeyword;

            _tags.Add(keyword, this);

            UpdateFilter(buttonFilter);
            UpdatePanel(panelImage);
            UpdatePanel(panelManage);

            return true;
        }

        public static bool RemoveTag(string tag)
        {
            if (!_tags.ContainsKey(tag)) return false;
            TagData td = _tags[tag];

            Parallel.ForEach(MainForm.images.Values, image =>
            {
                int index = image.keywords.FindIndex(s => s.Equals(td.keyword));
                if (index > -1) image.keywords.RemoveAt(index);
            });

            int index = MainForm.validTags.FindIndex(s => s.Equals(td.keyword));
            if (index > -1) MainForm.validTags.RemoveAt(index);

            td.buttonFilter.Dispose();
            td.panelImage.Dispose();
            td.panelManage.Dispose();

            _tags.Remove(tag);

            return true;
        }

        public void SetColor(Color color)
        {
            if (panelImage != null)
                panelImage.BackColor = color;
        }

        public static void ClearColors()
        {
            Color color = MainForm.mainForm.tagsFilterLayout.BackColor;
            foreach (TagData td in _tags.Values)
                if (td.panelImage != null)
                    td.panelImage.BackColor = defaultColor;
        }


        private Label CreateLabel()
        {
            MainForm mainForm = MainForm.mainForm;
            Label label = new Label();
            label.Tag = keyword;
            label.Text = keywordText;
            label.Dock = DockStyle.Fill;
            label.FlatStyle = FlatStyle.Flat;
            label.Font = new Font("Centaur", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label.ForeColor = Color.PeachPuff;
            label.BackColor = Color.FromArgb(0, 0, 0, 0);
            label.Name = $"label{keyword}";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            return label;
        }

        private Button CreateAddRemoveButton()
        {
            Button button = new Button();
            //button.Dock = DockStyle.Right;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Black;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64, 64);
            button.FlatStyle = FlatStyle.Flat;
            //button.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button.MaximumSize = new Size(200, 30);
            button.MinimumSize = button.MaximumSize;
            button.UseVisualStyleBackColor = true;
            button.UseCompatibleTextRendering = true;
            button.Tag = keyword;

            button.Name = $"imgTagAddRemove{keyword}";
            button.MouseUp += new MouseEventHandler(MainForm.mainForm.AddRemoveTagsToImage);
            button.Text = keywordText;

            button.Dock = DockStyle.Fill;
            button.Font = new Font("Centaur", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button.ForeColor = Color.PeachPuff;
            button.BackColor = Color.FromArgb(0, 0, 0, 0);
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            /*if (isAdd)
            {
                button.ForeColor = Color.LightGreen;
                button.Location = new Point(170, 0);
                button.Name = $"imgTagAdd{keyword}";
                button.Text = "+";
                button.Click += new EventHandler(MainForm.mainForm.AddTagsToImage);
            }
            else
            {
                button.ForeColor = Color.Red;
                button.Location = new Point(185, 0);
                button.Name = $"imgTagRemove{keyword}";
                button.Text = "-";
                button.Click += new EventHandler(MainForm.mainForm.RemoveTagsFromImage);
            }*/

            return button;
        }

        private Button CreateEditRemoveTagButton(bool isRemove)
        {
            Button button = new Button();
            button.Tag = keyword;
            button.Dock = DockStyle.Right;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.MaximumSize = new Size(18, 25);
            button.MinimumSize = button.MaximumSize;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.UseCompatibleTextRendering = true;
            button.UseVisualStyleBackColor = true;
            if (isRemove)
            {
                button.Name = $"buttonDelete{keyword}";
                button.Location = new Point(180, 0);
                button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                button.ForeColor = Color.OrangeRed;
                button.Text = "X";
                button.Click += new EventHandler(MainForm.mainForm.button_removeTag_Click);
            }
            else
            {
                button.Name = $"buttonEdit{keyword}";
                button.Location = new Point(160, 0);
                button.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
                button.ForeColor = Color.Yellow;
                button.Text = "/";
                button.Click += new EventHandler(MainForm.mainForm.button_editTag_Click);
            }
            return button;
        }

        private Panel CreateTagControl(bool bottomDock = false)
        {
            Panel panel = new Panel();
            panel.Tag = keyword;
            panel.Dock = bottomDock ? DockStyle.Bottom : DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(0);
            panel.Name = $"panel{keyword}";
            panel.MinimumSize = new Size(200, 30);
            panel.MaximumSize = panel.MinimumSize;
            panel.BackColor = Color.FromArgb(0, 0, 0, 0);
            return panel;
        }

        private Button CreateTagFilter(string tag)
        {
            MainForm mainForm = MainForm.mainForm;
            Button button = new Button();
            button.Tag = tag;
            button.Name = $"tagButton{tag}";
            button.Dock = mainForm.buttonUntagged.Dock;
            button.FlatAppearance.BorderSize = mainForm.buttonUntagged.FlatAppearance.BorderSize;
            button.FlatStyle = mainForm.buttonUntagged.FlatStyle;
            button.Font = mainForm.buttonUntagged.Font;
            button.ForeColor = mainForm.buttonUntagged.ForeColor;
            button.Margin = mainForm.buttonUntagged.Margin;
            button.MaximumSize = mainForm.buttonUntagged.MaximumSize;
            button.MinimumSize = mainForm.buttonUntagged.MinimumSize;
            button.Size = mainForm.buttonUntagged.Size;
            button.Text = tag.Replace("_", " ");
            button.TextAlign = mainForm.buttonUntagged.TextAlign;
            button.UseCompatibleTextRendering = mainForm.buttonUntagged.UseCompatibleTextRendering;
            button.UseVisualStyleBackColor = mainForm.buttonUntagged.UseVisualStyleBackColor;
            button.MouseDown += new MouseEventHandler(mainForm.tag_RegisterButton);
            button.MouseUp += new MouseEventHandler(mainForm.tag_ChangeState);
            button.MouseMove += new MouseEventHandler(mainForm.tag_MouseTrack);

            return button;
        }

        public bool CompareTo(TagData other)
        {
            if (String.IsNullOrEmpty(keyword)) return true;
            if (!group.Equals(""))
            {
                if (other.group.Equals("")) return true;
                if (!other.group.Equals(group)) return MainForm.tagGroups.IndexOf(group) < MainForm.tagGroups.IndexOf(other.group);
            }
            else if (!other.group.Equals("")) return false;
            char[] thisLetters = keyword.ToLower().ToCharArray();
            char[] otherLetters = other.keyword.ToLower().ToCharArray();
            int length = Math.Min(thisLetters.Length, otherLetters.Length);
            for(int i = 0; i < length; i++)
            {
                if (thisLetters[i] == otherLetters[i]) continue;
                return thisLetters[i] < otherLetters[i];
            }
            return thisLetters.Length < otherLetters.Length;
        }

        public static List<TagData> OrderedTags()
        {
            List<TagData> orderedTags = new List<TagData>();
            foreach (TagData tag in _tags.Values)
            {
                int i = 0;
                bool added = false;
                while (i < orderedTags.Count)
                {
                    if (tag.CompareTo(orderedTags[i]))
                    {
                        orderedTags.Insert(i, tag);
                        added = true;
                        break;
                    }
                    i++;
                }
                if (!added) orderedTags.Add(tag);
            }
            return orderedTags;
        }
    }
}
