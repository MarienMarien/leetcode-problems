public class Solution {
    public void SortColors(int[] nums) {
        var redId = -1;
        var blueId = nums.Length;
        var currId = 0;
        while(currId < blueId)
        {
            if (nums[currId] == 0)
            {
                redId++;

                var tmp = nums[redId];
                nums[redId] = nums[currId];
                nums[currId] = tmp;
            }
            if (nums[currId] == 2) {
                blueId--;
                var tmp = nums[blueId];
                nums[blueId] = nums[currId];
                nums[currId] = tmp;
                continue;
            }
            currId++;
        }
    }
}