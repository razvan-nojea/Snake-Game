namespace atestat
{
    partial class Joc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Joc));
            this.btnPause = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.Panel();
            this.lblPauza = new System.Windows.Forms.Label();
            this.btnContinua = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPause.FlatAppearance.BorderSize = 3;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(6, 4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(82, 34);
            this.btnPause.TabIndex = 41;
            this.btnPause.Tag = "turquoise";
            this.btnPause.Text = "Pauza";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(123, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 23);
            this.lblUser.TabIndex = 46;
            this.lblUser.Text = "User: ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(364, 12);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(71, 23);
            this.lblScore.TabIndex = 47;
            this.lblScore.Text = "Scor: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(631, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Timp:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(711, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(59, 23);
            this.lblTime.TabIndex = 49;
            this.lblTime.Text = "00:00";
            // 
            // grid
            // 
            this.grid.BackColor = System.Drawing.Color.LightGray;
            this.grid.Controls.Add(this.lblPauza);
            this.grid.Controls.Add(this.btnContinua);
            this.grid.Controls.Add(this.btnBack);
            this.grid.Location = new System.Drawing.Point(0, 51);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(900, 600);
            this.grid.TabIndex = 0;
            this.grid.VisibleChanged += new System.EventHandler(this.grid_VisibleChanged);
            // 
            // lblPauza
            // 
            this.lblPauza.AutoSize = true;
            this.lblPauza.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPauza.Location = new System.Drawing.Point(346, 80);
            this.lblPauza.Name = "lblPauza";
            this.lblPauza.Size = new System.Drawing.Size(220, 77);
            this.lblPauza.TabIndex = 45;
            this.lblPauza.Text = "Pauza";
            this.lblPauza.Visible = false;
            // 
            // btnContinua
            // 
            this.btnContinua.BackColor = System.Drawing.Color.SeaGreen;
            this.btnContinua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinua.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnContinua.FlatAppearance.BorderSize = 3;
            this.btnContinua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinua.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinua.Location = new System.Drawing.Point(368, 200);
            this.btnContinua.Name = "btnContinua";
            this.btnContinua.Size = new System.Drawing.Size(170, 87);
            this.btnContinua.TabIndex = 44;
            this.btnContinua.Tag = "turquoise";
            this.btnContinua.Text = "Continua";
            this.btnContinua.UseVisualStyleBackColor = false;
            this.btnContinua.Visible = false;
            this.btnContinua.Click += new System.EventHandler(this.btnContinua_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.BorderSize = 3;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(368, 326);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 87);
            this.btnBack.TabIndex = 43;
            this.btnBack.Tag = "turquoise";
            this.btnBack.Text = "Inapoi la meniu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 10);
            this.panel1.TabIndex = 46;
            // 
            // Joc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.grid);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Joc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Joc_KeyDown);
            this.grid.ResumeLayout(false);
            this.grid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel grid;
        private System.Windows.Forms.Label lblPauza;
        private System.Windows.Forms.Button btnContinua;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel panel1;
    }
}