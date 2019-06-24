namespace ReExtractor
{
    partial class Status
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
            this.SrcLbl = new MetroFramework.Controls.MetroLabel();
            this.DestLbl = new MetroFramework.Controls.MetroLabel();
            this.SrcData = new MetroFramework.Controls.MetroLabel();
            this.DestData = new MetroFramework.Controls.MetroLabel();
            this.Bar = new MetroFramework.Controls.MetroProgressBar();
            this.Spinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.Cancel = new MetroFramework.Controls.MetroButton();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // SrcLbl
            // 
            this.SrcLbl.AutoSize = true;
            this.SrcLbl.Location = new System.Drawing.Point(23, 60);
            this.SrcLbl.Name = "SrcLbl";
            this.SrcLbl.Size = new System.Drawing.Size(56, 19);
            this.SrcLbl.TabIndex = 0;
            this.SrcLbl.Text = "&Source :";
            // 
            // DestLbl
            // 
            this.DestLbl.AutoSize = true;
            this.DestLbl.Location = new System.Drawing.Point(23, 79);
            this.DestLbl.Name = "DestLbl";
            this.DestLbl.Size = new System.Drawing.Size(80, 19);
            this.DestLbl.TabIndex = 1;
            this.DestLbl.Text = "&Destination :";
            // 
            // SrcData
            // 
            this.SrcData.AutoSize = true;
            this.SrcData.Location = new System.Drawing.Point(110, 60);
            this.SrcData.Name = "SrcData";
            this.SrcData.Size = new System.Drawing.Size(28, 19);
            this.SrcData.TabIndex = 2;
            this.SrcData.Text = "n/a";
            // 
            // DestData
            // 
            this.DestData.AutoSize = true;
            this.DestData.Location = new System.Drawing.Point(110, 79);
            this.DestData.Name = "DestData";
            this.DestData.Size = new System.Drawing.Size(28, 19);
            this.DestData.TabIndex = 3;
            this.DestData.Text = "n/a";
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(23, 114);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(296, 23);
            this.Bar.TabIndex = 4;
            // 
            // Spinner
            // 
            this.Spinner.Location = new System.Drawing.Point(359, 60);
            this.Spinner.Maximum = 100;
            this.Spinner.Name = "Spinner";
            this.Spinner.Size = new System.Drawing.Size(38, 38);
            this.Spinner.TabIndex = 5;
            this.Spinner.UseSelectable = true;
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.Transparent;
            this.Cancel.Location = new System.Drawing.Point(325, 114);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(72, 23);
            this.Cancel.TabIndex = 6;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseCustomBackColor = true;
            this.Cancel.UseSelectable = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 160);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Spinner);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.DestData);
            this.Controls.Add(this.SrcData);
            this.Controls.Add(this.DestLbl);
            this.Controls.Add(this.SrcLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Status";
            this.Text = "Status";
            this.Load += new System.EventHandler(this.Status_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel SrcLbl;
        private MetroFramework.Controls.MetroLabel DestLbl;
        private MetroFramework.Controls.MetroLabel SrcData;
        private MetroFramework.Controls.MetroLabel DestData;
        private MetroFramework.Controls.MetroProgressBar Bar;
        private MetroFramework.Controls.MetroProgressSpinner Spinner;
        private MetroFramework.Controls.MetroButton Cancel;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}