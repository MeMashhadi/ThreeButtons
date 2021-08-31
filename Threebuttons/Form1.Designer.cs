namespace ThreeButtons
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.btnNewInstance = new System.Windows.Forms.Button();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.NewRunTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnTerminate
            // 
            this.btnTerminate.Location = new System.Drawing.Point(12, 134);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(75, 23);
            this.btnTerminate.TabIndex = 0;
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // btnNewInstance
            // 
            this.btnNewInstance.Location = new System.Drawing.Point(93, 134);
            this.btnNewInstance.Name = "btnNewInstance";
            this.btnNewInstance.Size = new System.Drawing.Size(97, 23);
            this.btnNewInstance.TabIndex = 1;
            this.btnNewInstance.Text = "New Instance";
            this.btnNewInstance.UseVisualStyleBackColor = true;
            this.btnNewInstance.Click += new System.EventHandler(this.btnNewInstance_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Location = new System.Drawing.Point(196, 134);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(75, 23);
            this.btnCloseAll.TabIndex = 2;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // NewRunTimer
            // 
            this.NewRunTimer.Tick += new System.EventHandler(this.NewRunTimer_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(278, 166);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.btnNewInstance);
            this.Controls.Add(this.btnTerminate);
            this.Name = "Form1";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Button btnNewInstance;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Timer NewRunTimer;
    }
}

