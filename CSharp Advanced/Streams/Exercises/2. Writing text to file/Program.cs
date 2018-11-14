    using System;
using System.IO;
using System.Text;

namespace _2._Writing_text_to_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Кирилица";
            FileStream stream = new FileStream(@"..\..\..\Text.txt", FileMode.Create);

            using (stream)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);

                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
