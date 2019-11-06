using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class Pacman
    {
        //fields
        protected List<Bitmap> sprites;
        protected Maze maze;
        private Direction direction;
        private Point position;
        protected Bitmap sprite;

        public Pacman(List<Bitmap> sprites, Maze maze, Point position): base(icons, maze, position)
        {
            //constructor
            this.sprites = sprites;
            this.maze = maze;

        }

        public void Move()
        {

        }

        public void Eatpellets()
        {

        }

        public void Animatepacman()
        {

        }
    }
}
