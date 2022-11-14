public class Solution {
    public int NumberOfSteps(int num) {
        var counter = 0;
        while (num > 0) {
            if ((num & 1) == 1) {
                counter++;
                num--;
            } else {
                num >>= 1;
                counter++;
            }
        }
        return counter;
    }
}