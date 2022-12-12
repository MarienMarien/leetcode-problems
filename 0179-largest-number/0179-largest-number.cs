public class Solution {
    public string LargestNumber(int[] nums) {
        Array.Sort(nums, 
            Comparer<int>.Create((x, y) => {
                var xStr = x.ToString();
                var yStr = y.ToString();
                var num1 = new StringBuilder(xStr).Append(yStr).ToString();
                var num2 = new StringBuilder(yStr).Append(xStr).ToString();
                return num2.CompareTo(num1);
            })
        );
        if(nums[0] == 0)
            return "0";
        var sb = new StringBuilder();
        foreach (var el in nums) {
            sb.Append(el);
        }
        return sb.ToString();
    }
}