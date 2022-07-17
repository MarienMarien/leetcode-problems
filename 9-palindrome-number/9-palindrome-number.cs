public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 10 && x > -1)
                return true;
            if (x > -1 && x < 0)
                return false;
            var stringifiedX = x.ToString();
            var start = 0;
            var end = stringifiedX.Length - 1;
            while (start < end) {
                if (stringifiedX[start] != stringifiedX[end])
                    return false;
                start++;
                end--;
            }
            
            return true;
    }
}