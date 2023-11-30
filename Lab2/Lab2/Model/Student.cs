using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Lab2.Model
{
    public class Student
    {
        [XmlElement(IsNullable = true)]
        public int? Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Phone { get; set; }
    }
}