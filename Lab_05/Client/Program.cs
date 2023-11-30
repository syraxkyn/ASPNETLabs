using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string binding = "BasicHttpBinding_IWCFSimplex";
            //string binding = "tcpEndpoint";
            WCFReference.WCFSimplexClient simpleClient = new WCFReference.WCFSimplexClient(binding);
            Console.WriteLine("ADD: " + simpleClient.Add(7, 10));
            Console.WriteLine("CONCAT: " + simpleClient.Concat("str", 3));
            WCFReference.A a = simpleClient.Sum(new WCFReference.A { f = 3.2f, k = 1, s = "4" }, new WCFReference.A { f = 1.3f, k = 2, s = "12" });
            Console.WriteLine($"SUM: f = {a.f} k = {a.k} s = {a.s}");
            Console.ReadLine();
            simpleClient.Close();
        }
    }
}
