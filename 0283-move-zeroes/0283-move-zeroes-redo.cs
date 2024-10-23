public class Solution {
    public void MoveZeroes(int[] nums) {
        var idToPlaceEl = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == 0)
                continue;
            nums[idToPlaceEl] = nums[i];
            if(idToPlaceEl != i)
                nums[i] = 0;
            idToPlaceEl++;
        }
    }
}