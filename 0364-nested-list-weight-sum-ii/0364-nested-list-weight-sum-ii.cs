/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    private int _maxDepth;
    private IList<(int val, int depth)> _items;
    public int DepthSumInverse(IList<NestedInteger> nestedList) {
        _maxDepth = 0;
        _items = new List<(int, int)>();
        GetItems(nestedList, 1);
        var ans = 0;
        foreach(var item in _items) {
            var w = _maxDepth - item.depth + 1;
            ans += item.val * w;
        }
        return ans;
    }

    private void GetItems(IList<NestedInteger> list, int depth){
        if(list.Count > 0)
            _maxDepth = Math.Max(_maxDepth, depth);
        foreach(var item in list){
            if(!item.IsInteger()){
                GetItems(item.GetList(), depth + 1);
                continue;
            }
            _items.Add((item.GetInteger(), depth));
        }
    }
}