using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1
{
    public class StackHandler : IHttpHandler
    {
        static int resultValue = 0;
        static Stack<int> resultStack = new Stack<int>();

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if (request.HttpMethod == "GET")
            {
                int result = resultValue;
                if (resultStack.Count > 0)
                    result += resultStack.First();
                response.ContentType = "application/json";
                response.Write("{\"result\": ");
                response.Write(result);
                response.Write("}");
            }
            else if (request.HttpMethod == "POST")
            {
                resultValue = Int32.Parse(request.Params["RESULT"]);
                response.Write($"result: {resultValue}");
            }
            else if (request.HttpMethod == "PUT")
            {
                resultStack.Push(Int32.Parse(request.Params["ADD"]));
                response.Write("PUSH operation is successfull");
            }
            else if (request.HttpMethod == "DELETE")
            {
                if (resultStack.Count == 0)
                {
                    response.Write("Stack is empty");
                }
                else
                {
                    resultStack.Pop();
                    response.Write("POP operation is successfull");
                }
            }
        }
    }
}
