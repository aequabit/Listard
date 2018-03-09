using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidUnitTest
{
    class TestFailException
    {
        public static bool Error = false;

        public static void Throw(string message)
        {
            Error = true;
            throw new Exception(message);
        }
    }
}
