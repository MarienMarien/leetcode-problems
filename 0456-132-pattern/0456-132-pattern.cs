public class Solution {
    public bool Find132pattern(int[] nums) {
        if (nums.Length < 3)
            return false;

        var incrIdentificators = new List<int>();
        var min = nums[0];
        for (var i = 0; i < nums.Length; i++) {
            if (min >= nums[i])
            {
                min = nums[i];
                incrIdentificators.Add(Int32.MinValue);
            }
            else {
                incrIdentificators.Add(min);
            }
        }

        var stack = new Stack<int>();
        for (var i = nums.Length - 1; i > 0; i--) {
            while (stack.Count > 0 && stack.Peek() <= incrIdentificators[i])
                stack.Pop();
            if (stack.Count > 0 && incrIdentificators[i] != Int32.MinValue && stack.Peek() < nums[i]) {
                return true;
            }
            
            stack.Push(nums[i]);
        }
        return false;
    }
}