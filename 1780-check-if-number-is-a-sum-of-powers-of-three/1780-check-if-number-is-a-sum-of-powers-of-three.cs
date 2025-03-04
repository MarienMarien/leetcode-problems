public class Solution {
    public bool CheckPowersOfThree(int n) {
        var ternaryRepresentation = GetTernaryRepresentation(n);
        foreach(var digit in ternaryRepresentation)
        {
            if(digit == 2)
            return false;
        }
        return true;
    }

    private IList<int> GetTernaryRepresentation(int n)
    {
        var ternary = new List<int>();
        while(n != 0)
        {
            var rem = n % 3;
            ternary.Add(rem);
            n /= 3;
        }

        return ternary;
    }
}