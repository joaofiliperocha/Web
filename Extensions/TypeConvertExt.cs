using System.IO;
using System.Xml;
using System.Xml.Serialization;

public static class TypeConvertExt
{
    internal static string ToJson(this object item)
    {
        if (item == null)
            return null;
        var js = new System.Web.Script.Serialization.JavaScriptSerializer();
        return js.Serialize(item);
    }
    internal static string ToXml(this object item)
    {
        if (item == null)
            return null;
        try
        {
            using (var stream = new StringWriter())
            {
                var settings = new XmlWriterSettings();
                settings.Indent = false;
                settings.OmitXmlDeclaration = true;
                using (var writer = XmlWriter.Create(stream, settings))
                {
                    var serializer = new XmlSerializer(item.GetType());
                    var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                    serializer.Serialize(writer, item, emptyNamepsaces);
                    return stream.ToString();
                }
            }
        }
        catch
        {
            throw;
        }

    }

}