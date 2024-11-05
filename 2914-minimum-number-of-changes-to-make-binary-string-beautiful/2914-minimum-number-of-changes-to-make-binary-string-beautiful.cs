public class Solution {
    public int MinChanges(string s) {
        var substrLen = 0;
        var changesCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            substrLen++;
            if (i < s.Length - 1 && s[i] != s[i + 1] && substrLen % 2 == 1)
            {
                changesCount++;
                i++;
                substrLen = 0;
                continue;
            }

        }

        return changesCount;
    }
}