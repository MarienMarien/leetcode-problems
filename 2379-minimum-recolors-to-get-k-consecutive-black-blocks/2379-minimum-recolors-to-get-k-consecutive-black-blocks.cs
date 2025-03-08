public class Solution {
    public int MinimumRecolors(string blocks, int k) {
        var startId = 0;
        var whiteCount = 0;
        var minRecolor = int.MaxValue;
        for(var i = 0; i < blocks.Length; i++)
        {
            if(blocks[i] == 'W')
                whiteCount++;
            if(i < k - 1)
                continue;
            minRecolor = Math.Min(minRecolor, whiteCount);
            if(blocks[startId] == 'W')
                whiteCount--;
            startId++;
        }

        return minRecolor;
    }
}