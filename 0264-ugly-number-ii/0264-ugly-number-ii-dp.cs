public class Solution {
    public int NthUglyNumber(int n) {
        var uglyNums = new int[n];
        uglyNums[0] = 1;

        int ugly2 = 2, ugly3 = 3, ugly5 = 5;
        int ugly2Id = 0, ugly3Id = 0, ugly5Id = 0;

        for (var i = 1; i < n; i++)
        {
            var nextUgly = Math.Min(ugly2, Math.Min(ugly3, ugly5));
            uglyNums[i] = nextUgly;
            if (nextUgly == ugly2)
            {
                ugly2Id++;
                ugly2 = uglyNums[ugly2Id] * 2;
            }
            if (nextUgly == ugly3)
            {
                ugly3Id++;
                ugly3 = uglyNums[ugly3Id] * 3;
            } 
            if(nextUgly == ugly5) 
            {
                ugly5Id++;
                ugly5 = uglyNums[ugly5Id] * 5;
            }
        }

        return uglyNums[^1];
    }
}