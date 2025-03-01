public class Solution {
    public int MinSwaps(int[] data) {
        var onesWindowSize = 0;
        foreach(var d in data)
        {
            if(d == 1)
                onesWindowSize++;
        }
        if(onesWindowSize < 2 || onesWindowSize == data.Length)
            return 0;
        var currWindowSize = 0;
        var zeroCount = 0;
        var minSwaps = int.MaxValue;
        for(var i = 0; i < data.Length; i++)
        {
            if(data[i] == 0)
                zeroCount++;
            currWindowSize++;
            if(currWindowSize < onesWindowSize)
            {
                continue;
            }
            
            minSwaps = Math.Min(minSwaps, zeroCount);
            if(data[i - onesWindowSize + 1] == 0)
                zeroCount--;
        }

        return minSwaps;
    }
}