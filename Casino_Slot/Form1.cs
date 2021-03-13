using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino_Slot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //WIN, BET AND CREDIT
        int credits = 10000;
        int win = 0;
        int bet = 5;
        int lines = 5;
        SoundPlayer winSound;

        private void Form1_Load(object sender, EventArgs e)
        {
            winSound = new SoundPlayer(Properties.Resources._360739__mattix__coin_dropped_on_table_01);
            pic1.Image = Image.FromFile("1.png");
            pic1_2.Image = Image.FromFile("2.png");
            pic1_3.Image = Image.FromFile("3.png");
            pic1_4.Image = Image.FromFile("4.png");
            pic1_5.Image = Image.FromFile("5.png");
            pic2.Image = Image.FromFile("6.png");
            pic2_2.Image = Image.FromFile("7.png");
            pic2_3.Image = Image.FromFile("3.png");
            pic2_4.Image = Image.FromFile("1.png");
            pic2_5.Image = Image.FromFile("4.png");
            pic3.Image = Image.FromFile("6.png");
            pic3_2.Image = Image.FromFile("1.png");
            pic3_3.Image = Image.FromFile("5.png");
            pic3_4.Image = Image.FromFile("1.png");
            pic3_5.Image = Image.FromFile("7.png");
            label1.Text = $"Credits: {credits}";
            label2.Text = $"Bet: {bet}";
            label3.Text = $"Win: {win}";
            label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //SPIN BUTTON
        {
            if (credits >= bet*lines)
            {
                //PREAPAIRING GAME, PAYING FOR GAME
                credits -= bet * lines;
                int gameWon = 0;

                //NEW GAME INITIALISING
                Gamble game = new Gamble();

                //SET ICONS

                //1 LINE
                if (pic1.Image != null) //1 SLOT
                {
                    pic1.Image.Dispose();
                    pic1.Image = game.slots[0, 0].resultImage;
                }
                if (pic1_2.Image != null) //2 SLOT
                {
                    pic1_2.Image.Dispose();
                    pic1_2.Image = game.slots[1, 0].resultImage;
                }
                if (pic1_3.Image != null) //3 SLOT
                {
                    pic1_3.Image.Dispose();
                    pic1_3.Image = game.slots[2, 0].resultImage;
                }
                if (pic1_4.Image != null) //4 SLOT
                {
                    pic1_4.Image.Dispose();
                    pic1_4.Image = game.slots[3, 0].resultImage;
                }
                if (pic1_5.Image != null) //5 SLOT
                {
                    pic1_5.Image.Dispose();
                    pic1_5.Image = game.slots[4, 0].resultImage;
                }

                //2 LINE
                if (pic2.Image != null) //1 SLOT
                {
                    pic2.Image.Dispose();
                    pic2.Image = game.slots[0, 1].resultImage;
                }
                if (pic1_2.Image != null) //2 SLOT
                {
                    pic2_2.Image.Dispose();
                    pic2_2.Image = game.slots[1, 1].resultImage;
                }
                if (pic1_3.Image != null) //3 SLOT
                {
                    pic2_3.Image.Dispose();
                    pic2_3.Image = game.slots[2, 1].resultImage;
                }
                if (pic2_4.Image != null) //4 SLOT
                {
                    pic2_4.Image.Dispose();
                    pic2_4.Image = game.slots[3, 1].resultImage;
                }
                if (pic2_5.Image != null) //5 SLOT
                {
                    pic2_5.Image.Dispose();
                    pic2_5.Image = game.slots[4, 1].resultImage;
                }

                //3 LINE
                if (pic3.Image != null) //1 SLOT
                {
                    pic3.Image.Dispose();
                    pic3.Image = game.slots[0, 2].resultImage;
                }
                if (pic3_2.Image != null) //2 SLOT
                {
                    pic3_2.Image.Dispose();
                    pic3_2.Image = game.slots[1, 2].resultImage;
                }
                if (pic3_3.Image != null) //3 SLOT
                {
                    pic3_3.Image.Dispose();
                    pic3_3.Image = game.slots[2, 2].resultImage;
                }
                if (pic3_4.Image != null) //4 SLOT
                {
                    pic3_4.Image.Dispose();
                    pic3_4.Image = game.slots[3, 2].resultImage;
                }
                if (pic3_5.Image != null) //5 SLOT
                {
                    pic3_5.Image.Dispose();
                    pic3_5.Image = game.slots[4, 2].resultImage;
                }

                //GAME RESULTS
                if (radioButton1.Checked)
                {
                    gameWon = game.OneLineGamble(bet);
                }
                if (radioButton2.Checked)
                {
                    gameWon = game.ThreeLineGamble(bet);
                }
                if (radioButton3.Checked)
                {
                    gameWon = game.FiveLineGamble(bet);
                }
                if (radioButton4.Checked)
                {
                    gameWon = game.SevenLineGamble(bet);
                }
                if (radioButton5.Checked)
                {
                    gameWon = game.TenLineGamble(bet);
                }

                //UPDATING INFORMATION
                credits += gameWon;
                win += gameWon;
                label1.Text = $"Credits: {credits}";
                label2.Text = $"Bet: {bet}";
                label3.Text = $"Win: {win}";

                if (gameWon > 0)
                {
                    winSound.Play();
                    label4.Text = $"YOU WIN {gameWon}";
                }
                else
                {
                    label4.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Please enter a coin.", "Game Aborted!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lines = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lines = 3;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lines = 5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lines = 7;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            lines = 10;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            bet = trackBar1.Value;
            label2.Text = $"Bet: {bet.ToString()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            credits += 1000;
            MessageBox.Show("Thank you for your donation!", "Coin Inserted");
            label1.Text = $"Credits: {credits}";
        }
    }

    class Slot //SINGLE ROLL CLASS
    {
        public int resultInt;
        public Image resultImage;

        public Slot()
        {
            resultInt = IntUtil.Random(1, 8);

            switch (resultInt)
            {
                case 1:
                    resultImage = Image.FromFile("1.png");
                    break;
                case 2:
                    resultImage = Image.FromFile("2.png");
                    break;
                case 3:
                    resultImage = Image.FromFile("3.png");
                    break;
                case 4:
                    resultImage = Image.FromFile("4.png");
                    break;
                case 5:
                    resultImage = Image.FromFile("5.png");
                    break;
                case 6:
                    resultImage = Image.FromFile("6.png");
                    break;
                case 7:
                    resultImage = Image.FromFile("7.png");
                    break;
            }
        }
    }

    class Gamble //SINGLE GAME CLASS
    {
        public Slot[,] slots;
        int tripple = 25;
        int quinta = 125;
        int penta = 500;

        public Gamble()
        {
            slots = new Slot[5,3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    slots[j, i] = new Slot();
                }
            }
        }

        public int OneLineGamble(int bet)
        {
            int counter = 1;
            for (int i = 1; i < 5; i++)
            {
                if (slots[i, 1].resultInt == slots[0, 1].resultInt)
                {
                    counter++;
                }
                else
                {
                    i = 10;
                    if (counter == 3)
                    {
                        return bet*tripple;
                    }
                    else if (counter == 4)
                    {
                        return bet * quinta;
                    }
                    else if (counter == 5)
                    {
                        return bet * penta;
                    }
                }
            }
            return 0;
        }

        public int ThreeLineGamble(int bet)
        {
            int won = 0;
            for (int j = 0; j < 3; j++)
            {
                int counter = 1;
                for (int i = 1; i < 5; i++)
                {
                    if (slots[i, j].resultInt == slots[0, j].resultInt)
                    {
                        counter++;
                    }
                    else
                    {
                        i = 10;
                        if (counter == 3)
                        {
                            won += bet * tripple;
                        }
                        else if (counter == 4)
                        {
                            won += bet * quinta;
                        }
                        else if (counter == 5)
                        {
                            won += bet * penta;
                        }
                    }
                }
            }
            return won;
        }

        public int FiveLineGamble(int bet)
        {
            int won = 0;
            won += ThreeLineGamble(bet);

            //4TH LINE
            if (slots[1, 1].resultInt == slots[0, 0].resultInt)
            {
                if (slots[2, 2].resultInt == slots[0, 0].resultInt)
                {
                    if (slots[3, 1].resultInt == slots[0, 0].resultInt)
                    {
                        if (slots[4, 0].resultInt == slots[0, 0].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            //5TH LINE
            if (slots[1, 1].resultInt == slots[0, 2].resultInt)
            {
                if (slots[2, 0].resultInt == slots[0, 2].resultInt)
                {
                    if (slots[3, 1].resultInt == slots[0, 2].resultInt)
                    {
                        if (slots[4, 2].resultInt == slots[0, 2].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            return won;
        }

        public int SevenLineGamble(int bet)
        {
            int won = 0;
            won += FiveLineGamble(bet);

            //6TH LINE
            if (slots[1, 1].resultInt == slots[0, 0].resultInt)
            {
                if (slots[2, 1].resultInt == slots[0, 0].resultInt)
                {
                    if (slots[3, 1].resultInt == slots[0, 0].resultInt)
                    {
                        if (slots[4, 0].resultInt == slots[0, 0].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            //7TH LINE
            if (slots[1, 1].resultInt == slots[0, 2].resultInt)
            {
                if (slots[2, 1].resultInt == slots[0, 2].resultInt)
                {
                    if (slots[3, 1].resultInt == slots[0, 2].resultInt)
                    {
                        if (slots[4, 2].resultInt == slots[0, 2].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            return won;
        }

        public int TenLineGamble(int bet)
        {
            int won = 0;
            won += SevenLineGamble(bet);

            //8TH LINE
            if (slots[1, 0].resultInt == slots[0, 0].resultInt)
            {
                if (slots[2, 1].resultInt == slots[0, 0].resultInt)
                {
                    if (slots[3, 2].resultInt == slots[0, 0].resultInt)
                    {
                        if (slots[4, 2].resultInt == slots[0, 0].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            //9TH LINE
            if (slots[1, 2].resultInt == slots[0, 2].resultInt)
            {
                if (slots[2, 1].resultInt == slots[0, 2].resultInt)
                {
                    if (slots[3, 0].resultInt == slots[0, 2].resultInt)
                    {
                        if (slots[4, 0].resultInt == slots[0, 2].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            //10TH LINE
            if (slots[1, 1].resultInt == slots[0, 1].resultInt)
            {
                if (slots[2, 0].resultInt == slots[0, 1].resultInt)
                {
                    if (slots[3, 1].resultInt == slots[0, 1].resultInt)
                    {
                        if (slots[4, 1].resultInt == slots[0, 1].resultInt)
                        {
                            won += bet * penta;
                        }
                        else
                        {
                            won += bet * quinta;
                        }
                    }
                    else
                    {
                        won += bet * tripple;
                    }
                }
            }

            return won;
        }

    }

    //GENERATE RANDOM NUMBERS
    public static class IntUtil
    {
        private static Random random;
        private static void Init()
        {
            if (random == null)
            {
                random = new Random();
            }
        }
        public static int Random(int min, int max)
        {
            Init();
            return random.Next(min, max);
        }
    }
}
