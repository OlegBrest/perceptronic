﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perceptronic
{
    public partial class Form1 : Form
    {
        struct etalon_templ
        {
            public double x;
            public double y;
        };

        int total_elements = 1000;
        etalon_templ[] etalon;
        etalon_templ[] result;
        double[] w;
        double T;
        bool started = false;
        public Form1()
        {
            w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.etalon = new etalon_templ[total_elements];
            this.result = new etalon_templ[total_elements];
            InitializeComponent();
            for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++) w[i] = 0.2;
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
            }

        }

        private void radio_sin_CheckedChanged(object sender, EventArgs e)
        {
            Etalon_Clean();
            for (int i = 0; i < this.etalon.Length; i++)
            {
                double dobavl = this.pictureBox.Height / 2;
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.etalon[i].y = Math.Sin(i * Math.PI / 30) * 100 + dobavl;
            }
        }

        private void Etalon_Clean()
        {
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.etalon[i].y = 0;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            started = !started;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox.CreateGraphics();
            Brush brsh = new SolidBrush(Color.FromArgb(5, 255, 255, 255));
            Rectangle rct = new Rectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height);
            g.FillRectangle(brsh, rct);
            if (started)
            {
                Draw_It(etalon, Color.Blue, Color.Aqua);
                Draw_It(result, Color.Red, Color.Red);
            }
        }

        void Draw_It(etalon_templ[] eta, Color color_start, Color color_end)
        {
            Graphics g = this.pictureBox.CreateGraphics();
            Brush br = new SolidBrush(color_start);
            Pen p = new Pen(br);
            Point old_point = new Point((int)eta[0].x, (int)(eta[0].y));
            Point new_point = new Point((int)eta[0].x, (int)(eta[0].y));
            for (int i = 0; i < this.etalon.Length; i++)
            {
                if (i > SamplesUpDown.Value)
                {
                    br = new SolidBrush(color_end);
                    p = new Pen(br);
                }
                new_point.X = (int)eta[i].x;
                new_point.Y = (int)eta[i].y;
                g.DrawLine(p, old_point, new_point);
                old_point = new_point;
            }
        }

        void Learn_It()
        {
            int w_size = this.w.Length;
            double[] x_es = new double[w_size];//temp array for next calc
            // fill started values in result
            for (int i = 0; i<w_size;i++)
            {
                this.result[i] = this.etalon[i];
                x_es[i] = this.etalon[i].y;
            }
            
            // starting learning step
            for (int i = w_size; i<total_elements;i++)
            {
                for (int ii = 0; ii < w_size; ii++)
                {
                    x_es[ii] = this.result[ii+i-w_size].y;
                }
                this.result[i].x = this.etalon[i].x;
                double next = Get_Next(x_es);
                double delta = next - this.etalon[i].y;
            }
        }

        double Get_Next(double[] x_es)
        {
            double ret_val = 0;
            int w_size = this.w.Length;

            for (int i = 0; i < w_size; i++)
            {
                ret_val += x_es[i] * this.w[i];
            }
            ret_val -= this.T;
            return ret_val;
        }
    }
}
