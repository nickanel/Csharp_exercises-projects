using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharptest26._3
{
    public class Rectangle : Shape
    {
        private readonly int  _width, _height;

        public int width { get { return _width; }  }
        public int height { get { return _height; }  }
        public  Rectangle(int a,int b)
        {
            _width = a;
            _height = b;
             Set_Color();
            Console.WriteLine("The Rectangle item was created ");
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Rectangle of color {Color}, width {width} and height {height}.");
        }
        public virtual void GetArea()
        {
            double area;
            area = width * height;            
        }
    }
}
