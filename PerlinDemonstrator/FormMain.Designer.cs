namespace PerlinDemonstrator
{
    partial class FormMain
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.codeRunnerHeightmap1 = new PerlinDemonstrator.CodeRunnerHeightmap();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.codeRunnerBiomes1 = new PerlinDemonstrator.CodeRunnerBiomes();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1266, 828);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.codeRunnerHeightmap1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1258, 800);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Heightmap";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // codeRunnerHeightmap1
            // 
            this.codeRunnerHeightmap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRunnerHeightmap1.Location = new System.Drawing.Point(3, 3);
            this.codeRunnerHeightmap1.LogFile = "last.txt";
            this.codeRunnerHeightmap1.Name = "codeRunnerHeightmap1";
            this.codeRunnerHeightmap1.SetupCode = "using PerlinDemonstrator;\nusing PerlinDemonstrator.JavaImports;\n\nfloat[,] data = " +
    "new float[512, 512];\nRandom rand = new(DateTime.Now.Ticks);";
            this.codeRunnerHeightmap1.Size = new System.Drawing.Size(1252, 794);
            this.codeRunnerHeightmap1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.codeRunnerBiomes1);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1258, 800);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Biomes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // codeRunnerBiomes1
            // 
            this.codeRunnerBiomes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeRunnerBiomes1.Location = new System.Drawing.Point(3, 3);
            this.codeRunnerBiomes1.LogFile = "last_biomes.txt";
            this.codeRunnerBiomes1.Name = "codeRunnerBiomes1";
            this.codeRunnerBiomes1.SetupCode = "using PerlinDemonstrator;\r\nusing PerlinDemonstrator.JavaImports;\r\n\r\nint data[,] =" +
    " [512, 512];";
            this.codeRunnerBiomes1.Size = new System.Drawing.Size(1252, 794);
            this.codeRunnerBiomes1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 828);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "PerlinDemonstrator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CodeRunnerHeightmap codeRunnerHeightmap1;
        private CodeRunnerBiomes codeRunnerBiomes1;
    }
}