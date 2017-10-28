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
            double x;
            double y;
        };

        etalon_templ[] etalon = new etalon_templ[1000];
        public Form1()
        {
            InitializeComponent();
        }

        private void radio_sin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
