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
    public partial class FormPopupAttribAdd : Form
    {

        string m_attrib;
        List<string> m_attributes;

        public string Attribute
        {
            get { return m_attrib; }
        }

        public FormPopupAttribAdd(List<string> Attributes)
        {
            m_attributes = Attributes;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m_attrib = textAttrib.Text;
            if (m_attrib == "")
            {
                MessageBox.Show("Input valid attribute.");
            }
            else if (!m_attributes.Contains(m_attrib))
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
                MessageBox.Show("Attribute already exists.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
