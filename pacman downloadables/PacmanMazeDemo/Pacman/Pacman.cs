using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pacman
{
    public class Pacman: Character
    {
        //fields
        protected List<Bitmap> sprites;
        protected Maze maze;
        private int direction;
        private Point position;
        protected Bitmap pacsprite;

        private int life = 3;
        private int top = 0, left = 0, next, temp = 1;


        public Pacman(List<Bitmap> sprites, Maze maze, Point position) : base()
        {
            //constructor
            this.sprites = sprites;
            this.maze = maze;

        }

        public void lives()
        {
            if (life == 0)
            {
                //pause for 2 seconds after losing the game.
                Thread.Sleep(2000);
                //endgame();
            }
        }

        public void Move()
        {

        }

        public void Eatpellets()
        {

        }

        public void animatedirection()
        {

            pacsprite = Properties.Resources.Pacman1;

            switch (direction)
            {
                case 1:
                    if (next == 2)
                    {
                        left = 2;
                        pacsprite = Properties.Resources.pacman1left;
                        direction = next;
                        temp = next;
                    }
                    break;

                case 2:
                    if (next == 1)
                    {
                        left = -2;
                        pacsprite = Properties.Resources.pacman1right;
                        direction = next;
                        temp = next;
                    }
                    break;

                case 3:
                    if (next == 4)
                    {
                        top = 2;
                        pacsprite = Properties.Resources.pacman1down;
                        direction = next;
                        temp = next;
                    }
                    break;

                case 4:
                    if (next == 3)
                    {
                        top = -2;
                        pacsprite = Properties.Resources.pacman1up;
                        direction = next;
                        temp = next;
                    }
                    break;
            }
        }
        //public void collision()
        //{
        //    if (pacman.Bounds.IntersectsWith(ghost1.Bounds) || pacman.Bounds.IntersectsWith(ghost2.Bounds) || pacman.Bounds.IntersectsWith(ghost3.Bounds) || pacman.Bounds.IntersectsWith(ghost4.Bounds))
        //    {
        //        if (pacman.Bounds.IntersectsWith(ghost1.Bounds) && !power1)
        //        {
        //            eat();
        //        }

        //        if (pacman.Bounds.IntersectsWith(ghost2.Bounds) && !power2)
        //        {
        //            eat();
        //        }

        //        if (pacman.Bounds.IntersectsWith(ghost3.Bounds) && !power3)
        //        {
        //            eat();
        //        }

        //        if (pacman.Bounds.IntersectsWith(ghost4.Bounds) && !power4)
        //        {
        //            eat();
        //        }

        //        if (power)
        //        {
        //            if (pacman.Bounds.IntersectsWith(ghost1.Bounds) && !power1)
        //            {
        //                eat();
        //            }

        //            if (pacman.Bounds.IntersectsWith(ghost2.Bounds) && !power2)
        //            {
        //                eat();
        //            }

        //            if (pacman.Bounds.IntersectsWith(ghost3.Bounds) && !power3)
        //            {
        //                eat();
        //            }

        //            if (pacman.Bounds.IntersectsWith(ghost4.Bounds) && !power4)
        //            {
        //                eat();
        //            }
        //        }

    }  
}
