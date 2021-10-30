using System;
using System.IO;
using System.Text;

namespace _FileStream
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public void Save(Stream stream)
        {
            // int -> 4 byte
            var bytesID = BitConverter.GetBytes(ID);
            stream.Write(bytesID, 0, 4);

            // double -> 8 byte
            var bytesPrice = BitConverter.GetBytes(Price);
            stream.Write(bytesPrice, 0, 8);

            // string
            var bytesName = Encoding.UTF8.GetBytes(Name);
            var bytesLeng = BitConverter.GetBytes(bytesName.Length); // Get bytes (BitConverter) to restore
            stream.Write(bytesLeng, 0, 4); // Before write string, need bytes to write
            stream.Write(bytesName, 0, bytesName.Length);

        }
        public void Restore(Stream stream)
        {
            // int -> 4 byte
            var bytesID = new byte[4];
            stream.Read(bytesID, 0, 4);
            ID = BitConverter.ToInt32(bytesID, 0);

            // double -> 8 byte
            var bytesPrice = new byte[8];
            stream.Read(bytesPrice, 0, 8);
            Price = BitConverter.ToDouble(bytesPrice, 0);

            // string -> 4 byte
            var bytesLeng = new byte[4];
            stream.Read(bytesLeng, 0, 4);
            int leng = BitConverter.ToInt32(bytesLeng, 0);

            var bytesName = new byte[leng];
            stream.Read(bytesName, 0, bytesName.Length);
            Name = Encoding.UTF8.GetString(bytesName, 0, bytesName.Length);
        }
    }
    public class Program
    {
        static void Mainx()
        {
            string path = "data2.dat";
            using var stream = new FileStream(path: path, FileMode.OpenOrCreate);

            // Product product = new Product()
            // {
            //     ID = 10,
            //     Name = "Iphone",
            //     Price = 1000
            // };

            Product product = new Product();

            // product.Save(stream);
            product.Restore(stream);
            System.Console.WriteLine($"{product.ID} - {product.Name} - {product.Price}");

            // // 1.1 Create File Stream
            // string path = "data.dat";
            // using var stream = new FileStream(path: path, FileMode.OpenOrCreate); // "using" to release memory

            // // 1.2 Save data
            // byte[] buffer = { 1, 2, 3 };
            // int offset = 0; // start save from buffer[0]
            // int count = 3; // save 3 bytes

            // stream.Write(buffer, offset, count);

            // // 1.3 Read data
            // int numberByteRead = stream.Read(buffer, offset, count);
            // System.Console.WriteLine(numberByteRead); // numberByte = 0 is at the end of file

            // // 1.4 int, double, .. -> bytes & bytes -> int, double, ..
            // int number = 123;
            // var bytesNumber = BitConverter.GetBytes(number); // int, double, .. -> bytes
            // BitConverter.ToInt32(bytesNumber, 0); // bytes -> int, double, ..

            // // 1.5 string -> bytes & bytes -> string
            // string s = "Abc";
            // var bytesString = Encoding.UTF8.GetBytes(s); // string -> bytes
            // System.Console.WriteLine(Encoding.UTF8.GetString(bytesString, 0, bytesString.Length));
        }
    }
}