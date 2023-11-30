using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Lab2.Model
{
    public class Error
    {
        [XmlAttribute]
        public int Code { get; set; }
        [XmlAttribute]
        public string Message { get; set; }
        public Error(int code, string message) 
        {
            Code = code;
            Message = message;
        }

        public Error(int code)
        {
            Code = code;
        }

        public Error()
        {
        }
    }
}