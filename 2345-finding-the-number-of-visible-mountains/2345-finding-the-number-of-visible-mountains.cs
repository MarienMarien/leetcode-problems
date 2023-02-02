public class Solution {
    public int VisibleMountains(int[][] peaks) {
        var len = peaks.Length;
        var mountains = new int[peaks.Length][];
        for (var i = 0; i < peaks.Length; i++) 
            mountains[i] = new int[] { peaks[i][0] - peaks[i][1], peaks[i][0] + peaks[i][1], peaks[i][1] };
        Array.Sort(mountains, (a, b) => a[0] - b[0]);
        var prev = mountains[0];
        var seen = false;

        for (var i = 1; i < mountains.Length; i++)
        {
            var curr = mountains[i];
            if (curr[0] >= prev[0] && curr[1] <= prev[1])
            {
                if (curr[0] == prev[0] && curr[1] == prev[1])
                {
                    prev = curr;
                    if (!seen)
                    {
                        len--;
                        seen = true;
                    }
                }
                len--;
            }
            else if (curr[0] == prev[0] && curr[1] > prev[1])
            {
                len--;
                prev = curr;
                seen = false;
            }
            else
            {
                prev = curr;
                seen = false;
            }
        }
        return len;
    }
}