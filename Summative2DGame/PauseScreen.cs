using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summative2DGame
{
    public partial class PauseScreen : UserControl
    {
        Color labelColor = Color.FromArgb(100, Color.Black);

        //pause button boolean
        Boolean PKeyDown;
        public PauseScreen()
        {
            coverLabel.BackColor = labelColor;
            InitializeComponent();
        }

        private void PauseScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    PKeyDown = true;
                    break;
            }
        }

        private void PauseScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.P:
                    PKeyDown = false;
                    break;
            }
        }
    }
}
