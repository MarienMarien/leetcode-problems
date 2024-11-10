public class Solution {
    public int MinimumSubarrayLength(int[] nums, int k) {
        var bitCount = new int[32];
        var startId = 0;
        var res = Int32.MaxValue;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var bitId = 0; bitId < 32; bitId++)
            {
                bitCount[bitId] += (nums[i] >> bitId) & 1;
            }
            while (startId <= i && BinToInt(bitCount) >= k)
            {
                res = Math.Min(res, i - startId + 1);
                for (var bitId = 0; bitId < 32; bitId++)
                {
                    bitCount[bitId] -= (nums[startId] >> bitId) & 1;
                }
                startId++;
            }
        }

        return res == Int32.MaxValue ? -1 : res;
    }

    private int BinToInt(int[] cnt)
    {
        var num = 0;
        for (int i = 0; i < 32; i++)
        {
            if (cnt[i] != 0)
            {
                num ^= 1 << i;
            }
        }
        return num;
    }
}