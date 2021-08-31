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
using System.Threading;
using Microsoft.Win32;

namespace ThreeButtons
{
    public partial class Form1 : Form
    {
        string KeyAddress = "HKEY_CURRENT_USER\\Software\\NordsonTest";

        public Form1()
        {
            RegistryKey SubKey = Registry.CurrentUser.OpenSubKey("Software\\NordsonTest", false);
            // if the subkey is null means it's the first time to run this program on this machine.
            // so need to create subkey and key value in the registry.
            if (SubKey == null)
            {
                Registry.CurrentUser.CreateSubKey("Software\\NordsonTest");
                Registry.SetValue(KeyAddress, "NewExecution", "Yes");
            }

            // If new execution accrues, it changes the key value in the registry and the main form checks this key value
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                Registry.SetValue(KeyAddress, "NewExecution", "Yes");
                Environment.Exit(0);
                Application.Exit();
            }
            InitializeComponent();
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
                Application.ExitThread();
            }
        }

        private void btnNewInstance_Click(object sender, EventArgs e)
        {
            // starta new instance of this form with title of Instance
            new Thread(() => {
                Form1 NewForm = new Form1();
                NewForm.Text = "Instance";
                Application.Run(NewForm);

            }).Start();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void NewRunTimer_Tick(object sender, EventArgs e)
        {
            if (this.Text == "Main")
            {
                if (Registry.GetValue(KeyAddress, "NewExecution", "No").ToString() == "Yes")
                {
                    // New execution changes "NewExecution" key in registery and here we know that new execution happened. 
                    // then restore the main form and bring it to the top of Z-order
                    Registry.SetValue(KeyAddress, "NewExecution", "No");
                    this.Visible = true;
                    this.Activate();
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
