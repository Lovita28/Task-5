using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tugas_Akhir_5___Stream_Input_Manual
{
    class Program
    {
        void Write()
        {
            //input
            Console.WriteLine("Masukan jumlah Array: ");
            int x = int.Parse(Console.ReadLine());
            int[] Arr = new int[x];

            for (int y = 0; y < x; y++)
            {
                Console.WriteLine("Angka ke- " + (y + 1) + "=");
                Arr[y] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("");
            //create file 
            using (BinaryWriter binWriter = new BinaryWriter(File.Open("file.bin", FileMode.Create)))
            {

                foreach (int i in Arr)
                {
                    binWriter.Write(i);

                }

            }
        }
        //read file
        void Read()
        {
            using (BinaryReader b = new BinaryReader(File.Open("file.bin", FileMode.Open)))
            {
                int pos = 0;
                int length = (int)b.BaseStream.Length;
                while (pos < length)
                {
                    int v = b.ReadInt32();
                    Console.WriteLine(v);
                    pos += sizeof(int);
                }

            }
        }
        static void Main(string[] args)
        {

            Program pr = new Program();
            pr.Write();
            pr.Read();

            Console.ReadKey();
        }
    }
}
