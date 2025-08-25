namespace TestDevSkiller
{
    public class IntervalMerger
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new int[][] { newInterval };
            }

            if (newInterval.Length == 0)
            {
                return intervals;
            }

            var currentIndex = 0;
            var isNewProcessed = false;
            var startMerged = newInterval[0];
            var endMerged = newInterval[1];
            var result = new List<int[]>();

            while (currentIndex < intervals.Length)
            {
                if (intervals[currentIndex][0] > newInterval[1] && !isNewProcessed)
                {
                    result.Add([startMerged, endMerged]);
                    isNewProcessed = true;
                }

                if (intervals[currentIndex][0] >= newInterval[0] && intervals[currentIndex][1] <= newInterval[1])
                {
                    currentIndex++;
                    continue;
                }

                if (intervals[currentIndex][1] < newInterval[0] || intervals[currentIndex][0] > newInterval[1])
                {
                    result.Add(intervals[currentIndex]);
                    currentIndex++;
                    continue;
                }

                if (intervals[currentIndex][0] < newInterval[0])
                {
                    startMerged = intervals[currentIndex][0];
                }

                if (intervals[currentIndex][1] > newInterval[1])
                {
                    endMerged = intervals[currentIndex][1];
                }

                currentIndex++;
            }

            if (!isNewProcessed)
            {
                result.Add([startMerged, endMerged]);
            }

            return result.ToArray();
        }

        public int[][] Merge(int[][] interval)
        {
            var sortedIntervals = interval
                .Where(i => i.Length == 2)
                .OrderBy(i => i[0])
                .ToArray();

            var result = new List<int[]>();
            var i = 0;
            var j = 1;

            while (i < sortedIntervals.Length)
            {
                var k = MergeTo(i, j, sortedIntervals, result);

                if (k == j)
                {
                    result.Add(sortedIntervals[i]);
                    i = k;
                    continue;
                }

                j = k;
            }

            return result.ToArray();
        }

        private int MergeTo(int indexMergeToInterval, int index, int[][] sortedIntervals, List<int[]> result)
        {
            if (index >= sortedIntervals.Length)
                {
                    return index;
                }

            while (index < sortedIntervals.Length && sortedIntervals[index][1] <= sortedIntervals[indexMergeToInterval][1])
                index++;

            if (index >= sortedIntervals.Length)
            {
                return index;
            }

            if (index < sortedIntervals.Length && sortedIntervals[index][0] <= sortedIntervals[indexMergeToInterval][1])
            {
                sortedIntervals[indexMergeToInterval][1] = sortedIntervals[index][1];
                index++;
            }

            return index;
        }
    }
}
