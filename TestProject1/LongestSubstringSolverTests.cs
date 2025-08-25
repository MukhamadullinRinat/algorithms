using TestDevSkiller;
using Xunit;

namespace TestProject1
{
    public class LongestSubstringSolverTests
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("", 0)]
        [InlineData("a", 1)]
        [InlineData("abcdef", 6)]
        [InlineData("abba", 2)]
        [InlineData("dvdf", 3)]
        [InlineData("anviaj", 5)]
        public void LengthOfLongestSubstring_Tests(string input, int expected)
        {
            var solver = new LongestSubstringSolver();
            var result = solver.LengthOfLongestSubstring(input);
            Assert.Equal(expected, result);
        }
    }
}
