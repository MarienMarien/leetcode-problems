public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var sums = new Dictionary<int, int> { { 0, 1 } };
        var runSum = 0;
        var count = 0;
        foreach(var n in nums)
        {
            runSum += n;
            if(sums.ContainsKey(runSum - k))
                count += sums[runSum - k];
            if(!sums.TryAdd(runSum, 1))
                sums[runSum] += 1;
        }

        return count;
    }
}