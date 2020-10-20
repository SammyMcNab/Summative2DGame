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
 
        //pause button boolean
        Boolean PKeyDown;
        public PauseScreen()
        {
            coverLabel.BackColor = System.Drawing.Color.FromArgb(160,Color.Black);
            InitializeComponent();
            if(PKeyDown)
            { SwitchScreens(); }
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
        public void SwitchScreens()
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
        }
    }
}
