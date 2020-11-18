using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Summative2DGame
{
    public class Player
    {
        public int x, y, width, height;
        public Boolean playerDirection;

        public Image image;

        public Player(int _x, int _y, int _width, int _height,  Image _image)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            image = _image;
        }
        public void Move(string direction)
        {
            int playerSpeed = 12;
            switch (direction)
            {
                case "up":
                    y -= playerSpeed;
                    break;
                case "down":
                    y += playerSpeed;
                    break;
                case "right":
                    x += playerSpeed;
                    break;
                case "left":
                    x -= playerSpeed;
                    break;
            }
        }
        public void Power(string power)
        {
            switch (power)
            {
                case "Green":
                    break;
                case "Purple":
                    break;
            }
        }
    }
}
