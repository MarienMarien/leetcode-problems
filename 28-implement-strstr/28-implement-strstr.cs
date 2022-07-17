public class Solution {
    public int StrStr(string haystack, string needle) {
        var res = -1;
            var len = haystack.Length;
            var i = 0;
            while (i < len) {
                if (haystack[i] == needle[0] && len - i >= needle.Length) {
                    res = i;
                    for (var j = 0; j < needle.Length; j++) {
                        if (haystack[i + j] != needle[j]) {
                            res = -1;
                            break;
                        }
                    }
                    if(res > -1)
                        return res;
                }
                i++;
            }
            return res;
    }
}