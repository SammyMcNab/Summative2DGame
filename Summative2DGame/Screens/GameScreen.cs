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
using System.Timers;
using System.IO;

namespace Summative2DGame
{
    public partial class GameScreen : UserControl
    {
        //alien list
        public static List<Alien> alien1 = new List<Alien>();
        public static List<Alien> leftAlien = new List<Alien>();
        public static List<Alien> midAlien = new List<Alien>();
        public static List<Alien> rightAlien = new List<Alien>();
        public static List<Alien> rowONE = new List<Alien>();
        public static List<Alien> rowTWO = new List<Alien>();


        //All bullets 
        public static List<Bullet> bulletList = new List<Bullet>();
        public static List<Bullet> leftBulletList1 = new List<Bullet>();
        public static List<Bullet> leftBulletList2 = new List<Bullet>();
        public static List<Bullet> rightBulletList1 = new List<Bullet>();
        public static List<Bullet> rightBulletList2 = new List<Bullet>();
        public static List<Bullet> beamBullet = new List<Bullet>();
        public static List<Bullet> alienBullet = new List<Bullet>();

        //brushes
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush starBrush = new SolidBrush(Color.White);

        //sounds
        SoundPlayer laser = new SoundPlayer(Properties.Resources.laserShot);
        SoundPlayer lose = new SoundPlayer(Properties.Resources.DieSound);
        SoundPlayer buttonClick = new SoundPlayer(Properties.Resources.ButtonClick);

        //key press booleans
        Boolean leftArrowDown, rightArrowDown, downArrowDown, upArrowDown, spaceKeyDown, escKeyDown;

        //creating player
        Player hero;

        Image shipImage, alienImage, bulletImage;

        //alien specs
        int alienWidth, alienHeight, alienSpeed;

        //player specs
        int playerWidth, playerHeight, playerHealth;

        //bullet specs
        int bulletWidth, bulletHeight, bulletSpeed;


        int powerUp;

        int spawnPoint = 50;

        //timer
        int counter = 30;
        int shotCounter = 21;
        int spawnTimer = 0;
        Random randNum = new Random();
        public GameScreen()
        {
            buttonClick.Play();
            InitializeComponent();
            //outputLabel.Visible = false;
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
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
                case Keys.Escape:
                    escKeyDown = true;
                    Pause();
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
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
                case Keys.Escape:
                    escKeyDown = false;
                    break;
            }
        }
        public void MakeAlien()
        {
            //get colour for box
            int spawnX1 = randNum.Next(0, this.Width - 10);

            Alien alienN1 = new Alien(spawnX1, 0, alienWidth, alienHeight, alienImage);
            alien1.Add(alienN1);
        }
        public void AlienSideSpawn()
        {

            int spawnY1 = randNum.Next(5, this.Height - 380);

            Alien row1 = new Alien(0, spawnY1, alienWidth, alienHeight, alienImage);
        }
        public void MakeBullet()
        {
            Bullet bullet = new Bullet(hero.x + 30, hero.y - 10, bulletWidth, bulletHeight, bulletImage);
            bulletList.Add(bullet);
        }
        public void OnStart()
        {
            Refresh();
            alien1.Clear();
            bulletList.Clear();

            alienWidth = 60;
            alienHeight = 100;
            alienSpeed = 12;

            playerWidth = 80;
            playerHeight = 120;
            playerHealth = 3;

            bulletWidth = 15;
            bulletHeight = 15;
            bulletSpeed = 20;

            bulletImage = Properties.Resources.BasicBullet;

            gameOverLabel.Visible = false;
            gameTimer.Enabled = true;

            alienImage = Properties.Resources.Monster;

            if (CharacterScreen.shipSelect == 1)
            {
                shipImage = Properties.Resources.PurpleJetNeutral;
                powerUp = 1;
            }
            else
            {
                shipImage = Properties.Resources.GreenJetHoveringNeutral;
                powerUp = 2;
            }
            hero = new Player(this.Width / 2 - 15, this.Height - 360, playerWidth, playerHeight, shipImage);
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle shipRec = new Rectangle(hero.x, hero.y, hero.width, hero.height);

            shotCounter++;
            spawnTimer++;

            RegBulletCollision();

            #region Move Alien
            foreach (Alien a in alien1)
            {
                a.MoveAlien(alienSpeed);
            }
            #endregion

            #region Spawn Alien

            if (spawnTimer > spawnPoint)
            {
                //MakeAlien();
                spawnTimer = 0;
            }
            #endregion

            #region Moving player
            if (leftArrowDown == true && hero.x > 0)
            {
                hero.Move("left");
            }
            if (rightArrowDown == true && hero.x < this.Width - hero.width)
            {
                hero.Move("right");
            }
            if (upArrowDown == true && hero.y > 0)
            {
                hero.Move("up");
            }
            if (downArrowDown == true && hero.y < this.Height - hero.height)
            {
                hero.Move("down");
            }
            #endregion

            #region shooting
            if (spaceKeyDown == true && shotCounter > 10)
            {
                shotCounter = 0;
                MakeBullet();
            }

            //move bullet up 
            foreach (Bullet b in bulletList)
            {
                b.MoveBullet(bulletSpeed);
            }

            #endregion

            #region Game Over
            //change to if hero gets hit 3 times
            if (playerHealth < 1)
            {
                GameOver();
            }
            #endregion

            Refresh();
        }
        public void GameWin()
        {
            gameTimer.Enabled = false;

            //outputLabel.Visible = false;
            gameOverLabel.Visible = true;
            gameOverLabel.Text = "You Win! Returning to main menu";
            gameOverLabel.Refresh();

            Thread.Sleep(2000);

            Form f = this.FindForm();
            f.Controls.Remove(this);
            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);

        }
        public static void LaserBeamCollision()
        {

        }
        public static void MultiGunCollision()
        {

        }
        public static void RegBulletCollision()
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
        public void SideAlien()
        {

        }
        public void Pause()
        {
            if (gameTimer.Enabled == true)
            {

                gameTimer.Enabled = false;

                DialogResult dr = PauseForm.Show();

                if (dr == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (dr == DialogResult.Abort)
                {
                    Form form = this.FindForm();
                    MainScreen ms = new MainScreen();

                    form.Controls.Add(ms);
                    form.Controls.Remove(this);
                }
            }
        }
        public void GameOver()
        {
            gameTimer.Enabled = false;

            lose.Play();

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
                e.Graphics.DrawImage(a.image, a.x, a.y, a.width, a.height);
            }

            //draw UI line
            //e.Graphics.FillRectangle(starBrush, 0, this.Height - 80, this.Width, this.Height);

            //drawhero
            e.Graphics.DrawImage(hero.image, hero.x, hero.y, hero.width, hero.height);

            foreach (Bullet b in bulletList)
            {
                e.Graphics.DrawImage(b.image, b.x, b.y, b.width, b.height);
            }

        }
    }
}
