public class Solution {
    public string ShiftingLetters(string s, int[][] shifts) {
        var moves = new int[s.Length];
        var lastPosition = s.Length - 1;
        foreach (var sh in shifts)
        {
            var start = sh[0];
            var end = sh[1];
            var move = sh[2] == 0 ? -1 : 1;
            moves[start] += move;
            if (end < lastPosition)
                moves[end + 1] -= move;
        }

        var shiftCount = 0;
        var shifted = s.ToCharArray();
        for (var i = 0; i < s.Length; i++)
        {
            shiftCount += moves[i];
            shifted[i] = GetShifted(shifted[i], shiftCount);
        }
        return new string(shifted);
    }

    private char GetShifted(char ch, int shiftCount)
    {
        var chInt = ch - 'a';
        chInt += shiftCount;
        var absChInt = Math.Abs(chInt);
        if (absChInt >= 26)
            absChInt = absChInt % 26;
        if (chInt < 0 && absChInt > 0)
            absChInt = 26 - absChInt;

        return (char)(absChInt + 'a');

    }
}