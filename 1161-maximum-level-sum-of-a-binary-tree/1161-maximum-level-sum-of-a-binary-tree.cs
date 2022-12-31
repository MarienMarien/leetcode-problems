/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private IDictionary<int, int> _layerSums;
    public int MaxLevelSum(TreeNode root) {
        _layerSums = new Dictionary<int, int>();
        GetLayerSums(root, 1);
        var maxLayer = 1;
        foreach (var l in _layerSums) {
            if (_layerSums[maxLayer] < l.Value)
            {
                maxLayer = l.Key;
            }
        }
        return maxLayer;
    }

    private void GetLayerSums(TreeNode root, int layer)
    {
        if (root == null)
            return;
        if (!_layerSums.ContainsKey(layer))
            _layerSums.Add(layer, 0);
        _layerSums[layer]+= root.val;
        GetLayerSums(root.left, layer + 1);
        GetLayerSums(root.right, layer + 1);
    }
}