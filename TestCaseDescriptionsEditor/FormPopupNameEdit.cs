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
    public partial class FormPopupNameEdit : Form
    {
        string m_name;
        string m_oldname;
        List<TestCaseDescription> m_cases;

        public string OldName
        {
            get { return m_oldname; }
        }

        public string CaseName
        {
            get { return m_name; }
        }

        public FormPopupNameEdit(List<TestCaseDescription> cases, string name)
        {
            m_oldname = name;
            m_cases = cases;
            InitializeComponent();
            textName.Text = name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            m_name = textName.Text;
            bool duplicate = false;
            foreach(TestCaseDescription testCase in m_cases)
            {
                if (testCase.Name.Equals(m_name) && !m_name.Equals(m_oldname))
                {
                    duplicate = true;
                    MessageBox.Show("Another test case already has that name.");
                }
            }
            if(!duplicate)
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
