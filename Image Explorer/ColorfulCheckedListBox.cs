using System.ComponentModel;

namespace Image_Explorer
{
    public partial class ColorfulCheckedListBox : CheckedListBox
    {
        public List<Color> Colors = new List<Color>();

        public ColorfulCheckedListBox()
        {
            //DoubleBuffered = true;
            InitializeComponent();
        }

        public ColorfulCheckedListBox(IContainer container)
        {
            container.Add(this);
            //DoubleBuffered = true;
            InitializeComponent();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var eventArgs = new DrawItemEventArgs(
                e.Graphics,
                e.Font,
                e.Bounds,
                e.Index,
                DrawItemState.NoAccelerator|DrawItemState.NoFocusRect,
                Color.Black,
                (e.Index > -1 && e.Index < Colors.Count) ? Colors[e.Index] : e.BackColor);
            base.OnDrawItem(eventArgs);
        }
    }
}
