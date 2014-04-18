using UnityEngine;
using System.Xml;
using System.Collections;

public class XMLParser
{
	
	private XmlDocument doc;
	private XmlNode rootNode;
	private string fileName;

	public XMLParser(string file)
	{
		doc = new XmlDocument();
		doc.Load(file);
		if (doc != null)
		{
			fileName = file;
			rootNode = doc.DocumentElement;
		}

		else 
		{
			UnityEngine.Debug.LogError("Cannot Parse XML file : " + file);
		}
	}

	public XmlNode findNode(string nodeName, string attributeName, string attributeValue, bool contains, XmlNode node)
	{
		do {
			string elementName = node.Name;
			if (elementName != null && elementName.Equals(nodeName))
			{
				XmlAttributeCollection attributes = node.Attributes;
				if (attributes != null)
				{
					XmlAttribute attr = (XmlAttribute)attributes.GetNamedItem(attributeName);
					if (attr != null)
					{
						string attrValue = attr.Value;
						if (contains)
						{
							if (attrValue != null && attrValue.Contains(attributeValue))
							{
								return node;
							}
							else if (attrValue != null && attributeValue != null && attributeValue.Equals ("*"))
							{
								return node;
							}
						}
						else {
							if (attrValue != null && attrValue.Equals(attributeValue))
							{
								return node;
							}
							else if (attrValue != null && attributeValue != null && attributeValue.Equals ("*"))
							{
								return node;
							}
						}
					}
				}

			}
			if (node.HasChildNodes)
			{
				XmlNodeList childNodes = node.ChildNodes;
				int childCount = childNodes.Count;
				for (int childPos = 0; childPos < childCount; childPos++) 
				{
					node = findNode(nodeName,attributeName,attributeValue,contains,childNodes[childPos]);
					if (node != null)
					{
						return node;
					}
				}
			}
			if (node != null)
			{
				node = node.NextSibling;
			}
		} while(node != null);
		return node;
	}

	public XmlNode getRootNode() 
	{
		return rootNode;
	}

	public void replaceString(string regex, string value)
	{
		if (doc != null)
		{
			doc.InnerXml = doc.InnerXml.Replace(regex,value);
		}
	}

	public void replaceElementValue(string name, string value, bool singleNode, XmlNode node)
	{	
		do {
			string elementName = node.Name;
			if (elementName != null && elementName.Equals(name))
			{
				node.InnerXml = value;
			}
			if (node.HasChildNodes && !singleNode)
			{
				XmlNodeList childNodes = node.ChildNodes;
				int childCount = childNodes.Count;
				for (int childPos = 0; childPos < childCount; childPos++) 
				{
					replaceElementValue(name,value,singleNode,childNodes[childPos]);
				}
			}
			if (singleNode)
			{
				node = null;
			}
			else {
				node = node.NextSibling;
			}
		} while (node != null);
	}

	public string getElementValueForAttribute(string attribute, string attributeValue, XmlNode node)
	{
		string value = null;
		do {
			XmlAttributeCollection attributes = node.Attributes;
			if (attributes != null)
			{
				XmlAttribute attr = (XmlAttribute)attributes.GetNamedItem(attribute);
				if (attr != null)
				{
					string attrValue = attr.Value;
					if (attrValue != null && attrValue.Equals(attributeValue))
					{
						value = node.InnerXml;
						return value;
					}
				}
			}
			if (node.HasChildNodes)
			{
				XmlNodeList childNodes = node.ChildNodes;
				int childCount = childNodes.Count;
				for (int childPos = 0; childPos < childCount; childPos++) 
				{
					value = getElementValueForAttribute(attribute,attributeValue,childNodes[childPos]);
					if (value != null)
					{
						return value;
					}
				}
			}
			node = node.NextSibling;
		} while(node != null);
		return value;
	}

	public void replaceElementValueforAttribute(string attribute, string attributeValue, string value, bool singleNode, XmlNode node)
	{
		do {
			XmlAttributeCollection attributes = node.Attributes;
			if (attributes != null)
			{
				XmlAttribute attr = (XmlAttribute)attributes.GetNamedItem(attribute);
				if (attr != null)
				{
					string attrValue = attr.Value;
					if (attrValue != null && attrValue.Equals(attributeValue))
					{
						node.InnerXml = value;
					}
				}
			}
			if (node.HasChildNodes && !singleNode)
			{
				XmlNodeList childNodes = node.ChildNodes;
				int childCount = childNodes.Count;
				for (int childPos = 0; childPos < childCount; childPos++) 
				{
					replaceElementValueforAttribute(attribute,attributeValue,value,singleNode,childNodes[childPos]);
				}
			}
			if (singleNode)
			{
				node = null;
			}
			else 
			{
				node = node.NextSibling;
			}
		} while(node != null);
	}

	public void saveXML()
	{
		doc.Save(fileName);
	}

	public void saveXMLToFile(string file)
	{
		doc.Save(file);
	}

	public void replaceAttributeValue(string name, string value, bool singleNode, XmlNode node)
	{
		do {
			XmlAttributeCollection attributes = node.Attributes;
			if (attributes != null)
			{
				XmlAttribute attribute = (XmlAttribute)attributes.GetNamedItem(name);
				if (attribute != null)
				{
					attribute.Value = value;
				}
			}
			if (node.HasChildNodes && !singleNode)
			{
				XmlNodeList childNodes = node.ChildNodes;
				int childCount = childNodes.Count;
				for (int childPos = 0; childPos < childCount; childPos++) 
				{
					replaceAttributeValue(name,value,singleNode,childNodes[childPos]);
				}
			}
			if (singleNode)
			{
				node = null;
			}
			else {
				node = node.NextSibling;
			}
		} while(node != null);
	}

}

