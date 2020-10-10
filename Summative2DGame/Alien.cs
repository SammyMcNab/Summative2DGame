using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Summative2DGame
{
    public class Alien
    {
        public int size, x, y, width, height;
        public Color color;
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
        }
        public Boolean Collision(Bullet a)
        {
            Rectangle bullRec = new Rectangle(a.x, a.y, a.size, a.size);
            Rectangle alienRec = new Rectangle(x, y, size, size);

             return bullRec.IntersectsWith(alienRec);
        }
    }
}
