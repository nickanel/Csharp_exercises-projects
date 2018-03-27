using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharptest26._3
{
    public abstract class Shape
    {
        private static Random rnd = new Random();
        public enum Shape_color { Red = 1, BLUE, Green, Yellow, Black, Gray };

        protected Shape_color _color;
        public Shape_color Color { get { return _color; } }



        public void Set_Color(int choice)
        {
            // Console.WriteLine("Give a number from 1-5 for colour: (e.g 1=red,2=blue,3=green,4=yellow,5=Black,6=Gray)");
            // int color_choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    _color = Shape_color.Red;
                    break;
                case 2:
                    _color = Shape_color.BLUE;
                    break;
                case 3:
                    _color = Shape_color.Green;
                    break;
                case 4:
                    _color = Shape_color.Yellow;
                    break;
                case 5:
                    _color = Shape_color.Black;
                    break;
                case 6:
                    _color = Shape_color.Gray;
                    break;
            }

        }

        protected void Random_setColor()
        {
            int epilogi;
            //Random rnd = new Random(DateTime.Now.Millisecond);
            epilogi = rnd.Next(1, 6);
            _color = (Shape_color)epilogi;
        }
        public abstract string GetInfo();
        public override string ToString()
        {
            return GetInfo().ToString();
        }

    }
}