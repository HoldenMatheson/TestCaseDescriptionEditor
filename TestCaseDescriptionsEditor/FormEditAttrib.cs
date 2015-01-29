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
    public partial class FormEditAttrib : Form
    {

        List<string> m_attributes;
        bool changesToSave;

        public FormEditAttrib(List<string> attributes)
        {
            m_attributes = attributes;
            changesToSave = false;
            InitializeComponent();
            PopulateList();
        }

        public List<string> Attributes
        {
            get {return m_attributes;}
            set {m_attributes = value;}
        }

        private void PopulateList()
        {
            listViewAttrib.Items.Clear();
            foreach (string attribute in m_attributes)
            {
                listViewAttrib.Items.Add(attribute);
            }
        }

        private void FormEditAttrib_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changesToSave)
            {
                DialogResult msgResult = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (msgResult == DialogResult.Cancel)
                    e.Cancel = true;
                else
                    this.DialogResult = msgResult;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mniAdd_Click(object sender, EventArgs e)
        {
            FormPopupAttribAdd popadd = new FormPopupAttribAdd(m_attributes);
            DialogResult popres = popadd.ShowDialog();
            if (popres == DialogResult.Yes)
            {
                m_attributes.Add(popadd.Attribute);
                changesToSave = true;
            }
            PopulateList();
        }

        private void mniEdit_Click(object sender, EventArgs e)
        {
            editAttrib();
        }

        private void mniRemove_Click(object sender, EventArgs e)
        {
            ListViewItem dataItem = listViewAttrib.SelectedItems[0];
            if (dataItem != null)
            {
                m_attributes.Remove(dataItem.Text);
                changesToSave = true;
                PopulateList();
            }
        }

        private void listViewMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            mniRemove.Enabled = (listViewAttrib.SelectedItems.Count > 0);
            mniEdit.Enabled = (listViewAttrib.SelectedItems.Count > 0);
        }

        private void listViewAttrib_DoubleClick(object sender, EventArgs e)
        {
            editAttrib();
        }

        private void editAttrib()
        {
            if (listViewAttrib.SelectedItems.Count > 0)
            {
                FormPopupAttribEdit popedit = new FormPopupAttribEdit(m_attributes, listViewAttrib.SelectedItems[0].Text);
                DialogResult popres = popedit.ShowDialog();
                if (popres == DialogResult.Yes)
                {
                    m_attributes.Remove(popedit.OldAttrib);
                    m_attributes.Add(popedit.Attrib);
                    PopulateList();
                    changesToSave = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAttrib.Text == "")
            {
                MessageBox.Show("Attribute must have a value.");
            }
            else if (!m_attributes.Contains(textBoxAttrib.Text))
            {
                m_attributes.Add(textBoxAttrib.Text);
                PopulateList();
                changesToSave = true;
            }
            else
            {
                MessageBox.Show("Attribute already exists.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (textBoxAttrib.Text == "")
            {
                MessageBox.Show("Attribute must have a value.");
            }
            else if (m_attributes.Contains(textBoxAttrib.Text))
            {
                m_attributes.Remove(textBoxAttrib.Text);
                PopulateList();
                changesToSave = true;
            }
            else
            {
                MessageBox.Show("Attribute does not exist.");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (textBoxAttrib.Text == "")
                MessageBox.Show("Attribute must have a value.");
            else if (listViewAttrib.SelectedItems.Count < 1)
                MessageBox.Show("No item to edit.");
            else if (textBoxAttrib.Text == listViewAttrib.SelectedItems[0].Text)
                MessageBox.Show("No changes to apply.");
            else if (m_attributes.Contains(textBoxAttrib.Text) && listViewAttrib.SelectedItems[0].Text != textBoxAttrib.Text)
                MessageBox.Show("Another data item with the same key already exists.");
            else
            {
                m_attributes.Remove(listViewAttrib.SelectedItems[0].Text);
                m_attributes.Add(textBoxAttrib.Text);
                PopulateList();
                changesToSave = true;
            }
        }
    }
}
