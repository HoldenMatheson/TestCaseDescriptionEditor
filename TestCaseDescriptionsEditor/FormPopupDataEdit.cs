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
    public partial class FormPopupDataEdit : Form
    {
        string m_oldkey;
        string m_key;
        string m_value;
        Dictionary<string, string> m_dataitems;

        public string OldKey
        {
            get { return m_oldkey; }
        }

        public string Key
        {
            get {return m_key;}
        }

        public string Value
        {
            get { return m_value; }
        }

        public FormPopupDataEdit(Dictionary<string,string> dataitems, string key, string value)
        {
            m_dataitems = dataitems;
            m_oldkey = key;
            m_value = value;
            InitializeComponent();
            textBoxKey.Text = key;
            textBoxValue.Text = value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            m_key = textBoxKey.Text;
            m_value = textBoxValue.Text;
            if (!m_dataitems.ContainsKey(m_key) || m_oldkey.Equals(m_key))
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
