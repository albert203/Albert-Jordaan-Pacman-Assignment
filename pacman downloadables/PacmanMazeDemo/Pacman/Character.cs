using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    /*This is the parent class of the “Pacman” class and the “Ghost” class. 
     *The parent class contains methods such as the Draw() method, 
     *that draws the sprite image onto a specific grid on the form, 
     *and the Move() method that  are used between the  between the 
     *child classes to share similar class methods.
     */
    public abstract class Character
    {
        //fields
        protected List<Bitmap> sprites;
        protected Bitmap sprite;
        protected Bitmap currentsprite;
        protected Maze maze;
        protected Point position;
        protected Enumdir direction;

        //constants
        protected const int GRIDLINESIZE = 20;
        
        public Character(List<Bitmap> sprites, Maze maze, Point position)
        {
            //constructor
            this.maze = maze;
            this.position = position;
            this.sprites = sprites;
            sprite = sprites[0];

            direction = Enumdir.Up;
        }

        //methods
        public abstract void Draw();
        public abstract void Move();
       
        public Enumdir Direction { get => direction; set => direction = value; }
    }
}
