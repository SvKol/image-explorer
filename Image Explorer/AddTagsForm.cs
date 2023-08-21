using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_Explorer
{
    public partial class AddTagsForm : Form
    {
        private static AddTagsForm? _form = null;

        public static bool hasForm { get { return _form != null; } }

        public static AddTagsForm getForm()
        {
            if (_form == null)
                return new AddTagsForm();
            return _form;
        }

        private AddTagsForm()
        {
            _form = this;
            InitializeComponent();
            ShowInTaskbar = false;
            foreach(string tag in MainForm.validTags)
                checkedListBox1.Items.Add(tag.Replace("_"," "));
            foreach (string group in MainForm.tagGroups)
                comboBox1.Items.Add(group);
            Show();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            string tag = textBox1.Text.ToKeyword();
            string group = comboBox1.Text.ToKeyword(true);
            if (tag.Length < 1) return;
            if (!MainForm.mainForm.AddNewTag(tag, group))
            {
                SystemSounds.Hand.Play();
                return;
            }
            if (!comboBox1.Items.Contains(group))
            {
                comboBox1.Items.Add(group);
                comboBox1.Text = group;
            }
            checkedListBox1.Items.Add(tag.Replace("_"," "));
            textBox1.Text = "";
            foreach(int check in checkedListBox1.CheckedIndices)
                checkedListBox1.SetItemChecked(check, false);
            checkedListBox1.Refresh();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _form = null;
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addTagButton_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            List<string> inherits = new List<string>();

            foreach (string selected in checkedListBox1.CheckedItems)
                inherits.AddRange(selected.Replace(" ", "_").GetTagChain());
            checkedListBox1.Colors.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Color color = checkedListBox1.BackColor;
                string val = checkedListBox1.Items[i].ToString().Replace(" ", "_");
                int c = (from kw in inherits where kw.Equals(val) select 0).Count();
                if (c > 0)
                {
                    if (c > 1) color = Color.Orange;
                    else color = Color.Lime;
                }
                checkedListBox1.Colors.Add(color);
            }
            checkedListBox1.Refresh();
        }
    }
}
