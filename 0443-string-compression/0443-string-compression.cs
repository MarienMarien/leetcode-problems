public class Solution {
    public int Compress(char[] chars) {
        var sId = 1;
        var prev = chars[0];
        var chId = 1;
        int count;
        var startPos = 0;
        while (chId < chars.Length) {
            if (chars[chId] != prev) {
                count = chId - startPos;
                if (count > 1)
                {
                    var countStr = count.ToString();
                    foreach (var ch in countStr)
                    {
                        chars[sId++] = ch;
                    }
                }
                startPos = chId;
                chars[sId++] = chars[chId];
                prev = chars[chId];
            }
            chId++;
        }
        count = chId - startPos;
        if (count > 1)
        {
            var countStr = count.ToString();
            foreach (var ch in countStr)
            {
                chars[sId++] = ch;
            }
        }
        return sId;
    }
}