using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Diagnostics;
using Microsoft.Win32;

namespace ThreeButtons
{
    public partial class Form1 : Form
    {
        string KeyAddress = "HKEY_CURRENT_USER\\Software\\NordsonTest";
        bool Finish = false;

        public Form1()
        {
            RegistryKey SubKey = Registry.CurrentUser.OpenSubKey("Software\\NordsonTest", false);
            // if the subkey is null means it's the first time to run this program on this machine.
            // so need to create subkey and key value in the registry.
            if (SubKey == null)
            {
                Registry.CurrentUser.CreateSubKey("Software\\NordsonTest");
                Registry.SetValue(KeyAddress, "Situation", "Yes");
            }


            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                InitializeComponent();
                this.Text = "Instance";
                NewRunTimer.Interval = 10;
            }
            else
            {

                // If new execution accrues, it changes the key value in the registry and the main form checks this key value
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    Registry.SetValue(KeyAddress, "Situation", "Yes");
                    Environment.Exit(0);
                    Application.Exit();
                }
                InitializeComponent();
                NewRunTimer.Interval = 100;
                this.Text = "Main";
            }
            NewRunTimer.Enabled = true;

        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            // hide the main Form or terminate other forms 
            if (this.Text == "Main")
            {
                this.Visible = false;
            }
            else
            {
                Application.Exit();
            }
        }

        private void btnNewInstance_Click(object sender, EventArgs e)
        {
            // start a new instance of this form with title of Instance
            System.Diagnostics.Process.Start("Threebuttons.exe", "Instance");
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            Registry.SetValue(KeyAddress, "Situation", "Close");
        }

        private void NewRunTimer_Tick(object sender, EventArgs e)
        {
            if (this.Text == "Main")
            {
                if (Registry.GetValue(KeyAddress, "Situation", "No").ToString() == "Yes")
                {
                    // New execution changes "Situation" key in registery and here we know that new execution happened. 
                    // then restore the main form and bring it to the top of Z-order
                    Registry.SetValue(KeyAddress, "Situation", "No");
                    this.Visible = true;
                    this.Activate();
                }

                if (Registry.GetValue(KeyAddress, "Situation", "No").ToString() == "Close" && Finish == true)
                {
                    Registry.SetValue(KeyAddress, "Situation", "No");
                    NewRunTimer.Enabled = false;
                    Application.ExitThread();
                    Environment.Exit(0);
                }

                if (Registry.GetValue(KeyAddress, "Situation", "No").ToString() == "Close" )
                {
                    Finish = true;
                }
            }
            else
            {
                if (Registry.GetValue(KeyAddress, "Situation", "No").ToString() == "Close")
                {
                    Application.Exit();
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "Main")
            {
                Visible = false;
                // Cancel the Closing event from closing the Main form.
                e.Cancel = true; 
            }
        }
    }
}
