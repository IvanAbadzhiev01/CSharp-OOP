using ChristmasPastryShop.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChristmasPastryShop.IO
{
    public class TxtWriter : IWriter
    {
        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter("../../../text.txt", true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }


}

