using Lab2.Configuration;
using Lab2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Lab2
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebAPIConfig.Register);
            GlobalConfiguration.Configuration.Formatters.Add(new XmlMediaTypeFormatter());
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SetSerializer<Student>(
                new XmlSerializer(typeof(Student)));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SetSerializer<Link>(
                new XmlSerializer(typeof(Link)));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                 new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }
    }
}