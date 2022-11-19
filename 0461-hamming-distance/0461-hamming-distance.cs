public class Solution {
    public int HammingDistance(int x, int y) {
        var resNum = x ^ y;
        var count = 0;
        if(resNum > 0)
            count++;
        while(resNum > 1){
            count += resNum % 2;
            resNum /= 2;
        }
        return count;
    }
}