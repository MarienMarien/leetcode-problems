public class Solution {
    public bool WinnerOfGame(string colors) {
        if (colors.Length < 3)
            return false;
        const char A = 'A';
        const char B = 'B';
        var aliceMoveCnt = 0;
        var bobMoveCnt = 0;
        for (var i = 1; i < colors.Length - 1; i++) {
            if (colors[i] == A) {
                if (colors[i - 1] == A && colors[i + 1] == A)
                    aliceMoveCnt++;
                continue;
            }

            if (colors[i - 1] == B && colors[i + 1] == B) {
                bobMoveCnt++;
            }
        }

        return aliceMoveCnt > bobMoveCnt ? true : false;
    }
}