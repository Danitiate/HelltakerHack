namespace HelltakerHack
{
    public enum CellState
    {
        WALL = 1,
        GROUND = 2,
        ENEMY = 3,
        ROCK = 4,
        SPIKE = 5,
        KEY = 6,
        DOOR = 7,
        GOAL = 8,
        PLAYER = 9,
        SPIKE0 = 10,
        SPIKE1 = 11,
        SPIKEROCK = 12
    }

    public enum Move
    {
        ILLEGALMOVE = 0,
        MOVE = 1,
        MOVEANDSPIKE = 2,
        MOVEROCK = 3,
        MOVEENEMY = 4,
        DOOR = 5,
        COLLECTKEY = 6,
        WIN = 7
    }

    public enum Direction
    {
        NODIRECTION = 0,
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4
    }

    public class Action
    {
        public Direction Direction;
        public Move Move;
        public int movesUsed = 1;

        public Action(Direction direction, Move move)
        {
            Direction = direction;
            Move = move;
            if (move == Move.MOVEANDSPIKE)
            {
                movesUsed = 2;
            }
        }

        public static Action IllegalAction()
        {
            return new Action(Direction.NODIRECTION, Move.ILLEGALMOVE);
        }

        public Direction OppositeDirection()
        {
            switch (Direction)
            {
                case Direction.NORTH:
                    return Direction.SOUTH;
                case Direction.EAST:
                    return Direction.WEST;
                case Direction.SOUTH:
                    return Direction.NORTH;
                case Direction.WEST:
                    return Direction.EAST;
                default:
                    return Direction.NODIRECTION;
            }
        }

        public bool MovedToANewPosition()
        {
            return Move == Move.MOVE || Move == Move.MOVEANDSPIKE || Move == Move.COLLECTKEY || Move == Move.DOOR;
        }

        public override string ToString()
        {
            var output = "";
            if(movesUsed > 1)
            {
                output = $"{movesUsed}";
            }
            switch (Direction)
            {
                case Direction.NORTH: return $"↑{output} ";
                case Direction.EAST: return $"→{output} "; 
                case Direction.WEST: return $"←{output} ";
                case Direction.SOUTH: return $"↓{output} ";
                default: return "";
            }
        }
    }
}
