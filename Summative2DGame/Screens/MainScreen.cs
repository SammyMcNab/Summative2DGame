using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Summative2DGame
{
    public partial class MainScreen : UserControl
    {
        //List to track stars on screeen
        List<ShootingStar> starTop = new List<ShootingStar>();
        List<ShootingStar> starSide = new List<ShootingStar>();

        //boolean for theme music 
        //Boolean themePlay = true;

        //brush for asteroid colour
        SolidBrush whiteBrush = new SolidBrush(Color.Snow);
        Random randNum = new Random();

        //sound player for music
        SoundPlayer theme = new SoundPlayer(Properties.Resources.MenuTheme);
        SoundPlayer buttonSwitch = new SoundPlayer(Properties.Resources.ButtonSwitch);

        public MainScreen()
        {
            InitializeComponent();
            theme.PlayLooping();
            MakeStar();
        }
        private void MakeStar()
        {
            int topX = randNum.Next(this.Width / 2 - 250, this.Width);
            int rightY = randNum.Next(0, this.Height - 70);
            int starSize = randNum.Next(5, 10);

            ShootingStar topStar = new ShootingStar(topX, 0, starSize);
            starTop.Add(topStar);

            ShootingStar sideStar = new ShootingStar(this.Width, rightY, starSize);
            starSide.Add(sideStar);
        }
        private void star_Timer_Tick(object sender, EventArgs e)
        {
            //update position of shooting star falling down
            foreach (ShootingStar s in starTop) { s.MoveStar(15); }
            foreach (ShootingStar s in starSide) { s.MoveStar(15); }

            if (starTop[0].y > this.Height)
            {
                starTop.RemoveAt(0);
                starSide.RemoveAt(0);
            }

            if (starTop[starTop.Count - 1].y > 80)
            {
                MakeStar();
            }

            if (starSide[starSide.Count - 1].y > 80)
            {
                MakeStar();
            }
            Refresh();
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw shooting star falling from top 
            foreach (ShootingStar ss in starTop) { e.Graphics.FillEllipse(whiteBrush, ss.x, ss.y, ss.size, ss.size); }
            //draw shooting star from side
            foreach (ShootingStar ss in starSide) { e.Graphics.FillEllipse(whiteBrush, ss.x, ss.y, ss.size, ss.size); }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            theme.Stop();
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CharacterScreen cs = new CharacterScreen();
            cs.Location = new Point((f.Width - cs.Width) / 2, (f.Height - cs.Height) / 2);
            f.Controls.Add(cs);
            cs.Focus();
        }

        private void playButton_Enter(object sender, EventArgs e)
        {
            buttonSwitch.Play();
            playButton.BackColor = Color.White;
            playButton.ForeColor = Color.Black;

            helpButton.BackColor = Color.Black;
            helpButton.ForeColor = Color.White;

            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
        }

        private void helpButton_Enter(object sender, EventArgs e)
        {
            buttonSwitch.Play();
            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;

            helpButton.BackColor = Color.White;
            helpButton.ForeColor = Color.Black;

            exitButton.BackColor = Color.Black;
            exitButton.ForeColor = Color.White;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            buttonSwitch.Play();
            playButton.BackColor = Color.Black;
            playButton.ForeColor = Color.White;

            helpButton.BackColor = Color.Black;
            helpButton.ForeColor = Color.White;

            exitButton.BackColor = Color.White;
            exitButton.ForeColor = Color.Black;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            Form form = this.FindForm();
            this.Location = new Point((form.Width - this.Width) / 2, (form.Height - this.Height) / 2);
        }
    }
}
