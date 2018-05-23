using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using beehive_2._0;

namespace beehive_2._0
{
    public partial class Form1 : Form
    {
        private Queen queen;
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(175, new string[] { "Nectar collector", "Honey manufacturing" });
            workers[1] = new Worker(114, new string[] { "Egg care", "Baby bee tutoring" });
            workers[2] = new Worker(149, new string[] { "Hive maintenance", "Sting patrol" });
            workers[3] = new Worker(155, new string[] { "Nectar collector", "Honey manufacturing",
                "Egg care", "Baby bee tutoring",
                "Hive maintenance", "Sting patrol" });
            queen = new Queen(275, workers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool workerAvailable;
            workerAvailable = queen.AssignWork(workerBeeJob.Text,(int)shifts.Value);
            if (!workerAvailable)
                MessageBox.Show($"There is no worker available to do the job '{workerBeeJob.Text}",
                    "The queen bee says...");
            else
            {
                MessageBox.Show($"The job '{workerBeeJob.Text}' will be done in {shifts.Value} shifts",
                    "The queen bee says...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = queen.WorkTheNextShift();
        }
    }
}
