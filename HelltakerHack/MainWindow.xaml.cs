using HelltakerGrid;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace HelltakerHack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int GRID_SIZE = 12;
        private int SelectedValue = 0;
        private Solver Solver;
        public Cell[,] Grid = new Cell[GRID_SIZE, GRID_SIZE];

        public MainWindow()
        {
            InitializeComponent();
            var amount = 0;
            var row = 0;
            var column = 0;
            foreach (var child in HelltakerGrid.Children)
            {
                var cell = ((Label)child);
                Grid[column, row] = new Cell(cell.Content, column, row);
                if (cell.Content == null)
                {
                    cell.Content = 1;
                    SetCellColor(cell);
                    cell.MouseLeftButtonUp += (object sender, MouseButtonEventArgs e) => HelltakerCellClick(sender);
                }
                else
                {
                    cell.FontWeight = FontWeight.FromOpenTypeWeight(750);
                }
                column++;
                amount++;
                if (amount % GRID_SIZE == 0)
                {
                    row++;
                    column = 0;
                }
            }
            Solver = new Solver(Grid);
        }

        private void HelltakerCellClick(object sender)
        {
            var amount = 0;
            var row = 0;
            var column = 0;
            foreach (var child in HelltakerGrid.Children)
            {
                if (sender == child)
                {
                    break;
                }
                column++;
                amount++;
                if (amount % GRID_SIZE == 0)
                {
                    row++;
                    column = 0;
                }
            }
            var cell = ((Label)sender);
            cell.Foreground = Brushes.Black;
            if (SelectedValue == 0)
            {
                cell.Content = null;
            }
            else
            {
                cell.Content = SelectedValue;
            }
            SetCellColor(cell);
            UpdateSpecificCellInGrid(row, column, SelectedValue);
        }

        public void UpdateGridCellStates()
        {
            foreach (var cell in Grid)
            {
                cell.CellState = cell.OriginalCellState;
            }
        }

        public void UpdateSpecificCellInGrid(int row, int column, int newValue)
        {
            var cell = Grid[column, row];
            switch (newValue)
            {
                case 1:
                    cell.CellState = CellState.WALL;
                    cell.OriginalCellState = CellState.WALL;
                    break;
                case 2:
                    cell.CellState = CellState.GROUND;
                    cell.OriginalCellState = CellState.GROUND;
                    break;
                case 3:
                    cell.CellState = CellState.ENEMY;
                    cell.OriginalCellState = CellState.ENEMY;
                    break;
                case 4:
                    cell.CellState = CellState.ROCK;
                    cell.OriginalCellState = CellState.ROCK;
                    break;
                case 5:
                    cell.CellState = CellState.SPIKE;
                    cell.OriginalCellState = CellState.SPIKE;
                    break;
                case 6:
                    cell.CellState = CellState.KEY;
                    cell.OriginalCellState = CellState.KEY;
                    break;
                case 7:
                    cell.CellState = CellState.DOOR;
                    cell.OriginalCellState = CellState.DOOR;
                    break;
                case 8:
                    cell.CellState = CellState.GOAL;
                    cell.OriginalCellState = CellState.GOAL;
                    break;
                case 9:
                    cell.CellState = CellState.PLAYER;
                    cell.OriginalCellState = CellState.PLAYER;
                    break;
                case 10:
                    cell.CellState = CellState.SPIKE0;
                    cell.OriginalCellState = CellState.SPIKE0;
                    break;
                case 11:
                    cell.CellState = CellState.SPIKE1;
                    cell.OriginalCellState = CellState.SPIKE1;
                    break;
                case 12:
                    cell.CellState = CellState.SPIKEROCK;
                    cell.OriginalCellState = CellState.SPIKEROCK;
                    break;
                default:
                    cell.CellState = CellState.WALL;
                    cell.OriginalCellState = CellState.WALL;
                    break;
            }

        }

        private void SetCellColor(Label cell)
        {
            switch (cell.Content)
            {
                case 1:
                    cell.Background = Brushes.Black;
                    break;
                case 2:
                    cell.Background = Brushes.White;
                    break;
                case 3:
                    cell.Background = Brushes.Red;
                    break;
                case 4:
                    cell.Background = Brushes.LightGray;
                    break;
                case 5:
                    cell.Background = Brushes.Blue;
                    break;
                case 6:
                    cell.Background = Brushes.LightYellow;
                    break;
                case 7:
                    cell.Background = Brushes.LightGreen;
                    break;
                case 8:
                    cell.Background = Brushes.Yellow;
                    break;
                case 9:
                    cell.Background = Brushes.Green;
                    break;
                case 10:
                    cell.Background = Brushes.LightBlue;
                    break;
                case 11:
                    cell.Background = Brushes.BlueViolet;
                    break;
                case 12:
                    cell.Background = Brushes.Brown;
                    break;
                default:
                    cell.Background = Brushes.Black;
                    break;
            }
        }

        private void KeyPadButtonClick(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender);
            var content = button.Content;
            if (content != null)
            {
                foreach (var element in KeyPad.Children)
                {
                    var child = ((Button)element);
                    child.IsEnabled = true;
                }
                if ((string)content == "DEL")
                {
                    SelectedValue = 0;
                }
                else
                {
                    SelectedValue = CellStateToInt((string)content);
                }
            }
            button.IsEnabled = false;
        }

        private int CellStateToInt(string selectedValue)
        {
            switch (selectedValue)
            {
                case "WALL": return 1;
                case "GROUND": return 2;
                case "ENEMY": return 3;
                case "ROCK": return 4;
                case "SPIKE": return 5;
                case "KEY": return 6;
                case "DOOR": return 7;
                case "GOAL": return 8;
                case "PLAYER": return 9;
                case "SPIKE 0": return 10;
                case "SPIKE 1": return 11;
                case "R SPIKE": return 12;
                default: return 0;
            }
        }

        private void SolveAllButtonClick(object sender, RoutedEventArgs e)
        {
            Output.Text = "Solving...";
            Int32.TryParse(MaxMoves.Text, out int maxMoves);
            Output.Text = Solver.SolvePuzzle(maxMoves);
            UpdateGridCellStates();
        }

        private void LevelSelectorButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonPressed = sender as Button;
            var levelSelected = (string)buttonPressed.Content;
            var levelSelectedAsInt = 0;
            Int32.TryParse(levelSelected, out levelSelectedAsInt);
            Grid = GridHelper.SetupGridFromLevel(levelSelectedAsInt);
            MaxMoves.Text = GridHelper.GetMaxAmountFromLevel(levelSelectedAsInt);
            var row = 0;
            var column = 0;
            foreach (var child in HelltakerGrid.Children)
            {
                var cell = ((Label)child);
                cell.Content = Grid[column, row].Value;
                SetCellColor(cell);
                column++;
                if (column == GRID_SIZE)
                {
                    row++;
                    column = 0;
                }
            }
            Solver = new Solver(Grid);
        }
    }
}
