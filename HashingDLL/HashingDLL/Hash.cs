using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashingDLL
{
    public class Hash
    {
        public static string Hashing(string value)
        {
            MD5CryptoServiceProvider mdval = new MD5CryptoServiceProvider();
            byte[] valbytes = Encoding.ASCII.GetBytes(value);
            mdval.ComputeHash(valbytes);
            byte[] hashedval = mdval.Hash;
            return BitConverter.ToString(hashedval);
        }
    }
}
