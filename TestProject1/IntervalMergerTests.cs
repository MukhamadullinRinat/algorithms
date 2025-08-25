using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class IntervalMergerTests
    {
        [Fact]
        public void MergeIntervals_Example1()
        {
            var intervals = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_Example2()
        {
            var intervals = new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 5 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_NoOverlap()
        {
            var intervals = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_AllOverlap()
        {
            var intervals = new int[][] { new int[] { 1, 5 }, new int[] { 2, 6 }, new int[] { 3, 7 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 7 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_SingleInterval()
        {
            var intervals = new int[][] { new int[] { 1, 10 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 10 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_Empty()
        {
            var intervals = new int[][] { };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }

        [Fact]
        public void MergeIntervals_TouchingButNotOverlapping()
        {
            var intervals = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 } };
            var merger = new IntervalMerger();
            var result = merger.Merge(intervals);
            var expected = new int[][] { new int[] { 1, 4 } };
            Assert.Equal(expected, result, new IntArrayComparer1());
        }
    }

    public class IntArrayComparer1 : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x == null || y == null) return false;
            if (x.Length != y.Length) return false;
            for (int i = 0; i < x.Length; i++)
                if (x[i] != y[i]) return false;
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            if (obj == null) return 0;
            int hash = 17;
            foreach (var i in obj)
                hash = hash * 23 + i.GetHashCode();
            return hash;
        }
    }
}
