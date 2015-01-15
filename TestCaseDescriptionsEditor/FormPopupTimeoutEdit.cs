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
    public partial class FormPopupTimeoutEdit : Form
    {
        int m_timeout;

        public int Timeout
        {
            get { return m_timeout; }
        }

        public FormPopupTimeoutEdit(int timeout)
        {
            m_timeout = timeout;
            InitializeComponent();
            textTimeout.Text = timeout.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textTimeout.Text, out m_timeout))
            {
                MessageBox.Show("Input valid timeout.");
            }
            else
            {
                if (m_timeout > -1)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                    MessageBox.Show("Invalid timeout.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
