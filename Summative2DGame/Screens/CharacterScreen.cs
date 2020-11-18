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
    public partial class CharacterScreen : UserControl
    {
        public static int shipSelect;
        public CharacterScreen()
        {
            InitializeComponent();
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            shipSelect = 1;
            purpleButton.BackColor = Color.Red;
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            shipSelect = 2;
            greenButton.BackColor = Color.Red;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (shipSelect > 0)
            {
                Form f = this.FindForm();
                f.Controls.Remove(this);

                GameScreen gs = new GameScreen();

                f.Controls.Add(gs);
                gs.Focus();
            }
            else { }
        }

        private void purpleButton_Enter(object sender, EventArgs e)
        {

            greenButton.BackColor = Color.Black;
            greenButton.ForeColor = Color.White;

            purpleButton.BackColor = Color.White;
            purpleButton.ForeColor = Color.Black;

            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;
        }

        private void greenButton_Enter(object sender, EventArgs e)
        {


            greenButton.BackColor = Color.Black;
            greenButton.ForeColor = Color.White;

            purpleButton.BackColor = Color.White;
            purpleButton.ForeColor = Color.Black;

            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;

        }

        private void playButton_Enter(object sender, EventArgs e)
        {

            greenButton.BackColor = Color.Black;
            greenButton.ForeColor = Color.White;

            purpleButton.BackColor = Color.White;
            purpleButton.ForeColor = Color.Black;

            greenButton.BackColor = Color.Black;
            greenButton.ForeColor = Color.White;
        }
    }
}
