using System;
using System.IO;

namespace _File
{
    public class Program
    {
        static void Mainx()
        {
            // ************ 1. DriveInfo ************
            // 1.1 Get drive info
            DriveInfo drive = new DriveInfo("C:/");
            Console.WriteLine($"Drive: {drive.Name}");
            Console.WriteLine($"Drive Type: {drive.DriveType}");
            Console.WriteLine($"Label: {drive.VolumeLabel}");
            Console.WriteLine($"Format: {drive.DriveFormat}");
            Console.WriteLine($"Size: {drive.TotalSize}");
            Console.WriteLine($"Free: {drive.TotalFreeSpace}");

            Console.WriteLine("===========");

            // 1.2 Get all drives
            var drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("==========================");
            // ************ 2. Directory ************
            string path = "Abc";
            // Directory.CreateDirectory(path); // 2.2 Create directory

            // Directory.Delete(path); // 2.3 Delete

            if (Directory.Exists(path)) // 2.1 Check exists
            {
                Console.WriteLine($"{path} exists");
            }
            else
            {
                Console.WriteLine($"{path} not exists");
            }

            Console.WriteLine("===========");
            string pathObj = "obj";

            // 2.4 Get all files in obj directory
            var files = Directory.GetFiles(pathObj);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("===========");
            // 2.5 Get all directories in obj directory
            var directories = Directory.GetDirectories(pathObj);
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            Console.WriteLine("===========");
            // 2.6 Get all files of all directores in obj directory
            ListFileDirectory(pathObj);

            Console.WriteLine("==========================");
            // ************ 3. Path ************
            // 3.1 Combine string to path
            string pathCombine = Path.Combine("Dir1", "Dir2", "test.txt");
            Console.WriteLine(pathCombine);

            // 3.2 Change extension to md
            string pathChanged = Path.ChangeExtension(pathCombine, "md");
            Console.WriteLine(pathChanged);

            // 3.3 Get directory name of file
            Console.WriteLine(Path.GetDirectoryName(pathChanged));

            // 3.4 Get extension
            Console.WriteLine(Path.GetExtension(pathChanged));

            // 3.5 Get file name
            Console.WriteLine(Path.GetFileName(pathChanged));

            // 3.6 Get full path 
            string path1 = "/Dir1/Dir2/test.md"; // (F:\Dir1\Dir2\test.md)
            string path2 = "Dir1/Dir2/test.md"; // (F:\Csharp\LearnCsharp2\CS002\Dir1\Dir2\test.md)
            Console.WriteLine(Path.GetFullPath(path1));
            Console.WriteLine(Path.GetFullPath(path2));

            // 3.7 Create a random file name
            Console.WriteLine(Path.GetRandomFileName()); // s2u0mpv3.2ro

            // 3.8 Create a temp file
            Console.WriteLine(Path.GetTempFileName()); // C:\Users\huynh\AppData\Local\Temp\tmpAFFE.tmp

            Console.WriteLine("==========================");
            // ************ 4. File ************
            // 4.1 Replace all text to file or create new file with content
            string fileName = "1.txt";
            string content = "Hello World!";
            // File.WriteAllText(fileName, content);

            // 4.2 Push text to exists file
            // File.AppendAllText(fileName, " How are you?");

            // 4.3 Read all text
            // Console.WriteLine(File.ReadAllText(fileName));

            // 4.4 Remame file
            // File.Move(fileName, "2.txt");

            // 4.5 Copy file
            // File.Copy("2.txt", "1.txt");

            // 4.6 Delete file
            // File.Delete("2.txt");
        }
        static void ListFileDirectory(string path) // 2.6
        {
            String[] directories = Directory.GetDirectories(path);
            String[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("====");
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
                ListFileDirectory(directory); // Recursive   
            }
        }
    }
}