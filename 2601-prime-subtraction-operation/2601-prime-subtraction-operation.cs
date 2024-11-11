public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        var maxEl = nums.Max();
        var closestPrime = new int[maxEl + 1];
        for (var i = 2; i < maxEl; i++)
        {
            if(IsPrime(i))
                closestPrime[i] = i;
            else
                closestPrime[i] = closestPrime[i - 1];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var diff = i == 0 ? nums[i] : nums[i] - nums[i - 1];
            if (diff <= 0)
                return false;
            nums[i] -= closestPrime[diff - 1];
        }
        return true;
    }
    private bool IsPrime(int n)
    {
        for (var i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}