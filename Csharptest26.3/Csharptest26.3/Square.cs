using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharptest26._3
{
    public sealed class Square : Rectangle ,IComparable,IEquatable<Object>
    {
        public Square(int a ) : base(a, a)
        {
        }
        public Square(int a, int color ):base(a,a,color)
        {

        }

        

        public override string GetInfo()
        {
            
            return ($"Square of color {Color}, and side length {height}.");
        }
    }
}
