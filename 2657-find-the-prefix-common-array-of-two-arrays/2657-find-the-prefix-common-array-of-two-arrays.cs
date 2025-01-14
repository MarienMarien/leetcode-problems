public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        var nSet = new int[51];
        var checkSum = 0;
        var elementsProcessed = 0;
        var res = new int[A.Length];
        for(var i = 0; i < A.Length; i++)
        {
            if (nSet[A[i]] == 0)
                elementsProcessed++;
            nSet[A[i]]++;

            if (nSet[B[i]] == 0)
                elementsProcessed++;
            nSet[B[i]]--;

            if (A[i] != B[i])
            {
                checkSum += nSet[A[i]] == 0 ? -1 : 1;
                checkSum += nSet[B[i]] == 0 ? -1 : 1;
            }

            res[i] = elementsProcessed - checkSum;
        }

        return res;
    }
}