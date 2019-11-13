using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public abstract class Character
    {
        //fields
        protected const int GRIDLINESIZE = 20;
        protected List<Bitmap> sprites;
        protected Maze maze;
        protected Bitmap sprite;
        protected Keys direction;
        protected Point position;

        protected Character(List<Bitmap> sprites, Maze maze, Point position)
        {
            //constructor
            this.sprites = sprites;
            this.maze = maze;
            sprite = sprites[0];
            direction = Keys.Right;
            this.position = position;
        }

        //methods

        //Drawing the Bitmap sprite onto the form's maze
        public void Draw()
        {
            //.Rows gets a collection that contains all the rows in that substring (aka data grid view). 
            //.Cells gets a collection of cells that encompass that row.
            //We look for the value of the Y position in that row then the X position in that cell giving us the point at which 
            //we draw the bitmap image onto the map
            maze.Rows[position.Y].Cells[position.X].Value = sprite;
        }

        //Moving the character (either pacman or the ghost) to the next grid section if it does not contain a wall. Essentially it is a check wall method
        public void Move()
        {
            switch (direction)
            {
                case Keys.Left:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X - 1, 1) != "w")
                    {
                        position = new Point(position.X - 1, position.Y);
                    }
                    break;
                case Keys.Right:
                    if (maze.Map.Substring(position.Y * GRIDLINESIZE + position.X + 1, 1) != "w")
                    {
                        position = new Point((position.X + 1), position.Y);
                    }
                    break;
                case Keys.Up:
                    if (maze.Map.Substring(((position.Y - 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point((position.X), position.Y - 1);
                    }
                    break;
                case Keys.Down:
                    if (maze.Map.Substring(((position.Y + 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point((position.X), position.Y + 1);
                    }
                    break;
            }
        }
        public Keys Direction { get => direction; set => direction = value; }
        public Point Position { get => position; set => position = value; }
    }
}
