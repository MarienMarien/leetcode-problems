public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        IList<int> res = new List<int>();
        for(var i = 0; i < nums.Length; i++){
            var curr = Math.Abs(nums[i]);
            if(nums[curr - 1] > 0)
                nums[curr - 1] *=  -1;
        }
        for(var i = 0; i < nums.Length; i++){
            if(nums[i] > 0)
                res.Add(i + 1);
        }
        return res;
    }
}