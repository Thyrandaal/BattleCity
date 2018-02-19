using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class Row
{
   // [/*XmlArray("Column"), XmlArrayItem("Column")]
    public List<Column> Columns = new List<Column>();

    [XmlAttribute("ID")]
    public string RowID;
}
