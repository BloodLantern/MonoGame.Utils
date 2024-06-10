using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MonoGame.Utils;

public static class XmlSerializationHelper
{
    public static T LoadFromXml<T>(string xmlString, XmlSerializer serial = null)
    {
        serial ??= new(typeof(T));
        T returnValue = default;
        using StringReader reader = new(xmlString);
        object result = serial.Deserialize(reader);
        if (result is T t)
            returnValue = t;
        return returnValue;
    }

    public static string GetXml(object obj, bool omitStandardNamespaces) => GetXml(obj, null, omitStandardNamespaces);

    public static string GetXml(object obj, XmlSerializer serializer = null, bool omitStandardNamespaces = false)
    {
        XmlSerializerNamespaces ns = null;
        if (omitStandardNamespaces)
        {
            ns = new();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
        }
        using StringWriter textWriter = new();
        XmlWriterSettings settings = new() { Indent = true, IndentChars = "    ", Encoding = Encoding.Default }; // For cosmetic purposes.
        using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
            (serializer ?? new XmlSerializer(obj.GetType())).Serialize(xmlWriter, obj, ns);
        return textWriter.ToString();
    }

    public static void Serialize(object obj, string path) => File.WriteAllText(path, GetXml(obj, true));

    public static T Deserialize<T>(string path) => LoadFromXml<T>(File.ReadAllText(path));
}
