namespace _02.StringEditor
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
            this.text.InsertRange(position, str.ToCharArray());
        }

        public void Append(string str)
        {
            this.text.AddRange(str.ToCharArray());
        }

        public void Delete(int startIndex, int count)
        {
            this.text.RemoveRange(startIndex, count);
        }

        public void Replace(int startIndex, int count, string str)
        {
            this.text.RemoveRange(startIndex, count);
            this.text.InsertRange(startIndex, str.ToCharArray());
        }

        public void Print()
        {
            foreach (var str in this.text)
            {
                Console.Write(str);
            }
        }

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
    }
}
