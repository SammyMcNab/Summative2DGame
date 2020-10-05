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

        List<Alien> alien1 = new List<Alien>();
        List<Bullet> bulletList = new List<Bullet>();
        Font waveFont = new Font("MS Gothic", 20);
        //brushes
        SolidBrush maroonBrush = new SolidBrush(Color.Maroon);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush bulletBrush = new SolidBrush(Color.Yellow);
        SolidBrush playerBrush = new SolidBrush(Color.Red);
        SolidBrush alienBrush = new SolidBrush(Color.White);

        SoundPlayer siren = new SoundPlayer(Properties.Resources.waveStart);
        SoundPlayer laser = new SoundPlayer(Properties.Resources.laserShot);

        Boolean waveOn = false;
        Boolean gameOver = false;
        Boolean leftArrowDown, rightArrowDown, SpaceKeyDown, right, shot;

        Player hero;

        //player configurations
        int heroSize = 20;
        int playerSpeed = 20;

        //bullet configurations
        int bulletSize = 10;
        int bulletSpeed = 15;

        //alien configurations;
        int alienSize;
        int alienSpeed = 3;
        int spawnPoint = 260;

        //timer
        int counter = 90;
        int timer = 0;

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
            int spawnX1 = randNum.Next(0, this.Width);
            int alienSize = randNum.Next(10, 20);
            int rand = randNum.Next(1, 6);
            Color c = Color.White;

            if (rand == 1) { c = Color.Red; }
            else if (rand == 2) { c = Color.WhiteSmoke; }
            else if (rand == 3) { c = Color.Gray; }
            else if (rand == 4) { c = Color.DimGray; }
            else if (rand == 5) { c = Color.Maroon; }

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
            outputLabel.Visible = true;
            MakeAlien();
            hero = new Player(this.Width / 2 - 15, this.Height - 30, heroSize);
        }
        //public void AlienBulletCollision()
        //{
        //    List<int> bulletRemove = new List<int>();
        //    List<int> alienRemove = new List<int>();
        //    foreach (Bullet b in bulletList)
        //    { 
        //        foreach (Alien a in alien1) { if (a.Collision(b)) } 
        //    }
        //}

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //stopping gameplay from starting until wave start message displays
            if (waveOn)
            {
                timer++;
                #region Countdown 
                if (timer > 50)
                {
                    counter--;
                    timer = 0;
                }
                outputLabel.Text = "" + counter;

                if (counter == 0)
                {
                    game_Tick.Enabled = false;
                }
                else if (counter < 60)
                { spawnPoint = 80; }
                #endregion

                foreach (Alien a in alien1) { a.MoveAlien(alienSpeed); }

                if (alien1[0].y > 482) { alien1.RemoveAt(0); }

                if (alien1[alien1.Count - 1].y > spawnPoint) { MakeAlien(); }

                #region Moving player
                if (leftArrowDown == true)
                {
                    hero.Move(playerSpeed, "left");
                }
                else if (rightArrowDown == true)
                {
                    hero.Move(playerSpeed, "right");
                }
                #endregion

                #region shooting
                if (SpaceKeyDown == true)
                {
                    MakeBullet();
                    laser.Play();
                }

                foreach (Bullet b in bulletList) { b.MoveBullet(10); }

                #endregion

                //#region Game Over
                //if (alien1[0].y > 467) { GameOver(); }
                //#endregion

            }
            else
            {

            }
            Refresh();
        }
        public void GameOver()
        {
            waveOn = false;
            gameOver = true;
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (waveOn)
            {
                //draw alien
                foreach (Alien a in alien1)
                {
                    alienBrush.Color = a.color;
                    e.Graphics.FillEllipse(alienBrush, a.x, a.y, a.size, a.size);
                }
                //draw ground
                e.Graphics.FillRectangle(greenBrush, 0, this.Height - 15, this.Width, this.Height);

                //drawhero
                e.Graphics.FillRectangle(playerBrush, hero.x, hero.y, hero.size, hero.size);

                if (SpaceKeyDown == true)
                {
                    foreach (Bullet b in bulletList)
                    { e.Graphics.FillEllipse(bulletBrush, b.x, b.y, bulletSize, bulletSize); }
                }
            }
            else if (gameOver)
            {
                outputLabel.Visible = false;
                gameOverLabel.Visible = true;
                gameOverLabel.Text = "Game over, returning to main menu.";
                Thread.Sleep(4000);
                Form f = this.FindForm();
                f.Controls.Remove(this);
                MainScreen ms = new MainScreen();
                f.Controls.Add(ms);
            }
            else if (gameOver == false)
            {
                siren.Play();
                waveOn = true;
            }
        }
    }
}
