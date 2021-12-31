namespace ClassWorkDialogWindowMonday
{
    partial class FindForm
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
            this.lbCurFolder = new System.Windows.Forms.Label();
            this.tbMask = new System.Windows.Forms.TextBox();
            this.btFind = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbCurFolder
            // 
            this.lbCurFolder.AutoSize = true;
            this.lbCurFolder.Location = new System.Drawing.Point(59, 9);
            this.lbCurFolder.Name = "lbCurFolder";
            this.lbCurFolder.Size = new System.Drawing.Size(73, 13);
            this.lbCurFolder.TabIndex = 0;
            this.lbCurFolder.Text = "CurrentFolder:";
            // 
            // tbMask
            // 
            this.tbMask.Location = new System.Drawing.Point(35, 41);
            this.tbMask.Name = "tbMask";
            this.tbMask.Size = new System.Drawing.Size(120, 20);
            this.tbMask.TabIndex = 1;
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(35, 82);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(120, 23);
            this.btFind.TabIndex = 2;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(35, 121);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(120, 199);
            this.listBox1.TabIndex = 3;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 340);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.tbMask);
            this.Controls.Add(this.lbCurFolder);
            this.Name = "FindForm";
            this.Text = "FindForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCurFolder;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.ListBox listBox1;
    }
}