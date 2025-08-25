namespace TestDevSkiller
{
    /// <summary>
    /// The maximum number of array where items could be summarized with a given target
    /// </summary>
    public class CombinationSumSolver
    {
        public List<List<int>> CombinationSum(int[] candidates, int target)
        {
            var result = new List<List<int>>();
            Backtrack(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void Backtrack(int[] candidates, int target, int start, List<int> current, List<List<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            if (target < 0)
                return;

            for (var i = start; i < candidates.Length; i++)
            {
                current.Add(candidates[i]);
                Backtrack(candidates, target - candidates[i], i, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
