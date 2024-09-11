public class Solution {
    public int MinBitFlips(int start, int goal) {
        var flipsCount = 0;
        if(start == goal)
            return flipsCount;

        while (start > 0 || goal > 0)
        {
            flipsCount += (start & 1) ^ (goal & 1);
            if (start > 0)
                start >>= 1;
            if (goal > 0)
                goal >>= 1;
        }

        return flipsCount;
    }
}