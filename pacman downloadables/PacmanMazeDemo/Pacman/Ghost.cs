﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pacman
{
    /* This is the child class of “Character” that contains the drawing of the ghost 
     * sprite onto the form, the ghost sprite movement and its functionality of how it 
     * interacts with other object aspects. The sprite image variation 
     * is displayed as the timer ticks.
     */
    public class Ghost : Character
    {
        private bool ghostfacingright;
        private Random random;

        public Ghost(List<Bitmap> sprites, Maze maze, Point position)
            : base(sprites, maze, position)
        {
            this.maze = maze;
            this.position = position;
            this.sprites = sprites;
            sprite = sprites[0];

            ghostfacingright = false;
            random = new Random();
            
        }

        public override void Draw()
        {
            //.Rows gets a collection that contains all the rows in that substring (aka data grid view). 
            //.Cells gets all the cell of the Rows Y position.
            //We look for the value of the Y position in that row then the X position in that cell within that row giving us the point at which 
            //we draw the bitmap image onto the map
            maze.Rows[position.Y].Cells[position.X].Value = sprite;
        }

        //Moving the character (either pacman or the ghost) to the next grid section if it does not contain a wall. Essentially it is a check wall method
        public override void Move()
        {
            //makes a random number between 0 and 3, this then chooses a case and inputs the a movement that is random into the sprite animation
            int randomnum = random.Next(4);

            switch (randomnum)
            {
                case 0:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X - 1, 1) != "w") 
                    {
                        position = new Point(position.X - 1, position.Y);
                    }
                    break;
                case 1:
                    if (maze.Map.Substring((position.Y * GRIDLINESIZE) + position.X + 1, 1) != "w")
                    {
                        position = new Point(position.X + 1, position.Y);
                    }
                    break;
                case 2:
                    if (maze.Map.Substring(((position.Y - 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point(position.X, position.Y - 1);
                    }
                    break;
                case 3:
                    if (maze.Map.Substring(((position.Y + 1) * GRIDLINESIZE) + position.X, 1) != "w")
                    {
                        position = new Point(position.X, position.Y + 1);
                    }
                    break;
            }
        }

        //variations in the sprite image change each timer tick, so it looks like the ghost 
        //is moving his eyes each movement, back and forth.
        public void animateddirection()
        {
            if (ghostfacingright == true)
            {
                sprite = sprites[0];
            }
            else if (ghostfacingright == false)
            {
                sprite = sprites[1];
            }
            ghostfacingright = !ghostfacingright;
        }
        public Point Position { get => position; set => position = value; }
    }
}
