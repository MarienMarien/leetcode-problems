public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var dict = new Dictionary<int, int>();
        var stack = new Stack<int>();
        for (var i = 0; i < nums2.Length; i++) {
            if (stack.Count > 0 && stack.Peek() < nums2[i]) {
                while (stack.Count > 0 && stack.Peek() < nums2[i]) { 
                    dict.Add(stack.Pop(), nums2[i]);
                }
            }
            stack.Push(nums2[i]);
        }
        while (stack.Count > 0) {
            dict.Add(stack.Pop(), -1);
        }
        var ans = new int[nums1.Length];
        for (var i = 0; i < nums1.Length; i++) {
            ans[i] = dict[nums1[i]];
        }
        return ans;
    }
}