using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;

namespace Image_Explorer
{
    partial class MainForm
    {
        private static MouseButtons buttonUsed;
        private static bool invalid;

        private void button_addTag_Click(object sender, EventArgs e)
        {
            AddTagsForm atf = AddTagsForm.getForm();
            atf.Tag = this;
            atf.Location = new Point(Location.X + (Size.Width - atf.Size.Width) / 2, Location.Y + (Size.Height - atf.Size.Height) / 2);
        }

        public void button_removeTag_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null) return;
            if (!TagData.RemoveTag((string)control.Tag)) return;
            changes = true;
        }

        public void button_editTag_Click(object sender, EventArgs e)
        {
            TagManagement form = TagManagement.Open((string)(sender as Control).Tag);
            form.Show();
            form.Location = new Point(Location.X + (Size.Width - form.Size.Width) / 2, Location.Y + (Size.Height - form.Size.Height) / 2);
        }

        public void tag_RegisterButton(object sender, MouseEventArgs e)
        {
            if (e.Location.X < 0 || e.Location.Y < 0 || e.Location.X > (sender as Control).Width || e.Location.Y > (sender as Control).Height) return;
            buttonUsed = e.Button;
            invalid = false;
        }

        public void tag_MouseTrack(object sender, MouseEventArgs e)
        {
            invalid = e.Location.X < 0 || e.Location.Y < 0 || e.Location.X > (sender as Control).Width || e.Location.Y > (sender as Control).Height;
        }

        public void tag_ChangeState(object sender, MouseEventArgs e)
        {
            if (invalid) return;

            Button cb = sender as Button;
            if (cb == null) return;
            TagData tag = TagData.Get((string)cb.Tag);
            if (buttonUsed == MouseButtons.Left)
            {
                if (tag.state == 1)
                    tag.state = 0;
                else
                    tag.state = 1;
            }
            if (buttonUsed == MouseButtons.Right)
            {
                if (tag.state == 2)
                    tag.state = 0;
                else
                    tag.state = 2;
            }
            if (buttonUsed == MouseButtons.Middle)
            {
                if (tag.state == 3)
                    tag.state = 0;
                else
                    tag.state = 3;
            }
            buttonUsed = MouseButtons.None;
        }

        public void AddTagsToImage(object sender, EventArgs e)
        {
            string tag = (string)(sender as Control).Tag;
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            foreach (ImageData img in selected)
                tag.AddTo(img);
            UpdateInfo();
            UpdateTagColors();
            changes = true;
        }

        public void RemoveTagsFromImage(object sender, EventArgs e)
        {
            string tag = (string)(sender as Control).Tag;
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            foreach (ImageData img in selected)
            {
                if (!img.keywords.Contains(tag)) continue;
                img.keywords.Remove(tag);
            }
            UpdateInfo();
            UpdateTagColors();
            changes = true;
        }
        public void AddRemoveTagsToImage(object sender, MouseEventArgs e)
        {
            byte state = 0; //do nothing;
            if (e.Button == MouseButtons.Right)
                state = 1; //default actions
            else if (e.Button == MouseButtons.Left)
                state = 3; //special actions
            else return;
            string tag = (string)(sender as Control).Tag;
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            foreach (ImageData img in selected)
            {
                if (!img.keywords.Contains(tag))
                {
                    state++;
                    break;
                }
            }
            switch (state)
            {
                //default remove
                case 1:
                    {
                        foreach (ImageData img in selected)
                        {
                            tag.RemoveFrom(img);
                        }
                        break;
                    }
                //default add
                case 2:
                    {
                        foreach (ImageData img in selected)
                        {
                            if (!img.keywords.Contains(tag))
                                img.keywords.Add(tag);
                        }
                        break;
                    }
                //special remove
                case 3:
                    {
                        foreach (ImageData img in selected)
                        {
                            if (img.keywords.Contains(tag))
                                img.keywords.Remove(tag);
                        }
                        break;
                    }
                //special add
                case 4:
                    {
                        foreach (ImageData img in selected)
                        {
                            tag.AddTo(img);
                        }
                        break;
                    }
            }
            UpdateInfo();
            UpdateTagColors();
            changes = true;
        }

        public void HideShowGroup(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;
            if (btn.ImageIndex == 0)
            {
                btn.ImageIndex = 1;
                new AnimationTimer(btn.Parent.Parent, false);
            }
            else
            {
                btn.ImageIndex = 0;
                new AnimationTimer(btn.Parent.Parent, true);
            }
        }

        private class AnimationTimer
        {
            private const int PIXELS_PER_SECOND = 400;
            private const int FRAMES_PER_SECOND = 30;
            private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            private int ticks;
            private int tick = 0;
            private Control panel;
            private int start;
            private int goal;

            private int panelAbsoluteY {  get { return panel.Location.Y + parentStartOfView; } }
            private int parentEndOfView { get { return panel.Parent.Height + parentStartOfView; } }
            private int parentStartOfView { get { return -(panel.Parent as SmoothFlowLayoutPanel).AutoScrollPosition.Y; } }
            private int parentTotalY
            {
                get
                {
                    int y = 0;
                    foreach (Control child in panel.Parent.Controls)
                        y += child.Height;
                    return y;
                }
            }

            public AnimationTimer(Control panel, bool expand)
            {
                this.panel = panel;
                AnimationTimer oldAt = panel.Tag as AnimationTimer;
                if (oldAt != null)
                {
                    oldAt.timer.Stop();
                }
                start = panel.Height;
                if (expand)
                {
                    timer.Tick += new EventHandler(Expand);
                    goal = 0;
                    foreach (Control c in panel.Controls)
                        goal += c.Height;
                    ticks = (goal - start) * FRAMES_PER_SECOND / PIXELS_PER_SECOND;
                }
                else
                {
                    timer.Tick += new EventHandler(Contract);
                    goal = panel.Controls[0].Height;
                    ticks = (start - goal) * FRAMES_PER_SECOND / PIXELS_PER_SECOND;
                }
                timer.Interval = 1000 / FRAMES_PER_SECOND;
                panel.Tag = this;
                timer.Start();
            }

            private void Expand(object sender, EventArgs e)
            {
                tick++;
                if (tick == ticks)
                {
                    timer.Stop();
                    panel.Tag = null;
                    panel.MaximumSize = new Size(panel.Width, goal);
                    panel.Size = panel.MaximumSize;
                    return;
                }
                panel.MaximumSize = new Size(panel.Width, start + (goal*tick/ticks));
                panel.Size = panel.MaximumSize;
            }

            private void Contract(object sender, EventArgs e)
            {
                tick++;
                if (tick == ticks)
                {
                    timer.Stop();
                    panel.Tag = null;
                    panel.MaximumSize = new Size(panel.Width, goal);
                    return;
                }
                Size size = new Size(panel.Width, (start * (ticks - tick) / ticks) + (goal * tick / ticks));
                int end = parentTotalY;
                if (end == parentEndOfView)
                {
                    int toTheEnd = end - panelAbsoluteY;
                    int deltaH = panel.Height - goal;
                    (panel.Parent as SmoothFlowLayoutPanel).AutoScrollPosition = new Point(0, (panelAbsoluteY - panel.Parent.Height) + (toTheEnd - deltaH));
                }
                panel.MaximumSize = size;
                panel.Size = size;
            }
        }

        private void pageBack_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadImages();
        }

        private void pageForward_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadImages();
        }

        public void MoveGroupUp(object sender, EventArgs e)
        {
            string group = (string)(sender as Control).Tag;
            int idx = tagGroups.IndexOf(group);
            if (idx < 2) return;
            tagGroups.Switch(idx, idx - 1);
            RefreshTags();
        }

        public void MoveGroupDown(object sender, EventArgs e)
        {
            string group = (string)(sender as Control).Tag;
            int idx = tagGroups.IndexOf(group);
            if (idx + 2 >= tagGroups.Count) return;
            tagGroups.Switch(idx, idx + 1);
            RefreshTags();
        }
    }
}