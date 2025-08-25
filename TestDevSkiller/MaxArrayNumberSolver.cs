namespace TestDevSkiller;

internal class MaxArrayNumberSolver
{
    public int Solve(int[] input)
    {
        if (input.Length == 0)
            return 0;

        if (input.Length == 1)
            return 1;

        var sortedArray = input.Order().ToArray();

        var stack = new Stack<StackItem>();

        stack.Push(new StackItem
        {
            Target = sortedArray[sortedArray.Length - 1],
            RightPointer = sortedArray.Length - 1
        });

        while (stack.Count > 0)
        {
            var item = stack.Pop();


        }
    }

    private int CheckIfPossibleCreateSubarrays(int targetSum, int rightIndex, int leftIndex, int[] array)
    {
        var numberArrays = 0;
        var currentResult = array[rightIndex];
        while (leftIndex <= rightIndex)
        {
            if (leftIndex == rightIndex)
            {
                if (currentResult != targetSum)
                {
                    numberArrays = 0;
                }

                numberArrays++;

                break;
            }

            if (array[rightIndex] == targetSum)
            {
                rightIndex--;
                numberArrays++;
                currentResult = array[rightIndex];
                continue;
            }

            
        }

        return numberArrays;
    }

    public class StackItem
    {
        public int Target { get; set; }

        public int RightPointer { get; set; }
    }
}
