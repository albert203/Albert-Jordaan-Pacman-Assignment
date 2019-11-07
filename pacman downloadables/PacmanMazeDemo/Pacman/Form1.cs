using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        //fields
        private const int FORMHEIGHT = 800;
        private const int FORMWIDTH = 600;

        //declare the Maze object, random variable and in-form labels so it can be used throughout the form
        private Random random;
        private Maze maze;
        private List<object> labels;
        public Form1(List<object> labels, Maze maze)
        {
            
            InitializeComponent();

            //constuctor, intialising newly called components 
            labels = new List<object>();

            //adding a label from my list of labels
            for (int i = 0; i < 3; i++)
            {
                labels.Add(label[i]);
            }

            // set the Properties of the form:
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;

            // create a Bitmap object for each image you want to display
            Bitmap k = Properties.Resources.kibble;    
            Bitmap w = Properties.Resources.wall;
            Bitmap b = Properties.Resources.blank;

            // create an instance of a Maze:
            maze = new Maze(k, w, b);

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);

            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           maze.Draw();

           if (Pacman.Enabled)
            {
                direction();
                freedirection();
            }

            if (ghost1.Enabled || ghost2.Enabled || ghost3.Enabled || ghost4.Enabled)
            {
                ghost();
            }
            if (c) control();
            supermod();
            points();
            collision();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StartPosition = true;
            Lives();
            Points();
            panel1.visible = false;
            resetall();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) next = 1;
            if (e.KeyCode == Keys.Right) next = 2;
            if (e.KeyCode == Keys.Up) next = 3;
            if (e.KeyCode == Keys.Down) next = 4;
            if (e.KeyCode == Keys.Escape) Close();
            temp = GetNextControl;
        }
    }
}
