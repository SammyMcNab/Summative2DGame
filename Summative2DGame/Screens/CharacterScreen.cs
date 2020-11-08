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
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            shipSelect = 2;
        }

        private void playButton_Click(object sender, EventArgs e)
        {

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
            greenButton.BackColor = Color.White;
            greenButton.ForeColor = Color.Black;

            purpleButton.BackColor = Color.Black;
            purpleButton.ForeColor = Color.White;

            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;

        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            playButton.BackColor = Color.White;
            playButton.ForeColor = Color.Black;

            purpleButton.BackColor = Color.Black;
            purpleButton.ForeColor = Color.White;

            greenButton.BackColor = Color.Black;
            greenButton.ForeColor = Color.White;
        }
    }
}
