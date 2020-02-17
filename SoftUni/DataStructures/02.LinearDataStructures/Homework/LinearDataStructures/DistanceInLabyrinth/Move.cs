
using System;

namespace LinearDataStructures.DistanceInLabyrinth
{
    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Move(int x, int y) 
        {
            this.X = x;
            this.Y = y;
        }
    }
}
