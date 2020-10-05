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
        public int speed, size, x, y;
        public Bullet(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
        public void MoveBullet(int speed)
        {
            y -= speed;
        }
        public void AlienBulletCollision()
        { 
        
        }
    }
}
