using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Summative2DGame
{
    public class PowerUp
    {
        public int x, y, size;

        Image image;

        public PowerUp(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size;
        }
        public void MovePower(int speed)
        {
            y += speed;
        }
    }
}
