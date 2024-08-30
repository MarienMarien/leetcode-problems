public class Solution {
    public int PathSum(int[] nums) {
        var sum = 0;
        var map = new Dictionary<int, (int sum, int koef)>();
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var val = nums[i] % 10;
            var level = nums[i] / 100;
            var position = (nums[i] / 10) % 10;
            var mapKey = nums[i] / 10;

            var childrenSum = 0;
            var currkoef = 1;
            
            if (map.ContainsKey(mapKey))
            {
                childrenSum = map[mapKey].sum;
                currkoef = map[mapKey].koef;
            }

            var parentMapKey = level == 1 ? 0 : (level - 1) * 10 + (int)Math.Ceiling(position / 2.0);
            var currSum = val * currkoef + childrenSum;
            if (!map.TryAdd(parentMapKey, (currSum, currkoef)))
            {
                map[parentMapKey] = (
                    map[parentMapKey].sum + currSum,
                    map[parentMapKey].koef + currkoef
                );
            }
        }

        sum = map.ContainsKey(0) ? map[0].sum : 0;
        return sum;
    }
}