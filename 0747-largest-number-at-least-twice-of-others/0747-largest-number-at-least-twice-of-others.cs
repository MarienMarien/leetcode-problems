public class Solution {
    public int DominantIndex(int[] nums) {
        var maxId = -1;
        var preMaxId = -1;
        for(var i = 0; i < nums.Length; i++){
            if(maxId < 0 || nums[i] > nums[maxId]){
                preMaxId = maxId;
                maxId = i;
            } else if(preMaxId < 0 || nums[i] > nums[preMaxId]){
                preMaxId = i;
            }
        }
        return nums[maxId] >= nums[preMaxId] * 2 ? maxId : -1;
    }
}