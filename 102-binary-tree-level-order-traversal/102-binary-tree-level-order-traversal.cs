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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null)
            return result;
        IList<int> rootList = new List<int>();
        rootList.Add(root.val);
        result.Add(rootList);
        var levelQueue = new Queue<TreeNode>();
        levelQueue.Enqueue(root);
        var childrenQueue = new Queue<TreeNode>();
        while (levelQueue.Count > 0) {
            var currentNode = levelQueue.Dequeue();
            if (currentNode.left != null) {
                childrenQueue.Enqueue(currentNode.left);
            }
            if(currentNode.right != null) {
                childrenQueue.Enqueue(currentNode.right);
            }
            if (levelQueue.Count == 0 && childrenQueue.Count > 0) {
                var leavesArr = childrenQueue.Select(x => x.val).ToList();
                result.Add(leavesArr);
                levelQueue = new Queue<TreeNode>(childrenQueue);
                childrenQueue.Clear();
            }
        }

        return result;
    }
}