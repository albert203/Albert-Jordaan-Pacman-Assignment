using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class Ghost : Character
    {
        private Bitmap Sprite;
         

        public Ghost(List<Bitmap> sprites, Maze maze, Point position, Enumdir direction)
            :base(sprites,maze, position)
        {
            
        }

        public override void Draw()
        {
            //.Rows gets a collection that contains all the rows in that substring (aka data grid view). 
            //.Cells gets all the cell of the Rows Y position.
            //We look for the value of the Y position in that row then the X position in that cell within that row giving us the point at which 
            //we draw the bitmap image onto the map
            maze.Rows[position.Y].Cells[position.X].Value = sprite;
        }
        public override void Move()
        {
            //Moving the character (either pacman or the ghost) to the next grid section if it does not contain a wall. Essentially it is a check wall method
            switch (direction)
            {
                case Enumdir.Left:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X - 1, 1) != "w")
                    {
                        position = new Point((position.X - 1), position.Y);
                    }
                    break;
                case Enumdir.Right:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X + 1, 1) != "w")
                    {
                        position = new Point((position.X + 1), position.Y);
                    }
                    break;
                case Enumdir.Up:
                    if (maze.Map.Substring(((position.Y - 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point((position.X), position.Y - 1);
                    }
                    break;
                case Enumdir.Down:
                    if (maze.Map.Substring(((position.Y + 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point((position.X), position.Y + 1);
                    }
                    break;
            }
        }
        public Point Position { get => position; set => position = value; }
    }
}
