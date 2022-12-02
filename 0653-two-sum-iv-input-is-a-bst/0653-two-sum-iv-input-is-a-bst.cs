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
    private HashSet<int> _complements;// 
    public bool FindTarget(TreeNode root, int k) {
        _complements = new HashSet<int>();
        return DFS(root, k);
    }

    private bool DFS(TreeNode node, int k){
        if(node == null)
            return false;
        if(_complements.Contains(node.val))
            return true;
        else{
            _complements.Add(k - node.val);
        }
        //var found = DFS(node.left, k);
        //if(!found)
        //    found = DFS(node.right, k);
        return  DFS(node.left, k) || DFS(node.right, k);
    }
}