using System;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace CryptoKeyGenerator
{
    class Program
    {
        static readonly Encoding AsciiEx = Encoding.GetEncoding(1252);

        static void Main(string[] args)
        {
            Console.OutputEncoding = AsciiEx;

            byte[] key;

            if (args.Length == 0)
            {
                key = GenerateKey();
            }
            else
            {
                key = AsciiEx.GetBytes(args[0]);
            }

            WL(key);
        }

        private static byte[] GenerateKey()
        {
            using (var e = RijndaelManaged.Create())
            {
                e.GenerateKey();
                return e.Key;
            }
        }

        private static void WL(byte[] key)
        {
            Console.WriteLine("Key bit length: {0}", key.Length * 8);
            Console.WriteLine();

            var base64 = Convert.ToBase64String(key);
            var hex = BitConverter.ToString(key).Replace("-", string.Empty).ToLowerInvariant();
            var ascii = Encoding.ASCII.GetString(key);
            var asciiex = AsciiEx.GetString(key);

            Console.WriteLine("Base64:");
            Console.WriteLine("\t{0}", base64);
            Console.WriteLine("\t|---------||---------||---------||---------|");
            Console.WriteLine();
            Console.WriteLine("Hex:");
            Console.WriteLine("\t{0}", hex);
            Console.WriteLine("\t|--------------||--------------||--------------||--------------|");
            Console.WriteLine();
            Console.WriteLine("ASCII:");
            Console.WriteLine("\t{0}     xml escape: {1}", ascii, SecurityElement.Escape(ascii));
            Console.WriteLine("\t|------||------||------||------|");
            Console.WriteLine();
            Console.WriteLine("ASCII-EX:");
            Console.WriteLine("\t{0}     xml escape: {1}", asciiex, SecurityElement.Escape(asciiex));
            Console.WriteLine("\t|------||------||------||------|");
        }
    }
}
