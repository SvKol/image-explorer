using Microsoft.VisualBasic.FileIO;
using System.Media;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Image_Explorer
{
    partial class MainForm
    {
        private ImageData GetContextMenuOwner()
        {
            ImageData image = null;
            ImageContainer imageContainer = imageContextMenu.SourceControl as ImageContainer;
            if (imageContainer != null)
                image = imageContainer.imageData;
            else if (imageContextMenu.SourceControl == pictureBox1 && !String.IsNullOrEmpty(pictureBox1.ImageLocation))
                image = images[pictureBox1.ImageLocation];
            return image;
        }

        private void SelectImage(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            SelectSingleImageContainer(image);
            subform_Click(image);
        }

        private void OpenImage(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!File.Exists(image.path)) return;
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(image.path) { UseShellExecute = true });
        }

        private void OpenDirectory(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!File.Exists(image.path)) return;
            string argument = "/select, \"" + image.path + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void RenameImage(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!image.path.Equals(pictureBox1.ImageLocation))
            {
                SelectSingleImageContainer(image);
                subform_Click(image);
            }
            if (!panelInfo.Visible)
                panelInfo.Show();
            textBoxName.Select();
            textBoxName.SelectionStart = 0;
            textBoxName.SelectionLength = textBoxName.Text.Length;
        }

        private void DeleteImage(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            DeleteImage(image);
        }

        private void CopyImageTo(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!File.Exists(image.path)) return;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ImageData copy = image.Copy(folderBrowserDialog1.SelectedPath);
                if (copy != null)
                {
                    images.TryAdd(copy.path, copy);
                    changes = true;
                    if (DataManager.GetFolders().Contains(folderBrowserDialog1.SelectedPath))
                        RefreshImages();
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("Can not copy " + image.imageName + " to " + folderBrowserDialog1.SelectedPath + ", as it's already there.\nUse duplicate instead.", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MoveImageTo(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!File.Exists(image.path)) return;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string oldPath = image.path;
                string newPath = folderBrowserDialog1.SelectedPath;
                if (image.Move(newPath))
                {
                    images.TryRemove(oldPath, out _);
                    images.TryAdd(image.path, image);
                    RefreshImages();
                    changes = true;
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show(image.imageName + " is already in " + folderBrowserDialog1.SelectedPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DuplicateImage(object sender, EventArgs e)
        {
            ImageData image = GetContextMenuOwner();
            if (image == null) return;
            if (!File.Exists(image.path)) return;
            ImageData duplicate = image.Duplicate(image.imageName);
            images.TryAdd(duplicate.path, duplicate);
            RefreshImages();
            changes = true;
        }

        private void MoveFiltered(object sender, EventArgs e)
        {
            if (loadedImages.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No valid filter results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to move {loadedImages.Count} images to {folderBrowserDialog1.SelectedPath}?", "Move Filtered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                MoveImages(loadedImages, folderBrowserDialog1.SelectedPath);
            }
        }

        private void MoveSelected(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to move {selected.Count} images to {folderBrowserDialog1.SelectedPath}?", "Move Selected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                MoveImages(selected, folderBrowserDialog1.SelectedPath);
            }
        }

        private void CopyFiltered(object sender, EventArgs e)
        {
            if (loadedImages.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No valid filter results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to copy {loadedImages.Count} images to {folderBrowserDialog1.SelectedPath}?", "Copy Filtered", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                CopyImages(loadedImages, folderBrowserDialog1.SelectedPath);
            }
        }

        private void CopySelected(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to copy {selected.Count} images to {folderBrowserDialog1.SelectedPath}?", "Copy Selected", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                CopyImages(selected, folderBrowserDialog1.SelectedPath);
            }
        }

        private void ShortcutFiltered(object sender, EventArgs e)
        {
            if (loadedImages.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No valid filter results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to create shortcuts of {loadedImages.Count} images at {folderBrowserDialog1.SelectedPath}?", "Create Shortcuts", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                ShortcutImages(loadedImages, folderBrowserDialog1.SelectedPath);
            }
        }

        private void ShortcutSelected(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                SystemSounds.Question.Play();
                DialogResult dialog = MessageBox.Show($"Are you sure you want to create shortcuts of {selected.Count} images at {folderBrowserDialog1.SelectedPath}?", "Create Shortcuts", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes) return;
                ShortcutImages(selected, folderBrowserDialog1.SelectedPath);
            }
        }

        private void DeleteSelected(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            if (selected.Count == 1) DeleteImage(selected[0]);
            else DeleteImages(selected);
        }

        private void DeleteFiltered(object sender, EventArgs e)
        {
            if (loadedImages.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No valid filter results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (loadedImages.Count == 1) DeleteImage(loadedImages[0]);
            else DeleteImages(loadedImages);
        }

        private void SelectedResetTags(object sender, EventArgs e)
        {
            List<ImageData> selected = GetSelected();
            if (selected.Count == 0)
            {
                NoImagesSelectedPanel();
                return;
            }
            SystemSounds.Question.Play();
            DialogResult dr;
            if (selected.Count == 1)
            {
                dr = MessageBox.Show($"Remove {selected[0].imageName}'s tags?", "Remove tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    selected[0].keywords.Clear();
            }
            else
            {
                dr = MessageBox.Show($"Remove tags from {selected.Count} images?", "Remove tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    ImagesRemoveTags(selected);
            }
            UpdateInfo();
        }

        private void FilteredResetTags(object sender, EventArgs e)
        {
            if (loadedImages.Count == 0)
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("No valid filter results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SystemSounds.Question.Play();
            DialogResult dr;
            if (loadedImages.Count == 1)
            {
                dr = MessageBox.Show($"Remove {loadedImages[0].imageName}'s tags?", "Remove tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    loadedImages[0].keywords.Clear();
                    UpdateInfo();
            }
            else
            {
                dr = MessageBox.Show($"Remove tags from {loadedImages.Count} images?", "Remove tags", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    ImagesRemoveTags(loadedImages);
            }
            UpdateInfo();
        }
    }
}