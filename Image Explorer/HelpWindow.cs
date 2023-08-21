using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Explorer
{
    public partial class HelpWindow : Form
    {
        private static HelpWindow? _window = null;

        public static HelpWindow Get()
        {
            if (_window == null)
                return _window = new HelpWindow();
            _window.Focus();
            return _window;
        }

        private HelpWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        private void HelpWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _window = null;
        }
    }
}
