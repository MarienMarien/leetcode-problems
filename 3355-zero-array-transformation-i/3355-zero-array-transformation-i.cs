public class Solution {
    public bool IsZeroArray(int[] nums, int[][] queries) {
        var queryPrefSum = new int[nums.Length];
        var lastId = nums.Length - 1;
        foreach(var q in queries)
        {
            queryPrefSum[q[0]] += 1;
            if(q[1] < lastId)
                queryPrefSum[q[1] + 1] -= 1;
        }

        var currTransform = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            currTransform += queryPrefSum[i];
            if(nums[i] > currTransform)
                return false;
        }

        return true;
    }
}