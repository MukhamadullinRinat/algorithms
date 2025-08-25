namespace TestDevSkiller
{
    public class LongestSubstringSolver
    {
        public int LengthOfLongestSubstring(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var start = 0;
            var end = 0;
            var result = 1;

            while (end < input.Length)
            {
                var substring = input.Substring(start, end - start + 1);

                var isCorrect = CheckSubstringCorrectness(substring);

                if (isCorrect)
                {
                    result = substring.Length;
                    end++;
                    continue;
                }

                end++;
                start++;
            }

            return result;
        }

        private bool CheckSubstringCorrectness(string substring)
        {
            var hashSet = new HashSet<char>();

            foreach (var c in substring)
                hashSet.Add(c);

            return hashSet.Count == substring.Length;
        }
    }
}
