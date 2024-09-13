public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        var xorPrefSum = new int[arr.Length];
        xorPrefSum[0] = arr[0];    

        for(var i = 1; i < arr.Length; i++)
        {
            xorPrefSum[i] = arr[i] ^ xorPrefSum[i - 1];
        }

        var res = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            if(queries[i][0] == queries[i][1])
            {
                res[i] = arr[queries[i][0]];
                continue;
            }
            if(queries[i][0] == 0)
            {
                res[i] = xorPrefSum[queries[i][1]];
            }
            else 
            {
                res[i] = xorPrefSum[queries[i][1]] ^ xorPrefSum[queries[i][0] - 1];
            }

        }

        return res;
    }
}