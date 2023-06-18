using System.IO;
using System.Xml.Serialization;

namespace SerializeTools
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyobject"></param>
        /// <returns></returns>
        public static string SerializeToXml<T>(T anyobject) where T : class  
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());  
  
            using (TextWriter writer = new StringWriter())  
            {  
                xmlSerializer.Serialize(writer, anyobject);
                return writer.ToString();
            }  
        }  
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anyobject"></param>
        /// <param name="xmlFilePath"></param>
        public static void SerializeToXml<T>(T anyobject, string xmlFilePath) where T : class  
        {  
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());  
  
            using (StreamWriter writer = new StreamWriter(xmlFilePath))  
            {  
                xmlSerializer.Serialize(writer, anyobject);  
            }  
        }  
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeXmlStringToObject<T>(string xml) where T : class  
        {  
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xml);
            writer.Flush();
            stream.Position = 0;
            return (T)ser.Deserialize(stream);
        }  
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static T DeserializeXmlToObject<T>(string filepath) where T : class  
        {  
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));  
  
            using (StreamReader sr = new StreamReader(filepath))  
            {  
                return (T)ser.Deserialize(sr);  
            }  
        }  
    }
}