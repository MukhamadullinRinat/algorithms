using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class MaxPotencySolverTests
    {
        [Theory]
        [InlineData(3, new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, 50, 230)] // Take all of 1st and 2nd
        [InlineData(2, new int[] { 10, 20 }, new int[] { 100, 50 }, 10, 100)] // Only enough for 1st
        [InlineData(2, new int[] { 10, 20 }, new int[] { 100, 50 }, 20, 125)] // Only enough for 1st
        [InlineData(2, new int[] { 10, 20 }, new int[] { 100, 50 }, 25, 125)] // 1st + half of 2nd
        [InlineData(1, new int[] { 10 }, new int[] { 100 }, 5, 50)] // Half of only ingredient
        public void MaxPotency_Tests(int n, int[] costs, int[] potencies, int budget, int expected)
        {
            var solver = new MaxPotencySolver();
            var result = solver.MaxPotency(n, costs, potencies, budget);
            Assert.Equal(expected, result);
        }
    }
}
