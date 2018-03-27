using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharptest26._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle(22,32);
            Rectangle b = new Rectangle(32,22);
            Rectangle c = new Rectangle(56,41);
            Rectangle d = new Rectangle(53,43);
            Rectangle e = new Rectangle(21,43);
            Rectangle f = new Rectangle(21,45);
            Console.WriteLine($"\nAre rectangles {a} = {f}= {a.Equals(f)} \n");
           

            List<Rectangle> Rectangle_list = new List<Rectangle>();            
            Rectangle_list.Add(a); Rectangle_list.Add(b); Rectangle_list.Add(c); Rectangle_list.Add(d); Rectangle_list.Add(e); Rectangle_list.Add(f);
            Console.WriteLine("Now we print the Rectangles of the list \n");
            foreach (Rectangle element in Rectangle_list)
            {
                Console.WriteLine(element + $" With area = {element.area}");
                //Console.WriteLine(element.GetInfo() +$" with area = {element.area}");
            }
            Console.WriteLine("\nThe list with rectangles is now being sorted and printed anew \n");
            Rectangle_list.Sort();
            foreach( Rectangle element in Rectangle_list)
            {
                Console.WriteLine(element + $" With area = {element.area}");
                //Console.WriteLine(element.GetInfo() +$" with area = {element.area}");
            }

            Square a1 = new Square(22);
            Square a12 = new Square(67);
            Square a13 = new Square(52);
            Square a14 = new Square(50);
            Square a15 = new Square(96);
            Square a16 = new Square(12);
            Square a17 = new Square(45);
            Console.WriteLine($"\nAre Squares {a1} = {a14}= {a1.Equals(a14)} \n ");

            List<Square> Square_List = new List<Square> { a1, a12, a13, a14, a15, a16 };
            Console.WriteLine("Now we print the Squares of the List \n");
            foreach (Square element in Square_List)
            {
                Console.WriteLine(element + $" With area = {element.area}");
                //Console.WriteLine(element.GetInfo() +$" with area = {element.area}");
            }
            
            Console.WriteLine("\nThe list with Squares is now being sorted and printed anew \n");
            Square_List.Sort();
            foreach (Square element in Square_List)
            {
                Console.WriteLine(element + $" With area = {element.area}");
                //Console.WriteLine(element.GetInfo() +$" with area = {element.area}");
            }



            Console.ReadKey();

        }
    }
}
