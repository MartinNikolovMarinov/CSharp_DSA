namespace _04.StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Wintellect.PowerCollections;

    public class StringEditor
    {
        private BigList<char> text;

        public int Count 
        {
            get 
            {
                return this.text.Count;
            }
        }

        public StringEditor() 
        {
            text = new BigList<char>();
        }

        public void Insert(string str, int position) 
        {
            try
            {
                this.text.InsertRange(position, str.ToCharArray());
            }
            catch (Exception)
            {
                Console.WriteLine("INSERT ERROR");
            }
        }

        public void Append(string str) 
        {
            try
            {
                this.text.AddRange(str.ToCharArray());
            }
            catch (Exception)
            {
                Console.WriteLine("APPEND ERROR");
            }
        }

        public void Delete(int startIndex, int count) 
        {
            try
            {
                this.text.RemoveRange(startIndex, count);
            }
            catch (Exception)
            {
                Console.WriteLine("DELETE ERROR");
            }
        }

        public void Replace(int startIndex, int count, string str) 
        {
            try
            {
                this.text.RemoveRange(startIndex, count);
                this.text.InsertRange(startIndex, str.ToCharArray());
            }
            catch (Exception)
            {
                Console.WriteLine("REPLACE ERROR");
            }
        }

        public void Print() 
        {
            foreach (var str in this.text)
            {
                Console.Write(str);
            }
        }
        
        #if DEBUG
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var str in this.text)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }

        public char[] GetRange(int start, int count) 
        {
            return this.text.GetRange(start, count).ToArray();
        }

        #endif
    }
}
