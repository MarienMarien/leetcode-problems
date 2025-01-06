public class Solution {
    public int[] MinOperations(string boxes) {
        const char ONE = '1';
        var leftOnesCount = 0;
        var rightOnesCount = 0;
        var opFromLeftCount = 0;
        var opFromRightCount = 0;

        var ans = new int[boxes.Length];
        var lastId = boxes.Length - 1;
        for (var i = 0; i < boxes.Length; i++)
        {
            var rightId = lastId - i;
            ans[i] += opFromLeftCount;
            ans[lastId - i] += opFromRightCount;
            if (boxes[i] == ONE)
                leftOnesCount++;
            if (boxes[rightId] == ONE)
                rightOnesCount++;
            opFromLeftCount += leftOnesCount;
            opFromRightCount += rightOnesCount;
        }

        return ans;
    }
}