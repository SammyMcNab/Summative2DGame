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
        public int width, height, x, y;

        public Image image;
        public Bullet(int _x, int _y, int _width, int _height, Image _image)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            image = _image;
        }
        public void MoveBullet(int speed)
        {
            y -= speed;
        }
        public void HomingBullet(int shipX, int shipY, int speed)
        {
            if (y > shipY)
            {
                y += speed;
            }
            else
            {
                y -= speed;
            }
            if (x > shipX)
            {
                x += speed;
            }
            else
            {
                x -= speed;
            }
        }
    }
}
