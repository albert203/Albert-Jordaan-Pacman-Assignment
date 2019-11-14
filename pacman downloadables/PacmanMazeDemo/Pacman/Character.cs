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
        //newpos
        protected Bitmap sprite;
        protected const int GRIDLINESIZE = 20;
        protected Maze maze;
        protected Enumdir direction;
        protected Point position;

        public Character(Bitmap sprite, Maze maze, Point position, Enumdir direction)
        {
            //constructor
            this.maze = maze;
            direction = Enumdir.Right;
            this.position = position;
            this.sprite = sprite;
        }

        //methods

        //Drawing the Bitmap sprite onto the form's maze
        public abstract void Draw();
        public abstract void Move();
       

        public Enumdir Direction { get => direction; set => direction = value; }
        
    }
}
