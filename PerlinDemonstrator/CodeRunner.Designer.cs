namespace PerlinDemonstrator
{
    partial class CodeRunner<T>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.inputTable = new System.Windows.Forms.TableLayoutPanel();
            this.labelSetupVariables = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.labelReturnVariables = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.resultsDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.inputTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.inputTable);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.resultsDisplay);
            this.splitContainer.Size = new System.Drawing.Size(1042, 798);
            this.splitContainer.SplitterDistance = 357;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.TabStop = false;
            // 
            // inputTable
            // 
            this.inputTable.ColumnCount = 1;
            this.inputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTable.Controls.Add(this.labelSetupVariables, 0, 0);
            this.inputTable.Controls.Add(this.codeBox, 0, 1);
            this.inputTable.Controls.Add(this.labelReturnVariables, 0, 2);
            this.inputTable.Controls.Add(this.btnExecute, 0, 3);
            this.inputTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTable.Location = new System.Drawing.Point(0, 0);
            this.inputTable.Name = "inputTable";
            this.inputTable.RowCount = 4;
            this.inputTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.inputTable.Size = new System.Drawing.Size(357, 798);
            this.inputTable.TabIndex = 0;
            // 
            // labelSetupVariables
            // 
            this.labelSetupVariables.AutoSize = true;
            this.labelSetupVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSetupVariables.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSetupVariables.Location = new System.Drawing.Point(3, 0);
            this.labelSetupVariables.Name = "labelSetupVariables";
            this.labelSetupVariables.Size = new System.Drawing.Size(351, 14);
            this.labelSetupVariables.TabIndex = 0;
            // 
            // codeBox
            // 
            this.codeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.codeBox.Location = new System.Drawing.Point(3, 17);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.codeBox.Size = new System.Drawing.Size(351, 733);
            this.codeBox.TabIndex = 1;
            this.codeBox.TabStop = false;
            // 
            // labelReturnVariables
            // 
            this.labelReturnVariables.AutoSize = true;
            this.labelReturnVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelReturnVariables.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelReturnVariables.Location = new System.Drawing.Point(3, 753);
            this.labelReturnVariables.Name = "labelReturnVariables";
            this.labelReturnVariables.Size = new System.Drawing.Size(351, 14);
            this.labelReturnVariables.TabIndex = 2;
            this.labelReturnVariables.Text = "return data;";
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecute.Location = new System.Drawing.Point(3, 770);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(351, 25);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.TabStop = false;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // resultsDisplay
            // 
            this.resultsDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsDisplay.Location = new System.Drawing.Point(0, 0);
            this.resultsDisplay.Name = "resultsDisplay";
            this.resultsDisplay.Size = new System.Drawing.Size(681, 798);
            this.resultsDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.resultsDisplay.TabIndex = 0;
            this.resultsDisplay.TabStop = false;
            // 
            // CodeRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CodeRunner";
            this.Size = new System.Drawing.Size(1042, 798);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.inputTable.ResumeLayout(false);
            this.inputTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer;
        private TableLayoutPanel inputTable;
        private Label labelSetupVariables;
        private TextBox codeBox;
        private Label labelReturnVariables;
        private Button btnExecute;
        private PictureBox resultsDisplay;
    }
}
