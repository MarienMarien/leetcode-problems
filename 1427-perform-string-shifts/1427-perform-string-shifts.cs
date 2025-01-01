public class Solution {
    public string StringShift(string s, int[][] shift) {
        var len = s.Length;
        var newSStart = 0;
        const int LEFT = 0;
        foreach(var sh in shift)
        {
            if(sh[0] == LEFT)
            {
                newSStart -= sh[1];
            } else 
            {
                newSStart += sh[1];
            }
        }
        var startPosAbs = Math.Abs(newSStart);
        if(startPosAbs >= len)
            startPosAbs %= len;
        if (newSStart < 0 && startPosAbs > 0)
            startPosAbs = len - startPosAbs;
        
        var newS = new char[len];
        for(var i = 0; i < len; i++)
        {
            newS[startPosAbs] = s[i];
            startPosAbs = (startPosAbs + 1) % len;
        }

        return new string(newS);
    }
}