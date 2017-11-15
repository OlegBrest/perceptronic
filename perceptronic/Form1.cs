using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        etalon_templ[] result_best;
        double[] w;
        double[] w_best;
        double T;
        double T_best;
        int samples = 180;
        bool started = false;
        double alpha = 0.1;
        double E = double.MaxValue;
        double E_best = double.MaxValue;
        int blending = 51;
        double median = 1;
        double corr = 1;
        Random rnd = new Random();


        public Form1()
        {

            this.etalon = new etalon_templ[total_elements];
            this.result = new etalon_templ[total_elements];
            this.result_best = new etalon_templ[total_elements];

            InitializeComponent();
            this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.w_best = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.alpha = Convert.ToDouble(alpha_txtbx.Text);
            this.samples = (int)SamplesUpDown.Value;
            this.blending = Convert.ToInt32(blending_UP_DOWN.Value);
            fill_w();
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.result_best[i].x = i;
            }

        }

        private void radio_sin_CheckedChanged(object sender, EventArgs e)
        {
            Etalon_Clean();
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.result_best[i].x = i;
                this.etalon[i].y = Math.Sin(i * Math.PI / 30);
            }
        }

        private void Etalon_Clean()
        {
            for (int i = 0; i < this.etalon.Length; i++)
            {
                this.etalon[i].x = i;
                this.result[i].x = i;
                this.result_best[i].x = i;
                this.etalon[i].y = 0;
                this.result[i].y = 0;
                this.result_best[i].y = 0;
            }
            this.T = 0;
            this.T_best = 0;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            started = !started;
            if (started)
            {
                this.start_button.Text = "Stop";
                this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
                this.w_best = new double[Convert.ToInt32(NeuronsUpDown.Value)];
                this.T = 0;
                this.T_best = 0;
                this.E_best = double.MaxValue;
                this.alpha = Convert.ToDouble(alpha_txtbx.Text);
                this.samples = (int)SamplesUpDown.Value;
                this.E = double.MaxValue;
                fill_w();
                for (int i = 0; i < this.etalon.Length; i++)
                {
                    this.etalon[i].x = i;
                    this.result[i].x = i;
                    this.result[i].y = 0;
                    this.result_best[i].y = 0;
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
            Draw_It(etalon, Color.Blue, Color.Aqua, true);
            Draw_It(result, Color.Red, Color.Red);
            Draw_It(result_best, Color.DarkGreen, Color.Green);
            E_label.Text = ("E=" + E_Calc().ToString());
            E_best_label.Text = ("E_best=" + this.E_best);
        }

        void Draw_It(etalon_templ[] eta, Color color_start, Color color_end, bool original = false)
        {
            double dobavl = this.pictureBox.Height / 2;
            double min_val = Double.MaxValue;
            double max_val = Double.MinValue;
            foreach (etalon_templ yy in eta)
            {
                if (min_val > yy.y) min_val = yy.y;
                if (max_val < yy.y) max_val = yy.y;
            }
            double delta = (max_val - min_val);
            if (original)
            {
                this.median = (max_val + min_val) / 2;
                this.corr = dobavl / (delta == 0 ? 1 : delta);
            }
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
                double y = (median - eta[i].y);
                y = y * corr + dobavl;
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


        void fill_w()
        {
            for (int i = 0; i < Convert.ToInt32(NeuronsUpDown.Value); i++)
            {
                double sign_next = (this.rnd.NextDouble() )/1000;
                //sign_next /= Math.Abs(sign_next);
                this.w[i] = sign_next / Convert.ToDouble(NeuronsUpDown.Value);
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
                double next = Get_Next(x_es, this.T);
                if ((Double.IsNaN(next)) || (Double.IsInfinity(next))) next = 0;
                double delta = next - this.etalon[i].y;
                double e_new = E_Calc();
                for (int ii = 0; ii < w_size; ii++)
                {
                    this.E = e_new;
                    double incr = (this.alpha * delta * this.etalon[i + ii].y) / w_size;
                    //double old_w = this.w[ii];
                    //double old_y = this.result[i].y;
                    this.w[ii] = this.w[ii] - incr;
                    this.result[i].y = next;

                    /*   e_new = E_Calc();
                       if ((e_new) == this.E)
                       {
                           if ((e_new < 1) && (this.alpha > 0.01)) this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 100000));
                           this.alpha_txtbx.Text = this.alpha.ToString();
                       }

                       if ((e_new) > this.E)
                       {
                           /*this.w[ii] = old_w;
                           this.result[i].y = old_y;
                           e_new = E_Calc();
                           this.E = e_new;
                           if ((e_new < 1) && (this.alpha < 0.7)) this.alpha *= (1.0 + ((e_new > 100 ? 1 : e_new) / 100000));
                           this.alpha_txtbx.Text = this.alpha.ToString();
                       }

                       if ((e_new) < this.E)
                       {
                           if ((e_new < 1) && (this.alpha > 0.01)) this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 700000));
                           this.alpha_txtbx.Text = this.alpha.ToString();
                           this.E = e_new;
                       }

      */
                    if ((Double.IsNaN(this.w[ii])) || (Double.IsInfinity(this.w[ii])) || (this.w[ii] == 0)) this.w[ii] = rnd.NextDouble()/w_size;
                }
                this.T = T + this.alpha * delta;

                e_new = E_Calc();
                if ((e_new) == this.E)
                {
                    if ((e_new < 1) && (this.alpha > 0.01)) this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 1000));
                    this.alpha_txtbx.Text = this.alpha.ToString();
                }

                if ((e_new) > this.E)
                {
                    this.T = T - this.alpha * delta;
                    e_new = E_Calc();
                    this.E = e_new;
                    if ((e_new < 1) && (this.alpha > 0.00000001)) this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 1000));
                    this.alpha_txtbx.Text = this.alpha.ToString();
                    //this.E = e_new;
                }

                if ((e_new) < this.E)
                {
                    this.E = e_new;
                    if ((e_new < 1) && (this.alpha < 0.6666)) this.alpha *= (1.0 + ((e_new > 100 ? 1 : e_new) / 7000));
                    this.alpha_txtbx.Text = this.alpha.ToString();
                }

                if ((e_new) < this.E_best)
                {
                    double[] x_best = new double[w_size];
                    for (int ii = 0; ii < w_size; ii++)
                    {
                        this.result_best[ii].y = this.etalon[ii].y;
                        this.w_best[ii] = this.w[ii];
                    }
                    this.E_best = e_new;
                    this.T_best = T;

                    for (int s = w_size; s < this.total_elements; s++)
                    {
                        for (int ii = 0; ii < w_size; ii++)
                        {
                            x_best[ii] = this.result_best[ii + s - w_size].y;
                        }
                        this.result_best[s].x = this.etalon[s].x;
                        double next_b = Get_Next(x_best, this.T_best);
                        this.result_best[s].y = next_b;
                    }
                }
                this.E = e_new;
                if (e_new > 1000)
                {
                    for (int wa = 0; wa < this.w.Length; wa++) this.w[wa] = this.w_best[wa];
                    this.T = this.T_best;
                    this.alpha /= (1.0 + ((e_new > 100 ? 1 : e_new) / 30));
                }
                if ((Double.IsNaN(this.T)) || (Double.IsInfinity(this.T))) this.T = 0;
                next = Get_Next(x_es, this.T);
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
                double next = Get_Next(x_es, this.T);
                this.result[i].y = next;
            }
        }

        // getting next value by array x_es
        double Get_Next(double[] x_es, double TT)
        {
            double ret_val = 0;
            int w_size = this.w.Length;

            for (int i = 0; i < w_size; i++)
            {
                ret_val += x_es[i] * this.w[i];
            }
            ret_val -= TT;
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
                    this.w_datagridview.Rows.Add(i, this.w[i], this.w_best[i]);
                }
            }
            else
            {
                for (int i = 0; i < w_count; i++)
                {
                    this.w_datagridview.Rows[i].Cells[1].Value = this.w[i];
                    this.w_datagridview.Rows[i].Cells[2].Value = this.w_best[i];
                }
            }
            this.w_datagridview.Update();
        }

        private void reset_bttn_Click(object sender, EventArgs e)
        {
            //this.etalon = new etalon_templ[total_elements];
            
            this.result = new etalon_templ[total_elements];
            this.w = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.w_best = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            this.alpha = Convert.ToDouble(alpha_txtbx.Text);
            this.E_best = double.MaxValue;
            fill_w();
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
            this.w_best = new double[Convert.ToInt32(NeuronsUpDown.Value)];
            fill_w();
        }

        private void File_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (File_radio.Checked)
            {
                this.Open_File_Bttn.Enabled = true;
                this.smooth_type_bx.Enabled = true;
                this.smooth_type_lvl.Enabled = true;
            }
            else
            {
                this.Open_File_Bttn.Enabled = false;
                this.smooth_type_bx.Enabled = false;
                this.smooth_type_lvl.Enabled = false;
            }
        }

        private void Open_File_Bttn_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filename = this.openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filename);
                Etalon_Clean();
                if ((lines.Length - 1) <= this.total_elements)
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] cells = lines[i].Split('\t');
                        this.etalon[i - 1].y = Convert.ToDouble(cells[2]);
                    }
                }
                else
                {
                    for (int i = 0; i < this.total_elements; i++)
                    {
                        string[] cells = lines[i + 1].Split('\t');
                        this.etalon[i].y = Convert.ToDouble(cells[2]);
                    }
                }
                int smooth_type = Convert.ToInt32(this.smooth_type_bx.SelectedIndex);
                int lvl = Convert.ToInt32(this.smooth_type_lvl.Value);
                // smooting
                if (smooth_type == 1)
                {
                    for (int i = lvl; i < this.total_elements; i++)
                    {
                        for (int ii = 0; ii < lvl; ii++)
                        {
                            this.etalon[i - lvl].y += this.etalon[i - ii].y;
                        }
                        this.etalon[i - lvl].y /= ((double)lvl + 1.0);
                    }
                }
                if (smooth_type == 2)
                {
                    double gain = 0.0005;
                    for (int i = lvl; i < this.total_elements; i++)
                    {
                        double delta = this.etalon[i].y - this.etalon[i - lvl].y;
                        if (Math.Abs(delta) < gain)
                        {
                            this.etalon[i - lvl].y = 0;
                        }
                        else
                        {
                            if (delta > 0) this.etalon[i - lvl].y = 1;
                            if (delta < 0) this.etalon[i - lvl].y = -1;
                        }
                    }
                }
            }
        }
    }
}
