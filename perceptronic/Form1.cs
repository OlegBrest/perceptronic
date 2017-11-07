using System;
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
        int samples = 180;
        bool started = false;
        double alpha = 0.1;
        double E = double.MaxValue;
        int blending = 51;

        public Form1()
        {

            this.etalon = new etalon_templ[total_elements];
            this.result = new etalon_templ[total_elements];

            InitializeComponent();
            this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.alpha = Convert.ToDouble(alpha_txtbx.Text);
            this.samples = (int)SamplesUpDown.Value;
            this.blending = Convert.ToInt32(blending_UP_DOWN.Value);
            for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++) w[i] = 1 / Convert.ToDouble(NeuronsUpDown.Value);
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
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.etalon[i].y = Math.Sin(i * Math.PI / 30);
            }
        }

        private void Etalon_Clean()
        {
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.etalon[i].y = 0;
                this.result[i].y = 0;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            started = !started;
            if (started)
            {
                this.start_button.Text = "Stop";
                this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
                this.T = 0;
                this.alpha = Convert.ToDouble(alpha_txtbx.Text);
                this.samples = (int)SamplesUpDown.Value;
                this.E = double.MaxValue;
                for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++) w[i] = 1 / Convert.ToDouble(NeuronsUpDown.Value);
                for (int i = 0; i < this.etalon.Length; i++)
                {
                    this.etalon[i].x = i;
                    this.result[i].x = i;
                    this.result[i].y = 0;
                }

            }
            else
            {
                this.start_button.Text = "Start";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.pictureBox.CreateGraphics();
            Brush brsh = new SolidBrush(Color.FromArgb(this.blending, 255, 255, 255));
            Rectangle rct = new Rectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height);
            g.FillRectangle(brsh, rct);
            if (this.started)
            {
                Learn_It();
            }
            W_Grid_Update();
            Draw_It(etalon, Color.Blue, Color.Aqua);
            Draw_It(result, Color.Red, Color.Red);
            E_label.Text = ("E=" + E_Calc().ToString());
        }

        void Draw_It(etalon_templ[] eta, Color color_start, Color color_end)
        {
            double dobavl = this.pictureBox.Height / 2;
            Graphics g = this.pictureBox.CreateGraphics();
            Brush br = new SolidBrush(color_start);
            Pen p = new Pen(br);
            Point old_point = new Point((int)eta[0].x, (int)(eta[0].y));
            Point new_point = new Point((int)eta[0].x, (int)(eta[0].y));
            for (int i = 0; i < this.etalon.Length; i++)
            {
                if (i > this.samples)
                {
                    br = new SolidBrush(color_end);
                    p = new Pen(br);
                }
                new_point.X = (int)eta[i].x;
                double y = eta[i].y;
                y = y * 100 + dobavl;
                y = y < 0 ? 0 : y > this.pictureBox.Height ? this.pictureBox.Height : y;
                if ((y < int.MaxValue) && (y > int.MinValue))
                { }
                else
                { y = 0; }
                new_point.Y = (int)y;
                g.DrawLine(p, old_point, new_point);
                old_point = new_point;
            }
        }

        void Learn_It()
        {
            Random rnd = new Random();
            int w_size = this.w.Length;
            double[] x_es = new double[w_size];//temp array for next calc
            // fill started values in result
            for (int i = 0; i < w_size; i++)
            {
                this.result[i] = this.etalon[i];
                x_es[i] = this.etalon[i].y;
            }

            // starting learning step
            for (int i = w_size; i < this.samples; i++)
            {
                for (int ii = 0; ii < w_size; ii++)
                {
                    x_es[ii] = this.etalon[ii + i - w_size].y;
                }
                this.result[i].x = this.etalon[i].x;
                double next = Get_Next(x_es);
                if ((Double.IsNaN(next)) || (Double.IsInfinity(next))) next = 0;
                double delta = next - this.etalon[i].y;
                double e_new = E_Calc();
                for (int ii = 0; ii < w_size; ii++)
                {
                    this.w[ii] = this.w[ii] - (this.alpha * delta * this.etalon[i + ii].y) / w_size;

                    e_new = E_Calc();/*
                    if ((e_new) == this.E)
                    {
                        this.alpha /= 1.000000001;
                        this.alpha_txtbx.Text = this.alpha.ToString();
                    }
                    */
                    if ((e_new) > this.E)
                    {
                        this.w[ii] = this.w[ii] + (this.alpha * delta * this.etalon[i + ii].y) / w_size;
                        //this.alpha *= 1.001;
                        //this.alpha_txtbx.Text = this.alpha.ToString();
                        //this.E = e_new;
                    }
                    /*
                    if ((e_new) < this.E)
                    {
                        this.alpha /= 1.002;
                        this.alpha_txtbx.Text = this.alpha.ToString();
                        this.E = e_new;
                    }

    */
                    if ((Double.IsNaN(this.w[ii])) || (Double.IsInfinity(this.w[ii])) || (this.w[ii] == 0)) this.w[ii] -= rnd.NextDouble();
                }
                this.T = T + this.alpha * delta;

                e_new = E_Calc();
                if ((e_new) == this.E)
                {
                    this.alpha /= (1.0 + ((e_new>100? 1: e_new) / 10000));
                    this.alpha_txtbx.Text = this.alpha.ToString();
                }

                if ((e_new) > this.E)
                {
                    this.T = T - this.alpha * delta;
                    this.alpha *= (1.0 + ((e_new > 100 ? 1 : e_new) / 10000));
                    this.alpha_txtbx.Text = this.alpha.ToString();
                    this.E = e_new;
                }

                if ((e_new) < this.E)
                {
                    this.E = e_new;
                    this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 70000));
                   this.alpha_txtbx.Text = this.alpha.ToString();
                }


                if ((Double.IsNaN(this.T)) || (Double.IsInfinity(this.T))) this.T = 0;
                next = Get_Next(x_es);
                this.result[i].y = next;
            }
            // calc after learning
            for (int i = this.samples; i < this.total_elements; i++)
            {
                for (int ii = 0; ii < w_size; ii++)
                {
                    x_es[ii] = this.result[ii + i - w_size].y;
                }
                this.result[i].x = this.etalon[i].x;
                double next = Get_Next(x_es);
                this.result[i].y = next;
            }
        }

        // getting next value by array x_es
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

        void W_Grid_Update()
        {

            int row_in_grid = this.w_datagridview.Rows.Count;
            int w_count = this.w.Length;
            if (w_count != row_in_grid)
            {
                for (int i = 0; i < row_in_grid; i++)
                {
                    this.w_datagridview.Rows.RemoveAt(0);
                }
                for (int i = 0; i < w_count; i++)
                {
                    this.w_datagridview.Rows.Add(i, this.w[i]);
                }
            }
            else
            {
                for (int i = 0; i < w_count; i++)
                {
                    this.w_datagridview.Rows[i].Cells[1].Value = this.w[i];
                }
            }
            this.w_datagridview.Update();
        }

        private void reset_bttn_Click(object sender, EventArgs e)
        {
            //this.etalon = new etalon_templ[total_elements];
            this.result = new etalon_templ[total_elements];
            this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.alpha = Convert.ToDouble(alpha_txtbx.Text);
            for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++) w[i] = 1 / Convert.ToDouble(NeuronsUpDown.Value);
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                //this.result[i].y = 0;
            }
        }

        private double E_Calc()
        {
            double ret_val = 0;
            int w_size = this.w.Length;

            for (int i = w_size; i < this.samples; i++)
            {
                double delta = this.result[i].y - this.etalon[i].y;
                ret_val += Math.Pow(delta, 2);
            }
            ret_val /= 2;
            return ret_val;
        }

        private void blending_UP_DOWN_ValueChanged(object sender, EventArgs e)
        {
            this.blending = Convert.ToInt32(blending_UP_DOWN.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Etalon_Clean();
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.etalon[i].y = (Math.Sin(i * Math.PI / 10) + Math.Cos(i * Math.PI / 13));
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Etalon_Clean();
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.etalon[i].y = (Math.Sin(i * Math.PI / 10) + Math.Cos(i * Math.PI / 13)) * Math.Sin(i * Math.PI / 5);
            }
        }

        private void NeuronsUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++) w[i] = 1 / Convert.ToDouble(NeuronsUpDown.Value);
        }
    }
}
