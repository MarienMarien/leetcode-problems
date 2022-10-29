public class Solution {
    public void ReverseString(char[] s) {
        var start = 0; 
        var end = s.Length - 1;
        while(start < end){
            var tmp = s[end];
            s[end] = s[start];
            s[start] = tmp;
            start++;
            end--;
        }
    }
}