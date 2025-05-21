public class Solution {
    public bool JudgeCircle(string moves) {
        const char L = 'L', R = 'R', U = 'U', D = 'D';
        var dCount = 0;
        var uCount = 0;
        var lCount = 0;
        var rCount = 0;
        foreach(var m in moves)
        {
            switch(m)
            {
                case L:
                    lCount++;
                    break;
                case R:
                    rCount++;
                    break;
                case D:
                    dCount++;
                    break;
                case U:
                    uCount++;
                    break;
                default:
                    break;
            }
        }

        return uCount == dCount && lCount == rCount;
    }
}