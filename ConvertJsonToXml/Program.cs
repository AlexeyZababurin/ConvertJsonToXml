using System.Xml;
using System.Text.Json;

string json = "{\"name\":\"Alexey\",\"age\":39,\"city\":\"Moscow\"}";

JsonDocument jsonDoc = JsonDocument.Parse(json);

XmlWriterSettings settings = new XmlWriterSettings();
settings.Indent = true;

using (XmlWriter writer = XmlWriter.Create("output.xml", settings))
{
    writer.WriteStartDocument();
    writer.WriteStartElement("root");

    foreach (JsonProperty property in jsonDoc.RootElement.EnumerateObject())
    {
        writer.WriteStartElement(property.Name);
        writer.WriteString(property.Value.ToString());
        writer.WriteEndElement();
    }

    writer.WriteEndElement();
    writer.WriteEndDocument();
}
