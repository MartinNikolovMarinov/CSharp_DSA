namespace _02.QueensPuzzle
{
    using System;

    public class ChessBoard
    {
        public int Size { get; set; }
        public bool[,] Board { get; set; }

        public ChessBoard()
        {
            this.Size = 8;
            this.Board = new bool[8, 8];
        }
    }
}
