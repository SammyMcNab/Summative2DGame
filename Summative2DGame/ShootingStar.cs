using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summative2DGame
{
    class ShootingStar
    {
        public int size, x, y;

        public ShootingStar(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
        public void MoveStar(int speed)
        {
            y += speed;
            x -= speed + 20;
        }
    }
}
