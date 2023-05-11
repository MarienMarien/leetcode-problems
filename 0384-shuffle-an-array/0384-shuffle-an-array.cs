public class Solution {

    private int[] _originalNums;
    private int _size;
    public Solution(int[] nums)
    {
        _originalNums = nums;
        _size = nums.Length;
    }

    public int[] Reset()
    {
        return _originalNums;
    }

    public int[] Shuffle()
    {
        Random rand = new Random();
        int[] shuffled = new int[_size];
        Array.Copy(_originalNums, shuffled, _size);
        for (int i = 0; i < _size; i++) {
            int nextShuffleId = rand.Next(_size);
            int tmp = shuffled[i];
            shuffled[i] = shuffled[nextShuffleId];
            shuffled[nextShuffleId] = tmp;
        }
        return shuffled;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */