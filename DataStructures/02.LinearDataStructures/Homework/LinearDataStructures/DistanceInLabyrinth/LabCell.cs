using System;

namespace LinearDataStructures.DistanceInLabyrinth
{
    public class LabCell
    {
        public bool Left { get; set; }
        public bool Right { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public string Value { get; set; }
        public bool InTheCurrentPath { get; set; }


        public LabCell(string value) 
        {
            this.Value = value;
            this.Left = false;
            this.Right = false;
            this.Up = false;
            this.Down = false;
            this.InTheCurrentPath = false;
        }

        public override bool Equals(object obj)
        {
            if (obj is LabCell)
            {
                LabCell objAsCell = obj as LabCell;

                if (this.Value == objAsCell.Value)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return  this.Value.GetHashCode() +
                    this.Left.GetHashCode() +
                    this.Right.GetHashCode() +
                    this.Up.GetHashCode() +
                    this.Down.GetHashCode();
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
