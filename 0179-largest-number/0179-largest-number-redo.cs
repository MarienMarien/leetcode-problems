public class Solution {
    public string LargestNumber(int[] nums) {
        Array.Sort(nums, Comparer<int>.Create((x, y) => { 
            var xStr = x.ToString();
            var yStr = y.ToString();
            return (yStr + xStr).CompareTo(xStr + yStr);
        }));

        if (nums[0] == 0)
            return "0";

        var sb = new StringBuilder();
        foreach (var n in nums)
        {
            sb.Append(n);
        }
        return sb.ToString();
    }
}