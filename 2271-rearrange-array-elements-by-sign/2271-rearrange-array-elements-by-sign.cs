public class Solution {
    public int[] RearrangeArray(int[] nums) {
        var res = new int[nums.Length];
        var pId = 0;
        var nId = 1;

        foreach (var n in nums)
        {
            if (n > 0)
            {
                res[pId] = n;
                pId += 2;
            }
            else
            {
                res[nId] = n;
                nId += 2;
            }
        }

        return res;
    }
}