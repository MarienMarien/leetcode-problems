public class Solution {
    public int FindLUSlength(string[] strs) {
        Array.Sort(strs, Comparer<string>.Create((x, y) => y.Length.CompareTo(x.Length)));

        for (var i = 0; i < strs.Length; i++)
        {
            var leftString = strs[i];
            var isUncommon = true;
            for (var j = 0; j < strs.Length; j++)
            {
                if (i == j)
                    continue;
                var rightStr = strs[j];
                isUncommon = !IsSubsequence(leftString, rightStr);
                if (!isUncommon)
                    break;
            }
            if (isUncommon)
                return leftString.Length;
        }

        return -1;
    }

    private bool IsSubsequence(string s1, string s2)
    {
        var s1Id = 0;
        var s2Id = 0;
        while (s1Id < s1.Length && s2Id < s2.Length)
        {
            if (s1[s1Id] == s2[s2Id])
                s1Id++;
            s2Id++;
        }

        return s1Id == s1.Length;
    }
}