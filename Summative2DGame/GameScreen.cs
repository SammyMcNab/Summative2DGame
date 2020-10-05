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

        //brushes
        SolidBrush whiteBrush = new SolidBrush(Color.WhiteSmoke);
        SolidBrush bulletBrush = new SolidBrush(Color.Yellow);
        SolidBrush alienBrush = new SolidBrush(Color.White);

        //sounds
        SoundPlayer siren = new SoundPlayer(Properties.Resources.waveStart);
        SoundPlayer laser = new SoundPlayer(Properties.Resources.laserShot);

        Boolean waveOn = false;
        Boolean gameOver = false;
        Boolean gameWin = false;
        Boolean leftArrowDown, rightArrowDown, SpaceKeyDown;

        Player hero;

        //player configurations
        int playerSize = 20;
        int playerSpeed = 15;

        //bullet configurations
        int bulletSize = 10;
        int bulletSpeed = 15;

        //alien configurations;
        int alienSpeed = 5;
        int spawnPoint = 100;

        //timer
        int counter = 10;
        int timer = 0;
        int shotCounter = 21;
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
            outputLabel.Visible = true;
            MakeAlien();
            hero = new Player(this.Width / 2 - 15, this.Height - 30, playerSize);
        }
        public void AlienBulletCollision()
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

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //stopping gameplay from starting until wave start message displays
            if (waveOn)
            {
                timer++;
                shotCounter++;

                AlienBulletCollision();

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
                else if (counter < 40)
                {
                    spawnPoint = 60;
                }
                else if (counter < 25)
                {
                    spawnPoint = 40;
                }
                #endregion

                foreach (Alien a in alien1) { a.MoveAlien(alienSpeed); }

                if (alien1[alien1.Count - 1].y > spawnPoint) { MakeAlien(); }

                if (alien1[0].y > 482) { alien1.RemoveAt(0); }

                #region Moving player
                if (leftArrowDown == true && hero.x > 0)
                {
                    hero.Move(playerSpeed, "left");
                }
                else if (rightArrowDown == true && hero.x < this.Width - playerSize)
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

                foreach (Bullet b in bulletList) { b.MoveBullet(bulletSpeed); }

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
        public void GameWin()
        {
            waveOn = false;
            gameOver = true;
            gameWin = true;
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
                e.Graphics.FillRectangle(whiteBrush, 0, this.Height - 15, this.Width, this.Height);

                //drawhero
                e.Graphics.FillRectangle(whiteBrush, hero.x, hero.y, hero.size, hero.size);

                foreach (Bullet b in bulletList)
                { e.Graphics.FillEllipse(bulletBrush, b.x, b.y, bulletSize, bulletSize); }

            }
            else if (gameOver && gameWin == false)
            {
                siren.Play();
                outputLabel.Visible = false;
                gameOverLabel.Visible = true;
                gameOverLabel.Text = "Game over, returning to main menu.";
                gameOverLabel.Refresh();
                Thread.Sleep(4000);
                Form f = this.FindForm();
                f.Controls.Remove(this);
                MainScreen ms = new MainScreen();
                f.Controls.Add(ms);
            }
            else if (gameOver && gameWin)
            {
                outputLabel.Visible = false;
                gameOverLabel.Visible = true;
                gameOverLabel.Text = "You Win! Returning to main menu";
                gameOverLabel.Refresh();
                Thread.Sleep(4000);
                Form f = this.FindForm();
                f.Controls.Remove(this);
                MainScreen ms = new MainScreen();
                f.Controls.Add(ms);
            }
            else if (gameOver == false)
            {
                waveOn = true;
            }
        }
    }
}
