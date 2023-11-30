using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Lab2.Model
{
    //[Serializable]
    public class Link
    {
        [XmlAttribute]
        public string Rel { get; set; }
        [XmlAttribute]
        public string Href { get; set; }
        [XmlAttribute]
        public string Method { get; set; }
    }
}