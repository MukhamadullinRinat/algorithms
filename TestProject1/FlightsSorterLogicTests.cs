using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class FlightsSorterLogicTests
    {
        [Theory]
        [InlineData(new[] { "AB12", "AB11", "AA10" }, new[] { "AA10", "AB11", "AB12" })]
        [InlineData(new[] { "ZZ99", "AA00", "AA01" }, new[] { "AA00", "AA01", "ZZ99" })]
        [InlineData(new[] { "AB", "AA", "AC" }, new[] { "AA", "AB", "AC" })]
        [InlineData(new[] { "AB12", "AB2", "AB1" }, new[] { "AB1", "AB12", "AB2" })]
        [InlineData(new[] { "AA10", "AA2", "AA1" }, new[] { "AA1", "AA10", "AA2" })]
        [InlineData(new[] { "AA", "AA1", "AA01" }, new[] { "AA", "AA01", "AA1" })]
        [InlineData(new[] { "AA", null, "AB" }, new[] { "AA", "AB", null })]
        [InlineData(new[] { null, null, "AA" }, new[] { "AA", null, null })]
        [InlineData(new[] { "AA", "AA" }, new[] { "AA", "AA" })]
        [InlineData(new[] { "AB12", "AB12", "AB11" }, new[] { "AB11", "AB12", "AB12" })]
        public void SortFlights_SortsCorrectly(string[] input, string[] expected)
        {
            var logic = new FlightsSorterLogic();
            var result = logic.SortFlights(input);
            Assert.Equal(expected, result);
        }
    }
}
