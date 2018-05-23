using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_6___beehive_management_system
{
    public partial class Form1 : Form
    {
        private Queen queen;
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Nectar collector", "Honey manufacturing" });
            workers[1] = new Worker(new string[] { "Egg care", "Baby bee tutoring" });
            workers[2] = new Worker(new string[] { "Hive maintenance", "Sting patrol" });
            workers[3] = new Worker(new string[] { "Nectar collector", "Honey manufacturing",
                "Egg care", "Baby bee tutoring",
                "Hive maintenance", "Sting patrol" });
            queen = new Queen(workers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool workerAvailable;
            workerAvailable = queen.AssignWork(workerBeeJob.Text,(int)shifts.Value);
            if (!workerAvailable)
                MessageBox.Show("There is no worker available");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = queen.WorkTheNextShift();
        }
    }
}
