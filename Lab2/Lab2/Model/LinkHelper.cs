using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Http;

namespace Lab2.Model
{
    public class LinkHelper<T> where T : class
    {

        public T Value { get; set; }
        public List<Link> Links { get; set; }

        public LinkHelper()
        {
            Links = new List<Link>();
        }

        public LinkHelper(T item)
        {
            Value = item;
            if (item is Error)
            {
                Links = new List<Link>
                {
                    new Link
                    {
                        Rel = "More info",
                        Href = $"localhost/api/errors/{(item as Error).Code}",
                        Method = "GET"
                    },
                    new Link
                    {
                        Rel = "Get all students",
                        Href = "localhost/api/students",
                        Method = "GET"
                    }
                };
            }
            else
            {
                Links = new List<Link>
                    {
                            new Link
                            {
                                Rel = "Get all students",
                                Href = "localhost/api/students",
                                Method = "GET"
                            },
                            new Link
                            {
                                Rel = "self-link",
                                Href = $"localhost/api/students/{(item as Student).Id}",
                                Method = "GET"
                            },
                            new Link
                            {
                                Rel = "Update student",
                                Href = $"localhost/api/students/{(item as Student).Id}",
                                Method = "PUT"
                            },
                            new Link
                            {
                                Rel = "Delete student",
                                Href = $"localhost/api/students/{(item as Student).Id}",
                                Method = "DELETE"
                            }
                    };
            }
        }
    }
}