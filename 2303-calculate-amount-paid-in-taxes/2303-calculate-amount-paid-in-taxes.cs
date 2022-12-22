public class Solution {
    public double CalculateTax(int[][] brackets, int income) {
        var upper0 = 0;
        var result = 0.0d;
        foreach(var b in brackets){
            if(b[0] >= income){
                result += (income - upper0) * (b[1] / 100.0d);
                break;
            } else {
                result += (b[0] - upper0) * (b[1] / 100.0d);
                upper0 = b[0];
            }
        }
        return result;
    }
}