using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Explorer
{
    public partial class TagManagement : Form
    {
        private static TagManagement instance;

        private TagData tag;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public static TagManagement Open(string tag)
        {
            if (instance == null) return new TagManagement(tag);
            instance.Close();
            return new TagManagement(tag);
        }

        private TagManagement(string tag)
        {
            instance = this;

            this.tag = TagData.Get(tag);

            Tag = this.tag;

            InitializeComponent();
            ShowInTaskbar = false;

            int idx = 0;
            for (int j = 0; j < MainForm.tagGroups.Count; j++)
            {
                comboBox1.Items.Add(MainForm.tagGroups[j]);
                if (MainForm.tagGroups[j].Equals(this.tag.group))
                    idx = j;
            }

            comboBox1.SelectedIndex = idx;

            foreach (string keyword in MainForm.validTags)
            {
                if (keyword.Equals(tag)) continue;
                if (this.tag.parentTags.Contains(TagData.Get(keyword)))
                    ownedTags.Items.Add(keyword.Replace("_", " "));
                else
                    unownedTags.Items.Add(keyword.Replace("_", " "));
            }
            myTag.Text = tag.Replace("_", " ");

            List<string> alreadyHas = tag.GetTagChain();
            for (int i = 0; i < unownedTags.Items.Count; i++)
            {
                Color color = unownedTags.BackColor;
                string val = unownedTags.Items[i].ToString().Replace(" ", "_");
                if (alreadyHas.Contains(val))
                    color = Color.Lime;
                unownedTags.Colors.Add(color);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            instance = null;
            Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            bool groupChanged = false;
            if (comboBox1.Text.ToKeyword(true) != tag.group)
            {
                string group = comboBox1.Text.ToKeyword(true);
                tag.group = group;
                if (!MainForm.tagGroups.Contains(group))
                {
                    MainForm.tagGroups.Add(group);
                    comboBox1.Items.Add(group);
                    buttonConfirm.Select();
                    comboBox1.Text = group;
                }
                groupChanged = true;
            }
            if (!(tag.ChangeKeyword(myTag.Text.ToKeyword()) || groupChanged))
                SystemSounds.Beep.Play();
            else MainForm.mainForm.changes = true;
            myTag.Text = tag.keyword.Replace("_", " ");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            while(unownedTags.CheckedItems.Count > 0)
            {
                string kwrd = (string)unownedTags.CheckedItems[0];
                ownedTags.Items.Add(kwrd);
                unownedTags.Items.Remove(kwrd);
                tag.parentTags.Add(TagData.Get(kwrd.Replace(" ", "_")));
            }
            ownedTags.Refresh();
            unownedTags.Refresh();
            MainForm.mainForm.changes = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            while (ownedTags.CheckedItems.Count > 0)
            {
                string kwrd = (string)ownedTags.CheckedItems[0];
                unownedTags.Items.Add(kwrd);
                ownedTags.Items.Remove(kwrd);
                tag.parentTags.Remove(TagData.Get(kwrd.Replace(" ", "_")));
            }
            ownedTags.Refresh();
            unownedTags.Refresh();
            MainForm.mainForm.changes = true;
        }

        private void myTag_Leave(object sender, EventArgs e)
        {
            var coordinates = buttonConfirm.PointToClient(Cursor.Position);
            if (coordinates.X > 0 && coordinates.Y > 0 && coordinates.X < buttonConfirm.Width && coordinates.Y < buttonConfirm.Height) return;
            myTag.Text = tag.keyword.Replace("_", " ");
        }

        private void TagManagement_Click(object sender, EventArgs e)
        {
            labelTag.Focus();
        }

        private void myTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tag.ChangeKeyword(myTag.Text.ToKeyword()))
                    e.SuppressKeyPress = true;
                myTag.Text = tag.keyword.Replace("_", " ");
                labelTag.Focus();
            }
        }

        private void ChecklistSelectedIndexChanged(object sender, MouseEventArgs e)
        {
            List<string> alreadyHas = tag.keyword.GetTagChain();
            List<string> canAdd = new List<string>();

            foreach (string uoSelected in unownedTags.CheckedItems)
                canAdd.AddRange(uoSelected.Replace(" ", "_").GetTagChain());
            unownedTags.Colors.Clear();
            for (int i = 0; i < unownedTags.Items.Count; i++)
            {
                Color color = unownedTags.BackColor;
                string val = unownedTags.Items[i].ToString().Replace(" ", "_");
                int c = (from kw in canAdd where kw.Equals(val) select 0).Count();
                if (alreadyHas.Contains(val))
                {
                    if (c > 0) color = Color.Orange;
                    else color = Color.Lime;
                }
                else if (c == 1) color = Color.Yellow;
                else if (c > 1) color = Color.Tan;
                unownedTags.Colors.Add(color);
            }
            ownedTags.Colors.Clear();
            for (int i = 0; i < ownedTags.Items.Count; i++)
            {
                Color color = ownedTags.BackColor;
                string val = ownedTags.Items[i].ToString().Replace(" ", "_");
                if (canAdd.Contains(val))
                    color = Color.Yellow;
                ownedTags.Colors.Add(color);
            }
            unownedTags.Refresh();
            ownedTags.Refresh();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            var coordinates = buttonConfirm.PointToClient(Cursor.Position);
            if (coordinates.X > 0 && coordinates.Y > 0 && coordinates.X < buttonConfirm.Width && coordinates.Y < buttonConfirm.Height) return;
            comboBox1.Text = comboBox1.SelectedText;
        }
    }
}
