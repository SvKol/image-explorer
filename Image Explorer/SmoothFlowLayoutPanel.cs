namespace Image_Explorer
{
    public class SmoothFlowLayoutPanel : FlowLayoutPanel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
}