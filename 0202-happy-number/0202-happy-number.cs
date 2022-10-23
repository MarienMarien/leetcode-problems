public class Solution {
    public bool IsHappy(int n) {
        var resultsSet = new HashSet<int>();
        while (n > 1) {
            var newN = 0;
            while (n > 0) {
                var rem = n % 10;//1
                newN += rem * rem;//82
                n /= 10;// 1
            }
            if (resultsSet.Contains(newN))
                return false;
            else
                resultsSet.Add(newN);
            n = newN;// 82
        }
        return true;
    }
}