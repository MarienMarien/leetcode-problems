public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        IList<int> res = new List<int>();
        var nums = "123456789";
        var lowLen = low.ToString().Length;
        var highLen = high.ToString().Length;
        var currLen = lowLen;
        while (currLen <= highLen)
        {
            var start = 0;
            var end = currLen;
            while (end < 10 && currLen <= highLen) {
                var curr = Int32.Parse(nums[start..end]);
                if (curr > high)
                    break;
                if (curr >= low)
                    res.Add(curr);
                start++;
                end++;
            }
            currLen++;
        }
        return res;
    }
}