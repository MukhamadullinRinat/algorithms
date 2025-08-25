using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class ProductOfArrayExceptSelfSolverTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
        [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
        [InlineData(new int[] { 2, 3 }, new int[] { 3, 2 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 0, 0 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 5, 1, 1, 1 }, new int[] { 1, 5, 5, 5 })]
        public void ProductExceptSelf_Tests(int[] input, int[] expected)
        {
            var solver = new ProductOfArrayExceptSelfSolver();
            var result = solver.ProductExceptSelf(input);
            Assert.Equal(expected, result);
        }
    }
}
