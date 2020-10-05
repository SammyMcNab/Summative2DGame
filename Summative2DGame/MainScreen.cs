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
    public partial class MainScreen : UserControl
    {
        //List to track stars on screeen
        List<ShootingStar> starTop = new List<ShootingStar>();
        List<ShootingStar> starSide = new List<ShootingStar>();

        //brush for asteroid colour
        SolidBrush whiteBrush = new SolidBrush(Color.Snow);
        Random randNum = new Random();

        public MainScreen()
        {
            InitializeComponent();
            MakeStar();
        }
        private void MakeStar()
        {
            int topX = randNum.Next(this.Width / 2 - 250, this.Width);
            int rightY = randNum.Next(0, this.Height / 2 + 40);
            int starSize = randNum.Next(5,10);

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

            if (starTop[0].y > 482)
            {
                starTop.RemoveAt(0);
                starSide.RemoveAt(0);
            }

            if (starTop[starTop.Count - 1].y > 90)
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
            Form f = this.FindForm();
            f.Controls.Remove(this);
            // Create an instance of the LoadingScreen
            GameScreen gs = new GameScreen();
            // Add the User Control to the Form 
            f.Controls.Add(gs);
            gs.Focus();
        }
    }
}
