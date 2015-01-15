namespace TestCaseDescriptionsEditor
{
    partial class FormPopupDataAdd
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelvalue = new System.Windows.Forms.Label();
            this.labelkey = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(47, 35);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(145, 20);
            this.textBoxValue.TabIndex = 9;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(47, 12);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(145, 20);
            this.textBoxKey.TabIndex = 8;
            // 
            // labelvalue
            // 
            this.labelvalue.AutoSize = true;
            this.labelvalue.Location = new System.Drawing.Point(13, 38);
            this.labelvalue.Name = "labelvalue";
            this.labelvalue.Size = new System.Drawing.Size(37, 13);
            this.labelvalue.TabIndex = 7;
            this.labelvalue.Text = "Value:";
            // 
            // labelkey
            // 
            this.labelkey.AutoSize = true;
            this.labelkey.Location = new System.Drawing.Point(13, 15);
            this.labelkey.Name = "labelkey";
            this.labelkey.Size = new System.Drawing.Size(28, 13);
            this.labelkey.TabIndex = 6;
            this.labelkey.Text = "Key:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(117, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormPopupDataAdd
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(215, 97);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelvalue);
            this.Controls.Add(this.labelkey);
            this.Name = "FormPopupDataAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Data Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label labelvalue;
        private System.Windows.Forms.Label labelkey;
        private System.Windows.Forms.Button btnCancel;
    }
}