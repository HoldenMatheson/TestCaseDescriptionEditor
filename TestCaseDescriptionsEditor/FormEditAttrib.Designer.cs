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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAttrib = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(54, 108);
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
            this.listViewAttrib.Location = new System.Drawing.Point(190, 10);
            this.listViewAttrib.MultiSelect = false;
            this.listViewAttrib.Name = "listViewAttrib";
            this.listViewAttrib.Size = new System.Drawing.Size(259, 121);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Attribute: ";
            // 
            // textBoxAttrib
            // 
            this.textBoxAttrib.Location = new System.Drawing.Point(71, 10);
            this.textBoxAttrib.Name = "textBoxAttrib";
            this.textBoxAttrib.Size = new System.Drawing.Size(100, 20);
            this.textBoxAttrib.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(34, 50);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(116, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 79);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FormEditAttrib
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 142);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.textBoxAttrib);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewAttrib);
            this.Controls.Add(this.btnDone);
            this.Name = "FormEditAttrib";
            this.Text = "Edit Attributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditAttrib_FormClosing);
            this.listViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ListView listViewAttrib;
        private System.Windows.Forms.ContextMenuStrip listViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mniAdd;
        private System.Windows.Forms.ToolStripMenuItem mniEdit;
        private System.Windows.Forms.ToolStripMenuItem mniRemove;
        private System.Windows.Forms.ColumnHeader Attribs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAttrib;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}