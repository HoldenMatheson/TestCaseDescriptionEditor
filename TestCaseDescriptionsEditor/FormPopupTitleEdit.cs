using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseDescriptionsEditor
{
    public partial class FormPopupTitleEdit : Form
    {
        string m_title;

        public string Title
        {
            get { return m_title; }
        }

        public FormPopupTitleEdit(string title)
        {
            m_title = title;
            InitializeComponent();
            textTitle.Text = Title;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            m_title = textTitle.Text;
            if (m_title == "")
            {
                MessageBox.Show("Input valid title.");
            }
            else 
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
