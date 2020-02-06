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
        readonly int MinTemp = 50; //these are global variables, available to all methods
        readonly int MaxTemp = 90; //read only

        bool ShowMinWarning = false;
        bool ShowMaxWarning = false;

        public Form1()
        {
            InitializeComponent();
            this.trkTemp.Scroll += new System.EventHandler(this.HouseConditionsChanged);

            this.trkTemp.Minimum = MinTemp; //initialized the min and max temp
            this.trkTemp.Maximum = MaxTemp;
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

            checkTempExtreme(homeTemp);
            //call new method, use return value

            string suggestedPlant = GenerateSuggestion(homeTemp,
                southFacingWindowAvailable);

            lblSuggestion.Text = suggestedPlant;
        }

        private void checkTempExtreme(int homeTemp)
        {
            
            if (homeTemp == MinTemp && ShowMinWarning == false)
            {
                MessageBox.Show(text: "Your home may be too cold for a houseplant",
                    caption: "Information");
                ShowMinWarning = true;
            }
            if (homeTemp == MaxTemp && ShowMaxWarning == false)
            {
                MessageBox.Show(text: "Your home may be too warm for most houseplants",
                    caption: "Information");
                ShowMaxWarning = true;
            }
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

        private void lnkHousePlantInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblSuggestion.Text == "Plant suggestion here")
            {
                ShowWebPage(); //this method removes default text so it isn't 
                //included in the url accidentally
            }
            
        else
            {
                ShowWebPage(lblSuggestion.Text);
            }
        }
        private void ShowWebPage(string plantName = null) // create new method 
        {
            string url = "https://www.houseplant411.com/";

            if (plantName != null)
            {
                //link to a specific plant should be in form 
                //"https://www.houseplant411.com/hosueplant?hpq=ivy"
                url = url + "houseplant?hpq=" + plantName;
            }
            System.Diagnostics.Process.Start(url); //launch browser
        }
    }
}
