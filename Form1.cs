using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EllGamal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int fun(int p, int a, int b)
        {
            int s = 1;
            for (int i = 1; i <= b; i++)
            {

                s = (s * a) % p;
            }
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1;
            Random myrandom = new Random();
            int p = int.Parse(textBox4.Text), g = int.Parse(textBox5.Text), da, ca, db, cb, k;
            ca = myrandom.Next(p);
            da = fun(p, g, ca);

            cb = myrandom.Next(p);
            db = fun(p, g, cb);

            str1 = textBox1.Text;
            textBox2.Text = "";
            textBox3.Text = "";

            for (int i = 0; i < str1.Length; i++)
            {
                k = (int)str1[i];
                                k = (k * fun(p, db, ca)) % p;
                textBox2.Text = textBox2.Text + k.ToString() + ".";
                               k = (k * fun(p, da, p - 1 - cb)) % p;
                textBox3.Text = textBox3.Text + (char)k;

            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("E:\\elgamal.txt", textBox3.Text += "\n");
            

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
