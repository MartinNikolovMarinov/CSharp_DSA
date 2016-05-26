namespace _02.QueensPuzzle
{
	using System;
	using System.Collections.Generic;

	class Program
	{
		static int solutionsCount;
		static ChessBoard chessBoard;
		static HashSet<int> attackedRows;
		static HashSet<int> attackedColumns;
		static HashSet<int> attackedRightDiagonal;
		static HashSet<int> attackedLeftDiagonal;

		static void Main(string[] args)
		{
			attackedRows = new HashSet<int>();
			attackedColumns = new HashSet<int>();
			attackedRightDiagonal = new HashSet<int>();
			attackedLeftDiagonal = new HashSet<int>();
			chessBoard = new ChessBoard();
			solutionsCount = 0;
			PutQueen(0);
			Console.WriteLine(solutionsCount);
		}

		private static void PutQueen(int row)
		{
			if (row == chessBoard.Size)
			{
				PrintQueens();
				solutionsCount++;
				return;
			}

			for (int col = 0; col < chessBoard.Size; col++)
			{
				if (CanPlaceQueen(row, col))
				{
					MarkAllAttacked(row, col);
					PutQueen(row + 1);
					UnmarkAllAttacked(row, col);
				}
			}
		}

		private static void PrintQueens()
		{
			for (int row = 0; row < chessBoard.Size; row++)
			{
				for (int col = 0; col < chessBoard.Size; col++)
				{
					if (chessBoard.Board[row, col])
						Console.Write('*');
					else
						Console.Write('-');
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		private static bool CanPlaceQueen(int row, int col)
		{
			bool queenIsAttacked = attackedRows.Contains(row) ||
				attackedColumns.Contains(col) ||
				attackedRightDiagonal.Contains(row + col) ||
				attackedLeftDiagonal.Contains(row - col);
			return !queenIsAttacked;
		}

		private static void MarkAllAttacked(int row, int col)
		{
			attackedRows.Add(row);
			attackedColumns.Add(col);
			attackedRightDiagonal.Add(row + col);
			attackedLeftDiagonal.Add(row - col);
			chessBoard.Board[row, col] = true;
		}

		private static void UnmarkAllAttacked(int row, int col)
		{
			attackedRows.Remove(row);
			attackedColumns.Remove(col);
			attackedRightDiagonal.Remove(row + col);
			attackedLeftDiagonal.Remove(row - col);
			chessBoard.Board[row, col] = false;
		}
	}
}
