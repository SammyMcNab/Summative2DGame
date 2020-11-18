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

        public Image image;

        public Alien(int _x, int _y, int _width, int _height, Image _image)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            image = _image;
        }
        public void MoveAlien(int speed)
        {
            y += speed;
        }
        public void MoveAlienLeft(int speed)
        {
            x -= speed;
        }
        public void MoveAlienRight(int speed)
        {
            x += speed;
        }
        public Boolean Collision(Bullet a)
        {
            Rectangle bullRec = new Rectangle(a.x, a.y, a.size, a.size);
            Rectangle alienRec = new Rectangle(x, y, size, size);

             return bullRec.IntersectsWith(alienRec);
        }
    }
}
