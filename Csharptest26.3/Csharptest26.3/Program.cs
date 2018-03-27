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
            Rectangle a1 = new Rectangle(22,32);
            Rectangle b2 = new Rectangle(32,22);
            Rectangle c3 = new Rectangle(56,41);
            Rectangle d4 = new Rectangle(53,43);
            Rectangle e5 = new Rectangle(21,43);
            Rectangle f6 = new Rectangle(21,45);
            Console.WriteLine($"\nAre rectangles {a1} = {f6}= {a1.Equals(f6)} \n");
           

            List<Rectangle> Rectangle_list = new List<Rectangle>();            
            Rectangle_list.Add(a1); Rectangle_list.Add(b2); Rectangle_list.Add(c3); Rectangle_list.Add(d4); Rectangle_list.Add(e5); Rectangle_list.Add(f6);
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

            Square a12 = new Square(22);
            Square a123 = new Square(67);
            Square a134 = new Square(52);
            Square a145 = new Square(50);
            Square a156 = new Square(96);
            Square a167 = new Square(12);
            Square a178 = new Square(45);
            Console.WriteLine($"\nAre Squares {a12} = {a145}= {a12.Equals(a145)} \n ");

            List<Square> Square_List = new List<Square> { a12, a123, a134, a145, a156, a167 };
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

            Square sq = new Square(42);
            Console.WriteLine(sq);
           


            Console.ReadKey();

        }
    }
}
