public class Solution {
    private ISet<int> _goodRotated = new HashSet<int> { 2, 5, 6, 9 };
    private ISet<int> _bad = new HashSet<int> { 3, 4, 7 };
    public int RotatedDigits(int n) {
        var count = 0;
        for(var num = 1; num <= n; num++)
        {
            if(IsGood(num))
                count++;
        }
        return count;
    }

    private bool IsGood(int n)
    {
        var hasGoodRotation = false;
        while(n > 0)
        {
            var digit = n % 10;
            if(_bad.Contains(digit))
                return false;
            if(_goodRotated.Contains(digit))
                hasGoodRotation = true;
            n /= 10;
        }
        
        return hasGoodRotation;
    }
}