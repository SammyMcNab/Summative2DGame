using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Summative2DGame
{
    public class Bullet
    {
        public int speed, size, width, height, x, y;
        public static int bulletSize = 15;
        public static int bulletSpeed = 20;
        public Bullet(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }
        //public Bullet(int _x, int _y, int _width, int _height, int _speed)
        //{
        //    x = _x;
        //    y = _y;
        //    width = _width;
        //    height = _height;
        //    speed = _speed;
        //}
        public void MoveBullet(int speed)
        {
            y -= speed;
        }
    }
}
