namespace TestDevSkiller
{
    public class FlightsSorterLogic
    {
        public string?[] SortFlights(string?[] input)
        {
            for (var i = 0; i < input.Length - 1; i++)
                for (var j = input.Length - 1; j > i; j--)
                {
                    var leftString = input[j - 1];
                    var rightString = input[j];

                    var compareResult = Compare(leftString, rightString);

                    if (compareResult == 0 || compareResult == 1)
                        continue;

                    input[j] = leftString;
                    input[j - 1] = rightString;
                }

            return input;
        }

        public int Compare(string? x, string? y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;


            for (var i = 0; i < 2; i++)
            {
                if (x[i] == y[i])
                    continue;

                if (!char.IsNumber(x[i]) && char.IsNumber(y[i]))
                    return 1;

                if (char.IsNumber(x[i]) && !char.IsNumber(y[i]))
                    return -1;

                return x[i] < y[i] ? 1 : -1;
            }

            for (var i = 2; i < x.Length; i++)
            {
                if (i >= y.Length)
                    return -1;

                if (x[i] == y[i])
                    continue;

                return x[i] < y[i] ? 1 : -1;
            }

            return x.Length < y.Length ? 1 : 0;
        }
    }
}
