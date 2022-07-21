public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var toDel = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val) {
                nums[toDel] = nums[i];
                toDel++;
            }
        }
        return toDel;
    }
}