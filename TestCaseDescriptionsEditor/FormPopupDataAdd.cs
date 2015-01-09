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
    public partial class FormPopupDataAdd : Form
    {
        string m_key;
        string m_value;
        Dictionary<string, string> m_dataitems;

        public string Key
        {
            get {return m_key;}
            set { m_key = value; }
        }

        public string Value
        {
            get { return m_value; }
            set { m_value = value; }
        }

        public FormPopupDataAdd(Dictionary<string,string> dataitems)
        {
            m_dataitems = dataitems;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m_key = textBoxKey.Text;
            m_value = textBoxValue.Text;
            if (!m_dataitems.ContainsKey(m_key))
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else if (m_key == "")
                MessageBox.Show("Input valid key.");
            else
                MessageBox.Show("Key already exists.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
