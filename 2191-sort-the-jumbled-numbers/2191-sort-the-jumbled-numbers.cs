public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        var mapped = new (int map, int id)[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            int j, k;
            int newN = 0;
            if (nums[i] == 0)
                newN = mapping[nums[i]];
            else
            {
                for (j = nums[i], k = 1; j > 0; j /= 10, k *= 10)
                {
                    var d = j % 10;
                    newN += mapping[d] * k;
                }
            }
            mapped[i] = (newN, i);
        }

        Array.Sort(mapped, nums, Comparer<(int map, int id)>.Create((x, y) => {
            if (x.map == y.map)
                return x.id - y.id;
            return x.map - y.map;
        }));

        return nums;
    }
}