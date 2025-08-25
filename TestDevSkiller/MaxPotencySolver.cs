namespace TestDevSkiller
{
    public class MaxPotencySolver
    {
        public int MaxPotency(int n, int[] costs, int[] potencies, int budget)
        {
            return MaxPotencyStack(n, costs, potencies, budget);
        }

        public int MaxPotencyStack(int n, int[] costs, int[] potencies, int budget)
        {
            int maxPotency = 0;
            var stack = new Stack<(int index, int remainingBudget, int currentPotency)>();
            stack.Push((0, budget - costs[0], potencies[0]));
            stack.Push((0, budget - costs[0] / 2, potencies[0] / 2));
            stack.Push((0, budget, 0));

            while (stack.Count > 0)
            {
                var (index, remainingBudget, currentPotency) = stack.Pop();

                if(remainingBudget == 0 && currentPotency > maxPotency)
                {
                    maxPotency = currentPotency;
                }

                if(remainingBudget > 0)
                {
                    if(index >= n - 1)
                    {
                        maxPotency = currentPotency > maxPotency ? currentPotency : maxPotency;
                        continue;
                    }

                    var nextIndex = index + 1;
                    //skip
                    stack.Push((nextIndex, remainingBudget, currentPotency));

                    //take half
                    stack.Push((nextIndex, remainingBudget - costs[nextIndex] / 2, currentPotency + potencies[nextIndex] / 2));

                    //take all
                    stack.Push((nextIndex, remainingBudget - costs[nextIndex], currentPotency + potencies[nextIndex]));
                }
            }

            return maxPotency;
        }
    }
}
