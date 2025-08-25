using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class ThreeSumSolverTests
    {
        [Fact]
        public void ThreeSum_Example1()
        {
            var nums = new int[] { -1, 0, 1, 2, -1, -4 };
            var solver = new ThreeSumSolver();
            var result = solver.ThreeSum(nums);
            var expected = new List<List<int>>
            {
                new List<int> { -1, -1, 2 },
                new List<int> { -1, 0, 1 }
            };
            Assert.True(ContainsSameTriplets(result, expected));
        }

        [Fact]
        public void ThreeSum_Example2()
        {
            var nums = new int[] { 0, 1, 1 };
            var solver = new ThreeSumSolver();
            var result = solver.ThreeSum(nums);
            Assert.Empty(result);
        }

        [Fact]
        public void ThreeSum_Example3()
        {
            var nums = new int[] { 0, 0, 0 };
            var solver = new ThreeSumSolver();
            var result = solver.ThreeSum(nums);
            var expected = new List<List<int>> { new List<int> { 0, 0, 0 } };
            Assert.True(ContainsSameTriplets(result, expected));
        }

        [Fact]
        public void ThreeSum_NoTriplets()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var solver = new ThreeSumSolver();
            var result = solver.ThreeSum(nums);
            Assert.Empty(result);
        }

        [Fact]
        public void ThreeSum_MultipleZeros()
        {
            var nums = new int[] { 0, 0, 0, 0 };
            var solver = new ThreeSumSolver();
            var result = solver.ThreeSum(nums);
            var expected = new List<List<int>> { new List<int> { 0, 0, 0 } };
            Assert.True(ContainsSameTriplets(result, expected));
        }

        private bool ContainsSameTriplets(List<List<int>> actual, List<List<int>> expected)
        {
            var actualSet = new HashSet<string>(actual.Select(t => string.Join(",", t.OrderBy(x => x))));
            var expectedSet = new HashSet<string>(expected.Select(t => string.Join(",", t.OrderBy(x => x))));
            return actualSet.SetEquals(expectedSet);
        }
    }
}
