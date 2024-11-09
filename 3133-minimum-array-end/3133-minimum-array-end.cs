public class Solution {
    public long MinEnd(int n, int x) {
        long last = x;
        var counter = 1;
        while (counter < n)
        {
            last = (last + 1) | x;
            counter++;
        }

        return last;
    }
}