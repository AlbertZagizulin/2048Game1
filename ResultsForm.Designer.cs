namespace _2048WinFormsApp
{
    partial class ResultsForm
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
            this.resultsTab = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTab)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsTab
            // 
            this.resultsTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsTab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.result});
            this.resultsTab.Location = new System.Drawing.Point(14, 10);
            this.resultsTab.Name = "resultsTab";
            this.resultsTab.RowHeadersWidth = 51;
            this.resultsTab.RowTemplate.Height = 24;
            this.resultsTab.Size = new System.Drawing.Size(308, 397);
            this.resultsTab.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(27, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.Width = 125;
            // 
            // result
            // 
            this.result.HeaderText = "Result";
            this.result.MinimumWidth = 6;
            this.result.Name = "result";
            this.result.Width = 125;
            // 
            // ResltsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultsTab);
            this.Text = "ResltsForm";
            this.Load += new System.EventHandler(this.ResltsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
    }
}