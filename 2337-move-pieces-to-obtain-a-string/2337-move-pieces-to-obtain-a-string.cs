public class Solution {
    public bool CanChange(string start, string target) {
        if (start.Length != target.Length)
            return false;
        Func<char, int, bool> canMove = (ch, n) => {
            switch (ch)
            {
                case 'R':
                    return n >= 0;
                default:
                    return n <= 0;
            }
        }; 
        var sId = 0;
        var tId = 0;
        const char UNDERSCORE = '_';

        while (sId <= start.Length && tId <= target.Length)
        {
            while (sId < start.Length && start[sId] == UNDERSCORE)
                sId++;
            while (tId < target.Length && target[tId] == UNDERSCORE)
                tId++;
            if (sId >= start.Length || tId >= target.Length)
                return sId >= start.Length && tId >= target.Length;
            if ((start[sId] != target[tId] || !canMove(start[sId], tId - sId)))
                return false;
            sId++;
            tId++;
        }

        return true;
    }
}