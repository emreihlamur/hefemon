﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hefemon
{
    public partial class Hefemon : Form
    {
        int timerTickForSeconds = -1;
        Player player = Player.Blue;

        Image currentPlayerDotColor;
        Image whiteDot = hefemon.Properties.Resources.white;
        Image redDot = hefemon.Properties.Resources.red;
        Image blueDot = hefemon.Properties.Resources.blue;

        Image leftArrow = hefemon.Properties.Resources.arrow_left;
        Image rightArrow = hefemon.Properties.Resources.arrow_right;

        enum Player
        {
            Red,
            Blue
        }

        void defineWhoPlaysFirst()
        {
            Random random = new Random();
            int randomNumber = random.Next(2);

            if (randomNumber == 0)
            {
                timerTickForSeconds = 13;
                player = Player.Red;
                arrow.Image = leftArrow;
                currentPlayerDotColor = redDot;

            } else {
                timerTickForSeconds = 12;
                player = Player.Blue;
                arrow.Image = rightArrow;
                currentPlayerDotColor = blueDot;
            }

        }

        void changeCurrentPlayer()
        {
            if (player == Player.Red)
            {
                player = Player.Blue;
                currentPlayerDotColor = blueDot;
                arrow.Image = rightArrow;
            }
            else
            {
                player = Player.Red;
                currentPlayerDotColor = redDot;
                arrow.Image = leftArrow;
            }

        }

        void clearGameTable()
        {
            PictureBox[] dots = { dot1, dot2, dot3, dot4, dot5, dot6, dot7,dot8,dot9, dot10,dot11,dot12, dot13, dot14, dot15, dot16, dot17, dot18, dot19,
                                    dot20, dot21, dot22, dot23, dot24, dot25, dot26, dot27, dot28, dot29, dot30, dot31, dot32, dot33, dot34, dot35, dot36,
                                    dot37, dot38, dot39, dot40, dot41, dot42};
           
            for (int i = 0; i < 42; i++)
            {
                int mode = i % 7;

                dots[i].Image = whiteDot;
                dots[i].Click += dotClicked;
            }

        }

        void startGame()
        {
            clearGameTable();
            defineWhoPlaysFirst();
            defineWhoPlaysFirstTimer.Interval = 100;
            defineWhoPlaysFirstTimer.Start();
        }

        private void dotClicked(object sender, EventArgs e)
        {
            PictureBox clickedOne = sender as PictureBox;

            if (clickedOne.Image == whiteDot)
            {
                putDot(clickedOne);
            }

        } 

        void putDot(PictureBox clickedOne)
        {
            
            PictureBox[,] dots = new PictureBox[7, 6]{
                                { dot1, dot8, dot15, dot22, dot29, dot36 },
                                { dot2, dot9, dot16, dot23, dot30, dot37 },
                                { dot3, dot10, dot17, dot24, dot31, dot38 },
                                { dot4, dot11, dot18, dot25, dot32, dot39 },
                                { dot5, dot12, dot19, dot26, dot33, dot40 },
                                { dot6, dot13, dot20, dot27, dot34, dot41 },
                                { dot7, dot14, dot21, dot28, dot35, dot42 }
                            };

            bool hasFoundPlaceToPut = false;
            int tryIndex = 0;
            int row = Convert.ToInt32(clickedOne.Tag);
            int puttedIndex = 0;

            while (!hasFoundPlaceToPut)
            {
                if (dots[row, tryIndex].Image == whiteDot) {
                    dots[row, tryIndex].Image = currentPlayerDotColor;
                    hasFoundPlaceToPut = true;
                    puttedIndex = tryIndex;
                    changeCurrentPlayer();
                }
                else
                {
                    tryIndex++;
                }
            }
        }

        public Hefemon()
        {
            InitializeComponent();
            startGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Hefemon_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void yeniOyunBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void defineWhoPlaysFirstTimer_Tick(object sender, EventArgs e)
        {
            timerTickForSeconds--;

            if (timerTickForSeconds != 0)
            {
                if (timerTickForSeconds % 2 == 0) {
                    arrow.Image = leftArrow;
                }
                else
                {
                    arrow.Image = rightArrow;
                }
            }
            else
            {
                if (player == Player.Red)
                {
                    arrow.Image = leftArrow;
                }
                else
                {
                    arrow.Image = rightArrow;
                }
                defineWhoPlaysFirstTimer.Stop();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
