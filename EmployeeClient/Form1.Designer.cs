namespace EmployeeClient
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
            this.txtRestUri = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.lblRequestUri = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRestUri
            // 
            this.txtRestUri.Location = new System.Drawing.Point(12, 52);
            this.txtRestUri.Name = "txtRestUri";
            this.txtRestUri.Size = new System.Drawing.Size(421, 20);
            this.txtRestUri.TabIndex = 0;
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(12, 104);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(502, 260);
            this.txtResponse.TabIndex = 1;
            // 
            // btnGetAll
            // 
            this.btnGetAll.Location = new System.Drawing.Point(439, 49);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(75, 23);
            this.btnGetAll.TabIndex = 2;
            this.btnGetAll.Text = "Get Employees";
            this.btnGetAll.UseVisualStyleBackColor = true;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // lblRequestUri
            // 
            this.lblRequestUri.AutoSize = true;
            this.lblRequestUri.Location = new System.Drawing.Point(12, 36);
            this.lblRequestUri.Name = "lblRequestUri";
            this.lblRequestUri.Size = new System.Drawing.Size(69, 13);
            this.lblRequestUri.TabIndex = 3;
            this.lblRequestUri.Text = "Request URI";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(12, 88);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(55, 13);
            this.lblResponse.TabIndex = 4;
            this.lblResponse.Text = "Response";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 376);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.lblRequestUri);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRestUri);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRestUri;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Label lblRequestUri;
        private System.Windows.Forms.Label lblResponse;
    }
}

