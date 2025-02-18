public class Solution {
    public string SmallestNumber(string pattern) {
        var len = pattern.Length + 1;
        var resChar = new char[len];
        for (var n = 0; n < len; n++)
            resChar[n] = (char)(n + 1 + '0');


        const char D = 'D';
        const char I = 'I';
        var patternId = 0;
        var lastIIndex = 0;
        var dStartId = -1;
        var i = 1;

        while(i < len)
        {
            if (pattern[patternId] == D)
            {
                dStartId = i;
                while (i < len && pattern[patternId] == 'D')
                {
                    patternId++;
                    i++;
                } 
                i--;
                var tmp = resChar[lastIIndex];
                resChar[lastIIndex] = resChar[i];
                resChar[i] = tmp;
                var start = dStartId;
                var end = i - 1;
                while (start < end)
                {
                    var toMove = resChar[start];
                    resChar[start] = resChar[end];
                    resChar[end] = toMove;
                    start++;
                    end--;
                }

                i++;
                continue;
            }
            else 
            {
                lastIIndex = i;
                
            }

            patternId++;
            i++;
        }

        return new string(resChar);
    }
}