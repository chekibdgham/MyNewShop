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
        public delegate T add<T>(T param1, T param2);

        static void Main(string[] args)
        {
            //add<int> sum = AddNumber;

            //Console.WriteLine(sum(10, 20));

            //add<string> conct = Concate;

            //Console.WriteLine(conct("Hello", " World!!"));

            MyGenericClass<int> mygenericclass = new MyGenericClass<int>(10);
            mygenericclass.genericMethod(200);
            Console.ReadKey();
        }

        public static int AddNumber(int val1, int val2)
        {
            return val1 + val2;
        }

        public static string Concate(string str1, string str2)
        {
            return str1 + str2;
        }

        public class MyGenericClass<T>
        {
            private T genericMemberVariable;
            public MyGenericClass(T value)
            {
                genericMemberVariable = value;
            }
            public T genericMethod(T genericParameter)
            {
                Console.WriteLine("Parameter type : {0}, value : {1}", typeof(T).Name, genericParameter);
                Console.WriteLine("Return type: {0}, value : {1}", typeof(T).Name, genericMemberVariable);
                return genericMemberVariable;
            }

            public T genericProperty { get; set; }
        }
       
    }
}
