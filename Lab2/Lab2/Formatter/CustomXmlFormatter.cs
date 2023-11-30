using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.Xml;
using Lab2.Model;

namespace Lab2.Formatter
{
    public class CustomXmlFormatter : XmlMediaTypeFormatter
    {
        public CustomXmlFormatter()
        {
            UseXmlSerializer = true;
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using (var xmlWriter = XmlWriter.Create(writeStream, settings))
            {
                var serializer = new XmlSerializer(type);
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty); // Убираем пространство имен

                // Проверяем, является ли значение поля Id null, и если да, то не создаем элемент
                var yourModel = value as Student;
                if (yourModel != null && yourModel.Id == null)
                {
                    serializer.Serialize(xmlWriter, null, namespaces);
                }
                else
                {
                    serializer.Serialize(xmlWriter, value, namespaces);
                }
            }

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }
    }
}