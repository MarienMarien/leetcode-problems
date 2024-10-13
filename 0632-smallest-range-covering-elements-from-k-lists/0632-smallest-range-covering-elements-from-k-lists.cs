public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        var merged = new List<(int num, int listId)>();
        for (var listId = 0; listId < nums.Count; listId++)
        {
            for (var i = 0; i < nums[listId].Count; i++)
            {
                if (i > 0 && nums[listId][i] == nums[listId][i - 1])
                    continue;
                merged.Add((nums[listId][i], listId));
            }
        }

        merged = merged.OrderBy(x => x.num).ToList();

        var freq = new Dictionary<int, int>();
        var rangeStart = 0;
        var rangeEnd = Int32.MaxValue;
        var left = 0;
        var count = 0;

        for (var right = 0; right < merged.Count; right++)
        {
            if(!freq.TryAdd(merged[right].listId, 1))
                freq[merged[right].listId] += 1;

            if (freq[merged[right].listId] == 1)
                count++;

            while (count == nums.Count)
            {
                var currRange = merged[right].num - merged[left].num;
                if (currRange < rangeEnd - rangeStart)
                {
                    rangeStart = merged[left].num;
                    rangeEnd = merged[right].num;
                }
                freq[merged[left].listId]--;

                if (freq[merged[left].listId] == 0)
                    count--;
                left++;
            }
            
        }

        return new int[] { rangeStart, rangeEnd };
    }
}