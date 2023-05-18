public class Solution {
    public int[] NumberOfLines(int[] widths, string s) {
        if(s == null || s.Length == 0)
            return new int[] { 0, 0 };
        const int LIMIT = 100;
        int linesCount = 1;
        int currLineWidth = 0;
        foreach (char ch in s) {
            int pixLen = widths[ch - 'a'];
            currLineWidth += pixLen;
            if(currLineWidth > 100) {
                currLineWidth = pixLen;
                linesCount++;
            }
        }
        return new int[]{ linesCount, currLineWidth };
    }
}