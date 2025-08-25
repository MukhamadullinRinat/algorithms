using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class CombinationSumSolverTests
    {
        [Fact]
        public void CombinationSum_Example1()
        {
            var candidates = new int[] { 2, 3, 6, 7 };
            int target = 7;
            var solver = new CombinationSumSolver();
            var result = solver.CombinationSum(candidates, target);
            var expected = new List<List<int>>
            {
                new List<int> { 2, 2, 3 },
                new List<int> { 7 }
            };
            Assert.True(ContainsSameCombinations(result, expected));
        }

        [Fact]
        public void CombinationSum_Example2()
        {
            var candidates = new int[] { 2, 3, 5 };
            int target = 8;
            var solver = new CombinationSumSolver();
            var result = solver.CombinationSum(candidates, target);
            var expected = new List<List<int>>
            {
                new List<int> { 2, 2, 2, 2 },
                new List<int> { 2, 3, 3 },
                new List<int> { 3, 5 }
            };
            Assert.True(ContainsSameCombinations(result, expected));
        }

        [Fact]
        public void CombinationSum_Example3()
        {
            var candidates = new int[] { 2 };
            int target = 1;
            var solver = new CombinationSumSolver();
            var result = solver.CombinationSum(candidates, target);
            Assert.Empty(result);
        }

        private bool ContainsSameCombinations(List<List<int>> actual, List<List<int>> expected)
        {
            var actualSet = new HashSet<string>(actual.Select(c => string.Join(",", c.OrderBy(x => x))));
            var expectedSet = new HashSet<string>(expected.Select(c => string.Join(",", c.OrderBy(x => x))));
            return actualSet.SetEquals(expectedSet);
        }
    }
}
