using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsightGroupTech
{
    public partial class Form1 : Form
    {
        // To receive values of ArrayList in the FileRead calss
        ArrayList arr = new ArrayList();

        FileRead fr = new FileRead();

        // In order to use Split method, it is required to put values in ArrayList into Array.
        string[] data; 
     
        // Another array is necessary to store separate string values without "," delimiter.
        string[] temp = new string[2];

        ListViewItem xyValue;

        // To prevent listing warehouse shelf locations more than once
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter++;
            Console.WriteLine(counter);

            if (counter > 1)
            return;
            
            try
            {
                arr = fr.coordValue();
                data = new string[arr.Count];
                arr.CopyTo(data);

                // Error message control. It shows "None" when it successfully imports wharehouse shelf locations
                label6.Text = "None";

                for (int i = 0; i < data.Length; i++)
                {

                    temp = data[i].Split(',');

                    // FYI, string was assigned to ArraList because "listView" object does not import numbers
                    xyValue = new ListViewItem(temp[0]);
                    xyValue.SubItems.Add(temp[1]);

                    // In order to update new values in the column of "Distance, empty value is required."
                    xyValue.SubItems.Add("");
                    listView1.Items.Add(xyValue);

                }

            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           double dX, dY, wX, wY, dist;

           try
           {
                // Convert value type from string to double to calculate the distance.
                dX = Convert.ToDouble(textBox1.Text);
                dY = Convert.ToDouble(textBox2.Text);

                for (int i = 0; i < data.Length; i++)
                {

                    temp = data[i].Split(',');

                    wX = Convert.ToDouble(temp[0]);
                    wY = Convert.ToDouble(temp[1]);

                    dist = Math.Round(Math.Sqrt(Math.Pow((dX - wX), 2) + Math.Pow((dY - wY), 2)), 2);

                    // Updating new values in the column of "Distance"
                    listView1.Items[i].SubItems[2].Text = Convert.ToString(dist);
                    label6.Text = "None";

                }
            }
            catch (FormatException fe)
            {
                // To prevent an error when the user input wrong value in the text boxes
                label6.Text = "Please, enter numbers.";
                Console.WriteLine(fe);
            }
            catch (Exception ee)
            {
                // To make the user import warehouse shelf locations first
                label6.Text = "Did you import?";
                Console.WriteLine(ee);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();

            textBox1.Text = "";
            textBox2.Text = "";

            label6.Text = "None";
            counter = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
