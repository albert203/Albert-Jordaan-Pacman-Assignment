using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
    /* The class where everything that involves the sprite Pacman and its functionality is kept. 
     * This functionality includes the sprites movement throughout the maze including wall 
     * collision, the sprites different animation states 
     * according to the users input by arrow key, 
     * how Pacman’s movement effects the map as he moves 
     * (aka eats kibble and other entities and leaves the map square blank afterwards). 
     * It also is draw Pacman onto the form from a specified location. */
    public class Pacman : Character
    {
        //fields
        private int life;
        private bool pacopen;

        public Pacman(List<Bitmap> sprites, Maze maze, Point position)
            : base(sprites, maze, position)
        {
            //constructor
            this.maze = maze;
            this.position = position;
            this.sprites = sprites;
            sprite = sprites[0];

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


        public override void Draw()
        {
            //.Rows gets a collection that contains all the rows in that substring (aka data grid view). 
            //.Cells gets all the cell of the Rows Y position.
            //We look for the value of the Y position in that row then the X position in that cell within that row giving us the point at which 
            //we draw the bitmap image onto the map
            maze.Rows[position.Y].Cells[position.X].Value = sprite;
        }


        public void animateddirection()
        {
            switch (direction)
            {
                case Enumdir.Right:
                    {
                        if (pacopen == true)
                        {
                            sprite = sprites[0];
                        }
                        else if (pacopen == false)
                        {
                            sprite = sprites[1];
                        }
                    }
                    break;

                case Enumdir.Left:
                    {
                        if (pacopen == true)
                        {
                            sprite = sprites[2];
                        }
                        else if (pacopen == false)
                        {
                            sprite = sprites[3];
                        }
                    }
                    break;

                case Enumdir.Up:
                    {
                        if (pacopen == true)
                        {
                            sprite = sprites[4];
                        }
                        else if (pacopen == false)
                        {
                            sprite = sprites[5];
                        }

                    }
                    break;

                case Enumdir.Down:
                    {
                        if (pacopen == true)
                        {
                            sprite = sprites[6];
                        }
                        else if (pacopen == false)
                        {
                            sprite = sprites[7];
                        }

                    }
                    break;
            }
            pacopen = !pacopen;
        }

        public override void Move()
        {
            //Moving the character (either pacman or the ghost) to the next grid section if it does not contain a wall. Essentially it is a check wall method
            switch (direction)
            {
                case Enumdir.Left:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X - 1, 1) != "w")
                    {
                        position = new Point(position.X - 1, position.Y);
                    }
                    break;
                case Enumdir.Right:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X + 1, 1) != "w")
                    {
                        position = new Point(position.X + 1, position.Y);
                    }
                    break;
                case Enumdir.Up:
                    if (maze.Map.Substring(((position.Y - 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point(position.X, position.Y - 1);
                    }
                    break;
                case Enumdir.Down:
                    if (maze.Map.Substring(((position.Y + 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point(position.X, position.Y + 1);
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




