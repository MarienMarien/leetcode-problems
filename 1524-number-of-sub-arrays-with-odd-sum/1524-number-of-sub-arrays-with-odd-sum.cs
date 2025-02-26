public class Solution {
    public int NumOfSubarrays(int[] arr) {
        const int MOD = 1_000_000_007;
        var prefSum = 0;
        var oddCount = 0;
        var evenCount = 1;
        var subarrayCount = 0;
        foreach(var a in arr)
        {
            prefSum += a;
            if(prefSum % 2 == 0)
            {
                evenCount++;
                subarrayCount += oddCount;
            } else {
                oddCount++;
                subarrayCount += evenCount;
            }
            subarrayCount %= MOD;
        }

        return subarrayCount;
    }
}