public class Solution {
    public int MaximumSwap(int num) {
        var maxDigitId = -1;
        var toSwap1Id = -1;
        var toSwap2Id = -1;

        var numStrArr = num.ToString().ToCharArray();
        for (var i = numStrArr.Length - 1; i >= 0; i--)
        {
            if (maxDigitId == -1 || numStrArr[i] > numStrArr[maxDigitId])
            {
                maxDigitId = i;
                continue;
            }
            if (numStrArr[i] < numStrArr[maxDigitId])
            {
                toSwap1Id = i;
                toSwap2Id = maxDigitId;
            }
        }

        if (toSwap2Id == -1 || toSwap1Id == -1)
        {
            return num;
        }

        var tmp = numStrArr[toSwap1Id];
        numStrArr[toSwap1Id] = numStrArr[toSwap2Id];
        numStrArr[toSwap2Id] = tmp;

        return Int32.Parse(new string(numStrArr));
    }
}