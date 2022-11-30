public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        var res = new int[nums.Length];
        var id = 0;
        var numsId = 0;
        var len = nums.Length;
        while(id < res.Length){
            res[id] = nums[numsId];
            numsId += n;
            if(numsId >= len){
                numsId = ++numsId % len;
            }
            id++;
        }
        return res;
    }
}