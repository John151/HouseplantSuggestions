using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseplantSuggestions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trkTemp_Scroll(object sender, EventArgs e)
        {
            //takes track value, turns into string type
            //sets temp text equal to track string value
            lblTemp.Text = trkTemp.Value.ToString("# °F");
        }
    }
}
