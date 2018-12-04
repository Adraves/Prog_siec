using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SMTP_console
{
    class B64
    {
        public static void encode(string path, string output)
        {

            byte[] file = File.ReadAllBytes(path);
            var bits = string.Empty;
            string base64 = string.Empty;


            for (int i = 0; i < file.Length; i++)
            {
                bits += Convert.ToString(file[i], 2).PadLeft(8, '0');
            }

            //Console.WriteLine(bits);

            int hexCounter = 0;
            var encodedString = string.Empty;
            while (hexCounter < bits.Length)
            {
                //List<char> currentOctets = bits.Skip(hexCounter).Take(24).ToList();
                char[] currentOctets = bits.Skip(hexCounter).Take(24).ToArray();


                int sextCounter = 0;
                while (sextCounter < currentOctets.Length)
                {
                    char[] currentSextet = currentOctets.Skip(sextCounter).Take(6).ToArray();
                    string sextet = string.Empty;
                    switch (currentSextet.Length % 3)
                    {
                        case 0:

                            for (int i = 0; i < 6; i++)
                            {
                                sextet += currentSextet[i];
                            }
                            break;
                        case 1:
                            for (int i = 0; i < 4; i++)
                            {
                                sextet += currentSextet[i];
                            }
                            sextet += "00";
                            break;
                        case 2:
                            for (int i = 0; i < 2; i++)
                            {
                                sextet += currentSextet[i];
                            }
                            sextet += "0000";
                            break;
                    }

                    //Console.WriteLine(sextet);
                    int letter = Convert.ToInt32(sextet, 2);
                    sextCounter += 6;
                    base64 += lookupTable[letter];
                }

                hexCounter += 24;
            }
            switch (bits.Length % 3)
            {
                case 1:
                    base64 += "=";
                    break;
                case 2:
                    base64 += "==";
                    break;

            }
            Console.WriteLine("Przewarzanie...");
            File.WriteAllText(output, base64);
            Console.WriteLine("\n Operacja zakonczona. Nacisnij dowolny przycisk by zakonczyc.");
            Console.ReadKey();
        }

        public static void decode(string inputPath, string outputPath)
        {
            string file = File.ReadAllText(inputPath);

            string byteString = string.Empty;
            short letterGroupSize = 4;
            int count = 0;
            List<string> bytesL = new List<string>();
            string bytes = string.Empty;

            while (count < (file.Length))
            {
                int padding;
                /* Bierzemy 4 znaki*/
                char[] currentLetters = file.Skip(count).Take(letterGroupSize).ToArray();
                string currentBits = string.Empty;
                string[] currentBytes = new string[3];
                if (count == (file.Length - 4) && currentLetters[3] == '=')
                {
                    if (currentLetters[2] == '=')
                    {
                        padding = 2;
                    }
                    else padding = 1;
                }
                else padding = 0;
                for (int i = 0; i < currentLetters.Length - padding; i++)
                {
                    int letterNumber = Array.IndexOf(lookupTable, currentLetters[i]);
                    currentBits += Convert.ToString(letterNumber, 2).PadLeft(6, '0');
                }
                switch (padding)
                {
                    case 1:
                        currentBits += "000000000000";
                        break;
                    case 2:
                        currentBits += "000000";
                        break;
                }
                char[] currentBitsA = currentBits.ToCharArray();
                for (int i = 0; i < 24 - (padding * 8); i += 8)
                {
                    char[] temp = currentBitsA.Skip(i).Take(8).ToArray();
                    string temp2 = new string(temp);
                    bytesL.Add(temp2);
                }

                count += letterGroupSize;
            }


            byte[] finalBytes = new byte[bytesL.Count];
            int x = 0;
            foreach (string byteL in bytesL)
            {
                finalBytes[x] = Convert.ToByte(byteL, 2);
                x++;
            }

            Console.WriteLine("Przewarzanie...");
            File.WriteAllBytes(outputPath, finalBytes);
            Console.WriteLine("\n Operacja zakonczona. Nacisnij dowolny przycisk by zakonczyc.");
            Console.ReadKey();
        }

        private static readonly char[] lookupTable = new char[64]
        {
            'A','B','C','D','E','F','G','H','I','J','K','L','M',
            'N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m',
            'n','o','p','q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9','+','/'
        };
    }
}
