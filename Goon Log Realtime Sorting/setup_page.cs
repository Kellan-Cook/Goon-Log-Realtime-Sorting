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


        public string dirvalue { get; set; }
        public bool autovalue { get; set; }
        public setup_page()
        {
            InitializeComponent();

        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.dirvalue = textBox1.Text;
            this.autovalue = autoDetectCheck.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
