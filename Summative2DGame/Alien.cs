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
            Rectangle alienRec = new Rectangle(a.x, a.y, a.size, a.size);
            Rectangle collisRec = new Rectangle(x, y, width, height);

            return alienRec.IntersectsWith(collisRec);
        }
        public static void AlienBulletCollision()
        {
            List<int> bulletRemove = new List<int>();
            List<int> alienRemove = new List<int>();
            foreach (Bullet b in GameScreen.bulletList)
            {
                foreach (Alien a in GameScreen.alien1)
                {
                    if (a.Collision(b))
                    {
                        if (!bulletRemove.Contains(GameScreen.bulletList.IndexOf(b)))
                        {
                            bulletRemove.Add(GameScreen.bulletList.IndexOf(b));
                        }
                        if (!alienRemove.Contains(GameScreen.alien1.IndexOf(a)))
                        {
                            alienRemove.Add(GameScreen.alien1.IndexOf(a));
                        }
                    }
                }
            }
            bulletRemove.Reverse();
            alienRemove.Reverse();
            foreach (int i in bulletRemove)
            {
                GameScreen.bulletList.RemoveAt(i);
            }
            foreach (int i in alienRemove)
            {
                GameScreen.alien1.RemoveAt(i);
            }
        }

    }
}
