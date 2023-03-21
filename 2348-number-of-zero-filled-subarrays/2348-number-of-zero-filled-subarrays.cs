public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        long subarrayCount = 0;
        long currZeroCount = 0;
        foreach (var n in nums) {
            if (n != 0)
            {
                subarrayCount += (currZeroCount * (currZeroCount + 1)) / 2;
                currZeroCount = 0;
            }
            else {
                currZeroCount++;
            }
        }
        if(currZeroCount > 0)
            subarrayCount += (currZeroCount * (currZeroCount + 1)) / 2;

        return subarrayCount;
    }
}