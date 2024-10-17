public class Solution {
    public int MaximumSwap(int num) {
        var numStr = num.ToString();
        var numStrArr = numStr.ToCharArray();
        var numStrArrSorted = numStr.ToCharArray();
        Array.Sort(numStrArrSorted, Comparer<char>.Create((x, y) => y - x));
        var smallToSwap = 0;
        for (;smallToSwap < numStr.Length; smallToSwap++)
        {
            if (numStr[smallToSwap] != numStrArrSorted[smallToSwap])
            {
                break;
            }
        }

        if (smallToSwap == numStr.Length)
            return num;

        var maxToSwap = numStr.Length - 1;
        for (; maxToSwap >= 0; maxToSwap--)
        {
            if (numStr[maxToSwap] == numStrArrSorted[smallToSwap])
            {
                break;
            }
        }

        numStrArr[maxToSwap] = numStrArr[smallToSwap];
        numStrArr[smallToSwap] = numStrArrSorted[smallToSwap];

        return Int32.Parse(new string(numStrArr));
    }
}