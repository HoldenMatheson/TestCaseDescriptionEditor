﻿using System;
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
    public partial class FormEditData : Form
    {
        Dictionary<string, string> m_dataitems;

        public Dictionary<string, string> DataItems
        {
            get { return m_dataitems; }
            set { m_dataitems = value; }
        }
        public FormEditData(Dictionary<string, string> dataitems)
        {
            m_dataitems = dataitems;
            InitializeComponent();
            PopulateList();
        }

        //Dictionary-List conversion is based off the dictionary key and listitem's names being the same
        private void PopulateList()
        {
            ListViewItem pair;
            listViewDataItems.Items.Clear();
            foreach(KeyValuePair<string, string> dataItemPair in m_dataitems)
            {
                pair = new ListViewItem(dataItemPair.Key);
                pair.SubItems.Add(dataItemPair.Value);
                listViewDataItems.Items.Add(pair);
            }
        }

        private void FormEditData_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNoCancel);
            if (msgResult == DialogResult.Cancel)
                e.Cancel = true;
            else
                this.DialogResult = msgResult;
        }

        private void mniRemove_Click(object sender, EventArgs e)
        {
            ListViewItem dataItem = listViewDataItems.SelectedItems[0];
            if (dataItem != null)
            {
                //listViewDataItems.Items.Remove(dataItem);
                m_dataitems.Remove(dataItem.Text);
                PopulateList();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            mniRemove.Enabled = (listViewDataItems.SelectedItems.Count > 0);
        }

        private void listViewDataItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text == "")
            {
                MessageBox.Show("Data item must have a key.");
            }
            else if (!m_dataitems.ContainsKey(textBoxKey.Text))
            {
                m_dataitems.Add(textBoxKey.Text, textBoxValue.Text);
                PopulateList();
            }
            else
            {
                MessageBox.Show("Data item already exists. Data items must have unique keys.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text == "")
            {
                MessageBox.Show("Data item must have a key.");
            }
            else if (m_dataitems.ContainsKey(textBoxKey.Text))
            {
                m_dataitems.Remove(textBoxKey.Text);
                PopulateList();
            }
            else
            {
                MessageBox.Show("Data item does not exist.");
            }
        }
    }
}
