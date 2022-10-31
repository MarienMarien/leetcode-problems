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
    public int SumNumbers(TreeNode root) {
        var sb = new StringBuilder();
        var numbers = new List<string>();
        GetNumbers(root, sb, numbers);
        var ans = 0;
        foreach (var n in numbers) { 
            ans += Int32.Parse(n);
        }
        return ans;
    }

    private void GetNumbers(TreeNode root, StringBuilder sb, List<string> list)
    {
        if (root == null)
            return;
        sb.Append(root.val);
        if (root.left == null && root.right == null) { 
            if(sb.Length > 0)
                list.Add(sb.ToString());
            return;
        }
        if (root.left != null)
        {
            GetNumbers(root.left, sb, list);
            sb.Remove(sb.Length - 1, 1);
        }
        if (root.right != null)
        {
            GetNumbers(root.right, sb, list);
            sb.Remove(sb.Length - 1, 1);
        }
    }
}