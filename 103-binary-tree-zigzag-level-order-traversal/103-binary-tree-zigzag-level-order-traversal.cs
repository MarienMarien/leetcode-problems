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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
         IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            var nodesToProcess = new Stack<TreeNode>();
            nodesToProcess.Push(root);
            var nextLayer = new Stack<TreeNode>();
            bool toRight = true;
            IList<int> layer = new List<int>();
            while (nodesToProcess.Count > 0) {
                var currentNode = nodesToProcess.Pop();
                layer.Add(currentNode.val);
                if (toRight) {
                    AddLeftNode(currentNode, nextLayer);
                    AddRightNode(currentNode, nextLayer);
                } else {
                    AddRightNode(currentNode, nextLayer);
                    AddLeftNode(currentNode, nextLayer);
                }
                if (nodesToProcess.Count == 0) {
                    nodesToProcess = nextLayer;
                    nextLayer = new Stack<TreeNode>();
                    result.Add(new List<int>(layer));
                    layer.Clear();
                    toRight = !toRight;
                }
            }


            return result;
        }


        private static void AddLeftNode(TreeNode node, Stack<TreeNode> stack) {
            if (node.left != null) { 
                stack.Push(node.left);
            }
        }

        private static void AddRightNode(TreeNode node, Stack<TreeNode> stack)
        {
            if (node.right != null)
            {
                stack.Push(node.right);
            }
        }
}