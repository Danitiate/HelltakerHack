using HelltakerHack;

namespace HelltakerGrid
{
    public class Cell
    {
        public int Column;
        public int Row;
        public int Value;
        public CellState CellState;
        public CellState OriginalCellState;

        public Cell(object value, int column, int row)
        {
            Column = column;
            Row = row;
            Value = value == null ? 1 : (int)value;
            CellState = GetCellState();
            OriginalCellState = GetCellState();
        }

        public CellState GetCellState()
        {
            switch (Value)
            {
                case 1: 
                    return CellState.WALL;
                case 2:
                    return CellState.GROUND;
                case 3:
                    return CellState.ENEMY;
                case 4:
                    return CellState.ROCK;
                case 5:
                    return CellState.SPIKE;
                case 6:
                    return CellState.KEY;
                case 7:
                    return CellState.DOOR;
                case 8:
                    return CellState.GOAL;
                case 9:
                    return CellState.PLAYER;
                case 10:
                    return CellState.SPIKE0;
                case 11:
                    return CellState.SPIKE1;
                case 12:
                    return CellState.SPIKEROCK;
                default:
                    return CellState.WALL;
            }
        }
    }
}
