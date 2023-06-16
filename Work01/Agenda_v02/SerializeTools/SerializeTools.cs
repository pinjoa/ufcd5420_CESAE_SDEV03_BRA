using System.IO;
using System.Xml.Serialization;

namespace SerializeTools
{
    public class XmlMethods
    {
        public static string SerializeToXml<T>(T anyobject) where T : class  
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());  
  
            using (TextWriter writer = new StringWriter())  
            {  
                xmlSerializer.Serialize(writer, anyobject);
                return writer.ToString();
            }  
        }  
    
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath) where T : class  
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());  
  
            using (StreamWriter writer = new StreamWriter(xmlFilePath))  
            {  
                xmlSerializer.Serialize(writer, anyobject);  
            }  
        }  
    
        public static T DeserializeStringToObject<T>(string xml) where T : class  
        {  
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;
            return (T)ser.Deserialize(stream);
        }  

        public static T DeserializeToObject<T>(string filepath) where T : class  
        {  
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));  
  
            using (StreamReader sr = new StreamReader(filepath))  
            {  
                return (T)ser.Deserialize(sr);  
            }  
        }  
    }
}