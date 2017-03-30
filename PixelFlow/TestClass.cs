using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelFlow
{
    public class TestClass
    {
        public static void DoSomething()
        {
            try
            {
                Console.WriteLine("I dood something!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
