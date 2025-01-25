public class Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        var sortedNums = new int[nums.Length];
        Array.Copy(nums, sortedNums, nums.Length);
        Array.Sort(sortedNums);

        var numToGroup = new Dictionary<int, int>();
        var groupList = new Dictionary<int, Queue<int>>();
        var groupNo = 0;
        for(var i = 0; i < sortedNums.Length; i++)
        {
            if (i > 0 && sortedNums[i] - sortedNums[i - 1] > limit)
                groupNo++;

            if (!numToGroup.ContainsKey(sortedNums[i]))
                numToGroup.Add(sortedNums[i], groupNo);

            if(!groupList.ContainsKey(groupNo))
                groupList.Add(groupNo, new Queue<int>());
            groupList[groupNo].Enqueue(sortedNums[i]);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var currGroup = numToGroup[nums[i]];
            nums[i] = groupList[currGroup].Dequeue();
        }

        return nums;
    }
}