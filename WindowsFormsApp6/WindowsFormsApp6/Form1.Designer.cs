namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btExit = new System.Windows.Forms.Button();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.tmrPrekreslit = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.retryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(863, 0);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 0;
            this.btExit.TabStop = false;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // pbCanvas
            // 
            this.pbCanvas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pbCanvas.BackColor = System.Drawing.Color.White;
            this.pbCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCanvas.Location = new System.Drawing.Point(58, 54);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(771, 477);
            this.pbCanvas.TabIndex = 1;
            this.pbCanvas.TabStop = false;
            // 
            // tmrPrekreslit
            // 
            this.tmrPrekreslit.Tick += new System.EventHandler(this.tmrPrekreslit_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // retryToolStripMenuItem
            // 
            this.retryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retryToolStripMenuItem1});
            this.retryToolStripMenuItem.Name = "retryToolStripMenuItem";
            this.retryToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.retryToolStripMenuItem.Text = "Menu";
            // 
            // retryToolStripMenuItem1
            // 
            this.retryToolStripMenuItem1.Name = "retryToolStripMenuItem1";
            this.retryToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.retryToolStripMenuItem1.Text = "Retry";
            this.retryToolStripMenuItem1.Click += new System.EventHandler(this.retryToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(938, 577);
            this.Controls.Add(this.pbCanvas);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wall destroyer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer tmrPrekreslit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem retryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retryToolStripMenuItem1;
    }
}

