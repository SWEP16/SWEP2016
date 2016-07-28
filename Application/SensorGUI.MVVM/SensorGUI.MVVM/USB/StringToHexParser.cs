using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usb
{
    public class StringToHexParser
    {
        public static byte[] parse(String input)
        {
            char[] charArray = input.ToCharArray();
            byte[] byteArray = new byte[charArray.Length];

            for(int i=0; i<charArray.Length; i++)
            {
                byteArray[i] = (byte)(charArray[i]);
            }

            return byteArray;
        }
    }
}
