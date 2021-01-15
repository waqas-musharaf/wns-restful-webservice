namespace rest_client
{
    partial class ClientForm
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
            this.lblRequest = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cbRequest = new System.Windows.Forms.ComboBox();
            this.lblResponse = new System.Windows.Forms.Label();
            this.lblParams = new System.Windows.Forms.Label();
            this.txtParams = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblRequest
            // 
            this.lblRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequest.AutoSize = true;
            this.lblRequest.Location = new System.Drawing.Point(25, 13);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(65, 17);
            this.lblRequest.TabIndex = 0;
            this.lblRequest.Text = "Request:";
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(96, 67);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(374, 266);
            this.txtResponse.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(383, 9);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 24);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cbRequest
            // 
            this.cbRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRequest.FormattingEnabled = true;
            this.cbRequest.Location = new System.Drawing.Point(96, 9);
            this.cbRequest.Name = "cbRequest";
            this.cbRequest.Size = new System.Drawing.Size(281, 24);
            this.cbRequest.TabIndex = 5;
            this.cbRequest.SelectedIndexChanged += new System.EventHandler(this.cbRequest_SelectedIndexChanged);
            // 
            // lblResponse
            // 
            this.lblResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(14, 67);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(76, 17);
            this.lblResponse.TabIndex = 6;
            this.lblResponse.Text = "Response:";
            // 
            // lblParams
            // 
            this.lblParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParams.AutoSize = true;
            this.lblParams.Location = new System.Drawing.Point(5, 39);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(85, 17);
            this.lblParams.TabIndex = 7;
            this.lblParams.Text = "Parameters:";
            // 
            // txtParams
            // 
            this.txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParams.Location = new System.Drawing.Point(96, 39);
            this.txtParams.Name = "txtParams";
            this.txtParams.Size = new System.Drawing.Size(374, 22);
            this.txtParams.TabIndex = 8;
            this.txtParams.TextChanged += new System.EventHandler(this.txtParams_TextChanged);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 345);
            this.Controls.Add(this.txtParams);
            this.Controls.Add(this.lblParams);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.cbRequest);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.lblRequest);
            this.Name = "ClientForm";
            this.Text = "REST Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRequest;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cbRequest;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.TextBox txtParams;
    }
}

