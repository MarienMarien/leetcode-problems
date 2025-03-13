public class Solution {
    public int MinZeroArray(int[] nums, int[][] queries) {
        int[] prefSum = new int[nums.Length + 1];
        int qId = 0;
        int minQCount = 0; 
        int prefSumSoFar = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            var currNum = nums[i];
            while(currNum > prefSumSoFar + prefSum[i])
            {
                if(qId >= queries.Length)
                    return -1;
                minQCount++;
                var qEnd = queries[qId][1];
                var qStart = Math.Max(queries[qId][0], i);
                var qVal = queries[qId][2];
                qId++;
                if(qStart <= qEnd)
                {
                    prefSum[qStart] += qVal;
                    prefSum[qEnd + 1] -= qVal;
                }
            }
            prefSumSoFar += prefSum[i];
        }
        return minQCount;
    }
}