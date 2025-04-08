public class Solution {
    public int MinimumOperations(int[] nums) {
        var numMap = new Dictionary<int, int>();
        var duplicatesCount = 0;
        foreach(var num in nums)
        {
            if(!numMap.TryAdd(num, 1))
            {
                duplicatesCount++;
                numMap[num]++;
            }
        }

        var opCount = 0;
        if(duplicatesCount == 0)
            return opCount;
        var id = 0;
        var n = nums.Length;
        while(id < n)
        {
            var boundary = Math.Min(id + 3, n);
            for(; id < boundary; id++)
            {
                if(numMap[nums[id]] > 1)
                    duplicatesCount--;
                numMap[nums[id]]--;
            }
            opCount++;
            if(duplicatesCount == 0)
                break;
        }
        return opCount;
    }
}