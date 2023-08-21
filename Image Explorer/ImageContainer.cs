namespace Image_Explorer
{
    public partial class ImageContainer : Form
    {
        //private static ConcurrentDictionary<string, ImageContainer> _mapper = new ConcurrentDictionary<string, ImageContainer>();
        public ImageData imageData;
        private bool _selected = false;

        public bool selected { 
            get { 
                return _selected; 
            }
            set {
                if (value) {
                    BackColor = SystemColors.Highlight;
                    label1.ForeColor = SystemColors.HighlightText;
                }
                else
                {
                    BackColor = SystemColors.Control;
                    label1.ForeColor = SystemColors.ControlText;
                }
                _selected = value;
            }
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

        public ImageContainer()
        {
            InitializeComponent();
            TopLevel = false;
        }

        /*public static ImageContainer Get(ImageData image)
        {
            //if (_mapper.ContainsKey(image.path))
            //    return _mapper[image.path];
            ImageContainer container = new ImageContainer();
            container.LoadImage(image);
            container.TopLevel = false;
            //_mapper.TryAdd(image.path, container);
            return container;
        }*/

        private void formClicked(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control) selected = !selected;
            else if (Control.ModifierKeys == Keys.Shift) MainForm.mainForm.AddImageContainerRange(imageData);
            else MainForm.mainForm.SelectSingleImageContainer(imageData);
            MainForm.mainForm.subform_Click(imageData);
        }

        public void LoadImage(ImageData image)
        {
            imageData = image;
            pictureBox.Image = image.thumbnail;
            label1.Text = image.imageName;
        }

        private void openWithDefaultViewer(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(imageData.path) { UseShellExecute = true });
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.mainForm.UpdateTagColors();
        }

        public void Rename(string newName)
        {
            label1.Text = newName;
        }
    }
}
