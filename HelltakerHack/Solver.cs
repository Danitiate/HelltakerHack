using HelltakerGrid;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelltakerHack
{
    public class Solver
    {
        private int MaxMoves = 0;
        List<Action> Moves = new List<Action>();
        Cell[,] Grid;

        public Solver(Cell[,] grid)
        {
            Grid = grid;
        }

        public string SolvePuzzle(int maxMoves)
        {
            try
            {
                MaxMoves = maxMoves;
                if (MaxMoves <= 0)
                {
                    throw new Exception("Please add a value above 0");
                }
                else if (MaxMoves > 50)
                {
                    throw new Exception("Too many MaxMoves");
                }

                bool gameWon = MovePlayerAllDirections(1);
                if (gameWon)
                {
                    var output = "";
                    foreach (var move in Moves)
                    {
                        output += move.ToString();
                    }

                    Moves.Clear();
                    return output;
                }
                else
                {
                    return "Could not find any solution";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool MovePlayerAllDirections(int movesTaken)
        {
            var previousDirection = Direction.NODIRECTION;
            if (Moves.Any())
            {
                var lastAction = Moves.Last();
                if (lastAction.MovedToANewPosition())
                {
                    previousDirection = lastAction.Direction;
                }
            }
            else if (Moves.Count > 4)
            {
                var lastCycle = Moves.TakeLast(4);
                if (lastCycle.All(a => a.Move == Move.MOVE))
                {
                    if (lastCycle.Any(a => a.Direction == Direction.NORTH) && lastCycle.Any(a => a.Direction == Direction.EAST) && lastCycle.Any(a => a.Direction == Direction.WEST) && lastCycle.Any(a => a.Direction == Direction.SOUTH))
                    {
                        return false;
                    }
                }
            }
            var gameWon = false;
            if (previousDirection != Direction.SOUTH)
            {
                gameWon = MovePlayer(Direction.NORTH, movesTaken);
            }
            if (gameWon == false && previousDirection != Direction.WEST)
            {
                gameWon = MovePlayer(Direction.EAST, movesTaken);
            }
            if (gameWon == false && previousDirection != Direction.NORTH)
            {
                gameWon = MovePlayer(Direction.SOUTH, movesTaken);
            }
            if (gameWon == false && previousDirection != Direction.EAST)
            {
                gameWon = MovePlayer(Direction.WEST, movesTaken);
            }
            return gameWon;
        }

        private bool MovePlayer(Direction direction, int currentMove)
        {
            var player = FindPlayer();
            if (CheckIfUserHasWon(player))
            {
                return true;
            }
            else if (currentMove > MaxMoves)
            {
                return false;
            }
            var nextAction = GetNextAction(player, direction);
            if (nextAction.Move == Move.ILLEGALMOVE)
            {
                return false;
            }
            Moves.Add(nextAction);
            var nextCell = GetNextCell(player, direction);
            PerformAction(player, nextCell, nextAction);

            var gameWon = MovePlayerAllDirections(currentMove + nextAction.movesUsed);
            if (gameWon)
            {
                return true;
            }
            RevertAction();
            return false;
        }

        private Cell FindPlayer()
        {
            foreach (var cell in Grid)
            {
                if (cell.CellState == CellState.PLAYER)
                {
                    return cell;
                }
            }
            throw new Exception("No player found");
        }

        private bool CheckIfUserHasWon(Cell player)
        {
            if (player.Row > 0)
            {
                var northCell = GetNextCell(player, Direction.NORTH);
                if (northCell.CellState == CellState.GOAL)
                {
                    return true;
                }
            }
            if (player.Row < Grid.GetLength(0))
            {
                var southCell = GetNextCell(player, Direction.SOUTH);
                if (southCell.CellState == CellState.GOAL)
                {
                    return true;
                }
            }
            if (player.Column > 0)
            {
                var westCell = GetNextCell(player, Direction.WEST);
                if (westCell.CellState == CellState.GOAL)
                {
                    return true;
                }
            }
            if (player.Column < Grid.GetLength(1))
            {
                var eastCell = GetNextCell(player, Direction.EAST);
                if (eastCell.CellState == CellState.GOAL)
                {
                    return true;
                }
            }
            return false;
        }

        private Action GetNextAction(Cell player, Direction direction)
        {
            try
            {
                var nextCell = GetNextCell(player, direction);
                var nextMove = HandleNextMove(nextCell);
                if (ValidateNextMove(nextCell, nextMove, direction))
                {
                    return new Action(direction, nextMove);
                }
                else
                {
                    return Action.IllegalAction();
                }
            }
            catch (Exception ex)
            {
                return Action.IllegalAction();
            }
        }


        public Cell GetNextCell(Cell player, Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return Grid[player.Column, player.Row - 1];
                case Direction.EAST:
                    return Grid[player.Column + 1, player.Row];
                case Direction.SOUTH:
                    return Grid[player.Column, player.Row + 1];
                case Direction.WEST:
                    return Grid[player.Column - 1, player.Row];
                default:
                    throw new Exception("Not a valid direction");
            }
        }

        private Move HandleNextMove(Cell nextCell)
        {
            switch (nextCell.CellState)
            {
                case CellState.WALL:
                    return Move.ILLEGALMOVE;
                case CellState.GROUND:
                    return Move.MOVE;
                case CellState.ENEMY:
                    return Move.MOVEENEMY;
                case CellState.ROCK:
                    return Move.MOVEROCK;
                case CellState.SPIKE:
                    return Move.MOVEANDSPIKE;
                case CellState.KEY:
                    return Move.COLLECTKEY;
                case CellState.DOOR:
                    return Move.DOOR;
                case CellState.GOAL:
                    return Move.WIN;
                case CellState.PLAYER:
                    return Move.MOVE;
                case CellState.SPIKE0:
                    if (Moves.Count % 2 == 0)
                    {
                        return Move.MOVEANDSPIKE;
                    }
                    else
                    {
                        return Move.MOVE;
                    }
                case CellState.SPIKE1:
                    if(Moves.Count % 2 == 0)
                    {
                        return Move.MOVE;
                    }
                    else
                    {
                        return Move.MOVEANDSPIKE;
                    }
                case CellState.SPIKEROCK:
                    return Move.MOVEROCK;
                default:
                    throw new Exception("Not a valid cellState");
            }
        }

        private bool ValidateNextMove(Cell nextCell, Move nextMove, Direction direction)
        {
            switch (nextMove)
            {
                case Move.ILLEGALMOVE:
                    return false;
                case Move.MOVE:
                    return true;
                case Move.MOVEANDSPIKE:
                    return true;
                case Move.MOVEROCK:
                    var moveCell = GetNextCell(nextCell, direction);
                    return !IsUnmovable(moveCell);
                case Move.MOVEENEMY:
                    return true;
                case Move.DOOR:
                    return KeyCollected();
                case Move.COLLECTKEY:
                    return true;
                case Move.WIN:
                    return true;
                default:
                    return false;
            }
        }

        public void PerformAction(Cell player, Cell nextCell, Action action)
        {
            switch (action.Move)
            {
                case Move.MOVE:
                    nextCell.CellState = CellState.PLAYER;
                    if(player.OriginalCellState == CellState.SPIKE || player.OriginalCellState == CellState.SPIKEROCK)
                    {
                        player.CellState = CellState.SPIKE;
                    }
                    else
                    {
                        player.CellState = CellState.GROUND;
                    }
                    break;
                case Move.MOVEROCK:
                    var moveCell = GetNextCell(nextCell, action.Direction);
                    if (moveCell.CellState == CellState.SPIKE)
                    {
                        moveCell.CellState = CellState.SPIKEROCK;
                    }
                    else
                    {
                        moveCell.CellState = CellState.ROCK;
                    }
                    if (nextCell.CellState == CellState.SPIKEROCK)
                    {
                        nextCell.CellState = CellState.SPIKE;
                    }
                    else if(nextCell.OriginalCellState == CellState.KEY)
                    {
                        nextCell.CellState = CellState.KEY;
                    }
                    else
                    {
                        nextCell.CellState = CellState.GROUND;
                    }
                    if (player.OriginalCellState == CellState.SPIKE || player.OriginalCellState == CellState.SPIKEROCK)
                    {
                        action.movesUsed = 2;
                    }
                    break;
                case Move.MOVEENEMY:
                    var moveCell2 = GetNextCell(nextCell, action.Direction);
                    nextCell.CellState = CellState.GROUND;
                    if (!IsUnmovable(moveCell2) && (moveCell2.CellState == CellState.SPIKE1 || moveCell2.CellState == CellState.SPIKE) == false)
                    {
                        moveCell2.CellState = CellState.ENEMY;
                    }
                    if (player.OriginalCellState == CellState.SPIKE || player.OriginalCellState == CellState.SPIKEROCK)
                    {
                        action.movesUsed = 2;
                    }
                    break;
                case Move.MOVEANDSPIKE:
                    nextCell.CellState = CellState.PLAYER;
                    player.CellState = CellState.GROUND;
                    action.movesUsed = 2;
                    break;
                case Move.DOOR:
                    nextCell.CellState = CellState.PLAYER;
                    player.CellState = CellState.GROUND;
                    break;
                case Move.COLLECTKEY:
                    nextCell.CellState = CellState.PLAYER;
                    player.CellState = CellState.GROUND;
                    break;
                default:
                    break;
            }
        }

        public void RevertAction()
        {
            if (Moves.Count == 0)
            {
                return;
            }
            var player = FindPlayer();
            var lastAction = Moves.Last();

            switch (lastAction.Move)
            {
                case Move.MOVE:
                    var previousCell = GetNextCell(player, lastAction.OppositeDirection());
                    previousCell.CellState = CellState.PLAYER;
                    if(player.OriginalCellState == CellState.SPIKE)
                    {
                        player.CellState = CellState.SPIKE;
                    }
                    else
                    {
                        player.CellState = CellState.GROUND;
                    }
                    break;
                case Move.MOVEROCK:
                    var moveCellTarget = GetNextCell(player, lastAction.Direction);
                    var moveCellDestination = GetNextCell(moveCellTarget, lastAction.Direction);
                    if (moveCellTarget.OriginalCellState == CellState.SPIKE || moveCellTarget.OriginalCellState == CellState.SPIKEROCK)
                    {
                        moveCellTarget.CellState = CellState.SPIKEROCK;
                    }
                    else
                    {
                        moveCellTarget.CellState = CellState.ROCK;
                    }
                    if (moveCellDestination.OriginalCellState == CellState.SPIKE || moveCellDestination.OriginalCellState == CellState.SPIKEROCK)
                    {
                        moveCellDestination.CellState = CellState.SPIKE;
                    }
                    else if(moveCellDestination.OriginalCellState == CellState.KEY)
                    {
                        moveCellDestination.CellState = CellState.KEY;
                    }
                    else
                    {
                        moveCellDestination.CellState = CellState.GROUND;
                    }
                    break;
                case Move.MOVEENEMY:
                    var moveCellTarget2 = GetNextCell(player, lastAction.Direction);
                    var moveCellDestination2 = GetNextCell(moveCellTarget2, lastAction.Direction);
                    moveCellTarget2.CellState = CellState.ENEMY;
                    if (IsUnmovable(moveCellDestination2))
                    {
                        moveCellDestination2.CellState = moveCellDestination2.OriginalCellState;
                    }
                    break;
                case Move.MOVEANDSPIKE:
                    var previousCell2 = GetNextCell(player, lastAction.OppositeDirection());
                    previousCell2.CellState = CellState.PLAYER;
                    player.CellState = CellState.SPIKE;
                    break;
                case Move.DOOR:
                    var previousCell3 = GetNextCell(player, lastAction.OppositeDirection());
                    previousCell3.CellState = CellState.PLAYER;
                    player.CellState = CellState.DOOR;
                    break;
                case Move.COLLECTKEY:
                    var previousCell4 = GetNextCell(player, lastAction.OppositeDirection());
                    previousCell4.CellState = CellState.PLAYER;
                    player.CellState = CellState.KEY;
                    break;
                default:
                    break;
            }
            Moves.RemoveAt(Moves.Count - 1);
        }

        private bool IsUnmovable(Cell cell)
        {
            return cell.CellState == CellState.WALL || cell.CellState == CellState.ENEMY || cell.CellState == CellState.ROCK || cell.CellState == CellState.DOOR || cell.CellState == CellState.GOAL || cell.CellState == CellState.SPIKEROCK;
        }

        private bool KeyCollected()
        {
            return Moves.Any(action => action.Move == Move.COLLECTKEY);
        }
    }
}
