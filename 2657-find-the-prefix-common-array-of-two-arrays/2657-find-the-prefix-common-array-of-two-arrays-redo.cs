public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        var nSet = new int[51];
        var prefLen = 0;
        var res = new int[A.Length];
        for(var i = 0; i < A.Length; i++)
        {
            nSet[A[i]]++;
            if (nSet[A[i]] == 2)
                prefLen++;
            
            nSet[B[i]]++;
            if (nSet[B[i]] == 2)
                prefLen++;

            res[i] = prefLen;
        }

        return res;
    }
}