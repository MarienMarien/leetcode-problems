public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        var res = new bool[queries.Length];
        var closestLeftBadParity = new int[nums.Length];
        var lastBadParityId = -1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] % 2 == nums[i - 1] % 2)
            {
                lastBadParityId = i;
            }
            closestLeftBadParity[i] = lastBadParityId;
        }

        for (var i = 0; i < queries.Length; i++)
        {
            var currQuery = queries[i];
            var closestBadParity = closestLeftBadParity[currQuery[1]];
            if (closestBadParity <= currQuery[0])
            {
                res[i] = true;
                continue;
            }
            res[i] = false;
        }
        return res;
    }
}