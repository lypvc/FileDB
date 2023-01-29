using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numeria.IO;
using System.IO;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Parallel Insert
            //

            string dbFile = @"D:\Temp\MvcDemo.dat";

            //string[] files = new string[] {
            //    @"D:\drocCloud\dcm\FLU Cheset.DCM", @"D:\drocCloud\dcm\TOMO.dcm", @"D:\drocCloud\dcm\重建图.dcm" };

            //Parallel.For(0, 3, (i) =>
            //{
            //    Console.WriteLine("Starting " + Path.GetFileName(files[i]));
            //    FileDB.Store(dbFile, files[i]);
            //    Console.WriteLine("Ended " + Path.GetFileName(files[i]));

            //});

            var dbfiles = FileDB.ListFiles(dbFile);
            foreach (var item in dbfiles)
            {
                var sm = new MemoryStream();
                FileDB.Read(dbFile, item.ID, sm);
                Console.WriteLine("ID:{0},Filename:{1},FileLength:{2},MimeType:{3}", item.ID, item.FileName, item.FileLength, item.MimeType);
            }

            Console.ReadLine();

        }
    }
}
