using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Summative2DGame
{
    public class Alien
    {
        public int size, x, y, width, height;
        public Color color;
        //public static Timer switchTimer;

        //Random rand = new Random();

        public Alien(int _x, int _y, int _size, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            color = _color;
        }
        public void MoveAlien(int speed)
        {
            y += speed;
            //int randNum = rand.Next(1, 5);
            //if(randNum == 1)
            //{
            //    switchTimer = new System.Timers.Timer();
            //    switchTimer.Interval = 2000;
            //    switchTimer.Enabled = true;
            //}
        }
        public Boolean Collision(Bullet a)
        {
            Rectangle bullRec = new Rectangle(a.x, a.y, a.size, a.size);
            Rectangle alienRec = new Rectangle(x, y, size, size);

             return bullRec.IntersectsWith(alienRec);
        }
    }
}
