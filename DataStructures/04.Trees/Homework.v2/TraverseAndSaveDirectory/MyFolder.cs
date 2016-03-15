namespace TraverseAndSaveDirectory
{
    using System.Collections.Generic;
    using System.IO;

    public class MyFolder
    {
        public string Name { get; set; }
        public List<MyFolder> ChildFolders { get; set; }
        public List<MyFile> Files { get; set; }

        public MyFolder(string name = null) 
        {
            this.Name = name;
            this.ChildFolders = new List<MyFolder>();
            this.Files = new List<MyFile>();
        }

        public void AddFolder(MyFolder folder) 
        {
            this.ChildFolders.Add(folder);
        }

        public void AddFiles(FileInfo[] fileArr) 
        {
            foreach (var file in fileArr)
            {
                this.Files.Add(new MyFile(file.Name, (int)(file.Length)));
            }
        }

        public static int FileSizeSumOnNode(MyFolder node) 
        {
            int size = 0;

            foreach (var file in node.Files)
            {
                size += file.Size;
            }

            return size;
        }

        private static void CalculateSizeInSubTree(MyFolder node, ref int currentSize) 
        {
            currentSize += FileSizeSumOnNode(node);

            foreach (var child in node.ChildFolders)
            {
                CalculateSizeInSubTree(child, ref currentSize);
            }
        }

        /// <summary>
        /// The algorithm doesn't take for account problems that might overflow the integer type.
        /// Test folders with more that 2,147,483,647 bits will break the code(like the WINDOWS directory).
        /// </summary>
        public static int CalculateSizeInSubTree(MyFolder node) 
        {
            int size = 0;
            CalculateSizeInSubTree(node, ref size);
            return size;
        }
    }
}
