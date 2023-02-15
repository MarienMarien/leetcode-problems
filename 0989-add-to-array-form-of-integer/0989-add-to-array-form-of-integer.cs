public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        var curr = k;
        var i = num.Length - 1;
        IList<int> res = new List<int>();
        while (i >= 0 || curr > 0) {
            if (i >= 0)
                curr += num[i];
            res.Add(curr % 10);
            curr /= 10;
            i--;
        }
        var start = 0;
        var end = res.Count - 1;
        while (start < end)
        {
            var tmp = res[start];
            res[start] = res[end];
            res[end] = tmp;
            start++;
            end--;
        }
        return res;
    }
}