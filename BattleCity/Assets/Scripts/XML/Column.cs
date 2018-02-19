using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Column
{
    [XmlAttribute("ID")]
    public int ColumnID;

    public string Block;
}
