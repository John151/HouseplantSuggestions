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
            this.trkTemp.Scroll += new System.EventHandler(this.HouseConditionsChanged);
        }

        private void trkTemp_Scroll(object sender, EventArgs e)
        {
            //takes track value, turns into string type
            //sets temp text equal to track string value
            lblTemp.Text = trkTemp.Value.ToString("# °F");
        }

        private void HouseConditionsChanged(object sender, EventArgs e)
        {
            int homeTemp = trkTemp.Value;
            bool southFacingWindowAvailable = chkSouthFacing.Checked;

            //call new method, use return value
            string suggestedPlant = GenerateSuggestion(homeTemp,
                southFacingWindowAvailable);

            lblSuggestion.Text = suggestedPlant;
        }
        private string GenerateSuggestion(int temp, bool southFacing)
        {
            if (southFacing)
            {
                if (temp > 65)
                {
                    return "Peace Lily"; //warm, light
                }
                else
                {
                    return "Spider Plant"; //cool, light
                }
            }
            else
            {
                if (temp > 65)
                {
                    return "Dragon Tree"; //warm, low light
                }
                else
                {
                    return "Ivy"; //cool, low light
                }


            }

        }
    }
}
