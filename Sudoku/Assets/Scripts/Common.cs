using System;
using System.Linq;
using System.Text;
using Roy.Sudoku.Common;

namespace Roy.Sudoku.Common
{
    public class Size
    {
        public const int BoardSize = 9;
        public const int GroupSize = 3;
        public const int NumberOfGroups = 9;
    }

    public class Validation
    {
        public const int ValidInputLow = 0;
        public const int ValidInputHigh = 9;
    }

    public class Defines
    {
        public const int RowIndex = 0;
        public const int ColumnIndex = 1;
        public const int IdLength = 8;
    }

    public class Generators
    {
        public const int CapitalZ = 65;
        public const int LowerA = 26;

        public static string GenerateRandomStringWithLength(int stringLength)
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(CapitalZ, LowerA)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(stringLength)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }
}

