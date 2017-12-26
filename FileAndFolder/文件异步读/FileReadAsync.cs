using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAndFolder.文件异步读
{
    class FileReadAsync
    {
        public static void Exec()
        {
            var path = @"文件异步读\TestFile\Class1.txt";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                int bufferSize = 512;
                var buffer = new byte[bufferSize];
                var asyncCallback = new AsyncCallback(MyCallback);
                var ar = fs.BeginRead(buffer, 0, bufferSize, asyncCallback, null);
                var endReadInt = fs.EndRead(ar);

                Console.WriteLine("endReadInt:" + endReadInt);

                Console.WriteLine("内容：");
                Console.WriteLine(Encoding.UTF8.GetString(buffer));
            }
        }

        public static void MyCallback(IAsyncResult ar)
        {
            var obj = ar.AsyncState;

            Console.WriteLine("MyCallback excuted.");
        }
    }
}
