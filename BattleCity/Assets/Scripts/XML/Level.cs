using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("RowCollection")]
public class Level
{
 //   [XmlArray("Rows"), XmlArrayItem("Row")]
    public List<Row> Rows = new List<Row>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(Level));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }

    public static Level Load(string path)
    {
        var serializer = new XmlSerializer(typeof(Level));
        using(var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Level;
        }
    }
}
