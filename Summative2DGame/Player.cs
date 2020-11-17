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
        public int x, y, width, height, speed, startY, startX;
        public Boolean playerDirection;

        public Image image;
        //player configurations
        public static int playerWidth = 40;
        public static int playerHeight = 100;
        public static int playerSpeed = 15;

        public Player(int _x, int _y, int _width, int _height,  Image _image)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            image = _image;
            startX = _x;
            startY = _y;
        }
        public void Move(string direction)
        {
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
