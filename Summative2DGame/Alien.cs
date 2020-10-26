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
        public int size, x, y, width, height, speed;

        public Color color;

        public static int alienSpeed = 4;

        int alienSize;


        public Alien(int _x, int _y, int _size, Color _color, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            color = _color;
            speed = _speed;
        }
        public void MoveAlien(int speed)
        {
            y += speed;

        }
        public Boolean Collision(Bullet a)
        {
            Rectangle bullRec = new Rectangle(a.x, a.y, a.size, a.size);
            Rectangle alienRec = new Rectangle(x, y, size, size);

             return bullRec.IntersectsWith(alienRec);
        }
    }
}
