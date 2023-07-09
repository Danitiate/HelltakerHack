using HelltakerGrid;
using System;

namespace HelltakerHack
{
    public class GridHelper
    {
        public const string ResetString = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                          "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level1String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 2 9 1 1 1 1\n" +
                                           "1 1 1 2 2 3 2 2 1 1 1 1\n" +
                                           "1 1 1 2 3 2 3 1 1 1 1 1\n" +
                                           "1 1 2 2 1 1 1 1 1 1 1 1\n" +
                                           "1 1 2 4 2 2 4 2 1 1 1 1\n" +
                                           "1 1 2 4 2 4 2 2 8 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level2String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 2 2 2 2 1 1 1 1\n" +
                                           "1 1 1 1 3 1 5 5 2 2 1 1\n" +
                                           "1 1 1 2 5 1 1 12 12 4 1 1\n" +
                                           "1 1 1 2 2 1 1 2 5 2 1 1\n" +
                                           "1 1 1 9 2 1 1 2 3 2 1 1\n" +
                                           "1 1 1 1 1 1 1 8 2 3 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level3String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 8 8 8 2 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 7 1 1\n" +
                                           "1 1 1 1 2 5 5 2 2 9 1 1\n" +
                                           "1 1 1 1 5 1 5 1 2 2 1 1\n" +
                                           "1 1 1 1 2 2 3 5 5 1 1 1\n" +
                                           "1 1 6 1 5 1 5 1 2 1 1 1\n" +
                                           "1 1 2 2 2 2 2 3 2 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level4String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 9 1 6 2 4 1 1 1 1 1 1\n" +
                                           "1 2 4 5 12 2 7 2 1 1 1 1\n" +
                                           "1 4 2 4 2 4 4 2 8 1 1 1\n" +
                                           "1 2 4 2 4 2 4 4 2 1 1 1\n" +
                                           "1 1 2 4 2 4 2 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level5String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 2 8 1 1\n" +
                                           "1 1 1 1 1 1 1 2 7 4 2 1\n" +
                                           "1 1 1 1 1 9 1 10 2 4 2 1\n" +
                                           "1 1 1 1 1 2 1 2 10 2 10 1\n" +
                                           "1 1 1 1 1 3 1 4 4 4 4 1\n" +
                                           "1 1 1 1 1 10 2 10 2 2 10 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 6 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level6String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 2 9 2 1 1 1 1 1 1\n" +
                                           "1 1 1 4 4 4 1 1 1 1 1 1\n" +
                                           "1 1 2 2 2 6 1 1 1 1 1 1\n" +
                                           "1 1 1 10 12 2 2 1 1 1 1 1\n" +
                                           "1 1 1 3 1 4 4 2 2 1 1 1\n" +
                                           "1 1 1 2 2 4 2 3 1 1 1 1\n" +
                                           "1 1 1 1 1 1 7 4 2 1 1 1\n" +
                                           "1 1 1 1 1 1 1 8 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level7String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 8 2 1 1 1 1 1\n" +
                                           "1 1 1 1 1 2 7 2 1 1 1 1\n" +
                                           "1 1 2 6 1 4 4 4 1 1 1 1\n" +
                                           "1 1 3 4 2 3 4 2 1 1 1 1\n" +
                                           "1 1 2 1 3 2 2 9 1 1 1 1\n" +
                                           "1 1 11 1 1 10 1 1 1 1 1 1\n" +
                                           "1 1 10 11 10 11 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level8String = "1 1 1 1 1 8 1 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 3 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 1 2 1 1 1 1 1\n" +
                                           "1 1 1 1 2 9 2 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public const string Level9String = "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 8 1 1 1 1 1 1\n" +
                                           "1 1 1 1 2 2 2 1 1 1 1 1\n" +
                                           "1 1 1 1 4 7 4 1 1 1 1 1\n" +
                                           "1 1 4 1 4 2 2 1 2 1 1 1\n" +
                                           "1 4 2 2 4 4 4 2 2 6 1 1\n" +
                                           "1 2 4 4 4 2 2 4 4 2 1 1\n" +
                                           "1 1 9 2 4 2 2 4 2 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1\n" +
                                           "1 1 1 1 1 1 1 1 1 1 1 1";

        public static Cell[,] SetupGrid(string gridString)
        {
            var rows = gridString.Split("\n");
            var grid = new Cell[rows[0].Split(' ').Length, rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                var columns = rows[i].Split(' ');
                for (int j = 0; j < columns.Length; j++)
                {
                    var value = Int32.Parse(columns[j]);
                    grid[j, i] = new Cell(value, j, i);
                }
            }
            return grid;
        }

        public static Cell[,] SetupGridFromLevel(int level)
        {
            switch (level)
            {
                case 0:
                    return SetupGrid(ResetString);
                case 1:
                    return SetupGrid(Level1String);
                case 2:
                    return SetupGrid(Level2String);
                case 3:
                    return SetupGrid(Level3String);
                case 4:
                    return SetupGrid(Level4String);
                case 5:
                    return SetupGrid(Level5String);
                case 6:
                    return SetupGrid(Level6String);
                case 7:
                    return SetupGrid(Level7String);
                case 8:
                    return SetupGrid(Level8String);
                case 9:
                    return SetupGrid(Level9String);
                default:
                    return SetupGrid(ResetString);
            }
        }

        public static string GetMaxAmountFromLevel(int level)
        {
            switch(level)
            {
                case 0:
                    return "0";
                case 1:
                    return "23";
                case 2:
                    return "24";
                case 3:
                    return "32";
                case 4:
                    return "23";
                case 5:
                    return "23";
                case 6:
                    return "43";
                case 7:
                    return "32";
                case 8:
                    return "12";
                case 9:
                    return "33";
                default: 
                    return "0";
            }
        }
    }
}
