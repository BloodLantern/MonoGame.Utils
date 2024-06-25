using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MonoGame.Utils;

public static class XmlSerializationHelper
{
    public static void Serialize<T>(T obj, string path)
    {
        XmlSerializerNamespaces ns = new();
        ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
        
        using XmlTextWriter textWriter = new(path, Encoding.UTF8);
        XmlWriterSettings settings = new() { Indent = true, IndentChars = "    ", Encoding = Encoding.UTF8 };
        using XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings);
        
        new XmlSerializer(typeof(T)).Serialize(xmlWriter, obj, ns);
    }

    public static T Deserialize<T>(string path)
    {
        using StringReader reader = new(File.ReadAllText(path));
        object result = new XmlSerializer(typeof(T)).Deserialize(reader);
        
        if (result is T t)
            return t;

        throw new SerializationException($"Cannot deserialize object of type {result?.GetType()} using type {typeof(T)}");
    }
}
