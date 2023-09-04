using System;

namespace ConsoleApp6
{
    class Program

    {
       static void fun( int x)
        {
            Console.WriteLine(x);  
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int y = 5;
            fun( y++);
        }
    }
}
