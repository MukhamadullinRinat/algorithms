namespace TestDevSkiller;

internal class FlightsSorter
{
}

internal class FlightStringComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if(x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        var firstTwoDigitsX = x.Substring(0, 2);
        var firstTwoDigitsY = y.Substring(0, 2);

        var compareResult = string.Compare(firstTwoDigitsX, firstTwoDigitsY, StringComparison.Ordinal);

        if(compareResult != 0) return compareResult;

        var secondTwoDigitsX = x.Length > 2 ? x.Substring(2) : string.Empty;
        var secondTwoDigitsY = x.Length > 2 ? y.Substring(2) : string.Empty;

        return string.Compare(secondTwoDigitsX, secondTwoDigitsY, StringComparison.Ordinal);
    }
}
