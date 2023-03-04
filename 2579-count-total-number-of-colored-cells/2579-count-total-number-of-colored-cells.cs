public class Solution {
    public long ColoredCells(int n) {
        long count = 1;
        var minute = 0;
        if(n > 1){
            while(minute < n){
                count += 4 + (4 * (minute - 1));
                minute++;
            }
        }
        return count;
    }
}