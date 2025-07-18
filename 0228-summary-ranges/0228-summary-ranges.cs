public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var result = new List<string>();
        if(nums.Length == 0)
            return result;

        var rStart = nums[0];
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i] - 1 == nums[i - 1])
                continue;

            var str = nums[i - 1] == rStart ? $"{rStart}" : $"{rStart}->{nums[i - 1]}";
            result.Add(str);

            rStart = nums[i];
        }

        var lastStr = nums[^1] == rStart ? $"{rStart}" : $"{rStart}->{nums[^1]}";
        result.Add(lastStr);

        return result;
    }
}