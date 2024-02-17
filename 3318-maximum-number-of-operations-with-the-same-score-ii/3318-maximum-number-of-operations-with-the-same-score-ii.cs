public class Solution {
    private IDictionary<string, int> _maxOpForScore;
    public int MaxOperations(int[] nums)
    {
        var leftId = 0;
        var rightId = nums.Length - 1;
        var possibleScores = new HashSet<int> {
            nums[leftId] + nums[leftId + 1],
            nums[rightId] + nums[rightId - 1],
            nums[leftId] + nums[rightId]
        };

        var n = nums.Length - 1;
        var maxScore = 0;

        foreach (var item in possibleScores) {
            _maxOpForScore = new Dictionary<string, int>();
            maxScore = Math.Max(maxScore, CountOperations(nums, item, 0, n));
        }

        return maxScore;
    }

    private int CountOperations(int[] nums, int score, int start, int end)
    {
        if (start >= nums.Length - 1 || start >= end)
            return 0;

        var left = start;
        var right = end;

        var key = $"{left}_{right}";
        if (!_maxOpForScore.ContainsKey(key))
        {
            var opCount = 0;
            if (nums[left] + nums[right] == score)
            {
                opCount = Math.Max(opCount, 1 + CountOperations(nums, score, left + 1, right - 1));
            }

            if (right - left > 1 && nums[left] + nums[left + 1] == score)
            {
                opCount = Math.Max(opCount, 1 + CountOperations(nums, score, left + 2, right));
            }

            if (right - left > 1 && nums[right] + nums[right - 1] == score)
            {
                opCount = Math.Max(opCount, 1 + CountOperations(nums, score, left, right - 2));
            }
            _maxOpForScore.Add(key, opCount);
        }

        return _maxOpForScore[key];
    }
}