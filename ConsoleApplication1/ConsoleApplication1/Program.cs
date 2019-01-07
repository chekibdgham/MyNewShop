using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "salut tout le monde";
            Type type = x.GetType();
            Console.WriteLine(type.FullName);
            Console.ReadKey();
        }

        public class Car
        {
            public int id { get; set; }
            public string color { get; set; }
            public string mark { get; set; }

            public Car()
            {

            }
        }
        

    }
}
