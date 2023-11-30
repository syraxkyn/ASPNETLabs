using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4
{
    /// <summary>
    /// Сводное описание для Simplex
    /// </summary>
    [WebService(Namespace = "http://SAA/", Description = "ASMX-сервис Simplex")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class Simplex : System.Web.Services.WebService
    {

        [WebMethod(MessageName = "Add", Description = "Возвращает значение суммы двух параметров")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "Concat", Description = "Возвращает конкатенацию первого и второго параметров")]
        public string Concat(string s, double d)
        {
            return s + " " + d.ToString();
        }

        [WebMethod(MessageName = "Sum", Description = "Возвращает объект A:\r\nполе s – конкатенация a1.s и a2.s;\r\nполе к – сумма a1.k и a2.k;\r\nполе f – сумма a1.f и a2.f;\r\n")]
        public A Sum(A a1, A a2)
        {
            this.Context.Request.SaveAs("C:\\inetpub\\wwwroot\\sum.txt", false);
            
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "Adds", Description = "Метод AddS аналогичен методу Add, но предназначен для вызова с помощью AJAX-запроса, отправляющего и принимающего сообщения в формате JSON.")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}
