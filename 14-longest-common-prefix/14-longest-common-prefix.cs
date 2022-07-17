public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if (strs == null || strs.Length == 0)
                return "";
            if (strs.Length == 1)
                return strs[0];
            var res = new StringBuilder();
            var firstItem = strs[0];
            for (var i = 0; i < firstItem.Length; i++) {
               for (var j = 1; j < strs.Length; j++) {
                    if (strs[j].Length - 1 < i || firstItem[i] != strs[j][i])
                        return res.ToString();
                }
                res.Append(firstItem[i]);
            }
            return res.ToString();
    }
}