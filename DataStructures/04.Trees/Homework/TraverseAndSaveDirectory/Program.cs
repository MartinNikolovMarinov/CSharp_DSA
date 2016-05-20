namespace TraverseAndSaveDirectory
{
    using System;
    using System.IO;

    class Program
    {
        public static void SaveFolderInMemory(DirectoryInfo[] dirInfoArr, FileInfo[] fileInfoArr, MyFolder directoryTree)
        {
            directoryTree.AddFiles(fileInfoArr);

            foreach (var dir in dirInfoArr)
            {
                try
                {
                    var newNode = new MyFolder(dir.Name);
                    directoryTree.AddFolder(newNode);
                    SaveFolderInMemory(dir.GetDirectories(), dir.GetFiles(), newNode);
                }
                catch (Exception)
                {
                    continue; // skip folders that we have no access for.
                }
            }
        }

        static void Main(string[] args)
        {
            string path = @"J:/TestFolder";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            MyFolder dirTree = new MyFolder();
            SaveFolderInMemory(dirInfo.GetDirectories(), dirInfo.GetFiles(), dirTree);
            int sizeInKbOfTheEntireSelectedFolder = MyFolder.CalculateSizeInSubTree(dirTree);
            Console.WriteLine();
        }
    }
}
