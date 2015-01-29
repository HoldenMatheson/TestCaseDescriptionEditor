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
        string currentFilename;

        //Tree prefixes and names used for node identification
        const string treePrefixName     = "Name: ";
        const string treePrefixTitle    = "Title: ";
        const string treePrefixTimeout  = "Timeout: ";
        const string treePrefixSelected = "Selected: ";
        const string treePrefixKey      = "Key: ";
        const string treePrefixValue    = "Value: ";
        const string treeNameRoot       = "TestCaseDescriptions";
        const string treeNameAttributes = "Attributes";
        const string treeNameDataItems  = "Data Items";
        const string defaultFileName    = "TestCaseDescriptions";

        public FormTestCaseDescriptions()
        {
            InitializeComponent();
            currentFilename = null;
        }

        private void PopulateTree()
        {
            fullTree.Nodes.Clear();
            TreeNode node = new TreeNode();
            TreeNode attrib = new TreeNode();
            TreeNode data = new TreeNode();
            TreeNode root = new TreeNode();
            root = fullTree.Nodes.Add(treeNameRoot);
            foreach(TestCaseDescription testCase in currentCases.Descriptions)
            {
                node = root.Nodes.Add(testCase.Title);
                node.Nodes.Add(treePrefixName    + testCase.Name);
                node.Nodes.Add(treePrefixTitle   + testCase.Title);
                node.Nodes.Add(treePrefixTimeout + testCase.Timeout.ToString());
                attrib = node.Nodes.Add(treeNameAttributes);
                foreach (String attribute in testCase.Attributes)
                {
                    attrib.Nodes.Add(attribute);
                }
                node.Nodes.Add(treePrefixSelected + (testCase.IsSelected ? "True" : "False"));
                data = node.Nodes.Add(treeNameDataItems);
                foreach (KeyValuePair<string, string> pair in testCase.DataItems)
                {
                    data.Nodes.Add(treePrefixKey + pair.Key);
                    data.Nodes.Add(treePrefixValue + pair.Value);
                }
            }
            fullTree.Nodes[0].Expand();
        }

        private void PopulateCurrentTree()
        {
            currTree.Nodes.Clear();
            TreeNode attrib = new TreeNode();
            TreeNode data = new TreeNode();
            currTree.Nodes.Add(treePrefixName    + currentCase.Name);
            currTree.Nodes.Add(treePrefixTitle   + currentCase.Title);
            currTree.Nodes.Add(treePrefixTimeout + currentCase.Timeout.ToString());
            attrib = currTree.Nodes.Add(treeNameAttributes);
            foreach (String attribute in currentCase.Attributes)
            {
                attrib.Nodes.Add(attribute);
            }
            currTree.Nodes.Add(treePrefixSelected + (currentCase.IsSelected ? "True" : "False"));
            data = currTree.Nodes.Add(treeNameDataItems);
            foreach (KeyValuePair<string, string> pair in currentCase.DataItems)
            {
                data.Nodes.Add(treePrefixKey   + pair.Key);
                data.Nodes.Add(treePrefixValue + pair.Value);
            }
        }

        private void fullTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.Contains(e.Location))
            {
                fullTree.SelectedNode = e.Node;
                TreeNode parentCase = e.Node;
                while (parentCase.Parent != null && parentCase.Parent.Text != treeNameRoot)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult diagResult = openFile.ShowDialog();
            if (diagResult == DialogResult.OK)
            {
                currentFilename = openFile.SafeFileName;
                currentCases.LoadXML(openFile.FileName, out errorMessage);
                PopulateTree();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            //Default filename is the current file name or defaultFileName
            saveFile.FileName = (currentFilename == null) ? defaultFileName : currentFilename;
            saveFile.DefaultExt = "xml";
            saveFile.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
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
            addTest();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            editData();
        }

        private void btnEditAttrib_Click(object sender, EventArgs e)
        {
            editAttrib();
        }

        private void addTest()
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

        private void editName()
        {
            FormPopupNameEdit popedit = new FormPopupNameEdit(currentCases.Descriptions, currentCase.Name);
            DialogResult popres = popedit.ShowDialog();
            if (popres == DialogResult.Yes)
            {
                currentCase.Name = popedit.CaseName;
                PopulateTree();
            }
        }

        private void editTitle()
        {
            FormPopupTitleEdit popedit = new FormPopupTitleEdit(currentCase.Title);
            DialogResult popres = popedit.ShowDialog();
            if (popres == DialogResult.Yes)
            {
                currentCase.Title = popedit.Title;
                PopulateTree();
            }
        }

        private void editTimeout()
        {
            FormPopupTimeoutEdit popedit = new FormPopupTimeoutEdit(currentCase.Timeout);
            DialogResult popres = popedit.ShowDialog();
            if (popres == DialogResult.Yes)
            {
                currentCase.Timeout = popedit.Timeout;
                PopulateTree();
            }
        }

        private void editAttribute()
        {
            FormPopupAttribEdit popedit = new FormPopupAttribEdit(currentCase.Attributes, fullTree.SelectedNode.Text);
            DialogResult popres = popedit.ShowDialog();
            if (popres == DialogResult.Yes)
            {
                int index = currentCase.Attributes.IndexOf(popedit.OldAttrib);
                currentCase.Attributes[index] = popedit.Attrib;
                PopulateTree();
            }
        }

        private void fullTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.Contains(e.Location) && e.Node.Parent != null)
            {
                DialogResult popres;
                if (e.Node.Parent.Text.Equals(treeNameDataItems))
                {
                    FormPopupDataEdit popedit = null;

                    // Selects the proper data item regardless of whether they clicked on the Key or Value
                    if (e.Node.Text.StartsWith(treePrefixKey))
                        popedit = new FormPopupDataEdit(currentCase.DataItems, e.Node.Text.Substring(5), e.Node.NextNode.Text.Substring(7));
                    else if (e.Node.Text.StartsWith(treePrefixValue))
                        popedit = new FormPopupDataEdit(currentCase.DataItems, e.Node.PrevNode.Text.Substring(5), e.Node.Text.Substring(7));
                    else
                        MessageBox.Show("Malformed Data Item: " + e.Node.Text);

                    if (popedit != null)
                    {
                        popres = popedit.ShowDialog();
                        if (popres == DialogResult.Yes)
                        {
                            currentCase.DataItems.Remove(popedit.OldKey);
                            currentCase.DataItems.Add(popedit.Key, popedit.Value);
                            PopulateTree();
                            PopulateCurrentTree();
                        }
                    }
                }
                else if (e.Node.Text.Equals(treeNameDataItems))
                {
                    editData();
                }
                else if (e.Node.Text.Equals(treeNameAttributes))
                {
                    editAttrib();
                }
                else if (e.Node.Parent.Text.Equals(treeNameAttributes))
                {
                    editAttribute();
                }
                else if (e.Node.Text.StartsWith(treePrefixName))
                {
                    editName();
                }
                else if (e.Node.Text.StartsWith(treePrefixTitle))
                {
                    editTitle();
                }
                else if (e.Node.Text.StartsWith(treePrefixTimeout))
                {
                    editTimeout();
                }
            }
        }

        private void mniAddTest_Click(object sender, EventArgs e)
        {
            addTest();
        }

        private void mniAddAttribute_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                FormPopupAttribAdd popadd = new FormPopupAttribAdd(currentCase.Attributes);
                DialogResult popres = popadd.ShowDialog();
                if (popres == DialogResult.Yes)
                {
                    currentCase.Attributes.Add(popadd.Attribute);
                }
                PopulateTree();
            }
        }

        private void mniAddData_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                FormPopupDataAdd popadd = new FormPopupDataAdd(currentCase.DataItems);
                DialogResult popres = popadd.ShowDialog();
                if (popres == DialogResult.Yes)
                {
                    currentCase.DataItems.Add(popadd.Key, popadd.Value);
                }
                PopulateTree();
            }
        }

        private void fullTreeStrip_Opening(object sender, CancelEventArgs e)
        {
            TreeNode node = fullTree.SelectedNode;
            bool editable = false;
            bool removable = false;
            bool movable = false;
            if (currentCase != null && node != null && node.Parent != null)
            {
                if (node.Parent.Text.Equals(treeNameDataItems) ||
                    node.Parent.Text.Equals(treeNameAttributes) ||
                    node.Text.Equals(treeNameDataItems) ||
                    node.Text.Equals(treeNameAttributes) ||
                    node.Text.StartsWith(treePrefixName) ||
                    node.Text.StartsWith(treePrefixTitle) ||
                    node.Text.StartsWith(treePrefixTimeout))
                {
                    editable = true;
                }

                if (node.Parent.Text.Equals(treeNameAttributes) ||
                    node.Parent.Text.Equals(treeNameRoot))
                {
                    movable = true;
                }

                if (node.Parent.Text.Equals(treeNameDataItems) ||
                    node.Parent.Text.Equals(treeNameAttributes) ||
                    node.Parent.Text.Equals(treeNameRoot))
                {
                    removable = true;
                }
            }
            mniEdit.Enabled = editable;
            mniRemove.Enabled = removable;
            mniMoveDown.Enabled = movable;
            mniMoveUp.Enabled = movable;
        }

        private void mniEdit_Click(object sender, EventArgs e)
        {
            if (fullTree.SelectedNode.Text.Equals(treeNameDataItems))
                editData();

            else if (fullTree.SelectedNode.Text.Equals(treeNameAttributes))
                editAttrib();

            else if (fullTree.SelectedNode.Text.StartsWith(treePrefixKey))
            {
                FormPopupDataEdit popedit = new FormPopupDataEdit(currentCase.DataItems,
                                                                fullTree.SelectedNode.Text.Substring(5),
                                                                fullTree.SelectedNode.NextNode.Text.Substring(7));
                DialogResult popres = popedit.ShowDialog();
                if (popres == DialogResult.Yes)
                {
                    currentCase.DataItems.Remove(popedit.OldKey);
                    currentCase.DataItems.Add(popedit.Key, popedit.Value);
                    PopulateTree();
                }
            }

            else if (fullTree.SelectedNode.Text.StartsWith(treePrefixValue))
            {
                FormPopupDataEdit popedit = new FormPopupDataEdit(currentCase.DataItems,
                                                                fullTree.SelectedNode.PrevNode.Text.Substring(5),
                                                                fullTree.SelectedNode.Text.Substring(7));
                DialogResult popres = popedit.ShowDialog();
                if (popres == DialogResult.Yes)
                {
                    currentCase.DataItems.Remove(popedit.OldKey);
                    currentCase.DataItems.Add(popedit.Key, popedit.Value);
                    PopulateTree();
                }
            }

            else if (fullTree.SelectedNode.Text.StartsWith(treePrefixName))
            {
                editName();
            }

            else if (fullTree.SelectedNode.Text.StartsWith(treePrefixTitle))
            {
                editTitle();
            }

            else if (fullTree.SelectedNode.Text.StartsWith(treePrefixTimeout))
            {
                editTimeout();
            }
            else if (fullTree.SelectedNode.Parent.Text.Equals(treeNameAttributes))
            {
                editAttribute();
            }
            else
                MessageBox.Show("Error: This node should not be editable!");
        }

        private void mniRemove_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                if (fullTree.SelectedNode.Parent.Text.Equals(treeNameRoot))
                {
                    currentCases.Remove(currentCase, out errorMessage);
                    PopulateTree();
                }
                else if (fullTree.SelectedNode.Parent.Text.Equals(treeNameAttributes))
                {
                    currentCase.Attributes.Remove(fullTree.SelectedNode.Text);
                    PopulateTree();
                }
                else if (fullTree.SelectedNode.Parent.Text.Equals(treeNameDataItems))
                {
                    if (fullTree.SelectedNode.Text.StartsWith(treePrefixKey))
                        currentCase.DataItems.Remove(fullTree.SelectedNode.Text.Substring(5));
                    else
                        currentCase.DataItems.Remove(fullTree.SelectedNode.PrevNode.Text.Substring(5));
                    PopulateTree();
                }
                else
                    MessageBox.Show("Error: This node should not be removable!");
            }
            else
                MessageBox.Show("Error: there should always be a selected case when remove is called!");
        }

        private void mniMoveUp_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                if (fullTree.SelectedNode.Parent.Text.Equals(treeNameRoot))
                {
                    currentCases.MoveUp(currentCase, out errorMessage);
                    PopulateTree();
                }
                else if (fullTree.SelectedNode.Parent.Text.Equals(treeNameAttributes))
                {
                    string attrib = fullTree.SelectedNode.Text;
                    int oldindex = currentCase.Attributes.IndexOf(attrib);
                    currentCase.Attributes.RemoveAt(oldindex);

                    //Tertiary operator prevents index underflow
                    currentCase.Attributes.Insert((oldindex > 0) ? oldindex - 1 : oldindex, attrib);
                    PopulateTree();
                    PopulateTree();
                }
                else
                    MessageBox.Show("Error: This node should not be movable!");
            }
            else
                MessageBox.Show("Error: there should always be a selected case when move up is called!");
        }

        private void mniMoveDown_Click(object sender, EventArgs e)
        {
            if (currentCase != null)
            {
                if (fullTree.SelectedNode.Parent.Text.Equals(treeNameRoot))
                {
                    currentCases.MoveDown(currentCase, out errorMessage);
                    PopulateTree();
                }
                else if (fullTree.SelectedNode.Parent.Text.Equals(treeNameAttributes))
                {
                    string attrib = fullTree.SelectedNode.Text;
                    int oldindex = currentCase.Attributes.IndexOf(attrib);
                    currentCase.Attributes.RemoveAt(oldindex);

                    //Tertiary operator prevents index overflow
                    currentCase.Attributes.Insert((oldindex < (currentCase.Attributes.Count - 1)) ? oldindex + 1 : oldindex, attrib);
                    PopulateTree();
                }
                else
                    MessageBox.Show("Error: This node should not be movable!");
            }
            else
                MessageBox.Show("Error: there should always be a selected case when move down is called!");
        }
    }
}
