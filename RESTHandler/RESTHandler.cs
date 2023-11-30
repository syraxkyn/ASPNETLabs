using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace RESTHandler
{
    public class RESTHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return true; }
        }
        public static int ResultValue = 0;
        //interfaces standarts 
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            var Session = HttpContext.Current.Session;
            if (request.HttpMethod == "GET")
            {
                Stack<int> resultStack = Session["ResultStack"] as Stack<int>;
                int result;
                if (resultStack != null && resultStack.Count > 0)
                    result = ResultValue + resultStack.Peek();
                else
                    result = ResultValue;

                response.ContentType = "application/json";
                response.Write("{\"result\": ");
                response.Write(result);
                response.Write("}");
            }
            else if (request.HttpMethod == "POST")
            {
                ResultValue = Int32.Parse(request.Params["RESULT"]);

                response.ContentType = "application/json";
                response.Write("{\"result\": ");
                response.Write(ResultValue);
                response.Write("}");
            }
            else if (request.HttpMethod == "PUT")
            {
                int addValue = Int32.Parse(request.Params["ADD"]);
                Stack<int> resultStack = Session["ResultStack"] as Stack<int>;

                //if (resultStack != null && resultStack.Count > 0) 
                //    ResultValue += resultStack.Peek(); 

                if (resultStack == null)
                {
                    resultStack = new Stack<int>();
                    Session["ResultStack"] = resultStack;
                }

                resultStack.Push(addValue);

                response.ContentType = "application/json";
                response.Write("{\"status\": \"ok\"}");
            }
            else if (request.HttpMethod == "DELETE")
            {
                Stack<int> resultStack = Session["ResultStack"] as Stack<int>;

                if (resultStack == null || resultStack.Count == 0)
                {
                    response.ContentType = "application/json";
                    response.Write("{\"status\": \"fail\"}");
                }
                else
                {
                    resultStack.Pop();
                    response.ContentType = "application/json";
                    response.Write("{\"status\": \"ok\"}");
                }
            }
        }
    }
}
