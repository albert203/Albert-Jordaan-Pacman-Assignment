using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        //fields

        //constants
        private const int FORMHEIGHT = 540;
        private const int FORMWIDTH = 540;

        private int leftghost1, leftghost2, leftghost3, leftghost4, left;
        private int topghost1, topghost2, topghost3, topghost4, top;
        private int next, direction, temp = 1;

        

        private void label1_Click(object sender, EventArgs e)
        {
            //clicking on "play game" in the menu, this hides the menu panel and resets the game with a small delay to load into the new game
            panel1.Visible = false;
            Thread.Sleep(2000);

            label3.Visible = true;
            Thread.Sleep(1000);
            label3.Visible = false;

            label4.Visible = true;
            Thread.Sleep(1000);
            label4.Visible = false;

            label5.Visible = true;
            Thread.Sleep(1000);
            label5.Visible = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            //clicking on quit button in the menu
            Application.Exit();
        }

        private bool pacmanturn, ghost1turn, ghost2turn, ghost3turn, ghost4turn, start, ghost1caneat, ghost2caneat, ghost3caneat, ghost4caneat, g1eat, g2eat, g3eat, g4eat;
        private bool dir1, dir2, dir3, dir4, c, Supermod, Supermod1, Supermod2, Supermod3, Supermod4, v1, v2, v3, v4, tresec = true;
        private int random1, random2, random3, random4, tic4, tic5, tic6, point;


        //declare the Maze object, random variable and in-form labels so it can be used throughout the form
        private Pacman pacman;
        private Random random;
        private Maze maze;
        //private List<object> labels;

        public Form1()
        {
            //pacman = new Pacman(sprite, maze, position);
            InitializeComponent();

            //constuctor, intialising newly called components 
            //labels = new List<object>();

            //adding a label from my list of labels
            //for (int i = 0; i < 3; i++)
            //{
                //labels.add(label[i]);
            //}

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
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //pacman and ghosts begins game at start position
            //StartPosition = true;

            //Pacman.Lives();
            //Points();
            //panel1.visible = false;
            //resetall();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                next = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                next = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                next = 3;
            }
            if (e.KeyCode == Keys.Down)
            {
                next = 4;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            pacman.animatedirection();
            //temp = GetNextControl;
        }

        
    }
}
