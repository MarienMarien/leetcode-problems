public class Solution {
    private int _min;
    private int _max;
    private int _firstDigit;
    public int MaxDiff(int num)
    {
        _min = num;
        _max = num;
        int numCopy = num;
        _firstDigit = num.ToString()[0] - '0';
        for (int times = 0; times < 2; times++)
        {
            ISet<int> checkedInt = new HashSet<int>();
            while (numCopy > 0)
            {
                int digit = numCopy % 10;
                if (!checkedInt.Contains(digit))
                {
                    checkedInt.Add(digit);
                    FindMinMax(num, digit);
                }
                numCopy /= 10;
            }

        }
        return _max - _min;
    }

    private void FindMinMax(int num, int digit)
    {
        int currMin = 0;
        int currMax = 0;
        int koef = 1;
        while (num > 0)
        {
            int currDigit = num % 10;
            int minDigit = currDigit;
            int maxDigit = currDigit;
            if (currDigit == digit)
            {
                minDigit = digit != _firstDigit ? 0 : 1;
                maxDigit = 9;
            }
            currMin = minDigit * koef + currMin;
            currMax = maxDigit * koef + currMax;
            koef *= 10;
            num /= 10;
        }
        _min = Math.Min(_min, currMin);
        _max = Math.Max(_max, currMax);
    }
}