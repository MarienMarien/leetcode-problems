public class Solution {
    public string FirstPalindrome(string[] words) {
        foreach(var w in words)
        {
            var start = 0;
            var end = w.Length - 1;
            var isPalindrom = true;
            while(start <= end) {
                if(w[start] != w[end])
                {
                    isPalindrom = false;
                    break;    
                }
                start++;
                end--;
            }
            if(isPalindrom)
                return w;
        }

        return string.Empty;
    }
}