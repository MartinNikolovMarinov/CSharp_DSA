using LinearDataStructures.DistanceInLabyrinth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearDataStructures
{
    class Program
    {

        public static void PrintMatrix(LabCell[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[j, i] + " ");
                }

                Console.WriteLine();
            }
        }

        public static void LabirintTraversal() 
        {
            LabCell[,] labirint = new LabCell[6, 6] 
            {
                {
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("*"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                },                
                {                 
                    new LabCell("x"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("x"),
                },                
                {                 
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("x"),
                    new LabCell("0"),
                },
                {
                    new LabCell("x"),
                    new LabCell("x"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("0"),
                    new LabCell("x"),
                }
            };

            LabCell[,] result = LabTraversal.FindPathsInLabirint(labirint, 1, 2);
            PrintMatrix(result);
        }

        static void Main(string[] args)
        {
            LabirintTraversal();
        }
    }
}
