namespace TraverseAndSaveDirectory
{

    public class MyFile
    {
        public int Size { get; set; }
        public string Name { get; set; }

        public MyFile(string name, int size) 
        {
            this.Name = name;
            this.Size = size;
        }
    }
}
