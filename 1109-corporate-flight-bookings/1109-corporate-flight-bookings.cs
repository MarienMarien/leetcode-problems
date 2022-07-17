public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        int[] ans = new int[n];
        foreach(int[] item in bookings){
            int start = item[0]-1;
            int end = item[1];
            int val = item[2];
            ans[start] += val;
            if(end < n){
                ans[end] -= val;
            }
        }
        for(int i = 1 ; i < n ; i++){
            ans[i] += ans[i-1];
        }
        return ans;
        
    }
    
}