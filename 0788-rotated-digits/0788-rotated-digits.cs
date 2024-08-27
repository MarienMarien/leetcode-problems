public class Solution {
    public int RotatedDigits(int n) {
        var dp = new int[n + 1];
        var goodCount = 0;
        var rotateToSelf = new HashSet<int> { 0, 1, 8 };
        var rotate = new HashSet<int> { 2, 5, 6, 9 };

        for (var i = 0; i <= n; i++)
        {
            if (i < 10)
            {
                if (rotateToSelf.Contains(i))
                    dp[i] = 1;
                else if (rotate.Contains(i))
                {
                    dp[i] = 2;
                    goodCount++;
                }
            }
            else {
                var rem = dp[i % 10];
                var div = dp[i / 10];
                if (rem == 1 && div == 1)
                {
                    dp[i] = 1;
                }
                else if(rem >=1 && div >= 1)
                {
                    dp[i] = 2;
                    goodCount++;
                }
            }
        }

        return goodCount;
    }
}