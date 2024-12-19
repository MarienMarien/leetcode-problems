public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        var prefSum = 0;
        var currSum = 0;
        var chunksCount = 0;

        for (var i = 0; i < arr.Length; i++)
        {
            currSum += arr[i];
            prefSum += i;
            if (currSum == prefSum)
                chunksCount++;
        }

        return chunksCount;
    }
}