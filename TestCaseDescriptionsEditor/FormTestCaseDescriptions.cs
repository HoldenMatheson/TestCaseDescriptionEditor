using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TestCaseDescriptionsEditor
{
    public partial class FormTestCaseDescriptions : Form
    {
        TestCaseDescriptions currentCases = new TestCaseDescriptions();
        TestCaseDescription currentCase;
        String errorMessage;

        public FormTestCaseDescriptions()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult diagResult = openFile.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                String filename = openFile.FileName;
                currentCases.LoadXML(filename, out errorMessage);
                PopulateTree();
            }
        }

        private void PopulateTree()
        {
            // Node names used to parse nodes to data structure. Changing node names may require
            // changes to fullTree_NodeMouseDoubleClick
            fullTree.Nodes.Clear();
            TreeNode node = new TreeNode();
            TreeNode attrib = new TreeNode();
            TreeNode data = new TreeNode();
            TreeNode root = new TreeNode();
            root = fullTree.Nodes.Add("TestCaseDescriptions");
            foreach(TestCaseDescription testCase in currentCases.Descriptions)
            {
                node = root.Nodes.Add(testCase.Title);
                node.Nodes.Add("Name: " +    testCase.Name);
                node.Nodes.Add("Title: " +   testCase.Title);
                node.Nodes.Add("Timeout: " + testCase.Timeout.ToString());
                attrib = node.Nodes.Add("Attributes");
                foreach (String attribute in testCase.Attributes)
                {
                    attrib.Nodes.Add(attribute);
                }
                node.Nodes.Add("Selected: " + (testCase.IsSelected ? "True" : "False"));
                data = node.Nodes.Add("Data Items");
                foreach (KeyValuePair<string, string> pair in testCase.DataItems)
                {
                    data.Nodes.Add("Key: " + pair.Key);
                    data.Nodes.Add("Value: " + pair.Value);
                }
            }
            fullTree.Nodes[0].Expand();
        }

        private void PopulateCurrentTree()
        {
            currTree.Nodes.Clear();
            TreeNode attrib = new TreeNode();
            TreeNode data = new TreeNode();
            currTree.Nodes.Add("Name: " + currentCase.Name);
            currTree.Nodes.Add("Title: " + currentCase.Title);
            currTree.Nodes.Add("Timeout: " + currentCase.Timeout.ToString());
            attrib = currTree.Nodes.Add("Attributes");
            foreach (String attribute in currentCase.Attributes)
            {
                attrib.Nodes.Add(attribute);
            }
            currTree.Nodes.Add("Selected: " + (currentCase.IsSelected ? "True" : "False"));
            data = currTree.Nodes.Add("Data Items");
            foreach (KeyValuePair<string, string> pair in currentCase.DataItems)
            {
                data.Nodes.Add("Key: " + pair.Key);
                data.Nodes.Add("Value: " + pair.Value);
            }
        }

        private void fullTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.Contains(e.Location))
            {
                TreeNode parentCase = e.Node;
                while (parentCase.Parent != null && parentCase.Parent.Text != "TestCaseDescriptions")
                {
                    parentCase = parentCase.Parent;
                }
                if (parentCase.Parent != null)
                    currentCase = currentCases.Descriptions.Find(d => d.Title == parentCase.Text);
                if (currentCase != null)
                {
                    txtName.Text = currentCase.Name;
                    txtTitle.Text = currentCase.Title;
                    PopulateCurrentTree();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            DialogResult diagResult = saveFile.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                String filename = saveFile.FileName;
                currentCases.SaveAsXML(filename, out errorMessage);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                currentCases.MoveUp(currentCase, out errorMessage);
                PopulateTree();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                currentCases.MoveDown(currentCase, out errorMessage);
                PopulateTree();
            }
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                currentCases.Remove(currentCase, out errorMessage);
                PopulateTree();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                currentCase.Name = txtName.Text;
                currentCase.Title = txtTitle.Text;
                PopulateTree();
            }
            else
                MessageBox.Show("No test case selected.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentCase = new TestCaseDescription();
            currentCases.Add(currentCase, out errorMessage);
            PopulateTree();
            currentCase = currentCases.Descriptions.Find(d => d.Title == "");
            if (currentCase != null)
            {
                txtName.Text = currentCase.Name;
                txtTitle.Text = currentCase.Title;
                currentCases.SelectedItem = currentCase;
                PopulateCurrentTree();
            }
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            editData();
        }

        private void editData()
        {
            DialogResult saveResult;
            if (currentCase != null)
            {
                Dictionary<string, string> dataItems = new Dictionary<string, string>(currentCase.DataItems);
                FormEditData dataWindow = new FormEditData(dataItems);
                saveResult = dataWindow.ShowDialog();
                switch (saveResult)
                {
                    case DialogResult.Yes:
                        currentCase.DataItems = dataWindow.DataItems;
                        break;
                    default:
                        break;
                }
                PopulateTree();
            }
            else
            {
                MessageBox.Show("Select a test case first.", "Error: No test case");
            }
        }

        private void editAttrib()
        {
            DialogResult saveResult;
            if (currentCase != null)
            {
                List<String> attributes = new List<String>(currentCase.Attributes);
                FormEditAttrib attribWindow = new FormEditAttrib(attributes);
                saveResult = attribWindow.ShowDialog();
                switch (saveResult)
                {
                    case DialogResult.Yes:
                        currentCase.Attributes = attribWindow.Attributes;
                        break;
                    default:
                        break;
                }
                PopulateTree();
            }
            else
            {
                MessageBox.Show("Select a test case first.", "Error: No test case");
            }
        }

        private void fullTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.Contains(e.Location) && e.Node.Parent != null)
            {
                DialogResult popres;
                // If double clicked a data item, open it for editing
                if (e.Node.Parent.Text.Equals("Data Items"))
                {
                    if (e.Node.Text.StartsWith("Key: "))
                    {
                        FormPopupDataEdit popedit = new FormPopupDataEdit(currentCase.DataItems, e.Node.Text.Substring(5),e.Node.NextNode.Text.Substring(7));
                        popres = popedit.ShowDialog();
                        if (popres == DialogResult.Yes)
                        {
                            currentCase.DataItems.Remove(popedit.OldKey);
                            currentCase.DataItems.Add(popedit.Key, popedit.Value);
                            PopulateTree();
                            PopulateCurrentTree();
                        }
                    }
                    else if (e.Node.Text.StartsWith("Value: "))
                    {
                        FormPopupDataEdit popedit = new FormPopupDataEdit(currentCase.DataItems, e.Node.PrevNode.Text.Substring(5), e.Node.Text.Substring(7));
                        popres = popedit.ShowDialog();
                        if (popres == DialogResult.Yes)
                        {
                            currentCase.DataItems.Remove(popedit.OldKey);
                            currentCase.DataItems.Add(popedit.Key, popedit.Value);
                            PopulateTree();
                            PopulateCurrentTree();
                        }
                    }
                    else
                        MessageBox.Show("Malformed Data Item: " + e.Node.Text);
                    
                }
                else if(e.Node.Text.Equals("Data Items"))
                {
                    editData();
                }
            }
        }

        private void btnEditAttrib_Click(object sender, EventArgs e)
        {
            editAttrib();
        }
    }
}
