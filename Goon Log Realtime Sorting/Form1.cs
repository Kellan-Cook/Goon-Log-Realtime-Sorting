using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Goon_Log_Realtime_Sorting.Properties;

namespace Goon_Log_Realtime_Sorting
{
   

    public partial class mainForm : Form
    {
        public mainForm()
        {
            GLRSettings settings = new GLRSettings();

            bool autovalue = false;
            InitializeComponent();
            if (File.Exists("GLRS_Settings.json"))
            {



            }
            else
            {
                Console.WriteLine("test");
                using (var form = new setup_page())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        settings.logDir = form.dirvalue;            //values preserved after close
                        autovalue = form.autovalue;
                        Console.WriteLine("given directory: " + settings.logDir);
                    }
                    if(autovalue == true)
                    {
                        string tooName = "NULL";
                        var fileNames = Directory.GetFiles(settings.logDir);
                        foreach (var fileName in fileNames)
                        {   
                            Console.WriteLine($"{fileName}");
                            try
                            {
                                tooName = File.ReadLines(fileName).Skip(2).Take(1).First();
                            }
                            catch (System.InvalidOperationException)
                            {
                                Console.WriteLine("ERROR: " + fileName + " too short");
                            }
                            
                            if (tooName.Contains("Listener:"))
                            {
                                tooName = tooName.Remove(0, 12);
                                Console.WriteLine("toon: " + tooName);
                                if (settings.toons.Contains(tooName))
                                {
                                    Console.WriteLine("already in list");
                                }
                                else
                                {
                                    settings.toons.Add(tooName);
                                }
                            }
                            
                        }
                    }
                }


            }

            listBox1.DataSource = settings.toons;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb != null)
            {
                Console.WriteLine("selected toon: " + lb.SelectedItem);
                //ADD HERE METHOD FOR GETTING MOST RECENT LOG EVENTS
            }
        }
    }
    public class GLRSettings
    {
        public string logDir = "null";
        public List<string> toons = new List<string>();

    }

}
