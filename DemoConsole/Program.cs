using AprioriObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        const string path = @"C:\\Users\\Ga9286\\Desktop\\Retail.dat";
        static string[] ReadFile(string filePath)
        {
            StreamReader objInput = new StreamReader(filePath, System.Text.Encoding.Default);
            string contents = objInput.ReadToEnd().Trim();
            string[] split = System.Text.RegularExpressions.Regex.Split(contents, "\\s+", RegexOptions.None);
            return split;
        }
        static void Main(string[] args)
        {
            
            //    double minSupp = 0.6;
            //    double minConf = 0.85;
            //    List<Items> db = new List<Items>();
            //    db.Add(new Items(new[] { "a", "c", "d" }));
            //    db.Add(new Items(new[] { "b", "c", "e" }));
            //    db.Add(new Items(new[] { "a", "b", "c", "e" }));
            //    db.Add(new Items(new[] { "b", "e" }));

            //    List<Frequent> frequents_1 = new List<Frequent>();
            //    frequents_1.Add(new Frequent(1, 0.65, db, db));


            //Test performance
            //var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            //var t = new HashSet<string>(new List<string>() { "g", "a" });
            //var e = new HashSet<string>(new List<string>() { "a" });
            //Console.WriteLine(e.IsSubsetOf(t) && t.IsSubsetOf(e));

            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed);

            //var m = new List<string>() { "g", "a" };
            //m.Sort();
            //var n=new List<string>() { "a" };
            //n.Sort();
            //Console.WriteLine(m.SequenceEqual(n));

            //stopWatch.Stop();
            //Console.WriteLine(stopWatch.Elapsed);

            Console.ReadLine();

        }
    }
}
