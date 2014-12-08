using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace TestCaseDescriptionsEditor
{
    //Assumes all test case descriptions will have a unique name
    class TestCaseDescriptions
    {
        List<TestCaseDescription> m_descriptions;
        TestCaseDescription m_selectedItem;

        public TestCaseDescriptions()
        {
            m_descriptions = new List<TestCaseDescription>();
            m_selectedItem = null;
        }

        public TestCaseDescriptions(List<TestCaseDescription> descriptions)
        {
            m_descriptions = descriptions;
            m_selectedItem = null;
        }

        public List<TestCaseDescription> Descriptions
        {
            get { return m_descriptions; }
            set { m_descriptions = value; }
        }

        public TestCaseDescription SelectedItem
        {
            get { return m_selectedItem; }
            set { m_selectedItem = value; }
        }

        public bool Add(TestCaseDescription descToAdd, out String errorMessage)
        {
            bool success = false;

            try
            {
                errorMessage = "";
                if (m_descriptions.Find(d => d.Name == descToAdd.Name) == null)
                {
                    m_descriptions.Add(descToAdd);
                    success = true;
                }
                else
                    errorMessage = "Test Case Description Already Exists.";
            }
            catch (Exception e)
            {
                errorMessage = "Add failed: " + e.Message;
            }
            return success;
        }

        public bool Remove(TestCaseDescription descToRemove, out String errorMessage)
        {
            bool success = false;

            try
            {
                errorMessage = "";
                if (m_descriptions.Find(d => d.Name == descToRemove.Name) != null)
                {
                    m_descriptions.Remove(descToRemove);
                    success = true;
                }
                else
                    errorMessage = "Test Case Description does not exist.";
            }
            catch (Exception e)
            {
                errorMessage = "Remove failed: " + e.Message;
            }
            return success;
        }

        public bool MoveUp(TestCaseDescription descToMove, out String errorMessage)
        {
            bool success = false;
            int indexOfDesc = -1;

            try
            {
                errorMessage = "";
                if (m_descriptions.Find(d => d.Name == descToMove.Name) != null)
                {
                    indexOfDesc = m_descriptions.IndexOf(descToMove);
                    if (indexOfDesc >= 0)
                    {

                        m_descriptions.Insert(indexOfDesc - 1, descToMove);
                        m_descriptions.RemoveAt(indexOfDesc + 1);
                        success = true;
                    }
                    else
                        errorMessage = "Invalid index of test case description";
                }
                else
                    errorMessage = "Test Case Description does not exist.";
            }
            catch (Exception e)
            {
                errorMessage = "Move up failed: " + e.Message;
            }
            return success;
        }

        public bool MoveDown(TestCaseDescription descToMove, out String errorMessage)
        {
            bool success = false;
            int indexOfDesc = -1;

            try
            {
                errorMessage = "";
                if (m_descriptions.Find(d => d.Name == descToMove.Name) != null)
                {
                    indexOfDesc = m_descriptions.IndexOf(descToMove);
                    if (indexOfDesc >= 0)
                    {
                        m_descriptions.Insert(indexOfDesc + 2, descToMove);
                        m_descriptions.RemoveAt(indexOfDesc);
                        success = true;
                    }
                    else
                        errorMessage = "Invalid index of test case description";
                }
                else
                    errorMessage = "Test Case Description does not exist.";
            }
            catch (Exception e)
            {
                errorMessage = "Move down failed: " + e.Message;
            }
            return success;
        }

        public bool SaveAsXML(String filename, out String errorMessage)
        {
            bool success = false;
            const string xmlVersion = "1.0";
            const string xmlEncoding = "utf-8";
            const string xmlStandAlone = "";
  
            try
            {
                errorMessage = "";

                XDeclaration xDeclaration = new XDeclaration(xmlVersion, xmlEncoding, xmlStandAlone);

                XElement cases = new XElement(XMLEnum.Root,
                    from testCase in m_descriptions
                    select new XElement(testCase.GetXML()));

                XDocument xDoc = new XDocument(xDeclaration, cases);
                xDoc.Save(filename);
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = "Save to XML failed: " + e.Message;
            }
            return success;
        }

        public bool LoadXML(String filename, out String errorMessage)
        {
            TestCaseDescription currentCase;
            bool success = false;
            try
            {
                errorMessage = "";
                XDocument xDoc = XDocument.Load(filename);
                IEnumerable<XElement> testCases = xDoc.Descendants(XMLEnum.Root).Elements();
                foreach (XElement testCase in testCases)
                {
                    if(String.Equals(XMLEnum.Case,testCase.Name.ToString()))
                    {
                        currentCase = new TestCaseDescription();
                        IEnumerable<XElement> elements = testCase.Elements();
                        foreach (XElement element in elements)
                        {
                            if (String.Equals(XMLEnum.Name, element.Name.ToString()))
                                currentCase.Name = element.Value;
                            else if (String.Equals(XMLEnum.Title, element.Name.ToString()))
                                currentCase.Title = element.Value;
                            else if (String.Equals(XMLEnum.Timeout, element.Name.ToString()))
                                currentCase.Timeout = int.Parse(element.Value);
                            else if (String.Equals(XMLEnum.Attributes, element.Name.ToString()))
                            {
                                if (element.HasElements)
                                {
                                    IEnumerable<XElement> attributes = element.Elements();
                                    foreach (XElement attribute in attributes)
                                    {
                                        currentCase.Attributes.Add(attribute.Value);
                                    }
                                }
                            }
                            else if (String.Equals(XMLEnum.IsSelected, element.Name.ToString()))
                            {
                                currentCase.IsSelected = String.Equals(element.Value, XMLEnum.IsSelectedTrue) ? true : false;
                            }
                            else if (String.Equals(XMLEnum.DataItems, element.Name.ToString()))
                            {
                                if (element.HasElements)
                                {
                                    IEnumerable<XElement> dataItems = element.Elements();
                                    foreach (XElement dataItem in dataItems)
                                    {
                                        currentCase.DataItems.Add(dataItem.Element(XMLEnum.DataKey).Value, dataItem.Element(XMLEnum.DataValue).Value);
                                    }
                                }
                            }
                        }
                        this.Add(currentCase, out errorMessage);
                    }

                }
                success = true;
            }
            catch (Exception e)
            {
                errorMessage = "Load XML failed: " + e.Message;
            }
            return success;
        }
    }
}
