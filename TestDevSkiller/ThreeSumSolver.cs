namespace TestDevSkiller
{
    public class ThreeSumSolver
    {
        public List<List<int>> ThreeSum(int[] input)
        {
            var result = new List<List<int>>();
            for (var i = 0; i < input.Length - 2; i++)
                for (var j = i + 1; j < input.Length - 1; j++)
                    for (var k = j + 1; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] != 0)
                            continue;

                        result.Add([input[i], input[j], input[k]]);
                    }

            return result;
        }
    }
}
