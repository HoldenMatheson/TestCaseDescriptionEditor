﻿namespace TestCaseDescriptionsEditor
{
    partial class FormEditData
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
            this.components = new System.ComponentModel.Container();
            this.labelkey = new System.Windows.Forms.Label();
            this.labelvalue = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.listViewDataItems = new System.Windows.Forms.ListView();
            this.listViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelkey
            // 
            this.labelkey.AutoSize = true;
            this.labelkey.Location = new System.Drawing.Point(13, 13);
            this.labelkey.Name = "labelkey";
            this.labelkey.Size = new System.Drawing.Size(28, 13);
            this.labelkey.TabIndex = 0;
            this.labelkey.Text = "Key:";
            // 
            // labelvalue
            // 
            this.labelvalue.AutoSize = true;
            this.labelvalue.Location = new System.Drawing.Point(13, 36);
            this.labelvalue.Name = "labelvalue";
            this.labelvalue.Size = new System.Drawing.Size(37, 13);
            this.labelvalue.TabIndex = 1;
            this.labelvalue.Text = "Value:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(47, 10);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(145, 20);
            this.textBoxKey.TabIndex = 2;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(47, 33);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(145, 20);
            this.textBoxValue.TabIndex = 3;
            // 
            // listViewDataItems
            // 
            this.listViewDataItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key,
            this.Value});
            this.listViewDataItems.ContextMenuStrip = this.listViewMenuStrip;
            this.listViewDataItems.FullRowSelect = true;
            this.listViewDataItems.Location = new System.Drawing.Point(318, 13);
            this.listViewDataItems.MultiSelect = false;
            this.listViewDataItems.Name = "listViewDataItems";
            this.listViewDataItems.Size = new System.Drawing.Size(241, 200);
            this.listViewDataItems.TabIndex = 4;
            this.listViewDataItems.UseCompatibleStateImageBehavior = false;
            this.listViewDataItems.View = System.Windows.Forms.View.Details;
            this.listViewDataItems.SelectedIndexChanged += new System.EventHandler(this.listViewDataItems_SelectedIndexChanged);
            // 
            // listViewMenuStrip
            // 
            this.listViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniRemove});
            this.listViewMenuStrip.Name = "contextMenuStrip1";
            this.listViewMenuStrip.Size = new System.Drawing.Size(118, 26);
            this.listViewMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mniRemove
            // 
            this.mniRemove.Name = "mniRemove";
            this.mniRemove.Size = new System.Drawing.Size(117, 22);
            this.mniRemove.Text = "Remove";
            this.mniRemove.Click += new System.EventHandler(this.mniRemove_Click);
            // 
            // Key
            // 
            this.Key.Text = "Key";
            this.Key.Width = 83;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 154;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(16, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(117, 68);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FormEditData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 262);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listViewDataItems);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelvalue);
            this.Controls.Add(this.labelkey);
            this.Name = "FormEditData";
            this.Text = "FormEditData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditData_FormClosing);
            this.listViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelkey;
        private System.Windows.Forms.Label labelvalue;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mniRemove;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ListView listViewDataItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}