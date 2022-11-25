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
using System.Threading;
using System.Reflection.Emit;

namespace Goon_Log_Realtime_Sorting
{
   

    public partial class mainForm : Form
    {
        public GLRSettings settings = new GLRSettings();
        public String tooName = "null";
        public string line = "null";
        public bool isStop = false;
        public mainForm()
        {

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
            Thread liveLogCheck = new Thread(logCheck);
            ListBox lb = sender as ListBox;
            liveLogCheck.Start();
            if (lb != null)
            {
                tooName =(string) lb.SelectedItem;
                //if (liveLogCheck.IsAlive)
                //{
                    //liveLogCheck.Abort();
               // }
                //else
                //{
                    
                    string newline = Environment.NewLine;

                //}
                Console.WriteLine("selected toon: " + lb.SelectedItem);
                //ADD HERE METHOD FOR GETTING MOST RECENT LOG EVENTS


                



            }
        }




        private void logCheck()
        {
            String toonfile = "null";
            DirectoryInfo info = new DirectoryInfo(settings.logDir);
            FileInfo[] files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                string name = "null";
                Console.WriteLine("CHECKED: " + file);
                try
                {
                    name = File.ReadLines((string)file.FullName).Skip(2).Take(1).First();
                }
                catch (System.InvalidOperationException)
                {
                    Console.WriteLine("ERROR: " + file + " too short");
                }

                if (name.Contains(tooName))
                {
                    Console.WriteLine("log for " + tooName + " FOUND in: " + file);
                    toonfile = file.FullName;
                    break;
                }

            }

            var lineCount = 0;
            while (true)
            {
                 
                string lastline = "null";

                try
                {
                    if (lineCount == File.ReadLines(toonfile).Count())
                    {
                        Console.WriteLine("no update wait 10sec");
                        Thread.Sleep(10000);
                    }
                    else
                    {
                        int a = (int)lineCount;
                        string linetoadd = File.ReadLines(toonfile).Skip(a).Take(1).First();
                        lineCount = a + 1;
                        lastline = (string)File.ReadAllText(toonfile);
                        line = lastline;
                        Console.WriteLine("update");
                        Console.WriteLine(linetoadd);
                        try
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                string newline = Environment.NewLine;
                                textBox1.AppendText(linetoadd + newline);
                            });
                        }
                        catch (System.InvalidOperationException)
                        {
                            isStop = true;
                            Console.WriteLine("closing threads");
                            break;
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("bad log access request");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class GLRSettings
    {
        public string logDir = "null";
        public List<string> toons = new List<string>();

    }



}
