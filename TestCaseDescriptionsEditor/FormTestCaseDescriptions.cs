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
                node.Nodes.Add(testCase.IsSelected ? "True" : "False");
                data = node.Nodes.Add("Data Items");
                foreach (KeyValuePair<string, string> pair in testCase.DataItems)
                {
                    data.Nodes.Add("Key: " + pair.Key);
                    data.Nodes.Add("Value: " + pair.Value);
                }
            }
            fullTree.Update();
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
            currTree.Nodes.Add(currentCase.IsSelected ? "True" : "False");
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
                currentCase = currentCases.Descriptions.Find(d => d.Title == e.Node.Text);
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
    }
}
