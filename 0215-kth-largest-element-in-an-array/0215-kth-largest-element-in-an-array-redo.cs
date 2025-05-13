public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var min = int.MaxValue;
        var max = int.MinValue;
        foreach(var n in nums)
        {
            min = Math.Min(min, n);
            max = Math.Max(max, n);
        }
        var counting = new int[max - min + 1];
        foreach(var n in nums)
        {
            counting[n - min]++;
        }
        var rem = k;
        for(var i = counting.Length - 1; i >= 0; i--)
        {
            rem -= counting[i];
            if(rem <= 0)
                return i + min;
        }
        return -1;
    }
}