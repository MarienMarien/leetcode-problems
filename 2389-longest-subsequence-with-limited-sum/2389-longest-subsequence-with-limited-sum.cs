public class Solution {
    public int[] AnswerQueries(int[] nums, int[] queries) {
        Array.Sort(nums);
        for (var i = 1; i < nums.Length; i++)
        {
            nums[i] += nums[i - 1];
        }
        var res = new int[queries.Length];
        for(var qId = 0; qId < queries.Length; qId++) {
            if (queries[qId] >= nums[^1]) {
                res[qId] = nums.Length;
                continue;
            }
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > queries[qId])
                {
                    res[qId] = i;
                    break;
                }
            }
        }
        return res;
    }
}