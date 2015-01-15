namespace TestCaseDescriptionsEditor
{
    partial class FormEditAttrib
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
            this.btnDone = new System.Windows.Forms.Button();
            this.listViewAttrib = new System.Windows.Forms.ListView();
            this.Attribs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mniAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mniEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(103, 227);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 1;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // listViewAttrib
            // 
            this.listViewAttrib.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Attribs});
            this.listViewAttrib.ContextMenuStrip = this.listViewMenuStrip;
            this.listViewAttrib.FullRowSelect = true;
            this.listViewAttrib.Location = new System.Drawing.Point(13, 13);
            this.listViewAttrib.MultiSelect = false;
            this.listViewAttrib.Name = "listViewAttrib";
            this.listViewAttrib.Size = new System.Drawing.Size(259, 208);
            this.listViewAttrib.TabIndex = 2;
            this.listViewAttrib.UseCompatibleStateImageBehavior = false;
            this.listViewAttrib.View = System.Windows.Forms.View.Details;
            this.listViewAttrib.DoubleClick += new System.EventHandler(this.listViewAttrib_DoubleClick);
            // 
            // Attribs
            // 
            this.Attribs.Text = "Attributes";
            this.Attribs.Width = 255;
            // 
            // listViewMenuStrip
            // 
            this.listViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAdd,
            this.mniEdit,
            this.mniRemove});
            this.listViewMenuStrip.Name = "listViewMenuStrip";
            this.listViewMenuStrip.Size = new System.Drawing.Size(118, 70);
            this.listViewMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.listViewMenuStrip_Opening);
            // 
            // mniAdd
            // 
            this.mniAdd.Name = "mniAdd";
            this.mniAdd.Size = new System.Drawing.Size(117, 22);
            this.mniAdd.Text = "Add";
            this.mniAdd.Click += new System.EventHandler(this.mniAdd_Click);
            // 
            // mniEdit
            // 
            this.mniEdit.Name = "mniEdit";
            this.mniEdit.Size = new System.Drawing.Size(117, 22);
            this.mniEdit.Text = "Edit";
            this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
            // 
            // mniRemove
            // 
            this.mniRemove.Name = "mniRemove";
            this.mniRemove.Size = new System.Drawing.Size(117, 22);
            this.mniRemove.Text = "Remove";
            this.mniRemove.Click += new System.EventHandler(this.mniRemove_Click);
            // 
            // FormEditAttrib
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.listViewAttrib);
            this.Controls.Add(this.btnDone);
            this.Name = "FormEditAttrib";
            this.Text = "Edit Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditAttrib_FormClosing);
            this.listViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ListView listViewAttrib;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniEdit;
        private System.Windows.Forms.ToolStripMenuItem mniRemove;
        private System.Windows.Forms.ColumnHeader Attribs;
    }
}