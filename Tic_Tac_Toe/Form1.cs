using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        static bool pc = false;// pc r sathe khelbo
        bool turn = true; // true = x turn. flase = y turn
        int turncount = 0;
        static String pl1="Shishir", pl2;
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = pl1;
            label3.Text = pl2;
        }
        public static void set_pc(String n1)
        {
            pl1 = n1;
            if (pl1 == " ")
                pl1 = "Shishir";
            pl2 = "Computer";
            pc = true;
           
        }
        

        public Form1()
        {
            InitializeComponent();
            //Form1.set_name(pl1, pl2);
            mar.Text = "It's " + pl1 + " 's turn now!!!!";
        }

        public static void set_name(String n1, String n2)
        {
       
            pl1 = n1;
            pl2 = n2;
            if (pl1 == " ") pl1 = "Shishir";
            if (pl2 == "") pl2 = "Lamia";
            //mar.Text = "It's " + pl1 + " 's turn now!!!!";
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Sifat Shishir","Tic Tac Toe");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (pl1 == "" || pl2 == "")
            {
                MessageBox.Show("You must specify the players names before starting\n");
            }
            else
            {
                if(turncount % 2 == 0)
                    mar.Text = "It's " + pl2 + " 's turn now!!!!";
                else
                    mar.Text = "It's " + pl1 + " 's turn now!!!!";
                Button b = (Button)sender;
                if (turn)
                {
                    
                    b.Text = "X";
                }
                else
                {
                    //mar.Text = "It's " + pl2 + " 's turn now!!!!";
                    b.Text = "O";
                }

                turn = !turn;
                b.Enabled = false;
                turncount++;
                check_winner();
            }

            if (!turn && pc)
            {
                pc_move();
            }
        }

        public void pc_move()
        {
            Button go = null;
            go = win_or_kill("O");

            if (go == null)
            {
                go = win_or_kill("X");

                if (go == null)
                {
                    go = corner();

                    if (go == null)
                    {
                        go = open();
                    }
                }
            }
            try
            {
                go.PerformClick();
            }
            catch { };
        }
        private Button open()
        {
            Button x = null;
            foreach (Control c in Controls)
            {
                x = c as Button;
                if (x != null)
                {
                    if (x.Text == "")
                        return x;
                }
            }
            return null;
        }

        private Button corner()
        {
            if (a1.Text == "O")
            {
                if (a3.Text == "") return a3;
                if (c3.Text == "") return c3;
                if (c1.Text == "") return c1;
            }

            if (a3.Text == "O")
            {
                if (a1.Text == "") return a1;
                if (c3.Text == "") return c3;
                if (c1.Text == "") return c1;
            }

            if (c3.Text == "O")
            {
                if (a3.Text == "") return a3;
                if (a1.Text == "") return a1;
                if (c1.Text == "") return c1;
            }

            if (c1.Text == "O")
            {
                if (a3.Text == "") return a3;
                if (c3.Text == "") return c3;
                if (a1.Text == "") return a1;
            }

            if (a1.Text == "") return a1;
            if (a3.Text == "") return a3;
            if (c3.Text == "") return c3;
            if (c1.Text == "") return c1;

            return null;
        }

        private Button win_or_kill(String m)
        {

            // horizontal
            if (a1.Text == m && a2.Text == m && a3.Text == "")
                return a3;
            if (a1.Text == m && a3.Text == m && a2.Text == "")
                return a2;
            if (a3.Text == m && a2.Text == m && a1.Text == "")
                return a1;

            if (b1.Text == m && b2.Text == m && b3.Text == "")
                return b3;
            if (b1.Text == m && b3.Text == m && b2.Text == "")
                return b2;
            if (b3.Text == m && b2.Text == m && b1.Text == "")
                return b1;

            if (c1.Text == m && c2.Text == m && c3.Text == "")
                return c3;
            if (c1.Text == m && c3.Text == m && c2.Text == "")
                return c2;
            if (c3.Text == m && c2.Text == m && c1.Text == "")
                return c1;


            //vertical
            if (a1.Text == m && b1.Text == m && c1.Text == "")
                return c1;
            if (a2.Text == m && b2.Text == m && c2.Text == "")
                return c2;
            if (a3.Text == m && b3.Text == m && c3.Text == "")
                return c3;

            if (a1.Text == m && b1.Text == "" && c1.Text == m)
                return b1;
            if (a2.Text == m && b2.Text == "" && c2.Text == m)
                return b2;
            if (a3.Text == m && b3.Text == "" && c3.Text == m)
                return b3;

            if (a1.Text == "" && b1.Text == m && c1.Text == m)
                return a1;
            if (a2.Text == "" && b2.Text == m && c2.Text == m)
                return a2;
            if (a3.Text == "" && b3.Text == m && c3.Text == m)
                return a3;

            //diagonal
            if (a1.Text == m && b2.Text == m && c3.Text == "")
                return c3;
            if (a1.Text == "" && b2.Text == m && c3.Text == m)
                return a1;
            if (a1.Text == m && b2.Text == "" && c3.Text == m)
                return b2;

            if (a3.Text == m && b2.Text == m && c1.Text == "")
                return c1;
            if (a3.Text == "" && b2.Text == m && c1.Text == m)
                return a3;
            if (a3.Text == m && b2.Text == "" && c1.Text == m)
                return b2;

            return null;
        }


        public void check_winner()
        {
            bool winner = false;
            if (a1.Text == a2.Text && a2.Text == a3.Text && !a1.Enabled)
                winner = true;
            else if (b1.Text == b2.Text && b2.Text == b3.Text && !b1.Enabled)
                winner = true;
            else if (c1.Text == c2.Text && c2.Text == c3.Text && !c1.Enabled)
                winner = true;

            else if (a1.Text == b1.Text && b1.Text == c1.Text && !a1.Enabled)
                winner = true;
            else if (a2.Text == b2.Text && b2.Text == c2.Text && !a2.Enabled)
                winner = true;
            else if (a3.Text == b3.Text && b3.Text == c3.Text && !a3.Enabled)
                winner = true;

            else if (a1.Text == b2.Text && b2.Text == c3.Text && !a1.Enabled)
                winner = true;
            else if (a3.Text == b2.Text && b2.Text == c1.Text && !a3.Enabled)
                winner = true;

            if (winner)
            {
                disableButton();
                String win = "";
                if (turn)
                {
                    win = pl2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text)+1).ToString();
                }
                else 
                {
                    win = pl1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text)+1).ToString();
                }
                if(pc && win=="Computer")
                    MessageBox.Show(win + " Wins!!", "Bad Luck");
                else MessageBox.Show(win + " Wins!!", "Yahoo!!");

            }
            else
            {
                if (turncount == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text)+1).ToString();
                    MessageBox.Show("Draw!!", "Try Again");
                    turn = true;
                    turncount = 0;
                    pc = false;
                }
                    

            }
        }

        public void disableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1.set_name(pl1, pl2);
            if (pl2 == "Computer") pc = true;
            turncount = 0;
            turn = true;

           
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }
            
            

        }

        

        private void againstPcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pl1 = "Shishir";
            pl2 = "Computer";
            label1.Text = pl1;
            label3.Text = pl2;
            turncount = 0;
            turn = true;
            pc = true;
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";
          
                foreach (Control c in Controls)
                {
                    try
                    {

                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }
         
        }

        private void t1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void resetCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";
        }
       
    }
}
