public class Solution {
    public int CountPrimes(int n) {
        if (n <= 2)
            return 0;
        var notPrime = new bool[n];
        var count = 1;
        var sqrt = Math.Sqrt(n);
        for (var i = 3; i < n; i += 2) {
            if (notPrime[i] == false)
            {
                count++;
                if (i > sqrt)
                    continue;
                for (var j = i*i; j < n; j += i)
                {
                    notPrime[j] = true;
                }
            }
        }
        return count;
    }
}