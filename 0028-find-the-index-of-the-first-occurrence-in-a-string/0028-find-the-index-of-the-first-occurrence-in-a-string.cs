public class Solution {
    public int StrStr(string haystack, string needle) {
        var index = -1;
        if (haystack.Length == needle.Length) {
            return haystack != needle ? index : 0;
        }
        for(var i = 0; i <= haystack.Length - needle.Length; i++) {
            if (haystack[i] != needle[0])
                continue;
            var found = true;
            for(var j = 0; j < needle.Length; j++){
                if (needle[j] != haystack[i + j]) {
                    found = false;
                    break;
                }
            }
            if (found) {
                index = i;
                break;
            }
        }
        return index;
    }
}