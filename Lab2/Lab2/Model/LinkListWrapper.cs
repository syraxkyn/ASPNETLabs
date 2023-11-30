using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Lab2.Model
{
    public class LinkListWrapper
    {
        public List<LinkHelper<Student>> Students;
        public List<Link> PaginationLinks;
        public Link PostLink = new Link
        {
            Rel = "Create student",
            Href = "localhost/api/students",
            Method = "POST"
        };
    }
}