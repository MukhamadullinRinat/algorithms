namespace TestDevSkiller
{
    public class ProductOfArrayExceptSelfSolver
    {
        public int[] ProductExceptSelf(int[] input)
        {
            int n = input.Length;
            if (n == 0)
                return Array.Empty<int>();

            int[] output = new int[n];
            int[] left = new int[n];
            int[] right = new int[n];

            left[0] = 1;
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] * input[i - 1];
            }

            right[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * input[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                output[i] = left[i] * right[i];
            }

            return output;
        }
    }
}
