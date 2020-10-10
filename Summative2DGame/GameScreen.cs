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
    public partial class GameScreen : UserControl
    {
        public static List<Alien> alien1 = new List<Alien>();
        public static List<Bullet> bulletList = new List<Bullet>();

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);
        SolidBrush bulletBrush = new SolidBrush(Color.OrangeRed);
        SolidBrush alienBrush = new SolidBrush(Color.White);

        //sounds
        SoundPlayer laser = new SoundPlayer(Properties.Resources.laserShot);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.DieSound);

        //key press booleans
        Boolean leftArrowDown, rightArrowDown, SpaceKeyDown;

        //creating player
        Player hero;

        //player configurations
        int playerSize = 20;
        int playerSpeed = 10;

        //bullet configurations
        int bulletSize = 15;
        int bulletSpeed = 20;

        //alien configurations;
        int alienSpeed = 4;
        int spawnPoint = 60;
        int alienSize;

        //timer
        int counter = 30;
        int timer = 0;
        int shotCounter = 21;
        int spawnTimer = 0;
        Random randNum = new Random();
        public GameScreen()
        {
            InitializeComponent();
            outputLabel.Visible = false;
            gameOverLabel.Visible = false;
            OnStart();

 
        }
        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    SpaceKeyDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Space:
                    SpaceKeyDown = false;
                    break;
            }
        }
        public void MakeAlien()
        {
            //get colour for box
            int spawnX1 = randNum.Next(0, this.Width - 10);
            alienSize = randNum.Next(15, 30);
            int rand = randNum.Next(1, 6);
            Color c = Color.White;

            if (rand == 1) { c = Color.White; }
            else if (rand == 2) { c = Color.WhiteSmoke; }
            else if (rand == 3) { c = Color.Gray; }
            else if (rand == 4) { c = Color.DimGray; }
            else if (rand == 5) { c = Color.GhostWhite; }

            Alien alienN1 = new Alien(spawnX1, 0, alienSize, c);
            alien1.Add(alienN1);
        }
        public void MakeBullet()
        {
            Bullet bullet = new Bullet(hero.x + 5, hero.y - 10, bulletSize);
            bulletList.Add(bullet);
        }
        public void OnStart()
        {
            Refresh();
            alien1.Clear();
            bulletList.Clear();
            outputLabel.Visible = true;
            gameOverLabel.Visible = false;
            game_Tick.Enabled = true;
            MakeAlien();
            hero = new Player(this.Width / 2 - 15, this.Height - 30, playerSize);
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            shotCounter++;
            spawnTimer++;

            AlienBulletCollision();

            //countdown display
            outputLabel.Text = "" + counter;

            #region Countdown 
            if (timer > 50)
            {
                counter--;
                timer = 0;
            }

            if (counter == 0)
            {
                outputLabel.Text = "0";
                GameWin();
            }
            else if (counter < 25)
            {
                spawnPoint = 40;
            }
            else if (counter < 15)
            {
                spawnPoint = 30;
                playerSpeed = 15;
            }
            #endregion

            #region Move Alien
            foreach (Alien a in alien1)
            {
                a.MoveAlien(alienSpeed);
            }
            #endregion

            #region Spawn Alien

            if (spawnTimer > spawnPoint)
            {
                MakeAlien();
                spawnTimer = 0;
            }
            #endregion

            #region Moving player
            if (leftArrowDown == true && hero.x > 0)
            {
                hero.Move(playerSpeed, false);
            }
            else if (rightArrowDown == true && hero.x < this.Width - playerSize)
            {
                hero.Move(playerSpeed, true);
            }
            #endregion

            #region shooting
            if (SpaceKeyDown == true && shotCounter > 10)
            {
                shotCounter = 0;
                MakeBullet();
                laser.Play();
            }

            foreach (Bullet b in bulletList) 
            {
                b.MoveBullet(bulletSpeed); 
            }

            #endregion

            #region Game Over
            foreach (Alien a in alien1) 
            { 
                if (a.y > 470) 
                { GameOver(); }
            } 

            #endregion

            Refresh();
        }
        public void GameWin()
        {
            game_Tick.Enabled = false;

            outputLabel.Visible = false;
            gameOverLabel.Visible = true;
            gameOverLabel.Text = "You Win! Returning to main menu";
            gameOverLabel.Refresh();

            Thread.Sleep(2000);

            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);

        }
        public static void AlienBulletCollision()
        {
            List<int> bulletRemove = new List<int>();
            List<int> alienRemove = new List<int>();
            foreach (Bullet b in bulletList)
            {
                foreach (Alien a in alien1)
                {
                    if (a.Collision(b))
                    {
                        if (!bulletRemove.Contains(bulletList.IndexOf(b)))
                        {
                            bulletRemove.Add(bulletList.IndexOf(b));
                        }
                        if (!alienRemove.Contains(alien1.IndexOf(a)))
                        {
                            alienRemove.Add(alien1.IndexOf(a));
                        }
                    }
                }
            }
            bulletRemove.Reverse();
            alienRemove.Reverse();
            foreach (int i in bulletRemove)
            {
                bulletList.RemoveAt(i);
            }
            foreach (int i in alienRemove)
            {
                alien1.RemoveAt(i);
            }
        }
        public void GameOver()
        {
            game_Tick.Enabled = false;

            lose.Play();
            outputLabel.Visible = false;
            gameOverLabel.Visible = true;
            gameOverLabel.Text = "Game over, returning to main menu.";
            gameOverLabel.Refresh();

            Thread.Sleep(3000);

            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);

        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw alien
            foreach (Alien a in alien1)
            {
                alienBrush.Color = a.color;
                e.Graphics.FillEllipse(alienBrush, a.x, a.y, a.size, a.size);
            }
            //draw ground
            e.Graphics.FillRectangle(whiteBrush, 0, this.Height - 15, this.Width, this.Height);

            //drawhero
            e.Graphics.FillRectangle(whiteBrush, hero.x, hero.y, hero.size, hero.size);

            foreach (Bullet b in bulletList)
            { e.Graphics.FillEllipse(bulletBrush, b.x, b.y, bulletSize, bulletSize); }

        }
    }
}
