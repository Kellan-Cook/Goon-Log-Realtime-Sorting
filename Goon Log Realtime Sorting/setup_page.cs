using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Goon_Log_Realtime_Sorting
{
    public partial class setup_page : Form
    {
        public bool clicky = false;

        public string dirvalue { get; set; }
        public bool autovalue { get; set; }
        public setup_page()
        {
            this.ControlBox = false;
            InitializeComponent();

        }

        public void button1_Click(object sender, EventArgs e)
        {
            clicky= true;
            this.dirvalue = textBox1.Text;
            this.autovalue = autoDetectCheck.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void setup_page_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(clicky == false)
            {
                System.Windows.Forms.Application.Exit();
            }
            
        }
    }
}
