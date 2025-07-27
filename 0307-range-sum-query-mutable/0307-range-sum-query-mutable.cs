public class NumArray {
    private int[] _nums;
    private int[] _segments;
    private int _n;

    public NumArray(int[] nums) {
        _nums = nums;
        _n = nums.Length;
        _segments = new int[4 * _n];
        BuildSegmentTree(1, 0, _n - 1);
    }
    
    public void Update(int index, int val) {
        UpdateNode(1, 0, _n - 1, index, val);
    }
    
    public int SumRange(int left, int right) {
        return GetRangeSum(1, 0, _n - 1, left, right);
    }

    private void BuildSegmentTree(int node, int left, int right)
    {
        if(left == right)
        {
            _segments[node] = _nums[left];
            return;
        }
        var mid = (left + right) / 2;
        var leftNode = 2 * node;
        var rightNode = 2 * node + 1;
        BuildSegmentTree(leftNode, left, mid);
        BuildSegmentTree(rightNode, mid + 1, right);
        _segments[node] = _segments[leftNode] + _segments[rightNode];
    }

    private void UpdateNode(int node, int left, int right, int id, int val)
    {
        if(left == right)
        {
            _segments[node] = val;
            _nums[id] = val;
            return;
        }

        var leftNode = 2 * node;
        var rightNode = 2 * node + 1;
        var mid = (left + right) / 2;
        if(left <= id && id <= mid)
            UpdateNode(leftNode, left, mid, id, val);
        else
            UpdateNode(rightNode, mid + 1, right, id, val);
        _segments[node] = _segments[leftNode] + _segments[rightNode];
    }

    private int GetRangeSum(int node, int left, int right, int start, int end)
    {
        if(end < left || right < start)
            return 0;
        if(start <= left && right <= end)
            return _segments[node];
        var mid = (left + right) / 2;
        var leftNode = 2 * node;
        var rightNode = 2 * node + 1;
        return GetRangeSum(leftNode, left, mid, start, end) + GetRangeSum(rightNode, mid + 1, right, start, end);
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * obj.Update(index,val);
 * int param_2 = obj.SumRange(left,right);
 */