public class Solution {
    public int PassThePillow(int n, int time) {
        var currPos = 1;
        var adding = 1;
        while (time > 0) {
            time--;
            currPos += adding;
            if (currPos == 1 || currPos == n)
                adding *= -1;
        }
        return currPos;
    }
}