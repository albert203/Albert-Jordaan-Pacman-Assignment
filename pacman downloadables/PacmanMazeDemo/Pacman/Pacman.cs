using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
    public class Pacman : Character
    {
        //fields
        private int life;
        private bool pacopen;

        public Pacman(List<Bitmap> sprites, Maze maze, Point position) : base(sprites, maze, position)
        {
            //constructor
            this.sprites = sprites;
            this.maze = maze;
            this.position = position;
            sprite = Properties.Resources.pacman1right;
            life = 3;
            pacopen = false;

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


        public bool Eatpellets()
        {
            bool eatpellets = false;

            if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X, 1) == "k")
            {
                StringBuilder stringgrid = new StringBuilder(maze.Map);
                char blankgrid = 'b';
                stringgrid[(position.Y * GRIDLINESIZE) + position.X] = blankgrid;
                maze.Map = stringgrid.ToString();
                eatpellets = true;
            }
            return eatpellets;
        }

        public void animateddirection()
        {
            switch (direction)
            {
                case Enumdir.Left:
                    {
                        sprite = Properties.Resources.ResourceManager.GetObject("pacman;
                    }
                    break;

                case Enumdir.Right:
                    {
                        sprite = Properties.Resources.pacman1right;
                    }
                    break;

                case Enumdir.Down:
                    {
                        sprite = Properties.Resources.pacman1up;
                    }
                    break;

                case Enumdir.Up:
                    {
                        sprite = Properties.Resources.pacman1down;
                    }
                    break;
            }

            switch (direction)
            {
                case Enumdir.Left:
                    {
                        sprite = Properties.Resources.pacman2right;
                    }
                    break;

                case Enumdir.Right:
                    {
                        sprite = Properties.Resources.pacman2left;
                    }
                    break;

                case Enumdir.Up:
                    {
                        sprite = Properties.Resources.pacman2up;
                    }
                    break;

                case Enumdir.Down:
                    {
                        sprite = Properties.Resources.pacman2down;
                    }
                    break;
            }
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




