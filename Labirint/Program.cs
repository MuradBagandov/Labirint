using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var glw = new GLWindow())
            {
                glw.Run(60, 60);
            }
        }
    }
}
