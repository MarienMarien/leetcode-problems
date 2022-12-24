public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        if(s1.Length != s2.Length)
            return false;
        var diffId = -1;
        var diffCount = 0;
        for (var i = 0; i < s1.Length; i++) {
            if (s1[i] != s2[i]) {
                if(diffCount > 0)
                    return false;
                if (diffId < 0) {
                    diffId = i;
                } else {
                    if(s1[diffId] != s2[i] || s2[diffId] != s1[i])
                        return false;
                    diffCount++;
                    diffId = -1;
                }
            }
        }
        return diffId < 0;
    }
}