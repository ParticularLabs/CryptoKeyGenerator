using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
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

            bool strip8bit = args.Contains("-7");
            bool stripControl = args.Contains("-s"); ;

            Console.WriteLine("Strip 8th bit: {0}", strip8bit);
            Console.WriteLine("Strip control: {0}", stripControl);


            if (args.Length == 0 || args.Last().StartsWith("-"))
            {
                key = GenerateKey();
            }
            else
            {
                var input = args.Last();
                Console.WriteLine("Input: {0}", input);
                key = Encoding.ASCII.GetBytes(input);
            }

            for (int i = 0; i < key.Length; i++)
            {
                var x = key[i];

                if (strip8bit)
                    x = (byte)(x & 0x7F);

                if (stripControl)
                    x = (byte)(x < 33 ? x + (byte)33 : x);

                key[i] = x;
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
