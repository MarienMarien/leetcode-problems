public class Solution {
    public int[] AnagramMappings(int[] nums1, int[] nums2) {
        var ans = new int[nums1.Length];
        var map = new Dictionary<int, Stack<int>>();
        for (var i = 0; i < nums1.Length; i++) {
            map.TryAdd(nums1[i], new Stack<int>());
            map[nums1[i]].Push(i);
        }
        for (var j = 0; j < nums2.Length; j++) { 
            var i = map[nums2[j]].Pop();
            ans[i] = j;
        }
        return ans;
    }
}