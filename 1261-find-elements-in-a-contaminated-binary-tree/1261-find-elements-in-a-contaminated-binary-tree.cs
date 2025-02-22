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
public class FindElements {
    private ISet<int> _values;
    public FindElements(TreeNode root) {
        _values = new HashSet<int>();
        RecoverTree(root, 0);
    }
    
    public bool Find(int target) {
        return _values.Contains(target);
    }

    private void RecoverTree(TreeNode node, int val)
    {
        if(node == null)
            return;
        node.val = val;
        _values.Add(val);
        RecoverTree(node.left, val * 2 + 1);
        RecoverTree(node.right, val * 2 + 2);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */