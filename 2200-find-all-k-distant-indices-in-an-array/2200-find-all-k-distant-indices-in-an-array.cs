public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        var keyIds = new Queue<int>();
        for(var i = 0; i < nums.Length; i++)
        {
            if(nums[i] == key)
                keyIds.Enqueue(i);
        }
        
        var kDistant = new List<int>();
        if(keyIds.Count == 0)
            return kDistant;
        
        for(var i = 0; i < nums.Length; i++)
        {
            if(i - keyIds.Peek() > k)
                keyIds.Dequeue();
            if (keyIds.Count == 0)
                break;
            if(Math.Abs(i - keyIds.Peek()) <= k)
                kDistant.Add(i);
        }
        return kDistant;
    }
}