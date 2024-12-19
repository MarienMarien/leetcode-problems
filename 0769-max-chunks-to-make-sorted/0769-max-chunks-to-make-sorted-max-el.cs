public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        var maxEl = -1;
        var chunksCount = 0;

        for (var i = 0; i < arr.Length; i++)
        {
            maxEl = Math.Max(maxEl, arr[i]);
            if (maxEl == i)
                chunksCount++;
        }

        return chunksCount;
    }
}