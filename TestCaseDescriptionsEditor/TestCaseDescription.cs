using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestCaseDescriptionsEditor
{
    public class TestCaseDescription
    {
        String m_name;
        String m_title;
        int m_timeout;
        List<String> m_attributes;
        Dictionary<string, string> m_dataItems;
        Boolean m_isSelected;

        public TestCaseDescription()
        {
            m_name = "";
            m_title = "";
            m_timeout = 0;
            m_attributes = new List<String>();
            m_dataItems = new Dictionary<string, string>();
            m_isSelected = false;
        }

        public TestCaseDescription(String name, String title, int timeout, List<String> attributes, Dictionary<String, String> dataItems, Boolean isSelected)
        {
            m_name = name;
            m_title = title;
            m_timeout = timeout;
            m_attributes = attributes;
            m_dataItems = dataItems;
            m_isSelected = isSelected;
        }

        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public String Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        public int Timeout
        {
            get { return m_timeout; }
            set { m_timeout = value; }
        }

        public List<String> Attributes
        {
            get { return m_attributes; }
            set { m_attributes = value; }
        }

        public Dictionary<String, String> DataItems
        {
            get { return m_dataItems; }
            set { m_dataItems = value; }
        }

        public Boolean IsSelected
        {
            get { return m_isSelected; }
            set { m_isSelected = value; }
        }

        public XElement GetXML()
        {
            {
                XElement testCase = new XElement(XMLEnum.Case,
                    new XElement(XMLEnum.Name, m_name),
                    new XElement(XMLEnum.Title, m_title),
                    new XElement(XMLEnum.Timeout, m_timeout),
                    new XElement(XMLEnum.Attributes,
                        from attrib in m_attributes
                        select new XElement(XMLEnum.Attribute, attrib)),
                    new XElement(XMLEnum.IsSelected, m_isSelected ? "True" : "False"),
                    new XElement(XMLEnum.DataItems, m_dataItems.Count > 0 ?
                        from data in m_dataItems
                        select new XElement(XMLEnum.DataItem,
                            new XElement(XMLEnum.DataKey, data.Key),
                            new XElement(XMLEnum.DataValue, data.Value)) : null));
                return testCase;
            }
        }
    }
}
