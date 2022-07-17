public class Solution {
    public int TriangularSum(int[] nums) {
        var currArrElementCnt = nums.Length;
        while(currArrElementCnt > 1)
        {
            for (var i = 0; i < currArrElementCnt - 1; i++)
            {
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }
            nums[currArrElementCnt - 1] = 0;// erase last elem.
            currArrElementCnt--;
        }
        return nums[0];
    }
}