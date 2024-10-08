public class Solution {
    public int MinSwaps(string s) {
        const char OPENBRACKET = '[';
        var openBracketsCount = 0;
        foreach(var ch in s)
        {
            if(ch == OPENBRACKET)
            {
                openBracketsCount++;
                continue;
            }
            if(openBracketsCount > 0)
                openBracketsCount--;
        }

        return (openBracketsCount + 1) / 2;
    }
}