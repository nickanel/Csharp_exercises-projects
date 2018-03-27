using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharptest26._3 
{
    public class Rectangle : Shape ,IComparable,IEquatable<Object>
    {
        private string name;
        private readonly int  _width, _height;
        
        public int width { get { return _width; }  }
        public int height { get { return _height; }  }
        public double area { get; set; }
        
        public  Rectangle(int a,int b)
        {
            name = "Rectangle";
            _width = a;
            _height = b;
            Random_setColor();            
            GetArea();
            
        }
        public Rectangle(int a, int b,int color_choice)
        {
            name = "Rectangle";
            _width = a;
            _height = b;
            Set_Color(color_choice);
            GetArea();
           // Console.WriteLine("The Rectangle item was created ");
        }
        public Rectangle() { }
        public override string GetInfo()
        {
            
            return ($"Rectangle of color {Color}, width {width} and height {height}.");
        }
        public virtual void GetArea()
        {
            
            area = width * height;            
        }

        public int CompareTo(object obj)
        {
            Rectangle other = obj as Rectangle;
            if (other == null)
            {
                throw new ArgumentException();
            }
            if (area == other.area)
            {
                return 0;
            }
            else if (area < other.area)
            {
                return -1;
            }
            else return 1;

            
        }

        public bool Equals(Object obj)
        {
            Rectangle other = obj as Rectangle;
            if (this.area == other.area)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
