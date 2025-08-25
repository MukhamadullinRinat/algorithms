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
            Backtrack(candidates, target, new List<int>(), result);
            return result;
        }

        private void Backtrack(int[] candidates, int target, List<int> current, List<List<int>> result)
        {
            if(target < 0)
            {
                return;
            }

            if(target == 0)
            {
                result.Add(new List<int>(current));
                return;
            }

            foreach(int candidate in candidates)
            {
                current.Add(candidate);
                Backtrack(candidates, target - candidate, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
