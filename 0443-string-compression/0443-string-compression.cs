public class Solution {
    public int Compress(char[] chars) {
        if (chars.Length < 2)
            return chars.Length;
        var count = 1;
        var prev = chars[0];
        var changeId = 0;
        for (var i = 1; i < chars.Length; i++) {
            if (chars[i] == prev) {
                count++;
                continue;
            }
            if (count > 1)
            {
                chars[changeId] = prev;
                changeId++;
                // add number
                foreach (var c in count.ToString())
                {
                    chars[changeId] = c;
                    changeId++;
                }
            }
            else
            {
                chars[changeId] = prev;
                changeId++;
            }
            prev = chars[i];
            count = 1;
        }
        chars[changeId] = prev;
        changeId++;
        // add number
        if(count > 1)
            foreach (var c in count.ToString())
            {
                chars[changeId] = c;
                changeId++;
            }
        return changeId;
    }
}