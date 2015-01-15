namespace TestCaseDescriptionsEditor
{
    partial class FormTestCaseDescriptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditData = new System.Windows.Forms.Button();
            this.btnEditAttrib = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.currTree = new System.Windows.Forms.TreeView();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.fullTree = new System.Windows.Forms.TreeView();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(38, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(295, 20);
            this.txtName.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(38, 91);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(295, 20);
            this.txtTitle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title:";
            // 
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(38, 128);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(109, 23);
            this.btnEditData.TabIndex = 5;
            this.btnEditData.Text = "Edit Data Items";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // btnEditAttrib
            // 
            this.btnEditAttrib.Location = new System.Drawing.Point(38, 158);
            this.btnEditAttrib.Name = "btnEditAttrib";
            this.btnEditAttrib.Size = new System.Drawing.Size(109, 23);
            this.btnEditAttrib.TabIndex = 6;
            this.btnEditAttrib.Text = "Edit Attributes";
            this.btnEditAttrib.UseVisualStyleBackColor = true;
            this.btnEditAttrib.Click += new System.EventHandler(this.btnEditAttrib_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Current:";
            // 
            // currTree
            // 
            this.currTree.Location = new System.Drawing.Point(38, 221);
            this.currTree.Name = "currTree";
            this.currTree.Size = new System.Drawing.Size(272, 117);
            this.currTree.TabIndex = 8;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(393, 549);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 9;
            this.btnMoveUp.Text = "Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(97, 549);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 549);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(488, 548);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 12;
            this.btnMoveDown.Text = "Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(584, 548);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(75, 23);
            this.btnKill.TabIndex = 13;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // fullTree
            // 
            this.fullTree.Location = new System.Drawing.Point(393, 48);
            this.fullTree.Name = "fullTree";
            this.fullTree.Size = new System.Drawing.Size(523, 494);
            this.fullTree.TabIndex = 14;
            this.fullTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fullTree_NodeMouseClick);
            this.fullTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.fullTree_NodeMouseDoubleClick);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(186, 158);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(134, 23);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(97, 519);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FormTestCaseDescriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 608);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.fullTree);
            this.Controls.Add(this.btnKill);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.currTree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEditAttrib);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTestCaseDescriptions";
            this.Text = "XML Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.Button btnEditAttrib;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView currTree;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.TreeView fullTree;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnAdd;
    }
}

